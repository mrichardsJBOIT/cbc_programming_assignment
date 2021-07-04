
namespace Display
{
    partial class Result
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HexInputText = new System.Windows.Forms.TextBox();
            this.HexConvertionResult = new System.Windows.Forms.Label();
            this.ConvertHexButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HexInputText
            // 
            this.HexInputText.AcceptsReturn = true;
            this.HexInputText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HexInputText.Location = new System.Drawing.Point(73, 34);
            this.HexInputText.Name = "HexInputText";
            this.HexInputText.Size = new System.Drawing.Size(509, 27);
            this.HexInputText.TabIndex = 0;
            this.HexInputText.Text = "Please enter hex value";
            // 
            // HexConvertionResult
            // 
            this.HexConvertionResult.AutoSize = true;
            this.HexConvertionResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HexConvertionResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HexConvertionResult.Location = new System.Drawing.Point(426, 97);
            this.HexConvertionResult.Name = "HexConvertionResult";
            this.HexConvertionResult.Size = new System.Drawing.Size(158, 22);
            this.HexConvertionResult.TabIndex = 1;
            this.HexConvertionResult.Text = "Hex conversion results";
            // 
            // ConvertHexButton
            // 
            this.ConvertHexButton.Location = new System.Drawing.Point(618, 31);
            this.ConvertHexButton.Name = "ConvertHexButton";
            this.ConvertHexButton.Size = new System.Drawing.Size(94, 29);
            this.ConvertHexButton.TabIndex = 2;
            this.ConvertHexButton.Text = "Convert";
            this.ConvertHexButton.UseVisualStyleBackColor = true;
            this.ConvertHexButton.Click += new System.EventHandler(this.ConvertHexButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hex conversion results:";
            // 
            // Result
            // 
            this.AcceptButton = this.ConvertHexButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 378);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConvertHexButton);
            this.Controls.Add(this.HexConvertionResult);
            this.Controls.Add(this.HexInputText);
            this.Name = "Result";
            this.Text = "Hex Converter";
            this.Load += new System.EventHandler(this.Result_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HexInputText;
        private System.Windows.Forms.Label HexConvertionResult;
        private System.Windows.Forms.Button ConvertHexButton;
        private System.Windows.Forms.Label label1;
    }
}

