using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace DragAndDropTest
{
    public partial class Window : Form
    {
		public class Character
		{
			public Character(string name, string fileDirectory)
			{
				Name = name;
				Sprites = new Dictionary<string, Image>();
				Directory = fileDirectory;
				ReInit();
			}
			public string Name;
			public Dictionary<string, Image> Sprites;
			public string Directory;
			public void Add(string s, Image b)
			{
				Sprites.Add(s, b);
			}
			public Image this[string s]
			{
				get { return Sprites[s]; }
				set { Sprites[s] = value; }
			}
			public void ReInit()
			{
				string helper = Directory.Remove(Directory.Length - Name.Length - 5);
				string[] files = System.IO.Directory.GetFiles(helper, "*.png");
				Sprites.Clear();
				foreach (var file in files)
				{
					string f = file;
					while (f.Contains('\\'))
					{
						f = f.Remove(0, 1);
					}
					Add(f.Remove(f.Length - 4), Image.FromFile(file));
				}
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(Directory))
				{
					file.WriteLine(Name);
					foreach (var file2 in files) file.WriteLine(file2);
				}
			}
		}
        public static Window FormReference;
        public static Color StartBoxCOL, DialogueBoxCOL, graphColor, editorColor, connectorColor, SplitterBoxCOL;
		/*protected override CreateParams CreateParams
		{
			get
			{
				CreateParams handleParam = base.CreateParams;
				handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
				return handleParam;
			}
		}*/
		public List<Character> CharactersList;
		public Window()
        {
			GraphicsFancy = true;
            graphColor = System.Drawing.Color.DarkSlateGray;
            editorColor = System.Drawing.Color.DarkGray;
            connectorColor = Color.Black;
            StartBoxCOL = Color.FromArgb(80, 0, 0);
            DialogueBoxCOL = Color.FromArgb(45, 0, 60);
			SplitterBoxCOL = Color.FromArgb(0, 80, 0);
            InitializeComponent();
			FormReference = this;
			splitContainer1.Panel2.AllowDrop = true;
            graphics = splitContainer1.Panel2.CreateGraphics();
			Moveables = new List<Control>();
			CharactersList = new List<Character>();
            ThreadStart start = new ThreadStart(() =>
            {
                while (true)
                {
                    Thread.Sleep(8);
					BufferedGraphicsContext currentContext;
					BufferedGraphics myBuffer;
					currentContext = BufferedGraphicsManager.Current;
					myBuffer = currentContext.Allocate(graphics, splitContainer1.Panel2.DisplayRectangle);
                    var list = Moveables.Where(x => x is DragPanel).Where(x => (x as DragPanel).Children().Count(z => z != null) > 0).Select(x => x as DragPanel).ToList();
                    myBuffer.Graphics.FillRectangle(new SolidBrush(graphColor), new Rectangle(new Point(0, 0), splitContainer1.Size));
                    try
                    {
                        foreach (DragPanel Moveable in list)
                        {
                            foreach (var child in Moveable.Children().Where(x => x != null))
                            {
                                if (GraphicsFancy)
                                {
                                    Point point1, point2, point3, point4;
                                    point1 = Moveable.Location + new Size(Moveable.Width / 2, Moveable.Height);
                                    point4 = child.Location + new Size(child.Width / 2, 0);
                                    int half;
                                    point2 = point1 + new Size(0, half = (point4.Y - point1.Y) / 2);
                                    point3 = point4 - new Size(0, half);
                                    myBuffer.Graphics.DrawBezier(new Pen(connectorColor, 2), point1, point2, point3, point4);
                                } else
                                {
                                    Point point1, point2;
                                    point1 = Moveable.Location + new Size(Moveable.Width / 2, Moveable.Height);
                                    point2 = child.Location + new Size(child.Width / 2, 0);
                                    myBuffer.Graphics.DrawLine(new Pen(connectorColor, 2), point1, point2);
                                }
                            }
                        }
						myBuffer.Render();
					}
                    catch (InvalidOperationException ex)
                    {
						continue;
                    }
                }
            });
            t = new Thread(start);
            t.Start();
            this.FormClosing += new FormClosingEventHandler(ClosingThread);
        }
        Thread t;
        Graphics graphics;
        private void ClosingThread(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }
        public List<Control> Moveables;
        private void SplitContainer1_Panel2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DragPanel c;
            switch (e.KeyCode)
            {
                case Keys.S: // Add Dialogue
                    if (e.Modifiers == Keys.Alt)
                    {
                        StartBoxColorBTN_Click(null, null);
                        return;
                    }
                    c = new StartDialogueDragPanel();
                    break;
                case Keys.D:
                    if (e.Modifiers == Keys.Alt)
                    {
                        DialogueBoxColorBTN_Click(null, null);
                        return;
                    }
                    c = new DialogueDragPanel();
                    break;
                case Keys.G:
					if (e.Modifiers == Keys.Alt)
						GraphColor(null, null);
					else
						GraphicsQualityBTN_Click(null, null);
                    return;
				case Keys.C:
					for (int i = 0; i < CharactersList.Count; i += 1)
					{
						CharactersList[i].ReInit();
					}
					return;
				case Keys.F:
					c = new SplitterDragPanel();
					break;
				case Keys.N:
					if (e.Modifiers == Keys.Alt)
					{
						ConnectorColor(null, null);
					} else
					{
						CharacterEditor editor = new CharacterEditor(this, null);
						editor.Show();
					}
					return;
				case Keys.E:
					if (e.Modifiers == Keys.Alt)
						EditorColor(null, null);
					return;
                default:
                    return;
            }
            c.Location = MousePosition - new Size(splitContainer1.Panel2.Location) - new Size(c.Width / 2, 24);
            c.MouseClick += new MouseEventHandler(AddedWidgetClickHandler);
            this.splitContainer1.Panel2.Controls.Add(c);
            Moveables.Add(c);
            c.UpdateAll();
        }

        private void SplitContainer1_Panel2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Control).Focus();
        }

        private void AddedWidgetClickHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                DeleteWidget(sender as Control);
        }
        private void DragHandle(int past, int present, bool X, Control c)
        {
            if (present - past > 1 || present - past < -1)
            {
                int z = -(present - past);
                c.Location += new Size(X ? z : 0, X ? 0 : z);
            }
            
        }
        Point previous;
        private void DragStart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                previous = MousePosition;
			else if (e.Button == MouseButtons.Left)
			{
				(sender as Control).Focus();
			}
        }

        private void DragEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                var transform = MousePosition - new Size(previous);
                foreach (var moveable in Moveables)
                    moveable.Location -= new Size(transform);
            }
        }

        private void DragContinue(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                var transform = MousePosition - new Size(previous);
                foreach (var moveable in Moveables)
                    moveable.Location += new Size(transform);
                previous += new Size(transform);
            }
        }

        public void Disconnect(DragPanel p)
        {
            foreach (DragPanel moveable in Moveables)
            {
                if (moveable.Children().Contains(p))
                {
                    moveable.childRemove(p);
                    
                }
            }
            p.UpdateAll();
        }

        private void AddNewDialogue(object sender, EventArgs e)
        {
			Random r = new Random();
			var pos = Cursor.Position;
			Cursor.Position = splitContainer1.Panel2.Location + new Size(r.Next(splitContainer1.Panel2.Width - 150) + 75, r.Next(splitContainer1.Panel2.Height - 150) + 75);
            SplitContainer1_Panel2_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.D));
			Cursor.Position = pos;
        }
        private void AddNewStart(object sender, EventArgs e)
        {
			Random r = new Random();
			var pos = Cursor.Position;
			Cursor.Position = splitContainer1.Panel2.Location + new Size(r.Next(splitContainer1.Panel2.Width - 150) + 75, r.Next(splitContainer1.Panel2.Height - 150) + 75);
			SplitContainer1_Panel2_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.S));
			Cursor.Position = pos;
		}

        public void DeleteWidget(Control d)
        {
            if (splitContainer1.Panel2.Controls.Contains(d))
                splitContainer1.Panel2.Controls.Remove(d);
        }

        public SplitterPanel getSplitPanel1()
        {
            return this.splitContainer1.Panel1;
        }

        private void SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer1.Panel1.Controls.Clear();
            DragPanel.Foc?.Edit();
        }
        bool GraphicsFancy;

        private void DialogueBoxColorBTN_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() != DialogResult.OK) return;
            DialogueBoxCOL = cd.Color;
            foreach (DialogueDragPanel c in Moveables.Where(x => x is DialogueDragPanel))
            {
                c.UpdateColor();
            }
        }

        private void StartBoxColorBTN_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() != DialogResult.OK) return;
			StartBoxCOL = cd.Color;
            foreach (StartDialogueDragPanel c in Moveables.Where(x => x is StartDialogueDragPanel))
            {
                c.UpdateColor();
            }
        }

        private void GraphicsQualityBTN_Click(object sender, EventArgs e)
        {
            if (GraphicsFancy)
            {
                GraphicsQualityBTN.Text = "Graphics: Fast (G)";
            } else
            {
                GraphicsQualityBTN.Text = "Graphics: Fancy (G)";
            }
            GraphicsFancy = !GraphicsFancy;
        }
        public int getGraphWidth()
        {
            return this.splitContainer1.Panel2.Width;
        }

		private void AddSplitter(object sender, EventArgs e)
		{
			Random r = new Random();
			var pos = Cursor.Position;
			Cursor.Position = splitContainer1.Panel2.Location + new Size(r.Next(splitContainer1.Panel2.Width - 150) + 75, r.Next(splitContainer1.Panel2.Height - 150) + 75);
			SplitContainer1_Panel2_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.F));
			Cursor.Position = pos;
		}

		public int getGraphHeight()
        {
            return this.splitContainer1.Panel2.Height;
        }

		private void ToolStripButton6_Click(object sender, EventArgs e)
		{
			SplitContainer1_Panel2_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.C));
		}

		private void ToolStripButton7_DropDownOpened(object sender, EventArgs e)
		{

		}

		private void DragFileIn(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}

		private void DropFile(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			foreach (string file in files.Where(x => x.EndsWith(".chr")))
			{
				string name;
				List<string> fileList = new List<string>();
				using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
				{
					name = reader.ReadLine();
					while (!reader.EndOfStream)
					{
						fileList.Add(reader.ReadLine());
					}
				}
				Character c = new Character(name, file);
				
				this.CharactersList.Add(c);
				MessageBox.Show("Character Added: " + c.Name);
			}
		}

		private void ToolStripButton8_Click(object sender, EventArgs e)
		{
			SplitContainer1_Panel2_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.N));
		}

		private void ToolStripButton6_Click_1(object sender, EventArgs e)
		{
			SplitContainer1_Panel2_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.C));
		}

		private void GraphColor(object sender, EventArgs e)
        {
            var c = new ColorDialog();
			if (c.ShowDialog() != DialogResult.OK) return;
			graphColor = c.Color;
        }

        private void EditorColor(object sender, EventArgs e)
        {
            var c = new ColorDialog();
			if (c.ShowDialog() != DialogResult.OK) return;
			getSplitPanel1().BackColor = editorColor = c.Color;
        }

        private void ConnectorColor(object sender, EventArgs e)
        {
            var c = new ColorDialog();
			if (c.ShowDialog() != DialogResult.OK) return;
			connectorColor = c.Color;
        }

        public SplitterPanel getSplitPanel2()
        {
            return this.splitContainer1.Panel2;
        }

		public static void SetDoubleBuffered(System.Windows.Forms.Control c)
		{
			//Taxes: Remote Desktop Connection and painting
			//http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
			if (System.Windows.Forms.SystemInformation.TerminalServerSession)
				return;

			System.Reflection.PropertyInfo aProp =
				  typeof(System.Windows.Forms.Control).GetProperty(
						"DoubleBuffered",
						System.Reflection.BindingFlags.NonPublic |
						System.Reflection.BindingFlags.Instance);

			aProp.SetValue(c, true, null);
		}
	}
}
