
namespace ConcatTXT
{
    partial class Form1
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
            this.panelInput = new System.Windows.Forms.Panel();
            this.panelOutput = new System.Windows.Forms.Panel();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxFPath = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.richTextBoxOut = new System.Windows.Forms.RichTextBox();
            this.panelInput.SuspendLayout();
            this.panelOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.btnStart);
            this.panelInput.Controls.Add(this.textBoxFPath);
            this.panelInput.Controls.Add(this.labelPath);
            this.panelInput.Location = new System.Drawing.Point(3, 12);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(317, 145);
            this.panelInput.TabIndex = 0;
            // 
            // panelOutput
            // 
            this.panelOutput.Controls.Add(this.richTextBoxOut);
            this.panelOutput.Location = new System.Drawing.Point(326, 12);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(518, 406);
            this.panelOutput.TabIndex = 1;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(3, 12);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(130, 15);
            this.labelPath.TabIndex = 0;
            this.labelPath.Text = "Укажите путь к папке :";
            // 
            // textBoxFPath
            // 
            this.textBoxFPath.Location = new System.Drawing.Point(3, 30);
            this.textBoxFPath.Name = "textBoxFPath";
            this.textBoxFPath.Size = new System.Drawing.Size(311, 23);
            this.textBoxFPath.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(226, 59);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Запустить";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(207, 395);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(110, 23);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "Сбросить все";
            this.btnClearAll.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 395);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // richTextBoxOut
            // 
            this.richTextBoxOut.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxOut.Name = "richTextBoxOut";
            this.richTextBoxOut.Size = new System.Drawing.Size(512, 400);
            this.richTextBoxOut.TabIndex = 0;
            this.richTextBoxOut.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 430);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.panelOutput);
            this.Controls.Add(this.panelInput);
            this.Name = "Form1";
            this.Text = "ConcatTXT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxFPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Panel panelOutput;
        private System.Windows.Forms.RichTextBox richTextBoxOut;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnExit;
    }
}

