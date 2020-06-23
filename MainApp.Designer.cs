﻿namespace MTF_Calc
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
            this.FieldSizeButton = new System.Windows.Forms.Button();
            this.SerialSelect = new System.Windows.Forms.ComboBox();
            this.FieldSizeRatio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.IlluminationControl = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.zcoord = new System.Windows.Forms.TextBox();
            this.ycoord = new System.Windows.Forms.TextBox();
            this.xcoord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MoveStageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieldSizeRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IlluminationControl)).BeginInit();
            this.SuspendLayout();
            // 
            // load_image_button
            // 
            this.load_image_button.Location = new System.Drawing.Point(92, 88);
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
            this.ImageDisplay.Size = new System.Drawing.Size(1063, 615);
            this.ImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageDisplay.TabIndex = 1;
            this.ImageDisplay.TabStop = false;
            this.ImageDisplay.Click += new System.EventHandler(this.ImageDisplay_Click);
            // 
            // SingleImageButton
            // 
            this.SingleImageButton.Location = new System.Drawing.Point(12, 88);
            this.SingleImageButton.Name = "SingleImageButton";
            this.SingleImageButton.Size = new System.Drawing.Size(74, 22);
            this.SingleImageButton.TabIndex = 2;
            this.SingleImageButton.Text = "Single Image";
            this.SingleImageButton.UseVisualStyleBackColor = true;
            this.SingleImageButton.Click += new System.EventHandler(this.SingleImageButton_Click);
            // 
            // LiveFeedButton
            // 
            this.LiveFeedButton.Location = new System.Drawing.Point(12, 116);
            this.LiveFeedButton.Name = "LiveFeedButton";
            this.LiveFeedButton.Size = new System.Drawing.Size(74, 23);
            this.LiveFeedButton.TabIndex = 4;
            this.LiveFeedButton.Text = "Live Feed";
            this.LiveFeedButton.UseVisualStyleBackColor = true;
            this.LiveFeedButton.Click += new System.EventHandler(this.LiveFeedButton_Click);
            // 
            // StopLiveFeedButton
            // 
            this.StopLiveFeedButton.Location = new System.Drawing.Point(92, 116);
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
            this.cameraconnectbutton.Location = new System.Drawing.Point(12, 12);
            this.cameraconnectbutton.Name = "cameraconnectbutton";
            this.cameraconnectbutton.Size = new System.Drawing.Size(99, 32);
            this.cameraconnectbutton.TabIndex = 6;
            this.cameraconnectbutton.Text = "Connect camera";
            this.cameraconnectbutton.UseVisualStyleBackColor = true;
            this.cameraconnectbutton.Click += new System.EventHandler(this.cameraconnectbutton_Click);
            // 
            // GetBMPValuesVer
            // 
            this.GetBMPValuesVer.Location = new System.Drawing.Point(11, 184);
            this.GetBMPValuesVer.Name = "GetBMPValuesVer";
            this.GetBMPValuesVer.Size = new System.Drawing.Size(76, 48);
            this.GetBMPValuesVer.TabIndex = 7;
            this.GetBMPValuesVer.Text = "Get BMP Values Vertical";
            this.GetBMPValuesVer.UseVisualStyleBackColor = true;
            this.GetBMPValuesVer.Click += new System.EventHandler(this.GetBMPValuesVer_Click);
            // 
            // XposVert
            // 
            this.XposVert.Location = new System.Drawing.Point(12, 158);
            this.XposVert.Name = "XposVert";
            this.XposVert.Size = new System.Drawing.Size(75, 20);
            this.XposVert.TabIndex = 8;
            this.XposVert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // YposVert
            // 
            this.YposVert.Location = new System.Drawing.Point(93, 158);
            this.YposVert.Name = "YposVert";
            this.YposVert.Size = new System.Drawing.Size(75, 20);
            this.YposVert.TabIndex = 9;
            this.YposVert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // StartTestButton
            // 
            this.StartTestButton.Location = new System.Drawing.Point(11, 396);
            this.StartTestButton.Name = "StartTestButton";
            this.StartTestButton.Size = new System.Drawing.Size(99, 26);
            this.StartTestButton.TabIndex = 10;
            this.StartTestButton.Text = "Start Test";
            this.StartTestButton.UseVisualStyleBackColor = true;
            this.StartTestButton.Visible = false;
            this.StartTestButton.Click += new System.EventHandler(this.StartTestButton_Click);
            // 
            // CenterStageButton
            // 
            this.CenterStageButton.Location = new System.Drawing.Point(11, 357);
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
            this.FieldSizeTextbox.Location = new System.Drawing.Point(116, 607);
            this.FieldSizeTextbox.Name = "FieldSizeTextbox";
            this.FieldSizeTextbox.Size = new System.Drawing.Size(72, 20);
            this.FieldSizeTextbox.TabIndex = 12;
            this.FieldSizeTextbox.Visible = false;
            this.FieldSizeTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // CalibrateStageButton
            // 
            this.CalibrateStageButton.Location = new System.Drawing.Point(11, 284);
            this.CalibrateStageButton.Name = "CalibrateStageButton";
            this.CalibrateStageButton.Size = new System.Drawing.Size(99, 30);
            this.CalibrateStageButton.TabIndex = 13;
            this.CalibrateStageButton.Text = "Calibrate stage";
            this.CalibrateStageButton.UseVisualStyleBackColor = true;
            this.CalibrateStageButton.Visible = false;
            this.CalibrateStageButton.Click += new System.EventHandler(this.CalibrateStageButton_Click);
            // 
            // CalibrateImageButton
            // 
            this.CalibrateImageButton.Location = new System.Drawing.Point(11, 320);
            this.CalibrateImageButton.Name = "CalibrateImageButton";
            this.CalibrateImageButton.Size = new System.Drawing.Size(99, 31);
            this.CalibrateImageButton.TabIndex = 14;
            this.CalibrateImageButton.Text = "Calibrate Image";
            this.CalibrateImageButton.UseVisualStyleBackColor = true;
            this.CalibrateImageButton.Click += new System.EventHandler(this.CalibrateImageButton_Click);
            // 
            // StageConnectButton
            // 
            this.StageConnectButton.Location = new System.Drawing.Point(12, 50);
            this.StageConnectButton.Name = "StageConnectButton";
            this.StageConnectButton.Size = new System.Drawing.Size(98, 32);
            this.StageConnectButton.TabIndex = 15;
            this.StageConnectButton.Text = "Connect Stage";
            this.StageConnectButton.UseVisualStyleBackColor = true;
            this.StageConnectButton.Click += new System.EventHandler(this.StageConnectButton_Click);
            // 
            // FieldSizeButton
            // 
            this.FieldSizeButton.Location = new System.Drawing.Point(15, 607);
            this.FieldSizeButton.Name = "FieldSizeButton";
            this.FieldSizeButton.Size = new System.Drawing.Size(85, 20);
            this.FieldSizeButton.TabIndex = 16;
            this.FieldSizeButton.Text = "Set field ratio";
            this.FieldSizeButton.UseVisualStyleBackColor = true;
            this.FieldSizeButton.Visible = false;
            // 
            // SerialSelect
            // 
            this.SerialSelect.FormattingEnabled = true;
            this.SerialSelect.Location = new System.Drawing.Point(116, 57);
            this.SerialSelect.Name = "SerialSelect";
            this.SerialSelect.Size = new System.Drawing.Size(59, 21);
            this.SerialSelect.TabIndex = 17;
            // 
            // FieldSizeRatio
            // 
            this.FieldSizeRatio.Location = new System.Drawing.Point(106, 249);
            this.FieldSizeRatio.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FieldSizeRatio.Name = "FieldSizeRatio";
            this.FieldSizeRatio.Size = new System.Drawing.Size(69, 20);
            this.FieldSizeRatio.TabIndex = 18;
            this.FieldSizeRatio.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.FieldSizeRatio.ValueChanged += new System.EventHandler(this.FieldSizeRatio_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Field size ratio %";
            // 
            // IlluminationControl
            // 
            this.IlluminationControl.Location = new System.Drawing.Point(116, 439);
            this.IlluminationControl.Name = "IlluminationControl";
            this.IlluminationControl.Size = new System.Drawing.Size(69, 20);
            this.IlluminationControl.TabIndex = 21;
            this.IlluminationControl.ValueChanged += new System.EventHandler(this.IlluminationControl_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Illumination level";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(156, 530);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(12, 13);
            this.zLabel.TabIndex = 31;
            this.zLabel.Text = "z";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(156, 501);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(12, 13);
            this.yLabel.TabIndex = 30;
            this.yLabel.Text = "y";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(156, 475);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(12, 13);
            this.xLabel.TabIndex = 29;
            this.xLabel.Text = "x";
            // 
            // zcoord
            // 
            this.zcoord.Location = new System.Drawing.Point(57, 527);
            this.zcoord.Name = "zcoord";
            this.zcoord.Size = new System.Drawing.Size(90, 20);
            this.zcoord.TabIndex = 28;
            this.zcoord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // ycoord
            // 
            this.ycoord.Location = new System.Drawing.Point(57, 501);
            this.ycoord.Name = "ycoord";
            this.ycoord.Size = new System.Drawing.Size(90, 20);
            this.ycoord.TabIndex = 27;
            this.ycoord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // xcoord
            // 
            this.xcoord.Location = new System.Drawing.Point(57, 475);
            this.xcoord.Name = "xcoord";
            this.xcoord.Size = new System.Drawing.Size(90, 20);
            this.xcoord.TabIndex = 26;
            this.xcoord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 530);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Z Coord";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 504);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Y Coord";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "X Coord";
            // 
            // MoveStageButton
            // 
            this.MoveStageButton.Location = new System.Drawing.Point(9, 564);
            this.MoveStageButton.Name = "MoveStageButton";
            this.MoveStageButton.Size = new System.Drawing.Size(60, 22);
            this.MoveStageButton.TabIndex = 32;
            this.MoveStageButton.Text = "Move ";
            this.MoveStageButton.UseVisualStyleBackColor = true;
            this.MoveStageButton.Click += new System.EventHandler(this.MoveStageButton_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 639);
            this.Controls.Add(this.MoveStageButton);
            this.Controls.Add(this.zLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.zcoord);
            this.Controls.Add(this.ycoord);
            this.Controls.Add(this.xcoord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IlluminationControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FieldSizeRatio);
            this.Controls.Add(this.SerialSelect);
            this.Controls.Add(this.FieldSizeButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.FieldSizeRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IlluminationControl)).EndInit();
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
        private System.Windows.Forms.Button FieldSizeButton;
        private System.Windows.Forms.ComboBox SerialSelect;
        private System.Windows.Forms.NumericUpDown FieldSizeRatio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown IlluminationControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox zcoord;
        private System.Windows.Forms.TextBox ycoord;
        private System.Windows.Forms.TextBox xcoord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button MoveStageButton;
    }
}

