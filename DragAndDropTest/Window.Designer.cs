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
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
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
            this.StartBoxColorBTN,
            this.toolStripSeparator5,
            this.toolStripButton2,
            this.toolStripSeparator6,
            this.toolStripButton3,
            this.toolStripSeparator7,
            this.toolStripButton4});
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
            this.toolStripButton1.Size = new System.Drawing.Size(131, 24);
            this.toolStripButton1.Text = "Add Dialogue (D)";
            this.toolStripButton1.ToolTipText = resources.GetString("toolStripButton1.ToolTipText");
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
            this.AddStartBTN.Size = new System.Drawing.Size(98, 24);
            this.AddStartBTN.Text = "Add Start (S)";
            this.AddStartBTN.ToolTipText = resources.GetString("AddStartBTN.ToolTipText");
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
            this.GraphicsQualityBTN.Size = new System.Drawing.Size(137, 24);
            this.GraphicsQualityBTN.Text = "Graphics: Fancy (G)";
            this.GraphicsQualityBTN.ToolTipText = "Alternates graphics quality. \r\nConnectors between nodes will be\r\ndrawn on smooth " +
    "paths in fancy\r\nquality mode.";
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
            this.DialogueBoxColorBTN.Size = new System.Drawing.Size(191, 24);
            this.DialogueBoxColorBTN.Text = "Dialogue Box Color (Alt D)";
            this.DialogueBoxColorBTN.ToolTipText = "Adjusts the color of Dialogue Nodes.\r\n*note* works best with mid-tones and\r\ndarke" +
    "r tones.";
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
            this.StartBoxColorBTN.Size = new System.Drawing.Size(158, 24);
            this.StartBoxColorBTN.Text = "Start Box Color (Alt S)";
            this.StartBoxColorBTN.ToolTipText = "Adjusts the color of Start Nodes.\r\n*note* works best with mid-tones and\r\ndarker t" +
    "ones.\r\n";
            this.StartBoxColorBTN.Click += new System.EventHandler(this.StartBoxColorBTN_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(140, 24);
            this.toolStripButton2.Text = "Graph Color (Alt G)";
            this.toolStripButton2.ToolTipText = "Adjusts the color of the node-graph\r\nbackground";
            this.toolStripButton2.Click += new System.EventHandler(this.GraphColor);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(138, 24);
            this.toolStripButton3.Text = "Editor Color (Alt E)";
            this.toolStripButton3.ToolTipText = "Adjusts the background color of the\r\nnode editor on the left panel.";
            this.toolStripButton3.Click += new System.EventHandler(this.EditorColor);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(167, 24);
            this.toolStripButton4.Text = "Connector Color (Alt C)";
            this.toolStripButton4.ToolTipText = "Adjusts the color of the connecting \r\nlines between nodes.";
            this.toolStripButton4.Click += new System.EventHandler(this.ConnectorColor);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}

