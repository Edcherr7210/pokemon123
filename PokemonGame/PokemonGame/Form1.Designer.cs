namespace PokemonGame
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
            butPlay = new Button();
            butQuit = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // butPlay
            // 
            butPlay.Anchor = AnchorStyles.None;
            butPlay.Location = new Point(397, 321);
            butPlay.Name = "butPlay";
            butPlay.Size = new Size(174, 107);
            butPlay.TabIndex = 0;
            butPlay.Text = "Play";
            butPlay.UseVisualStyleBackColor = true;
            butPlay.Click += butPlay_Click;
            // 
            // butQuit
            // 
            butQuit.Anchor = AnchorStyles.None;
            butQuit.Location = new Point(632, 321);
            butQuit.Name = "butQuit";
            butQuit.Size = new Size(174, 107);
            butQuit.TabIndex = 2;
            butQuit.Text = "Quit";
            butQuit.UseVisualStyleBackColor = true;
            butQuit.Click += butQuit_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Location = new Point(157, 321);
            button3.Name = "button3";
            button3.Size = new Size(174, 107);
            button3.TabIndex = 3;
            button3.Text = "Rules";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Showcard Gothic", 25.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(189, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(582, 59);
            textBox1.TabIndex = 4;
            textBox1.Text = "POKEMON BATTLE GROUNDS";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Menu_image_for_game;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(963, 536);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(butQuit);
            Controls.Add(butPlay);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button butPlay;
        private Button butQuit;
        private Button button3;
        private TextBox textBox1;
    }
}
