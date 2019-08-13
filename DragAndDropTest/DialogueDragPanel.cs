using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace DragAndDropTest
{
    class DialogueDragPanel : DragPanel
    {
        public Window.Character Speaker;
        public string Sprite;
        public string EntryText;
        public string Dialogue;
		private DragPanel[] children;
        GroupBox speakerGB, spriteGB, entryTextGB, dialogueGB;
        RichTextBox entryTextTXT, dialogueTXT;
		ComboBox speakerCBB, spriteCBB;
		PictureBox spritePB;
        public DialogueDragPanel()
        {
            Sprite = EntryText = Dialogue = "";
			Speaker = null;
			children = new DragPanel[3];
        }
        public static explicit operator string(DialogueDragPanel p)
        {
            return "[\n" + p.Speaker.Name + "\n" + p.Sprite + "\n" + p.EntryText.Replace("\n", "\\") + "\n" + p.Dialogue.Replace("\n", "\\") + "\n]";
        }
		public override void ClearChildren()
		{
			for (int i = 0; i < children.Length; i += 1)
			{
				children[i] = null;
			}
		}
		public override void AddChildren(DragPanel p)
		{
			uint z = (uint)children.Count(x => x != null);
			children[z < 3 ? z : 2] = p;
		}
		public override void childRemove(DragPanel p)
		{
			for (int i = 0; i < children.Length; i += 1)
			{
				if (p == children[i])
					children[i] = null;
			}
		}
		public override DragPanel[] Children()
		{
			return children;
		}
		public override void Edit()
        {
            var panel = FormReference.getSplitPanel1();
            panel.Controls.Add(speakerGB = new GroupBox()
            {
                Text = "Speaker Name",
                Size = new Size(panel.Width - 14, 80),
                Location = new Point(5, 10),
            });
                speakerGB.Controls.Add(speakerCBB = new ComboBox()
                {
                    Text = Speaker?.Name,
                    Location = new Point(5,28),
                    Size = new Size(speakerGB.Width - 14, speakerGB.Height - 44),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                });
                speakerCBB.TextChanged += new EventHandler(SpeakerChanged);
				speakerCBB.DropDown += new EventHandler(ShowCharacters);
            panel.Controls.Add(spriteGB = new GroupBox()
            {
                Text = "Sprite Name",
                Size = new Size(panel.Width - 14, 80),
                Location = new Point(5, 95),
            });
                spriteGB.Controls.Add(spriteCBB = new ComboBox()
                {
                    Text = Sprite,
                    Location = new Point(5, 28),
                    Size = new Size(spriteGB.Width - 14, spriteGB.Height - 44),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                });
                spriteCBB.TextChanged += new EventHandler(SpriteChanged);
				spriteCBB.DropDown += new EventHandler(ShowSprites);
			panel.Controls.Add(spritePB = new PictureBox()
			{
				Location = new Point(5, 545),
				Image = Speaker?.Sprites?[Sprite],
				SizeMode = PictureBoxSizeMode.Zoom,
				Size = new Size(panel.Width - 10, panel.Width - 10),
			});
            panel.Controls.Add(entryTextGB = new GroupBox()
            {
                Text = "Entry Dialogue",
                Size = new Size(panel.Width - 14, 180),
                Location = new Point(5, 180),
            });
                entryTextGB.Controls.Add(entryTextTXT = new RichTextBox()
                {
                    Text = EntryText,
                    Location = new Point(5, 28),
                    Size = new Size(entryTextGB.Width - 14, entryTextGB.Height - 44),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                });
                entryTextTXT.TextChanged += new EventHandler(EntryTextChanged);
            panel.Controls.Add(dialogueGB = new GroupBox()
            {
                Text = "Speaker Dialogue",
                Size = new Size(panel.Width - 14, 180),
                Location = new Point(5, 365),
            });
                dialogueGB.Controls.Add(dialogueTXT = new RichTextBox()
                {
                    Text = Dialogue,
                    Location = new Point(5, 28),
                    Size = new Size(dialogueGB.Width - 14, dialogueGB.Height - 44),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                });
                dialogueTXT.TextChanged += new EventHandler(DialogueChanged);

        }
        private void SpeakerChanged(object sender, EventArgs e)
        {
			if (FormReference.CharactersList.Any(x => x.Name == speakerCBB.Text))
			{
				this.Speaker = FormReference.CharactersList.First(x => x.Name == speakerCBB.Text);
			} else
			{
				MessageBox.Show("Cannot find character " + speakerCBB.Text);
			}
        }
        private void changeText(ComboBox r)
        {
            if (r.Text.Contains('\n'))
                r.Text = r.Text.Replace("\n", "");
        }
        protected override Color GetBackColor()
        {
            return Window.DialogueBoxCOL;
        }
        private void EnterPressedLeave(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (sender == entryTextTXT)
                    dialogueTXT.Focus();
            }
        }
		private void ShowCharacters(object sender, EventArgs e)
		{
			speakerCBB.Items.Clear();
			speakerCBB.Items.AddRange(FormReference.CharactersList.Select(x => x.Name).ToArray());
		}
		private void ShowSprites(object sender, EventArgs e)
		{
			if (Speaker != null)
			{
				spriteCBB.Items.Clear();
				spriteCBB.Items.AddRange(Speaker.Sprites.Keys.ToArray());
			}
		}
        private void SpriteChanged(object sender, EventArgs e)
        {
            Sprite = spriteCBB.Text;
			try
			{
				spritePB.Image = Speaker.Sprites[Sprite];
			} catch
			{
				MessageBox.Show("Sprite Not Found");
			}
        }
        private void EntryTextChanged(object sender, EventArgs e)
        {
            EntryText = entryTextTXT.Text;
        }
        private void DialogueChanged(object sender, EventArgs e)
        {
            Dialogue = dialogueTXT.Text;
        }
    }
}
