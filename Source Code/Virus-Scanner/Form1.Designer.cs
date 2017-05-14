namespace Virus_Scanner
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
            this.sqlScript = new System.ComponentModel.BackgroundWorker();
            this.databaseStatus = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.log_list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sqlScript
            // 
            this.sqlScript.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sqlScript_DoWork);
            this.sqlScript.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.sqlScript_ProgressChanged);
            this.sqlScript.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sqlScript_RunWorkerCompleted);
            // 
            // databaseStatus
            // 
            this.databaseStatus.AutoSize = true;
            this.databaseStatus.Location = new System.Drawing.Point(12, 9);
            this.databaseStatus.Name = "databaseStatus";
            this.databaseStatus.Size = new System.Drawing.Size(92, 13);
            this.databaseStatus.TabIndex = 0;
            this.databaseStatus.Text = "Database Status: ";
            this.databaseStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open Virus File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // log_list
            // 
            this.log_list.FormattingEnabled = true;
            this.log_list.Location = new System.Drawing.Point(15, 55);
            this.log_list.Name = "log_list";
            this.log_list.Size = new System.Drawing.Size(574, 199);
            this.log_list.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 261);
            this.Controls.Add(this.log_list);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.databaseStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker sqlScript;
        private System.Windows.Forms.Label databaseStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox log_list;
    }
}

