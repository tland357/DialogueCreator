using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DragAndDropTest
{
    public abstract class DragPanel : Panel
    {
        protected Window FormReference;
        Point previous;
        public static DragPanel Foc = null;
        public List<DragPanel> Children;
        public Button b, topConnecter, topDisconnecter, removeChildren;
        protected Panel drag;
        public static bool dragging;
        public DragPanel()
        {
            Children = new List<DragPanel>();
            Width = 100;
            Height = 124;
            BorderStyle = BorderStyle.Fixed3D;
            FormReference = Window.FormReference;
            UpdateColor();
            
            Controls.Add(b = new Button()
            {
                Text = "X",
                ForeColor = Color.White,
                BackColor = Color.Red,
                Width = 24,
                Location = new Point(0,0)
            });
            Controls.Add(drag = new Panel()
            {
                Width = 70,
                Height = b.Height,
                Location = new Point(24,0),
                BorderStyle = BorderStyle.Fixed3D
            });
            Controls.Add(topConnecter = new Button()
            {
                Text = "Connect",
                Location = new Point(0, 24),
                ForeColor = Color.White,
                Width = this.Width - 4,
            });
            Controls.Add(topDisconnecter = new Button()
            {
                Text = "Disconnect",
                Name = "Disconnect",
                Location = new Point(0, 48),
                ForeColor = Color.White,
                Width = this.Width - 4,
                Enabled = false,
            });
            Controls.Add(removeChildren = new Button()
            {
                Text = "Remove\nChildren",
                Location = new Point(0, 72),
                ForeColor = Color.White,
                Width = this.Width - 4,
                Height = 48,
                Enabled = false,
            });
            MouseDown += new MouseEventHandler(Add);
            drag.MouseDown += new MouseEventHandler(dragStart);
            drag.MouseMove += new MouseEventHandler(dragContinue);
            drag.MouseUp += new MouseEventHandler(dragEnd);
            b.Click += new EventHandler(deleteOwner);
            topConnecter.Click += new EventHandler(Connect);
            topDisconnecter.Click += new EventHandler(Disconnect);
            removeChildren.Click += new EventHandler(RemoveChildren);
            Add(null, null);
        }
        public void deleteOwner(object sender, EventArgs e)
        {
            this.FormReference.Disconnect(this);
            this.RemoveChildren(null, null);
            this.FormReference.DeleteWidget(this);
            this.FormReference.getSplitPanel1().Controls.Clear();
        }
        protected abstract Color GetBackColor();
        public void dragStart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                previous = MousePosition;
                Add(null, null);
                dragging = true;
            }
        }
        public void UpdateColor()
        {
            Color c = GetBackColor();
            if (this == Foc)
            {
                this.BackColor = Color.FromArgb(Math.Min(c.R * 3 / 2,255), Math.Min(c.G * 3 / 2,255), Math.Min(c.B * 3 / 2,255));
            }
            else
            {
                this.BackColor = c;
            }
            
        }
        //Sprotected abstract Color GetBackColor();
        public void dragContinue(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var transform = MousePosition - new Size(previous);
                this.Location += new Size(transform);
                previous += new Size(transform);
            }

        }
        public void dragEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var transform = MousePosition - new Size(previous);
                this.Location += new Size(transform);
                dragging = false;
            }
        }
        public void Add(object sender, EventArgs e)
        {
            var prev = Foc;
            Foc = this;
            
            if (prev != null)
            {
                prev.UpdateColor();
            }
            Foc.UpdateColor();
            FormReference.getSplitPanel1().Controls.Clear();
            Edit();
            UpdateAll();
        }
        public virtual void Connect(object sender, EventArgs e)
        {
            if (Foc != null)
            {
                if (Foc is StartDialogueDragPanel)
                {
                    if (Foc != this)
                    {
                        if (!Foc.Children.Contains(this))
                        {
                            if (!this.Children.Contains(Foc))
                            {
                                
                                Foc.Children.Clear();
                                Foc.Children.Add(this);
                                UpdateAll();
                            }
                        }
                    }
                }
                else if (this is StartDialogueDragPanel)
                {
                    if (Foc != this)
                    {
                        if (!Foc.Children.Contains(this))
                        {
                            if (!this.Children.Contains(Foc))
                            {
                                this.Children.Clear();
                                this.Children.Add(Foc);
                                UpdateAll();
                            }
                        }
                    }
                }
                else
                {
                    if (Foc != this)
                    {
                        if (!Foc.Children.Contains(this))
                        {
                            if (!this.Children.Contains(Foc))
                            {
                                if (this.Location.Y > Foc.Location.Y)
                                {
                                    Foc.Children.Add(this);
                                    UpdateAll();
                                } else
                                {
                                    this.Children.Add(Foc);
                                    UpdateAll();
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Disconnect(object sender, EventArgs e)
        {
            FormReference.Disconnect(this);
            UpdateAll();
        }
        public void RemoveChildren(object sender, EventArgs e)
        {
            while (Children.Count > 0)
                foreach (var child in Children)
                {
                    this.Children.Remove(child);
                    break;
                }
            UpdateAll();
        }
        public abstract void Edit();
        public void UpdateAll()
        {
            foreach (DragPanel panel in FormReference.Moveables)
            {
                if (panel.Children.Count > 0)
                {
                    panel.removeChildren.Enabled = true;
                } else
                {
                    panel.removeChildren.Enabled = false;
                }
                if (FormReference.Moveables.Any(x => (x as DragPanel).Children.Contains(panel)))
                {
                    panel.topDisconnecter.Enabled = true;
                } else
                {
                    panel.topDisconnecter.Enabled = false;
                }
                if (panel == Foc || panel.Children.Contains(Foc) || Foc.Children.Contains(panel) || FormReference.Moveables.Count <= 1)
                {
                    panel.topConnecter.Enabled = false;
                } else
                {
                    panel.topConnecter.Enabled = true;
                }
            }
        }
    }
}
