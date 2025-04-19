namespace PokemonGame
{
    partial class Rules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rules));
            butCloseRules = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // butCloseRules
            // 
            butCloseRules.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            butCloseRules.BackColor = Color.FromArgb(255, 128, 0);
            butCloseRules.Location = new Point(691, 335);
            butCloseRules.Name = "butCloseRules";
            butCloseRules.Size = new Size(228, 167);
            butCloseRules.TabIndex = 0;
            butCloseRules.Text = "CLOSE";
            butCloseRules.UseVisualStyleBackColor = false;
            butCloseRules.Click += butCloseRules_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(673, 500);
            textBox1.TabIndex = 1;
            textBox1.Text = resources.GetString("textBox1.Text");
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Rules
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 514);
            Controls.Add(textBox1);
            Controls.Add(butCloseRules);
            Name = "Rules";
            Text = "Rules";
            Load += Rules_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button butCloseRules;
        private TextBox textBox1;
    }
}