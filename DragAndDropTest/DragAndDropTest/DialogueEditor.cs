using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DragAndDropTest
{
    class DialogueEditor : Panel
    {
        private TextBox SpeakerTXT;
        private TextBox SpriteTXT;
        private RichTextBox EntryTextTXT;
        private RichTextBox DialogueTXT;
        private Label SpeakerLBL;
        private Label SpriteLBL;
        private Label EntryTextLBL;
        private Label DialogueLBL;

        private void InitializeComponent()
        {
            this.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(SpeakerTXT);
            this.Controls.Add(SpeakerLBL);
            this.Controls.Add(SpriteTXT);
            this.Controls.Add(SpriteLBL);
            this.Controls.Add(EntryTextTXT);
            this.Controls.Add(EntryTextLBL);
            this.Controls.Add(DialogueTXT);
            this.Controls.Add(DialogueLBL);

            this.SpeakerTXT = new System.Windows.Forms.TextBox();
            this.SpriteTXT = new System.Windows.Forms.TextBox();
            this.EntryTextTXT = new System.Windows.Forms.RichTextBox();
            this.DialogueTXT = new System.Windows.Forms.RichTextBox();
            this.SpeakerLBL = new System.Windows.Forms.Label();
            this.SpriteLBL = new System.Windows.Forms.Label();
            this.EntryTextLBL = new System.Windows.Forms.Label();
            this.DialogueLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SpeakerTXT
            // 
            this.SpeakerTXT.Location = new System.Drawing.Point(0, 0);
            this.SpeakerTXT.Name = "SpeakerTXT";
            this.SpeakerTXT.Size = new System.Drawing.Size(100, 22);
            this.SpeakerTXT.TabIndex = 0;
            // 
            // SpriteTXT
            // 
            this.SpriteTXT.Location = new System.Drawing.Point(0, 0);
            this.SpriteTXT.Name = "SpriteTXT";
            this.SpriteTXT.Size = new System.Drawing.Size(100, 22);
            this.SpriteTXT.TabIndex = 0;
            // 
            // EntryTextTXT
            // 
            this.EntryTextTXT.Location = new System.Drawing.Point(0, 0);
            this.EntryTextTXT.Name = "EntryTextTXT";
            this.EntryTextTXT.Size = new System.Drawing.Size(100, 96);
            this.EntryTextTXT.TabIndex = 0;
            this.EntryTextTXT.Text = "";
            // 
            // DialogueTXT
            // 
            this.DialogueTXT.Location = new System.Drawing.Point(0, 0);
            this.DialogueTXT.Name = "DialogueTXT";
            this.DialogueTXT.Size = new System.Drawing.Size(100, 96);
            this.DialogueTXT.TabIndex = 0;
            this.DialogueTXT.Text = "";
            // 
            // SpeakerLBL
            // 
            this.SpeakerLBL.AutoSize = true;
            this.SpeakerLBL.Location = new System.Drawing.Point(0, 0);
            this.SpeakerLBL.Name = "SpeakerLBL";
            this.SpeakerLBL.Size = new System.Drawing.Size(100, 23);
            this.SpeakerLBL.TabIndex = 0;
            this.SpeakerLBL.Text = "Speaker Name";
            // 
            // SpriteLBL
            // 
            this.SpriteLBL.AutoSize = true;
            this.SpriteLBL.Location = new System.Drawing.Point(0, 0);
            this.SpriteLBL.Name = "SpriteLBL";
            this.SpriteLBL.Size = new System.Drawing.Size(100, 23);
            this.SpriteLBL.TabIndex = 0;
            this.SpriteLBL.Text = "Sprite Name";
            // 
            // EntryTextLBL
            // 
            this.EntryTextLBL.AutoSize = true;
            this.EntryTextLBL.Location = new System.Drawing.Point(0, 0);
            this.EntryTextLBL.Name = "EntryTextLBL";
            this.EntryTextLBL.Size = new System.Drawing.Size(100, 23);
            this.EntryTextLBL.TabIndex = 0;
            this.EntryTextLBL.Text = "Entry Dialogue";
            // 
            // DialogueLBL
            // 
            this.DialogueLBL.AutoSize = true;
            this.DialogueLBL.Location = new System.Drawing.Point(0, 0);
            this.DialogueLBL.Name = "DialogueLBL";
            this.DialogueLBL.Size = new System.Drawing.Size(100, 23);
            this.DialogueLBL.TabIndex = 0;
            this.DialogueLBL.Text = "Speaker Dialogue";
        }
    }
}
