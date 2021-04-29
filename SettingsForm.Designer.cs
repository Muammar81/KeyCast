namespace KeyCast
{
    partial class SettingsForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fadeDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.historySteps = new System.Windows.Forms.NumericUpDown();
            this.hasBackColor = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shrinkHistory = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OpacityLabel = new System.Windows.Forms.Label();
            this.OpacityBar = new System.Windows.Forms.TrackBar();
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationTip = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.RunStartup_CheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fadeDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historySteps)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(123, 359);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.ShowColor = true;
            // 
            // fadeDelay
            // 
            this.fadeDelay.Location = new System.Drawing.Point(73, 25);
            this.fadeDelay.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.fadeDelay.Name = "fadeDelay";
            this.fadeDelay.Size = new System.Drawing.Size(37, 20);
            this.fadeDelay.TabIndex = 1;
            this.fadeDelay.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fade Delay:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seconds";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Font";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "History:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Steps";
            // 
            // historySteps
            // 
            this.historySteps.Location = new System.Drawing.Point(73, 51);
            this.historySteps.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.historySteps.Name = "historySteps";
            this.historySteps.Size = new System.Drawing.Size(37, 20);
            this.historySteps.TabIndex = 6;
            this.historySteps.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // hasBackColor
            // 
            this.hasBackColor.AutoSize = true;
            this.hasBackColor.Location = new System.Drawing.Point(86, 30);
            this.hasBackColor.Name = "hasBackColor";
            this.hasBackColor.Size = new System.Drawing.Size(100, 17);
            this.hasBackColor.TabIndex = 7;
            this.hasBackColor.Text = "Use Back Color";
            this.hasBackColor.UseVisualStyleBackColor = true;
            this.hasBackColor.CheckedChanged += new System.EventHandler(this.hasBackColor_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shrinkHistory);
            this.groupBox1.Controls.Add(this.historySteps);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fadeDelay);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 118);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Behaviour";
            // 
            // shrinkHistory
            // 
            this.shrinkHistory.AutoSize = true;
            this.shrinkHistory.Location = new System.Drawing.Point(6, 86);
            this.shrinkHistory.Name = "shrinkHistory";
            this.shrinkHistory.Size = new System.Drawing.Size(91, 17);
            this.shrinkHistory.TabIndex = 7;
            this.shrinkHistory.Text = "&Shrink History";
            this.shrinkHistory.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.OpacityLabel);
            this.groupBox2.Controls.Add(this.OpacityBar);
            this.groupBox2.Controls.Add(this.locationLabel);
            this.groupBox2.Controls.Add(this.hasBackColor);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 160);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Appearance";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeyCast.Properties.Resources.kisspng_computer_mouse_computer_icons_pointer_cursor_move_5b16e905858be5_509014621528228101547;
            this.pictureBox1.Location = new System.Drawing.Point(147, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.ShowMoveTip);
            // 
            // OpacityLabel
            // 
            this.OpacityLabel.AutoSize = true;
            this.OpacityLabel.Location = new System.Drawing.Point(6, 66);
            this.OpacityLabel.Name = "OpacityLabel";
            this.OpacityLabel.Size = new System.Drawing.Size(75, 13);
            this.OpacityLabel.TabIndex = 8;
            this.OpacityLabel.Text = "Opacity: 100%";
            // 
            // OpacityBar
            // 
            this.OpacityBar.Location = new System.Drawing.Point(2, 82);
            this.OpacityBar.Maximum = 100;
            this.OpacityBar.Name = "OpacityBar";
            this.OpacityBar.Size = new System.Drawing.Size(188, 45);
            this.OpacityBar.TabIndex = 9;
            this.OpacityBar.TickFrequency = 5;
            this.OpacityBar.Scroll += new System.EventHandler(this.OpacityBar_Scroll);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(6, 135);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(135, 13);
            this.locationLabel.TabIndex = 8;
            this.locationLabel.Text = "Start Up Location: 999,222";
            this.locationLabel.MouseHover += new System.EventHandler(this.ShowMoveTip);
            // 
            // locationTip
            // 
            this.locationTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.locationTip.ToolTipTitle = "Setting Location";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel1.Location = new System.Drawing.Point(9, 373);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "About";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // RunStartup_CheckBox
            // 
            this.RunStartup_CheckBox.AutoSize = true;
            this.RunStartup_CheckBox.Location = new System.Drawing.Point(12, 312);
            this.RunStartup_CheckBox.Name = "RunStartup_CheckBox";
            this.RunStartup_CheckBox.Size = new System.Drawing.Size(95, 17);
            this.RunStartup_CheckBox.TabIndex = 11;
            this.RunStartup_CheckBox.Text = "Run at Startup";
            this.RunStartup_CheckBox.UseVisualStyleBackColor = true;
            this.RunStartup_CheckBox.CheckedChanged += new System.EventHandler(this.RunStartup_CheckBox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 394);
            this.Controls.Add(this.RunStartup_CheckBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Cast - Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.fadeDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historySteps)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.NumericUpDown fadeDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown historySteps;
        private System.Windows.Forms.CheckBox hasBackColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.ToolTip locationTip;
        private System.Windows.Forms.CheckBox shrinkHistory;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label OpacityLabel;
        private System.Windows.Forms.TrackBar OpacityBar;
        private System.Windows.Forms.CheckBox RunStartup_CheckBox;
    }
}