using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DragAndDropTest
{
	class SplitterDragPanel : DragPanel
	{
		private DragPanel[] children;
		string Description;
		GroupBox DescriptionGB;
		TextBox DescriptionTXT;
		public SplitterDragPanel()
		{
			children = new DragPanel[2];
		}
		public override void Edit()
		{
			topConnecter.Enabled = false;
			var panel = FormReference.getSplitPanel1();
			panel.Controls.Add(DescriptionGB = new GroupBox()
			{
				Text = "Description",
				Size = new Size(panel.Width - 14, 140),
				Location = new Point(5, 10),
			});
			DescriptionGB.Controls.Add(DescriptionTXT = new TextBox()
			{
				Text = "",
				Size = new Size(DescriptionGB.Width - 14, DescriptionGB.Height - 14),
				Location = new Point(5, 10),
			});
		}
		public override DragPanel[] Children()
		{
			if (children == null)
				return new DragPanel[2];
			return children;
		}
		public override void AddChildren(DragPanel p)
		{
			if (children[0] == null)
				children[0] = p;
			else if (children[1] == null)
				children[1] = p;
			else {
				Random r = new Random();
				children[r.Next(1)] = p;
			}
		}
		public override void ClearChildren()
		{
			children[0] = null;
			children[1] = null;
		}
		public override void childRemove(DragPanel p)
		{
			children = children.Select(x => x == p ? null : x).ToArray();
		}
		protected override Color GetBackColor()
		{
			return Window.SplitterBoxCOL;
		}
	}
}
