namespace proyecto_final
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbusu = new System.Windows.Forms.TextBox();
            this.tbpsw = new System.Windows.Forms.TextBox();
            this.BTN_LOG = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(224, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(160, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "USUARIO";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(160, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "CONTRASEÑA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbusu
            // 
            this.tbusu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbusu.Location = new System.Drawing.Point(281, 118);
            this.tbusu.Name = "tbusu";
            this.tbusu.Size = new System.Drawing.Size(136, 26);
            this.tbusu.TabIndex = 3;
            // 
            // tbpsw
            // 
            this.tbpsw.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbpsw.Location = new System.Drawing.Point(281, 152);
            this.tbpsw.Name = "tbpsw";
            this.tbpsw.Size = new System.Drawing.Size(136, 26);
            this.tbpsw.TabIndex = 4;
            // 
            // BTN_LOG
            // 
            this.BTN_LOG.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BTN_LOG.Location = new System.Drawing.Point(146, 221);
            this.BTN_LOG.Name = "BTN_LOG";
            this.BTN_LOG.Size = new System.Drawing.Size(142, 28);
            this.BTN_LOG.TabIndex = 5;
            this.BTN_LOG.Text = "INICIAR";
            this.BTN_LOG.UseVisualStyleBackColor = true;
            this.BTN_LOG.Click += new System.EventHandler(this.BTN_LOG_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(303, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "CREAR CUENTA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 349);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTN_LOG);
            this.Controls.Add(this.tbpsw);
            this.Controls.Add(this.tbusu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbusu;
        private TextBox tbpsw;
        private Button BTN_LOG;
        private Button button1;
    }
}