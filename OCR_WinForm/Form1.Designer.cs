namespace OCR_WinForm
{
    partial class OCR
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
            this.btnOCR = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblImageBeforeOCR = new System.Windows.Forms.Label();
            this.pbImageBeforeOCR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageBeforeOCR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOCR
            // 
            this.btnOCR.Location = new System.Drawing.Point(7, 13);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(75, 23);
            this.btnOCR.TabIndex = 0;
            this.btnOCR.Text = "Get Image";
            this.btnOCR.UseVisualStyleBackColor = true;
            this.btnOCR.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(7, 79);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(317, 590);
            this.txtResult.TabIndex = 2;
            this.txtResult.Text = "";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(117, 49);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(55, 20);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Result";
            // 
            // lblImageBeforeOCR
            // 
            this.lblImageBeforeOCR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageBeforeOCR.AutoSize = true;
            this.lblImageBeforeOCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageBeforeOCR.Location = new System.Drawing.Point(505, 49);
            this.lblImageBeforeOCR.Name = "lblImageBeforeOCR";
            this.lblImageBeforeOCR.Size = new System.Drawing.Size(116, 20);
            this.lblImageBeforeOCR.TabIndex = 5;
            this.lblImageBeforeOCR.Text = "Image for OCR";
            // 
            // pbImageBeforeOCR
            // 
            this.pbImageBeforeOCR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImageBeforeOCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImageBeforeOCR.Location = new System.Drawing.Point(330, 79);
            this.pbImageBeforeOCR.Name = "pbImageBeforeOCR";
            this.pbImageBeforeOCR.Size = new System.Drawing.Size(449, 590);
            this.pbImageBeforeOCR.TabIndex = 3;
            this.pbImageBeforeOCR.TabStop = false;
            // 
            // OCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 681);
            this.Controls.Add(this.pbImageBeforeOCR);
            this.Controls.Add(this.lblImageBeforeOCR);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnOCR);
            this.Name = "OCR";
            this.Text = "Lets do OCR";
            ((System.ComponentModel.ISupportInitialize)(this.pbImageBeforeOCR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOCR;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblImageBeforeOCR;
        private System.Windows.Forms.PictureBox pbImageBeforeOCR;
    }
}

