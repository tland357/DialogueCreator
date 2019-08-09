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

namespace DragAndDropTest
{
    public partial class Window : Form
    {
        public static Window FormReference;
        public static Color StartBoxCOL, DialogueBoxCOL, graphColor, editorColor, connectorColor;
        public Window()
        {
            GraphicsFancy = true;
            graphColor = System.Drawing.Color.DarkSlateGray;
            editorColor = System.Drawing.Color.DarkGray;
            connectorColor = Color.Black;
            StartBoxCOL = Color.FromArgb(80, 0, 0);
            DialogueBoxCOL = Color.FromArgb(45, 0, 60);
            InitializeComponent();
            FormReference = this;
            Moveables = new List<Control>();
            graphics = splitContainer1.Panel2.CreateGraphics();
            ThreadStart start = new ThreadStart(() =>
            {
				while (true)
				{
					Thread.Sleep(8);
					BufferedGraphicsContext currentContext;
					BufferedGraphics myBuffer;
					currentContext = BufferedGraphicsManager.Current;
					myBuffer = currentContext.Allocate(graphics, splitContainer1.Panel2.DisplayRectangle);
					splitContainer1.Panel2.ResumeLayout();
					splitContainer1.Panel2.SuspendLayout();
					var list = Moveables.Where(x => x is DragPanel).Where(x => (x as DragPanel).Children.Count(z => z != null) > 0).Select(x => x as DragPanel).ToList();
					myBuffer.Graphics.FillRectangle(new SolidBrush(graphColor), new Rectangle(new Point(0, 0), splitContainer1.Size));
					try
					{
						foreach (DragPanel Moveable in list)
						{
							foreach (var child in Moveable.Children.Where(x => x != null))
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
								}
								else
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
                    GraphicsQualityBTN_Click(null, null);
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
                if (moveable.Children.Contains(p))
                {
                    moveable.Children.Remove(p);
                    
                }
            }
            p.UpdateAll();
        }

        private void AddNewDialogue(object sender, EventArgs e)
        {
            Cursor.Position = splitContainer1.Panel2.Location + new Size(splitContainer1.Panel2.Width / 2, splitContainer1.Panel2.Height / 2);
            SplitContainer1_Panel2_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.D));
        }
        private void AddNewStart(object sender, EventArgs e)
        {
            Cursor.Position = splitContainer1.Panel2.Location + new Size(splitContainer1.Panel2.Width / 2, splitContainer1.Panel2.Height / 2);
            SplitContainer1_Panel2_PreviewKeyDown(null, new PreviewKeyDownEventArgs(Keys.S));
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
            cd.ShowDialog();
            DialogueBoxCOL = cd.Color;
            foreach (DialogueDragPanel c in Moveables.Where(x => x is DialogueDragPanel))
            {
                c.UpdateColor();
            }
        }

        private void StartBoxColorBTN_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
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

        public int getGraphHeight()
        {
            return this.splitContainer1.Panel2.Height;
        }

        private void GraphColor(object sender, EventArgs e)
        {
            var c = new ColorDialog();
            c.ShowDialog();
            graphColor = c.Color;
        }

        private void EditorColor(object sender, EventArgs e)
        {
            var c = new ColorDialog();
            c.ShowDialog();
            getSplitPanel1().BackColor = editorColor = c.Color;
        }

        private void ConnectorColor(object sender, EventArgs e)
        {
            var c = new ColorDialog();
            c.ShowDialog();
            connectorColor = c.Color;
        }

        public SplitterPanel getSplitPanel2()
        {
            return this.splitContainer1.Panel2;
        }
    }
}
