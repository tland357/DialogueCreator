﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace DragAndDropTest
{
    class StartDialogueDragPanel : DragPanel
    {
        public string FilePath;
        public Button WriteToFileBTN, FileInputBTN;
        public GroupBox WriteToFileGB, FileInputGB;
		private DragPanel children;
        public StartDialogueDragPanel()
        {
            
        }
        public override void Edit()
        {
            topConnecter.Enabled = false;
            var panel = FormReference.getSplitPanel1();
            FilePath = null;
            panel.Controls.Add(WriteToFileGB = new GroupBox()
            {
                Text = "Save File",
                Location = new Point(5, 77),
                Size = new Size(panel.Width - 14, 72),
            });
            WriteToFileGB.Controls.Add(WriteToFileBTN = new Button()
            {
                Text = "Save",
                Location = new Point(5, 28),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                Width = WriteToFileGB.Width - 12,
                Height = 32,
            });
            panel.Controls.Add(FileInputGB = new GroupBox()
            {
                Text = "Load File",
                Location = new Point(5, 144),
                Size = new Size(panel.Width - 14, 72),
            });
            FileInputGB.Controls.Add(FileInputBTN = new Button()
            {
                Text = "Load",
                Location = new Point(5, 28),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                Width = FileInputGB.Width - 12,
                Height = 32
            });
            WriteToFileBTN.Click += new EventHandler(OpenFolder);
            FileInputBTN.Click += new EventHandler(LoadDialogue);
        }
		public override void AddChildren(DragPanel p)
		{
			children = p;
		}
		public override void childRemove(DragPanel p)
		{
			children = null;
		}
		public override void ClearChildren()
		{
			children = null;
		}
		public override DragPanel[] Children()
		{
			DragPanel[] child = new DragPanel[1];
			child[0] = children;
			return child;
		}
		private void OpenFolder(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Dialogue File (*.dlg) | All Files (*.*)";
            var result = save.ShowDialog();
			if (result == DialogResult.Cancel) return;
            if (!save.FileName.EndsWith(".dlg")) save.FileName += ".dlg";
            FilePath = save.FileName;
			SaveDialogue();
        }
        protected override Color GetBackColor()
        {
            return Window.StartBoxCOL;
        }
        private void SaveDialogue()
        {
            if (string.IsNullOrWhiteSpace(FilePath)) {
                MessageBox.Show("Please select a file directory");
                return;
            }
            if (!FilePath.EndsWith(".dlg")) {
                MessageBox.Show("Must write to .dlg file format");
                return;
            }
            using (StreamWriter file = new StreamWriter(FilePath))
            {
                WriteToFile(file);
            }
        }
        private void WriteToFile(StreamWriter file)
        {
            int index = 0;
            Dictionary<DialogueDragPanel, int> indices = new Dictionary<DialogueDragPanel, int>();
            HashSet<DialogueDragPanel> printed = new HashSet<DialogueDragPanel>();
            var startNode = (Children()[0] as DialogueDragPanel);
            indices.Add(startNode, index++);
            recursiveHelper(file, startNode, indices, printed, ref index);
        }
        private void recursiveHelper(StreamWriter file, DialogueDragPanel panel, Dictionary<DialogueDragPanel, int> indices, HashSet<DialogueDragPanel> printed, ref int index)
        {
			if (panel != null)
			{
				file.Write(indices[panel].ToString() + ';');
				file.Write((string)panel);
				printed.Add(panel);
				file.Write("");
				bool comma = false;
				foreach (DialogueDragPanel child in panel.Children().Where(x => x is DialogueDragPanel))
				{
					if (child != null)
					{
						if (comma)
						{
							file.Write(",");
						}
						else
						{
							comma = true;
						}
						if (indices.ContainsKey(child))
						{
							file.Write(indices[child]);
						}
						else
						{
							file.Write(index);
							indices.Add(child, index++);
						}
					}
				}
				file.Write('\n');
				foreach (DialogueDragPanel child in panel.Children().Where(x => !printed.Contains(x)))
				{
					recursiveHelper(file, child, indices, printed, ref index);
				}
			}
        }
        //LoadDialogue
        private void LoadDialogue(object sender, EventArgs e)
        {
            if (this.Children().Count(x => x != null) > 0) { MessageBox.Show("Cannot load file to a start node with connections"); return; }
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Dialogue Files (*.dlg)|*.dlg|All Files (*.*) | *.*",
            };
			if (dialog.ShowDialog() != DialogResult.OK) return;
            List<string> strList = new List<string>();
            using (StreamReader file = new StreamReader(dialog.FileName))
            {
                while (!file.EndOfStream)
                {
                    strList.Add(file.ReadLine());
                }
            }
			this.ClearChildren();
			try
			{
				this.AddChildren(GetTree(strList));
			} catch (IndexOutOfRangeException)
			{
			}
        }
        private DialogueDragPanel GetTree(List<string> strList)
        {
            Dictionary<int, DialogueDragPanel> tracker = new Dictionary<int, DialogueDragPanel>();
            Random r = new Random();
            for (int i = 0; i < strList.Count; i += 1)
            {
                var strs = strList[i].Split(";".ToCharArray(), StringSplitOptions.None);
				if (strs.Length != 6) continue;
				DialogueDragPanel panel = new DialogueDragPanel();
				tracker.Add(int.Parse(strs[0]), panel);
				if (FormReference.CharactersList.Any(x => x.Name == strs[1])) {
					panel.Speaker = FormReference.CharactersList.First(x => x.Name == strs[1]);
					if (panel.Speaker.Sprites.ContainsKey(strs[2]))
					{
						panel.Sprite = strs[2];
					}
				}
				panel.EntryText = strs[3];
				panel.Dialogue = strs[4];
            }
            for (int i = 0; i < strList.Count; i += 1)
            {
				var strs = strList[i].Split(";".ToCharArray(), StringSplitOptions.None);
				
				foreach (var str in strs[5].Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries))
				{
					tracker[int.Parse(strs[0])].AddChildren(tracker[int.Parse(str)]);
				}
            }
            foreach (var panel in tracker.Values)
            {
                if (!FormReference.getSplitPanel2().Controls.Contains(panel))
                    FormReference.getSplitPanel2().Controls.Add(panel);
                if (!FormReference.Moveables.Contains(panel))
                    FormReference.Moveables.Add(panel);
            }
            return tracker[0];
        }
    }
}
