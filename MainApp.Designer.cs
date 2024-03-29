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
            this.CalibrateStageButton = new System.Windows.Forms.Button();
            this.CalibrateImageButton = new System.Windows.Forms.Button();
            this.StageConnectButton = new System.Windows.Forms.Button();
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
            this.PositionButton = new System.Windows.Forms.Button();
            this.FindGraticuleButton = new System.Windows.Forms.Button();
            this.FindUSAFButton = new System.Windows.Forms.Button();
            this.TestPositionsButton = new System.Windows.Forms.Button();
            this.SaveCalibrationButton = new System.Windows.Forms.Button();
            this.CalibrateStageCenterButton = new System.Windows.Forms.Button();
            this.GroupSelectionButton = new System.Windows.Forms.Button();
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
            this.ImageDisplay.Location = new System.Drawing.Point(209, 12);
            this.ImageDisplay.Name = "ImageDisplay";
            this.ImageDisplay.Size = new System.Drawing.Size(1049, 615);
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
            this.GetBMPValuesVer.Location = new System.Drawing.Point(57, 607);
            this.GetBMPValuesVer.Name = "GetBMPValuesVer";
            this.GetBMPValuesVer.Size = new System.Drawing.Size(58, 20);
            this.GetBMPValuesVer.TabIndex = 7;
            this.GetBMPValuesVer.Text = "Get BMP Values Vertical";
            this.GetBMPValuesVer.UseVisualStyleBackColor = true;
            this.GetBMPValuesVer.Visible = false;
            this.GetBMPValuesVer.Click += new System.EventHandler(this.GetBMPValuesVer_Click);
            // 
            // XposVert
            // 
            this.XposVert.Location = new System.Drawing.Point(113, 607);
            this.XposVert.Name = "XposVert";
            this.XposVert.Size = new System.Drawing.Size(75, 20);
            this.XposVert.TabIndex = 8;
            this.XposVert.Visible = false;
            this.XposVert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // YposVert
            // 
            this.YposVert.Location = new System.Drawing.Point(128, 607);
            this.YposVert.Name = "YposVert";
            this.YposVert.Size = new System.Drawing.Size(75, 20);
            this.YposVert.TabIndex = 9;
            this.YposVert.Visible = false;
            this.YposVert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberCheck);
            // 
            // StartTestButton
            // 
            this.StartTestButton.Enabled = false;
            this.StartTestButton.Location = new System.Drawing.Point(5, 403);
            this.StartTestButton.Name = "StartTestButton";
            this.StartTestButton.Size = new System.Drawing.Size(89, 26);
            this.StartTestButton.TabIndex = 10;
            this.StartTestButton.Text = "Start Test";
            this.StartTestButton.UseVisualStyleBackColor = true;
            this.StartTestButton.Click += new System.EventHandler(this.StartTestButton_Click);
            // 
            // CenterStageButton
            // 
            this.CenterStageButton.Enabled = false;
            this.CenterStageButton.Location = new System.Drawing.Point(5, 289);
            this.CenterStageButton.Name = "CenterStageButton";
            this.CenterStageButton.Size = new System.Drawing.Size(95, 41);
            this.CenterStageButton.TabIndex = 11;
            this.CenterStageButton.Text = "Center stage";
            this.CenterStageButton.UseVisualStyleBackColor = true;
            this.CenterStageButton.Click += new System.EventHandler(this.CenterStageButton_Click);
            // 
            // CalibrateStageButton
            // 
            this.CalibrateStageButton.Enabled = false;
            this.CalibrateStageButton.Location = new System.Drawing.Point(5, 191);
            this.CalibrateStageButton.Name = "CalibrateStageButton";
            this.CalibrateStageButton.Size = new System.Drawing.Size(95, 44);
            this.CalibrateStageButton.TabIndex = 13;
            this.CalibrateStageButton.Text = "Calibrate stage";
            this.CalibrateStageButton.UseVisualStyleBackColor = true;
            this.CalibrateStageButton.Click += new System.EventHandler(this.CalibrateStageButton_Click);
            // 
            // CalibrateImageButton
            // 
            this.CalibrateImageButton.Enabled = false;
            this.CalibrateImageButton.Location = new System.Drawing.Point(5, 241);
            this.CalibrateImageButton.Name = "CalibrateImageButton";
            this.CalibrateImageButton.Size = new System.Drawing.Size(95, 42);
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
            this.FieldSizeRatio.Location = new System.Drawing.Point(102, 150);
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
            this.label1.Location = new System.Drawing.Point(12, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Field size ratio %";
            // 
            // IlluminationControl
            // 
            this.IlluminationControl.Location = new System.Drawing.Point(106, 439);
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
            // PositionButton
            // 
            this.PositionButton.Location = new System.Drawing.Point(75, 564);
            this.PositionButton.Name = "PositionButton";
            this.PositionButton.Size = new System.Drawing.Size(67, 22);
            this.PositionButton.TabIndex = 33;
            this.PositionButton.Text = "Position";
            this.PositionButton.UseVisualStyleBackColor = true;
            this.PositionButton.Click += new System.EventHandler(this.PositionButton_Click);
            // 
            // FindGraticuleButton
            // 
            this.FindGraticuleButton.Location = new System.Drawing.Point(89, 608);
            this.FindGraticuleButton.Name = "FindGraticuleButton";
            this.FindGraticuleButton.Size = new System.Drawing.Size(58, 19);
            this.FindGraticuleButton.TabIndex = 34;
            this.FindGraticuleButton.Text = "Find Graticule";
            this.FindGraticuleButton.UseVisualStyleBackColor = true;
            this.FindGraticuleButton.Visible = false;
            this.FindGraticuleButton.Click += new System.EventHandler(this.FindGraticuleButton_Click);
            // 
            // FindUSAFButton
            // 
            this.FindUSAFButton.Location = new System.Drawing.Point(121, 12);
            this.FindUSAFButton.Name = "FindUSAFButton";
            this.FindUSAFButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FindUSAFButton.Size = new System.Drawing.Size(67, 31);
            this.FindUSAFButton.TabIndex = 35;
            this.FindUSAFButton.Text = "Find USAF";
            this.FindUSAFButton.UseVisualStyleBackColor = true;
            this.FindUSAFButton.Click += new System.EventHandler(this.FindUSAFButton_Click);
            // 
            // TestPositionsButton
            // 
            this.TestPositionsButton.Enabled = false;
            this.TestPositionsButton.Location = new System.Drawing.Point(106, 241);
            this.TestPositionsButton.Name = "TestPositionsButton";
            this.TestPositionsButton.Size = new System.Drawing.Size(89, 42);
            this.TestPositionsButton.TabIndex = 37;
            this.TestPositionsButton.Text = "Test Positions";
            this.TestPositionsButton.UseVisualStyleBackColor = true;
            this.TestPositionsButton.Click += new System.EventHandler(this.TestPositionsButton_Click);
            // 
            // SaveCalibrationButton
            // 
            this.SaveCalibrationButton.Enabled = false;
            this.SaveCalibrationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.SaveCalibrationButton.Location = new System.Drawing.Point(106, 289);
            this.SaveCalibrationButton.Name = "SaveCalibrationButton";
            this.SaveCalibrationButton.Size = new System.Drawing.Size(89, 41);
            this.SaveCalibrationButton.TabIndex = 38;
            this.SaveCalibrationButton.Text = "Save Calib";
            this.SaveCalibrationButton.UseVisualStyleBackColor = true;
            this.SaveCalibrationButton.Click += new System.EventHandler(this.SaveCalibrationButton_Click);
            // 
            // CalibrateStageCenterButton
            // 
            this.CalibrateStageCenterButton.Enabled = false;
            this.CalibrateStageCenterButton.Location = new System.Drawing.Point(106, 191);
            this.CalibrateStageCenterButton.Name = "CalibrateStageCenterButton";
            this.CalibrateStageCenterButton.Size = new System.Drawing.Size(89, 44);
            this.CalibrateStageCenterButton.TabIndex = 39;
            this.CalibrateStageCenterButton.Text = "Calibrate stage center";
            this.CalibrateStageCenterButton.UseVisualStyleBackColor = true;
            this.CalibrateStageCenterButton.Click += new System.EventHandler(this.CalibrateStageCenterButton_Click);
            // 
            // GroupSelectionButton
            // 
            this.GroupSelectionButton.Enabled = false;
            this.GroupSelectionButton.Location = new System.Drawing.Point(100, 388);
            this.GroupSelectionButton.Name = "GroupSelectionButton";
            this.GroupSelectionButton.Size = new System.Drawing.Size(88, 41);
            this.GroupSelectionButton.TabIndex = 40;
            this.GroupSelectionButton.Text = "Group selection";
            this.GroupSelectionButton.UseVisualStyleBackColor = true;
            this.GroupSelectionButton.Click += new System.EventHandler(this.GroupSelectionButton_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 639);
            this.Controls.Add(this.GroupSelectionButton);
            this.Controls.Add(this.CalibrateStageCenterButton);
            this.Controls.Add(this.SaveCalibrationButton);
            this.Controls.Add(this.TestPositionsButton);
            this.Controls.Add(this.FindUSAFButton);
            this.Controls.Add(this.FindGraticuleButton);
            this.Controls.Add(this.PositionButton);
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
            this.Controls.Add(this.StageConnectButton);
            this.Controls.Add(this.CalibrateImageButton);
            this.Controls.Add(this.CalibrateStageButton);
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
            this.Text = "Main";
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
        private System.Windows.Forms.Button CalibrateStageButton;
        private System.Windows.Forms.Button CalibrateImageButton;
        private System.Windows.Forms.Button StageConnectButton;
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
        private System.Windows.Forms.Button PositionButton;
        private System.Windows.Forms.Button FindGraticuleButton;
        private System.Windows.Forms.Button FindUSAFButton;
        private System.Windows.Forms.Button TestPositionsButton;
        private System.Windows.Forms.Button SaveCalibrationButton;
        private System.Windows.Forms.Button CalibrateStageCenterButton;
        private System.Windows.Forms.Button GroupSelectionButton;
    }
}

