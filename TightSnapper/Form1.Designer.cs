namespace TightSnapper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startRecordingBtn = new System.Windows.Forms.Button();
            this.stopRecordingBtn = new System.Windows.Forms.Button();
            this.snapBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.intervalSelection = new System.Windows.Forms.NumericUpDown();
            this.browseBtn = new System.Windows.Forms.Button();
            this.saveToTxtBox = new System.Windows.Forms.TextBox();
            this.durationSelection = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.compressionNumeric = new System.Windows.Forms.NumericUpDown();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.intervalSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressionNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // startRecordingBtn
            // 
            this.startRecordingBtn.Location = new System.Drawing.Point(12, 15);
            this.startRecordingBtn.Name = "startRecordingBtn";
            this.startRecordingBtn.Size = new System.Drawing.Size(153, 69);
            this.startRecordingBtn.TabIndex = 0;
            this.startRecordingBtn.Text = "Start Recording";
            this.startRecordingBtn.UseVisualStyleBackColor = true;
            this.startRecordingBtn.Click += new System.EventHandler(this.startRecordingBtn_Click);
            // 
            // stopRecordingBtn
            // 
            this.stopRecordingBtn.Location = new System.Drawing.Point(182, 15);
            this.stopRecordingBtn.Name = "stopRecordingBtn";
            this.stopRecordingBtn.Size = new System.Drawing.Size(153, 69);
            this.stopRecordingBtn.TabIndex = 1;
            this.stopRecordingBtn.Text = "Stop Recording";
            this.stopRecordingBtn.UseVisualStyleBackColor = true;
            this.stopRecordingBtn.Click += new System.EventHandler(this.stopRecordingBtn_Click);
            // 
            // snapBtn
            // 
            this.snapBtn.Location = new System.Drawing.Point(12, 90);
            this.snapBtn.Name = "snapBtn";
            this.snapBtn.Size = new System.Drawing.Size(323, 38);
            this.snapBtn.TabIndex = 2;
            this.snapBtn.Text = "Quick Snap";
            this.snapBtn.UseVisualStyleBackColor = true;
            this.snapBtn.Click += new System.EventHandler(this.snapBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Interval (seconds): ";
            // 
            // intervalSelection
            // 
            this.intervalSelection.Location = new System.Drawing.Point(115, 141);
            this.intervalSelection.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.intervalSelection.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.intervalSelection.Name = "intervalSelection";
            this.intervalSelection.Size = new System.Drawing.Size(44, 20);
            this.intervalSelection.TabIndex = 3;
            this.intervalSelection.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.intervalSelection.ValueChanged += new System.EventHandler(this.intervalSelection_ValueChanged);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(182, 166);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(153, 27);
            this.browseBtn.TabIndex = 7;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // saveToTxtBox
            // 
            this.saveToTxtBox.Location = new System.Drawing.Point(182, 140);
            this.saveToTxtBox.Name = "saveToTxtBox";
            this.saveToTxtBox.Size = new System.Drawing.Size(153, 20);
            this.saveToTxtBox.TabIndex = 6;
            this.saveToTxtBox.Text = "Save snaps to...";
            // 
            // durationSelection
            // 
            this.durationSelection.Location = new System.Drawing.Point(115, 199);
            this.durationSelection.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.durationSelection.Name = "durationSelection";
            this.durationSelection.Size = new System.Drawing.Size(44, 20);
            this.durationSelection.TabIndex = 5;
            this.durationSelection.ValueChanged += new System.EventHandler(this.durationSelection_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Duration (minutes):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Compression ( % ):";
            // 
            // compressionNumeric
            // 
            this.compressionNumeric.Location = new System.Drawing.Point(115, 173);
            this.compressionNumeric.Name = "compressionNumeric";
            this.compressionNumeric.Size = new System.Drawing.Size(44, 20);
            this.compressionNumeric.TabIndex = 4;
            this.compressionNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.compressionNumeric.ValueChanged += new System.EventHandler(this.compressionNumeric_ValueChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(182, 213);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(155, 13);
            this.linkLabel1.TabIndex = 41;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "http://lionclawelectronics.com/";
            this.linkLabel1.Text = "http://lionclawelectronics.com/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 234);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.compressionNumeric);
            this.Controls.Add(this.durationSelection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.saveToTxtBox);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.intervalSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.snapBtn);
            this.Controls.Add(this.stopRecordingBtn);
            this.Controls.Add(this.startRecordingBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TightSnapper v1";
            ((System.ComponentModel.ISupportInitialize)(this.intervalSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressionNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startRecordingBtn;
        private System.Windows.Forms.Button stopRecordingBtn;
        private System.Windows.Forms.Button snapBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown intervalSelection;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox saveToTxtBox;
        private System.Windows.Forms.NumericUpDown durationSelection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown compressionNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

