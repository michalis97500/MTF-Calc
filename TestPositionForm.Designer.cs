namespace MTF_Calc
{
    partial class TestPositionForm
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
            this.CenterCheckBox = new System.Windows.Forms.CheckBox();
            this.LECheckbox = new System.Windows.Forms.CheckBox();
            this.LTCCheckbox = new System.Windows.Forms.CheckBox();
            this.LBCCheckBox = new System.Windows.Forms.CheckBox();
            this.RECheckBox = new System.Windows.Forms.CheckBox();
            this.RBCCheckBox = new System.Windows.Forms.CheckBox();
            this.RTCCheckBox = new System.Windows.Forms.CheckBox();
            this.UECheckBox = new System.Windows.Forms.CheckBox();
            this.BECheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CenterCheckBox
            // 
            this.CenterCheckBox.AutoSize = true;
            this.CenterCheckBox.Location = new System.Drawing.Point(27, 12);
            this.CenterCheckBox.Name = "CenterCheckBox";
            this.CenterCheckBox.Size = new System.Drawing.Size(57, 17);
            this.CenterCheckBox.TabIndex = 9;
            this.CenterCheckBox.Text = "Center";
            this.CenterCheckBox.UseVisualStyleBackColor = true;
            // 
            // LECheckbox
            // 
            this.LECheckbox.AutoSize = true;
            this.LECheckbox.Location = new System.Drawing.Point(27, 173);
            this.LECheckbox.Name = "LECheckbox";
            this.LECheckbox.Size = new System.Drawing.Size(71, 17);
            this.LECheckbox.TabIndex = 10;
            this.LECheckbox.Text = "Left edge";
            this.LECheckbox.UseVisualStyleBackColor = true;
            // 
            // LTCCheckbox
            // 
            this.LTCCheckbox.AutoSize = true;
            this.LTCCheckbox.Location = new System.Drawing.Point(27, 35);
            this.LTCCheckbox.Name = "LTCCheckbox";
            this.LTCCheckbox.Size = new System.Drawing.Size(95, 17);
            this.LTCCheckbox.TabIndex = 11;
            this.LTCCheckbox.Text = "Left top corner";
            this.LTCCheckbox.UseVisualStyleBackColor = true;
            // 
            // LBCCheckBox
            // 
            this.LBCCheckBox.AutoSize = true;
            this.LBCCheckBox.Location = new System.Drawing.Point(27, 58);
            this.LBCCheckBox.Name = "LBCCheckBox";
            this.LBCCheckBox.Size = new System.Drawing.Size(112, 17);
            this.LBCCheckBox.TabIndex = 12;
            this.LBCCheckBox.Text = "Left bottom corner";
            this.LBCCheckBox.UseVisualStyleBackColor = true;
            // 
            // RECheckBox
            // 
            this.RECheckBox.AutoSize = true;
            this.RECheckBox.Location = new System.Drawing.Point(27, 196);
            this.RECheckBox.Name = "RECheckBox";
            this.RECheckBox.Size = new System.Drawing.Size(78, 17);
            this.RECheckBox.TabIndex = 13;
            this.RECheckBox.Text = "Right edge";
            this.RECheckBox.UseVisualStyleBackColor = true;
            // 
            // RBCCheckBox
            // 
            this.RBCCheckBox.AutoSize = true;
            this.RBCCheckBox.Location = new System.Drawing.Point(27, 81);
            this.RBCCheckBox.Name = "RBCCheckBox";
            this.RBCCheckBox.Size = new System.Drawing.Size(119, 17);
            this.RBCCheckBox.TabIndex = 14;
            this.RBCCheckBox.Text = "Right bottom corner";
            this.RBCCheckBox.UseVisualStyleBackColor = true;
            // 
            // RTCCheckBox
            // 
            this.RTCCheckBox.AutoSize = true;
            this.RTCCheckBox.Location = new System.Drawing.Point(27, 104);
            this.RTCCheckBox.Name = "RTCCheckBox";
            this.RTCCheckBox.Size = new System.Drawing.Size(106, 17);
            this.RTCCheckBox.TabIndex = 15;
            this.RTCCheckBox.Text = "Right Top corner";
            this.RTCCheckBox.UseVisualStyleBackColor = true;
            // 
            // UECheckBox
            // 
            this.UECheckBox.AutoSize = true;
            this.UECheckBox.Location = new System.Drawing.Point(27, 127);
            this.UECheckBox.Name = "UECheckBox";
            this.UECheckBox.Size = new System.Drawing.Size(83, 17);
            this.UECheckBox.TabIndex = 16;
            this.UECheckBox.Text = "Upper Edge";
            this.UECheckBox.UseVisualStyleBackColor = true;
            // 
            // BECheckBox
            // 
            this.BECheckBox.AutoSize = true;
            this.BECheckBox.Location = new System.Drawing.Point(27, 150);
            this.BECheckBox.Name = "BECheckBox";
            this.BECheckBox.Size = new System.Drawing.Size(87, 17);
            this.BECheckBox.TabIndex = 17;
            this.BECheckBox.Text = "Bottom Edge";
            this.BECheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 37);
            this.button1.TabIndex = 18;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 285);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BECheckBox);
            this.Controls.Add(this.UECheckBox);
            this.Controls.Add(this.RTCCheckBox);
            this.Controls.Add(this.RBCCheckBox);
            this.Controls.Add(this.RECheckBox);
            this.Controls.Add(this.LBCCheckBox);
            this.Controls.Add(this.LTCCheckbox);
            this.Controls.Add(this.LECheckbox);
            this.Controls.Add(this.CenterCheckBox);
            this.Name = "TestPositionForm";
            this.Text = "TestPositionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox CenterCheckBox;
        private System.Windows.Forms.CheckBox LECheckbox;
        private System.Windows.Forms.CheckBox LTCCheckbox;
        private System.Windows.Forms.CheckBox LBCCheckBox;
        private System.Windows.Forms.CheckBox RECheckBox;
        private System.Windows.Forms.CheckBox RBCCheckBox;
        private System.Windows.Forms.CheckBox RTCCheckBox;
        private System.Windows.Forms.CheckBox UECheckBox;
        private System.Windows.Forms.CheckBox BECheckBox;
        private System.Windows.Forms.Button button1;
    }
}