using System;
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
        public Button WriteToFileBTN, FileOutputBTN, FileInputBTN;
        public GroupBox WriteToFileGB, FileOutputGB, FileInputGB;
        public TextBox FileOutputTXT;
		private DragPanel children;
        public StartDialogueDragPanel()
        {
            
        }
        public override void Edit()
        {
            topConnecter.Enabled = false;
            var panel = FormReference.getSplitPanel1();
            FilePath = null;
            panel.Controls.Add(FileOutputGB = new GroupBox()
            {
                Text = "File Output",
                Size = new Size(panel.Width - 14, 72),
                Location = new Point(5, 10),
            });
            FileOutputGB.Controls.Add(FileOutputTXT = new TextBox()
            {
                Text = "",
                Location = new Point(5, 28),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                Width = FileOutputGB.Width - 90,
            });
            FileOutputGB.Controls.Add(FileOutputBTN = new Button()
            {
                Text = "Open",
                Location = new Point(FileOutputGB.Width - 86, 28),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 16F),
                Width = 78,
                Height = 32,
            });
            FileOutputBTN.Click += new EventHandler(OpenFolder);
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
            WriteToFileBTN.Click += new EventHandler(SaveDialogue);
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
            save.ShowDialog();
            if (!save.FileName.EndsWith(".dlg")) save.FileName += ".dlg";
            FileOutputTXT.Text = FilePath = save.FileName;
        }
        protected override Color GetBackColor()
        {
            return Window.StartBoxCOL;
        }
        private void SaveDialogue(object sender, EventArgs e)
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
            file.WriteLine("(" + indices[panel] + ")");
            file.WriteLine((string)panel);
            printed.Add(panel);
            file.Write("<");
            bool comma = false;
            string s = (string)panel;
            foreach (DialogueDragPanel child in panel.Children().Select(x => x as DialogueDragPanel)) {
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
                } else
                {
                    file.Write(index);
                    indices.Add(child, index++);
                }
            }
            file.WriteLine(">\n");
            foreach (DialogueDragPanel child in panel.Children().Where(x => !printed.Contains(x)))
            {
                recursiveHelper(file, child, indices, printed, ref index);
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
            dialog.ShowDialog();
            List<string> strList = new List<string>();
            using (StreamReader file = new StreamReader(dialog.FileName))
            {
                while (!file.EndOfStream)
                {
                    strList.Add(file.ReadLine());
                }
            }
			this.ClearChildren();
            this.AddChildren(GetTree(strList));
        }
        private DialogueDragPanel GetTree(List<string> strList)
        {
            Dictionary<int, DialogueDragPanel> tracker = new Dictionary<int, DialogueDragPanel>();
            Random r = new Random();
            for (int i = 0; i < strList.Count; i += 1)
            {
                string str = strList[i];
                if (str.StartsWith("("))
                {
                    DialogueDragPanel panel = new DialogueDragPanel();
                    int index = int.Parse(str.Replace("(", "").Replace(")", ""));
                    tracker.Add(index, panel);
                    i += 2;
                    panel.EntryText = strList[++i].Replace("\\", "\n");
                    panel.Dialogue = strList[++i].Replace("\\", "\n");
                    panel.Location = new Point(r.Next(FormReference.getGraphWidth()), r.Next(FormReference.getGraphHeight()));
                }
            }
            for (int i = 0; i < strList.Count; i += 1)
            {
                
                if (strList[i].StartsWith("("))
                {
                    int index = int.Parse(strList[i].Replace("(", "").Replace(")", ""));
                    foreach (string s in strList[i + 7].Replace("<","").Replace(">","").Split(','))
                    {
                        if (!string.IsNullOrWhiteSpace(s))
                            tracker[index].AddChildren(tracker[int.Parse(s)]);
                    }
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
