namespace KCNEUserInterface
{
    partial class MainForm
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
            this._versionBox = new System.Windows.Forms.ComboBox();
            this._versionLabel = new System.Windows.Forms.Label();
            this._startButton = new System.Windows.Forms.Button();
            this._stopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _versionBox
            // 
            this._versionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._versionBox.FormattingEnabled = true;
            this._versionBox.Location = new System.Drawing.Point(70, 16);
            this._versionBox.Name = "_versionBox";
            this._versionBox.Size = new System.Drawing.Size(121, 21);
            this._versionBox.TabIndex = 1;
            // 
            // _versionLabel
            // 
            this._versionLabel.AutoSize = true;
            this._versionLabel.Location = new System.Drawing.Point(12, 19);
            this._versionLabel.Name = "_versionLabel";
            this._versionLabel.Size = new System.Drawing.Size(45, 13);
            this._versionLabel.TabIndex = 2;
            this._versionLabel.Text = "Version:";
            // 
            // _startButton
            // 
            this._startButton.Location = new System.Drawing.Point(15, 51);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(176, 51);
            this._startButton.TabIndex = 3;
            this._startButton.Text = "Start";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this.OnStartClick);
            // 
            // _stopButton
            // 
            this._stopButton.Location = new System.Drawing.Point(15, 116);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(176, 51);
            this._stopButton.TabIndex = 4;
            this._stopButton.Text = "Stop";
            this._stopButton.UseVisualStyleBackColor = true;
            this._stopButton.Click += new System.EventHandler(this.OnStopClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 184);
            this.Controls.Add(this._stopButton);
            this.Controls.Add(this._startButton);
            this.Controls.Add(this._versionLabel);
            this.Controls.Add(this._versionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _versionBox;
        private System.Windows.Forms.Label _versionLabel;
        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _stopButton;
    }
}