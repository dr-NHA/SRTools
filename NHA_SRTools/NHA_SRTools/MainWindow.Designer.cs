namespace NHA_SRTools
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.UI_Thread = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.UnpackButton = new System.Windows.Forms.Button();
            this.ThreadsPanel = new System.Windows.Forms.Panel();
            this.Threads = new System.Windows.Forms.NumericUpDown();
            this.ThreadsLabel = new System.Windows.Forms.Label();
            this.State = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ThreadsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Threads)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "Open A Compatible File";
            this.OpenFile.Filter = "Packed Saints Row File|*.vpp_pc|Packed Saints Row File|*.str2_pc";
            this.OpenFile.Title = "Open A Packed Saints Row File";
            // 
            // UI_Thread
            // 
            this.UI_Thread.Enabled = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel1MinSize = 110;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Output);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(282, 109);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.UnpackButton);
            this.panel1.Controls.Add(this.ThreadsPanel);
            this.panel1.Controls.Add(this.State);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(111, 103);
            this.panel1.TabIndex = 0;
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.Color.Black;
            this.Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Output.Location = new System.Drawing.Point(3, 3);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(155, 103);
            this.Output.TabIndex = 3;
            this.Output.Text = "";
            this.Output.WordWrap = false;
            // 
            // UnpackButton
            // 
            this.UnpackButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UnpackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnpackButton.Location = new System.Drawing.Point(3, 42);
            this.UnpackButton.Name = "UnpackButton";
            this.UnpackButton.Size = new System.Drawing.Size(103, 23);
            this.UnpackButton.TabIndex = 8;
            this.UnpackButton.Text = "Unpack";
            this.UnpackButton.UseVisualStyleBackColor = true;
            // 
            // ThreadsPanel
            // 
            this.ThreadsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThreadsPanel.Controls.Add(this.Threads);
            this.ThreadsPanel.Controls.Add(this.ThreadsLabel);
            this.ThreadsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ThreadsPanel.Location = new System.Drawing.Point(3, 18);
            this.ThreadsPanel.Name = "ThreadsPanel";
            this.ThreadsPanel.Padding = new System.Windows.Forms.Padding(1);
            this.ThreadsPanel.Size = new System.Drawing.Size(103, 24);
            this.ThreadsPanel.TabIndex = 9;
            // 
            // Threads
            // 
            this.Threads.BackColor = System.Drawing.Color.Black;
            this.Threads.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Threads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Threads.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Threads.Location = new System.Drawing.Point(50, 1);
            this.Threads.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Threads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Threads.Name = "Threads";
            this.Threads.Size = new System.Drawing.Size(50, 20);
            this.Threads.TabIndex = 5;
            this.Threads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Threads.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ThreadsLabel
            // 
            this.ThreadsLabel.AutoSize = true;
            this.ThreadsLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ThreadsLabel.Location = new System.Drawing.Point(1, 1);
            this.ThreadsLabel.Name = "ThreadsLabel";
            this.ThreadsLabel.Size = new System.Drawing.Size(49, 13);
            this.ThreadsLabel.TabIndex = 4;
            this.ThreadsLabel.Text = "Threads:";
            // 
            // State
            // 
            this.State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.State.Dock = System.Windows.Forms.DockStyle.Top;
            this.State.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.State.Location = new System.Drawing.Point(3, 3);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(103, 15);
            this.State.TabIndex = 10;
            this.State.Text = "Idle!";
            this.State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "NHA Saints Row Tools";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ThreadsPanel.ResumeLayout(false);
            this.ThreadsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Threads)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.Timer UI_Thread;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button UnpackButton;
        private System.Windows.Forms.Panel ThreadsPanel;
        private System.Windows.Forms.NumericUpDown Threads;
        private System.Windows.Forms.Label ThreadsLabel;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.RichTextBox Output;
    }
}

