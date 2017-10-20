namespace PDFOptimiser
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
            this.btnOptimise = new System.Windows.Forms.Button();
            this.tboxPath = new System.Windows.Forms.TextBox();
            this.tboxFound = new System.Windows.Forms.TextBox();
            this.tboxOptimised = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOptimise
            // 
            this.btnOptimise.Location = new System.Drawing.Point(599, 175);
            this.btnOptimise.Name = "btnOptimise";
            this.btnOptimise.Size = new System.Drawing.Size(75, 23);
            this.btnOptimise.TabIndex = 0;
            this.btnOptimise.Text = "Optimise";
            this.btnOptimise.UseVisualStyleBackColor = true;
            this.btnOptimise.Click += new System.EventHandler(this.btnOptimiseParallel_Click);
            // 
            // tboxPath
            // 
            this.tboxPath.Location = new System.Drawing.Point(12, 37);
            this.tboxPath.Name = "tboxPath";
            this.tboxPath.Size = new System.Drawing.Size(662, 20);
            this.tboxPath.TabIndex = 1;
            // 
            // tboxFound
            // 
            this.tboxFound.Location = new System.Drawing.Point(169, 133);
            this.tboxFound.Name = "tboxFound";
            this.tboxFound.Size = new System.Drawing.Size(100, 20);
            this.tboxFound.TabIndex = 2;
            // 
            // tboxOptimised
            // 
            this.tboxOptimised.Location = new System.Drawing.Point(430, 133);
            this.tboxOptimised.Name = "tboxOptimised";
            this.tboxOptimised.Size = new System.Drawing.Size(100, 20);
            this.tboxOptimised.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Files found";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Files optimised";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 210);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxOptimised);
            this.Controls.Add(this.tboxFound);
            this.Controls.Add(this.tboxPath);
            this.Controls.Add(this.btnOptimise);
            this.Name = "Form1";
            this.Text = "PDF Optimiser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOptimise;
        private System.Windows.Forms.TextBox tboxPath;
        private System.Windows.Forms.TextBox tboxFound;
        private System.Windows.Forms.TextBox tboxOptimised;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

