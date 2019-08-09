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
        public string Speaker;
        public string Sprite;
        public string EntryText;
        public string Dialogue;
		private DragPanel children;
        GroupBox speakerGB, spriteGB, entryTextGB, dialogueGB;
        RichTextBox speakerTXT, spriteTXT, entryTextTXT, dialogueTXT;
        public DialogueDragPanel()
        {
            Speaker = Sprite = EntryText = Dialogue = "";
            
        }
        public static explicit operator string(DialogueDragPanel p)
        {
            return "[\n" + p.Speaker + "\n" + p.Sprite + "\n" + p.EntryText.Replace("\n", "\\") + "\n" + p.Dialogue.Replace("\n", "\\") + "\n]";
        }
		public override void ClearChildren()
		{
			children = null;
		}
		public override void AddChildren(DragPanel p)
		{
			children = p;
		}
		public override void childRemove(DragPanel p)
		{
			children = null;
		}
		public override DragPanel[] Children()
		{
			DragPanel[] child = new DragPanel[1];
			child[0] = children;
			return child;
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
                speakerGB.Controls.Add(speakerTXT = new RichTextBox()
                {
                    Text = Speaker,
                    Location = new Point(5,28),
                    Size = new Size(speakerGB.Width - 14, speakerGB.Height - 44),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                });
                speakerTXT.TextChanged += new EventHandler(SpeakerChanged);
                speakerTXT.KeyDown += new KeyEventHandler(EnterPressedLeave);
            panel.Controls.Add(spriteGB = new GroupBox()
            {
                Text = "Sprite Name",
                Size = new Size(panel.Width - 14, 80),
                Location = new Point(5, 95),
            });
                spriteGB.Controls.Add(spriteTXT = new RichTextBox()
                {
                    Text = Sprite,
                    Location = new Point(5, 28),
                    Size = new Size(spriteGB.Width - 14, spriteGB.Height - 44),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                });
                spriteTXT.TextChanged += new EventHandler(SpriteChanged);
                spriteTXT.KeyDown += new KeyEventHandler(EnterPressedLeave);
            panel.Controls.Add(entryTextGB = new GroupBox()
            {
                Text = "Entry Dialogue",
                Size = new Size(panel.Width - 14, 240),
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
                Size = new Size(panel.Width - 14, 240),
                Location = new Point(5, 425),
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
            changeText(speakerTXT);
            Speaker = speakerTXT.Text;
        }
        private void changeText(RichTextBox r)
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
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == speakerTXT)
                    spriteTXT.Focus();
                if (sender == spriteTXT)
                    entryTextTXT.Focus();
                (sender as RichTextBox).Text = (sender as RichTextBox).Text.Replace("\n", "").Replace("\r", "");
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (sender == speakerTXT)
                    spriteTXT.Focus();
                if (sender == spriteTXT)
                    entryTextTXT.Focus();
                if (sender == entryTextTXT)
                    dialogueTXT.Focus();
            }
        }
        private void SpriteChanged(object sender, EventArgs e)
        {
            changeText(spriteTXT);
            Sprite = spriteTXT.Text;
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
