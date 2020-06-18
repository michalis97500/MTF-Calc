namespace CoordsDemoApp
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.heightInMicronsTextBox = new System.Windows.Forms.TextBox();
            this.widthInMicronsTextBox = new System.Windows.Forms.TextBox();
            this.widthInMicronsLabel = new System.Windows.Forms.Label();
            this.heightInMicronsLabel = new System.Windows.Forms.Label();
            this.cursorInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(16, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 296);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(16, 16);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(104, 32);
            this.loadImageButton.TabIndex = 1;
            this.loadImageButton.Text = "Load  Image...";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // heightInMicronsTextBox
            // 
            this.heightInMicronsTextBox.Location = new System.Drawing.Point(112, 80);
            this.heightInMicronsTextBox.Name = "heightInMicronsTextBox";
            this.heightInMicronsTextBox.Size = new System.Drawing.Size(104, 20);
            this.heightInMicronsTextBox.TabIndex = 2;
            this.heightInMicronsTextBox.Text = "6000";
            // 
            // widthInMicronsTextBox
            // 
            this.widthInMicronsTextBox.Location = new System.Drawing.Point(112, 56);
            this.widthInMicronsTextBox.Name = "widthInMicronsTextBox";
            this.widthInMicronsTextBox.Size = new System.Drawing.Size(104, 20);
            this.widthInMicronsTextBox.TabIndex = 3;
            this.widthInMicronsTextBox.Text = "10000";
            // 
            // widthInMicronsLabel
            // 
            this.widthInMicronsLabel.AutoSize = true;
            this.widthInMicronsLabel.Location = new System.Drawing.Point(16, 60);
            this.widthInMicronsLabel.Name = "widthInMicronsLabel";
            this.widthInMicronsLabel.Size = new System.Drawing.Size(85, 13);
            this.widthInMicronsLabel.TabIndex = 4;
            this.widthInMicronsLabel.Text = "Width in microns";
            // 
            // heightInMicronsLabel
            // 
            this.heightInMicronsLabel.AutoSize = true;
            this.heightInMicronsLabel.Location = new System.Drawing.Point(16, 84);
            this.heightInMicronsLabel.Name = "heightInMicronsLabel";
            this.heightInMicronsLabel.Size = new System.Drawing.Size(88, 13);
            this.heightInMicronsLabel.TabIndex = 5;
            this.heightInMicronsLabel.Text = "Height in microns";
            // 
            // cursorInfoLabel
            // 
            this.cursorInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cursorInfoLabel.Location = new System.Drawing.Point(232, 8);
            this.cursorInfoLabel.Name = "cursorInfoLabel";
            this.cursorInfoLabel.Size = new System.Drawing.Size(256, 104);
            this.cursorInfoLabel.TabIndex = 6;
            this.cursorInfoLabel.Text = "Cursor Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 433);
            this.Controls.Add(this.cursorInfoLabel);
            this.Controls.Add(this.heightInMicronsLabel);
            this.Controls.Add(this.widthInMicronsLabel);
            this.Controls.Add(this.widthInMicronsTextBox);
            this.Controls.Add(this.heightInMicronsTextBox);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.TextBox heightInMicronsTextBox;
        private System.Windows.Forms.TextBox widthInMicronsTextBox;
        private System.Windows.Forms.Label widthInMicronsLabel;
        private System.Windows.Forms.Label heightInMicronsLabel;
        private System.Windows.Forms.Label cursorInfoLabel;
    }
}

