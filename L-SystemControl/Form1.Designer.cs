
using System.Windows.Forms;

namespace L_SystemControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button simpleButtonRunLSystem;

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
            this.simpleButtonRunLSystem = new Button();
            this.SuspendLayout();
            // 
            // simpleButtonRunLSystem
            // 
            this.simpleButtonRunLSystem.Location = new System.Drawing.Point(735, 183);
            this.simpleButtonRunLSystem.Name = "simpleButtonRunLSystem";
            this.simpleButtonRunLSystem.Size = new System.Drawing.Size(28, 74);
            this.simpleButtonRunLSystem.TabIndex = 0;
            this.simpleButtonRunLSystem.Text = "simpleButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.simpleButtonRunLSystem);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

