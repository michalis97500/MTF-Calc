namespace MTF_Calc
{
    partial class MainApp
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
        public void InitializeComponent()
        {
            this.load_image_button = new System.Windows.Forms.Button();
            this.ImageDisplay = new System.Windows.Forms.PictureBox();
            this.SingleImageButton = new System.Windows.Forms.Button();
            this.LiveFeedButton = new System.Windows.Forms.Button();
            this.StopLiveFeedButton = new System.Windows.Forms.Button();
            this.cameraconnectbutton = new System.Windows.Forms.Button();
            this.GetBMPValuesVer = new System.Windows.Forms.Button();
            this.XposVert = new System.Windows.Forms.TextBox();
            this.YposVert = new System.Windows.Forms.TextBox();
            this.StartTestButton = new System.Windows.Forms.Button();
            this.CenterStageButton = new System.Windows.Forms.Button();
            this.FieldSizeTextbox = new System.Windows.Forms.TextBox();
            this.CalibrateStageButton = new System.Windows.Forms.Button();
            this.CalibrateImageButton = new System.Windows.Forms.Button();
            this.StageConnectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // load_image_button
            // 
            this.load_image_button.Location = new System.Drawing.Point(92, 41);
            this.load_image_button.Name = "load_image_button";
            this.load_image_button.Size = new System.Drawing.Size(76, 22);
            this.load_image_button.TabIndex = 0;
            this.load_image_button.Text = "Load Image";
            this.load_image_button.UseVisualStyleBackColor = true;
            this.load_image_button.Click += new System.EventHandler(this.load_image_button_Click);
            // 
            // ImageDisplay
            // 
            this.ImageDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageDisplay.Location = new System.Drawing.Point(195, 12);
            this.ImageDisplay.Name = "ImageDisplay";
            this.ImageDisplay.Size = new System.Drawing.Size(835, 451);
            this.ImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageDisplay.TabIndex = 1;
            this.ImageDisplay.TabStop = false;
            this.ImageDisplay.Click += new System.EventHandler(this.ImageDisplay_Click);
            // 
            // SingleImageButton
            // 
            this.SingleImageButton.Location = new System.Drawing.Point(12, 41);
            this.SingleImageButton.Name = "SingleImageButton";
            this.SingleImageButton.Size = new System.Drawing.Size(74, 22);
            this.SingleImageButton.TabIndex = 2;
            this.SingleImageButton.Text = "Single Image";
            this.SingleImageButton.UseVisualStyleBackColor = true;
            this.SingleImageButton.Click += new System.EventHandler(this.SingleImageButton_Click);
            // 
            // LiveFeedButton
            // 
            this.LiveFeedButton.Location = new System.Drawing.Point(12, 69);
            this.LiveFeedButton.Name = "LiveFeedButton";
            this.LiveFeedButton.Size = new System.Drawing.Size(74, 23);
            this.LiveFeedButton.TabIndex = 4;
            this.LiveFeedButton.Text = "Live Feed";
            this.LiveFeedButton.UseVisualStyleBackColor = true;
            this.LiveFeedButton.Click += new System.EventHandler(this.LiveFeedButton_Click);
            // 
            // StopLiveFeedButton
            // 
            this.StopLiveFeedButton.Location = new System.Drawing.Point(92, 69);
            this.StopLiveFeedButton.Name = "StopLiveFeedButton";
            this.StopLiveFeedButton.Size = new System.Drawing.Size(76, 23);
            this.StopLiveFeedButton.TabIndex = 5;
            this.StopLiveFeedButton.Text = "Stop Live";
            this.StopLiveFeedButton.UseVisualStyleBackColor = true;
            this.StopLiveFeedButton.Click += new System.EventHandler(this.StopLiveFeedButton_Click);
            // 
            // cameraconnectbutton
            // 
            this.cameraconnectbutton.AutoSize = true;
            this.cameraconnectbutton.Location = new System.Drawing.Point(44, 12);
            this.cameraconnectbutton.Name = "cameraconnectbutton";
            this.cameraconnectbutton.Size = new System.Drawing.Size(95, 23);
            this.cameraconnectbutton.TabIndex = 6;
            this.cameraconnectbutton.Text = "Connect camera";
            this.cameraconnectbutton.UseVisualStyleBackColor = true;
            this.cameraconnectbutton.Click += new System.EventHandler(this.cameraconnectbutton_Click);
            // 
            // GetBMPValuesVer
            // 
            this.GetBMPValuesVer.Location = new System.Drawing.Point(34, 137);
            this.GetBMPValuesVer.Name = "GetBMPValuesVer";
            this.GetBMPValuesVer.Size = new System.Drawing.Size(109, 48);
            this.GetBMPValuesVer.TabIndex = 7;
            this.GetBMPValuesVer.Text = "Get BMP Values Vertical";
            this.GetBMPValuesVer.UseVisualStyleBackColor = true;
            this.GetBMPValuesVer.Click += new System.EventHandler(this.GetBMPValuesVer_Click);
            // 
            // XposVert
            // 
            this.XposVert.Location = new System.Drawing.Point(12, 111);
            this.XposVert.Name = "XposVert";
            this.XposVert.Size = new System.Drawing.Size(75, 20);
            this.XposVert.TabIndex = 8;
            this.XposVert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // YposVert
            // 
            this.YposVert.Location = new System.Drawing.Point(93, 111);
            this.YposVert.Name = "YposVert";
            this.YposVert.Size = new System.Drawing.Size(75, 20);
            this.YposVert.TabIndex = 9;
            this.YposVert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // StartTestButton
            // 
            this.StartTestButton.Location = new System.Drawing.Point(54, 298);
            this.StartTestButton.Name = "StartTestButton";
            this.StartTestButton.Size = new System.Drawing.Size(75, 23);
            this.StartTestButton.TabIndex = 10;
            this.StartTestButton.Text = "Start Test";
            this.StartTestButton.UseVisualStyleBackColor = true;
            this.StartTestButton.Click += new System.EventHandler(this.StartTestButton_Click);
            // 
            // CenterStageButton
            // 
            this.CenterStageButton.Location = new System.Drawing.Point(44, 383);
            this.CenterStageButton.Name = "CenterStageButton";
            this.CenterStageButton.Size = new System.Drawing.Size(99, 33);
            this.CenterStageButton.TabIndex = 11;
            this.CenterStageButton.Text = "Center stage";
            this.CenterStageButton.UseVisualStyleBackColor = true;
            this.CenterStageButton.Visible = false;
            this.CenterStageButton.Click += new System.EventHandler(this.CenterStageButton_Click);
            // 
            // FieldSizeTextbox
            // 
            this.FieldSizeTextbox.Location = new System.Drawing.Point(15, 228);
            this.FieldSizeTextbox.Name = "FieldSizeTextbox";
            this.FieldSizeTextbox.Size = new System.Drawing.Size(152, 20);
            this.FieldSizeTextbox.TabIndex = 12;
            this.FieldSizeTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // CalibrateStageButton
            // 
            this.CalibrateStageButton.Location = new System.Drawing.Point(44, 336);
            this.CalibrateStageButton.Name = "CalibrateStageButton";
            this.CalibrateStageButton.Size = new System.Drawing.Size(99, 41);
            this.CalibrateStageButton.TabIndex = 13;
            this.CalibrateStageButton.Text = "Calibrate stage";
            this.CalibrateStageButton.UseVisualStyleBackColor = true;
            this.CalibrateStageButton.Click += new System.EventHandler(this.CalibrateStageButton_Click);
            // 
            // CalibrateImageButton
            // 
            this.CalibrateImageButton.Location = new System.Drawing.Point(49, 259);
            this.CalibrateImageButton.Name = "CalibrateImageButton";
            this.CalibrateImageButton.Size = new System.Drawing.Size(89, 28);
            this.CalibrateImageButton.TabIndex = 14;
            this.CalibrateImageButton.Text = "Calibrate Image";
            this.CalibrateImageButton.UseVisualStyleBackColor = true;
            this.CalibrateImageButton.Click += new System.EventHandler(this.CalibrateImageButton_Click);
            // 
            // StageConnectButton
            // 
            this.StageConnectButton.Location = new System.Drawing.Point(44, 191);
            this.StageConnectButton.Name = "StageConnectButton";
            this.StageConnectButton.Size = new System.Drawing.Size(88, 28);
            this.StageConnectButton.TabIndex = 15;
            this.StageConnectButton.Text = "Connect Stage";
            this.StageConnectButton.UseVisualStyleBackColor = true;
            this.StageConnectButton.Click += new System.EventHandler(this.StageConnectButton_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 475);
            this.Controls.Add(this.StageConnectButton);
            this.Controls.Add(this.CalibrateImageButton);
            this.Controls.Add(this.CalibrateStageButton);
            this.Controls.Add(this.FieldSizeTextbox);
            this.Controls.Add(this.CenterStageButton);
            this.Controls.Add(this.StartTestButton);
            this.Controls.Add(this.YposVert);
            this.Controls.Add(this.XposVert);
            this.Controls.Add(this.GetBMPValuesVer);
            this.Controls.Add(this.cameraconnectbutton);
            this.Controls.Add(this.StopLiveFeedButton);
            this.Controls.Add(this.LiveFeedButton);
            this.Controls.Add(this.SingleImageButton);
            this.Controls.Add(this.ImageDisplay);
            this.Controls.Add(this.load_image_button);
            this.Name = "MainApp";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button load_image_button;
        public System.Windows.Forms.PictureBox ImageDisplay;
        private System.Windows.Forms.Button SingleImageButton;
        private System.Windows.Forms.Button LiveFeedButton;
        private System.Windows.Forms.Button StopLiveFeedButton;
        private System.Windows.Forms.Button cameraconnectbutton;
        private System.Windows.Forms.Button GetBMPValuesVer;
        private System.Windows.Forms.TextBox XposVert;
        private System.Windows.Forms.TextBox YposVert;
        private System.Windows.Forms.Button StartTestButton;
        private System.Windows.Forms.Button CenterStageButton;
        private System.Windows.Forms.TextBox FieldSizeTextbox;
        private System.Windows.Forms.Button CalibrateStageButton;
        private System.Windows.Forms.Button CalibrateImageButton;
        private System.Windows.Forms.Button StageConnectButton;
    }
}

