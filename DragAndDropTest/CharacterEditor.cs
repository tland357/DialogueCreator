using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DragAndDropTest
{
	public partial class CharacterEditor : Form
	{
		public CharacterEditor(Window w, Window.Character c)
		{
			InitializeComponent();
			FormReference = w;
			Character = c;
			textBox1.Text = c?.Name ?? "";
		}
		protected Window FormReference;
		public Window.Character Character;
		private void Button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog D = new FolderBrowserDialog();
			D.Description = "Select a directory containing dialogue sprites";
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Must specify a name for the character before loading images");
			}
			else if (D.ShowDialog() != DialogResult.Cancel) {
				if (Character == null)
				{
					Character = new Window.Character(textBox1.Text,D.SelectedPath + '\\' + textBox1.Text + ".chr");
				} else {
					FormReference.CharactersList.Remove(Character);
				}
				Character.Name = textBox1.Text;
				Character.Sprites.Clear();
				var files = Directory.GetFiles(D.SelectedPath, "*.png");
				foreach (var file in files)
				{
					string f = file;
					while (f.Contains('\\'))
					{
						f = f.Remove(0, 1);
					}
					Character.Sprites.Add(f.TrimEnd(".png".ToCharArray()),Image.FromFile(file));
				}
				FormReference.CharactersList.Add(Character);
				using (StreamWriter writer = new StreamWriter(D.SelectedPath + "\\" + Character.Name + ".chr"))
				{
					writer.WriteLine(Character.Name);
					foreach (var file in files) writer.WriteLine(file);
				}
			}
			this.Close();
		}
	}
}
