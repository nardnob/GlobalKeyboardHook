namespace GlobalKeyboardHook
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblClickCount = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRestartListeners = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKeyCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click count:";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // lblClickCount
            // 
            this.lblClickCount.AutoSize = true;
            this.lblClickCount.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, System.Drawing.FontStyle.Italic);
            this.lblClickCount.ForeColor = System.Drawing.Color.Red;
            this.lblClickCount.Location = new System.Drawing.Point(174, 12);
            this.lblClickCount.Name = "lblClickCount";
            this.lblClickCount.Size = new System.Drawing.Size(34, 43);
            this.lblClickCount.TabIndex = 1;
            this.lblClickCount.Text = "0";
            this.lblClickCount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(292, 120);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveImage.TabIndex = 2;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Fuchsia;
            this.label3.Location = new System.Drawing.Point(103, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "ALT+1 to hide/show form";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            // 
            // btnRestartListeners
            // 
            this.btnRestartListeners.Location = new System.Drawing.Point(12, 101);
            this.btnRestartListeners.Name = "btnRestartListeners";
            this.btnRestartListeners.Size = new System.Drawing.Size(273, 42);
            this.btnRestartListeners.TabIndex = 4;
            this.btnRestartListeners.Text = "Restart Listeners";
            this.btnRestartListeners.UseVisualStyleBackColor = true;
            this.btnRestartListeners.Click += new System.EventHandler(this.btnRestartListeners_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(75, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Key count:";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown_1);
            // 
            // lblKeyCount
            // 
            this.lblKeyCount.AutoSize = true;
            this.lblKeyCount.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyCount.ForeColor = System.Drawing.Color.Red;
            this.lblKeyCount.Location = new System.Drawing.Point(169, 54);
            this.lblKeyCount.Name = "lblKeyCount";
            this.lblKeyCount.Size = new System.Drawing.Size(18, 22);
            this.lblKeyCount.TabIndex = 6;
            this.lblKeyCount.Text = "0";
            this.lblKeyCount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblKeyCount_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(379, 155);
            this.Controls.Add(this.lblKeyCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRestartListeners);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.lblClickCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clicker Counter";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClickCount;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRestartListeners;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKeyCount;
    }
}

