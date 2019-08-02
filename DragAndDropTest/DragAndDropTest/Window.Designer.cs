using System.Drawing;

namespace DragAndDropTest
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddStartBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.GraphicsQualityBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DialogueBoxColorBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.StartBoxColorBTN = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragStart);
            this.splitContainer1.Panel2.MouseEnter += new System.EventHandler(this.SplitContainer1_Panel2_MouseEnter);
            this.splitContainer1.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragContinue);
            this.splitContainer1.Panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragEnd);
            this.splitContainer1.Panel2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SplitContainer1_Panel2_PreviewKeyDown);
            this.splitContainer1.Size = new System.Drawing.Size(1924, 1040);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitterMoved);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.AddStartBTN,
            this.toolStripSeparator2,
            this.GraphicsQualityBTN,
            this.toolStripSeparator3,
            this.DialogueBoxColorBTN,
            this.toolStripSeparator4,
            this.StartBoxColorBTN});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1617, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(106, 24);
            this.toolStripButton1.Text = "Add &Dialogue";
            this.toolStripButton1.Click += new System.EventHandler(this.AddNewDialogue);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // AddStartBTN
            // 
            this.AddStartBTN.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AddStartBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddStartBTN.Image = ((System.Drawing.Image)(resources.GetObject("AddStartBTN.Image")));
            this.AddStartBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddStartBTN.Name = "AddStartBTN";
            this.AddStartBTN.Size = new System.Drawing.Size(76, 24);
            this.AddStartBTN.Text = "Add &Start";
            this.AddStartBTN.Click += new System.EventHandler(this.AddNewStart);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // GraphicsQualityBTN
            // 
            this.GraphicsQualityBTN.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GraphicsQualityBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GraphicsQualityBTN.Image = ((System.Drawing.Image)(resources.GetObject("GraphicsQualityBTN.Image")));
            this.GraphicsQualityBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GraphicsQualityBTN.Name = "GraphicsQualityBTN";
            this.GraphicsQualityBTN.Size = new System.Drawing.Size(113, 24);
            this.GraphicsQualityBTN.Text = "&Graphics: Fancy";
            this.GraphicsQualityBTN.Click += new System.EventHandler(this.GraphicsQualityBTN_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // DialogueBoxColorBTN
            // 
            this.DialogueBoxColorBTN.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DialogueBoxColorBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DialogueBoxColorBTN.Image = ((System.Drawing.Image)(resources.GetObject("DialogueBoxColorBTN.Image")));
            this.DialogueBoxColorBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DialogueBoxColorBTN.Name = "DialogueBoxColorBTN";
            this.DialogueBoxColorBTN.Size = new System.Drawing.Size(143, 24);
            this.DialogueBoxColorBTN.Text = "Dialogue Box Color";
            this.DialogueBoxColorBTN.Click += new System.EventHandler(this.DialogueBoxColorBTN_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // StartBoxColorBTN
            // 
            this.StartBoxColorBTN.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StartBoxColorBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StartBoxColorBTN.Image = ((System.Drawing.Image)(resources.GetObject("StartBoxColorBTN.Image")));
            this.StartBoxColorBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartBoxColorBTN.Name = "StartBoxColorBTN";
            this.StartBoxColorBTN.Size = new System.Drawing.Size(113, 24);
            this.StartBoxColorBTN.Text = "Start Box Color";
            this.StartBoxColorBTN.ToolTipText = "Choose";
            this.StartBoxColorBTN.Click += new System.EventHandler(this.StartBoxColorBTN_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1040);
            this.Controls.Add(this.splitContainer1);
            this.HelpButton = true;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Window";
            this.Text = "DialogueGenerator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AddStartBTN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton GraphicsQualityBTN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton StartBoxColorBTN;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton DialogueBoxColorBTN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

