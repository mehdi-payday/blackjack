namespace Interface
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
            this.Player2Panel = new System.Windows.Forms.Panel();
            this.Player3Panel = new System.Windows.Forms.Panel();
            this.Player1Panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_balance = new System.Windows.Forms.TextBox();
            this.label_balance = new System.Windows.Forms.Label();
            this.btnStand = new System.Windows.Forms.Button();
            this.btmHitMe = new System.Windows.Forms.Button();
            this.label_Player2 = new System.Windows.Forms.Label();
            this.label_Player1 = new System.Windows.Forms.Label();
            this.label_Player3 = new System.Windows.Forms.Label();
            this.Player1Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Player2Panel
            // 
            this.Player2Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player2Panel.Location = new System.Drawing.Point(12, 72);
            this.Player2Panel.Name = "Player2Panel";
            this.Player2Panel.Size = new System.Drawing.Size(359, 286);
            this.Player2Panel.TabIndex = 1;
            // 
            // Player3Panel
            // 
            this.Player3Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player3Panel.Location = new System.Drawing.Point(593, 72);
            this.Player3Panel.Name = "Player3Panel";
            this.Player3Panel.Size = new System.Drawing.Size(359, 286);
            this.Player3Panel.TabIndex = 1;
            // 
            // Player1Panel
            // 
            this.Player1Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1Panel.Controls.Add(this.panel1);
            this.Player1Panel.Controls.Add(this.btnStand);
            this.Player1Panel.Controls.Add(this.btmHitMe);
            this.Player1Panel.Location = new System.Drawing.Point(304, 417);
            this.Player1Panel.Name = "Player1Panel";
            this.Player1Panel.Size = new System.Drawing.Size(359, 286);
            this.Player1Panel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_balance);
            this.panel1.Controls.Add(this.label_balance);
            this.panel1.Location = new System.Drawing.Point(286, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 48);
            this.panel1.TabIndex = 6;
            // 
            // textBox_balance
            // 
            this.textBox_balance.Enabled = false;
            this.textBox_balance.Location = new System.Drawing.Point(7, 21);
            this.textBox_balance.Name = "textBox_balance";
            this.textBox_balance.Size = new System.Drawing.Size(60, 20);
            this.textBox_balance.TabIndex = 1;
            // 
            // label_balance
            // 
            this.label_balance.AutoSize = true;
            this.label_balance.Location = new System.Drawing.Point(0, 0);
            this.label_balance.Name = "label_balance";
            this.label_balance.Size = new System.Drawing.Size(49, 13);
            this.label_balance.TabIndex = 0;
            this.label_balance.Text = "Balance:";
            // 
            // btnStand
            // 
            this.btnStand.Location = new System.Drawing.Point(84, 246);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(66, 30);
            this.btnStand.TabIndex = 1;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // btmHitMe
            // 
            this.btmHitMe.Location = new System.Drawing.Point(12, 246);
            this.btmHitMe.Name = "btmHitMe";
            this.btmHitMe.Size = new System.Drawing.Size(66, 30);
            this.btmHitMe.TabIndex = 0;
            this.btmHitMe.Text = "Hit me!";
            this.btmHitMe.UseVisualStyleBackColor = true;
            this.btmHitMe.Click += new System.EventHandler(this.btmHitMe_Click);
            // 
            // label_Player2
            // 
            this.label_Player2.AutoSize = true;
            this.label_Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player2.Location = new System.Drawing.Point(6, 38);
            this.label_Player2.Name = "label_Player2";
            this.label_Player2.Size = new System.Drawing.Size(121, 31);
            this.label_Player2.TabIndex = 3;
            this.label_Player2.Text = "Player 2";
            // 
            // label_Player1
            // 
            this.label_Player1.AutoSize = true;
            this.label_Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player1.Location = new System.Drawing.Point(298, 383);
            this.label_Player1.Name = "label_Player1";
            this.label_Player1.Size = new System.Drawing.Size(65, 31);
            this.label_Player1.TabIndex = 4;
            this.label_Player1.Text = "You";
            // 
            // label_Player3
            // 
            this.label_Player3.AutoSize = true;
            this.label_Player3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Player3.Location = new System.Drawing.Point(587, 38);
            this.label_Player3.Name = "label_Player3";
            this.label_Player3.Size = new System.Drawing.Size(121, 31);
            this.label_Player3.TabIndex = 5;
            this.label_Player3.Text = "Player 3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(964, 728);
            this.Controls.Add(this.label_Player3);
            this.Controls.Add(this.label_Player1);
            this.Controls.Add(this.label_Player2);
            this.Controls.Add(this.Player1Panel);
            this.Controls.Add(this.Player3Panel);
            this.Controls.Add(this.Player2Panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Player1Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private void AddCardsPlayer1(CardUtils.Deck hand ) {
            //TODO need to use the Deck received in order to display the cards
        }
        private void showPlayer2Cards(CardUtils.Deck hand)
        {
            //TODO need to use the Deck received in order to display the cards
        }
        private void showPlayer3Cards(CardUtils.Deck hand)
        {
            //TODO need to use the Deck received in order to display the cards
        }
        private void AddCardsPlayer2(int nbOfCards)
        {
            this.Player2Cards = new System.Windows.Forms.PictureBox[nbOfCards];
            int width = 65;
            int spacing = 5;
            int cardNb = 0; // when the number of cards is 4 we reset to 0 so we can start the new row
            // first row starts at 11 and second one at 142
            int row = 11;
            this.Player2Panel.Controls.Clear();
            for (int i = 0; i < nbOfCards; ++i)
            {
                if (i == 4) { row = 142; cardNb = 0; }
                System.Windows.Forms.PictureBox aCard = new System.Windows.Forms.PictureBox();
                aCard.Size = new System.Drawing.Size(65, 125);
                aCard.Location = new System.Drawing.Point((cardNb * width) + spacing, row);
                aCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                aCard.Image = global::Interface.Properties.Resources.back;
                this.Player2Panel.Controls.Add(aCard);
                cardNb++;
            }
        }
        private void AddCardsPlayer3(int nbOfCards)
        {
            this.Player3Cards = new System.Windows.Forms.PictureBox[nbOfCards];
            int width = 65;
            int spacing = 5;
            int cardNb = 0; // when the number of cards is 4 we reset to 0 so we can start the new row
            // first row starts at 11 and second one at 142
            int row = 11;
            this.Player3Panel.Controls.Clear();
            for (int i = 0; i < nbOfCards; ++i)
            {
                if (i == 4) { row = 142; cardNb = 0; }
                System.Windows.Forms.PictureBox aCard = new System.Windows.Forms.PictureBox();
                aCard.Size = new System.Drawing.Size(65, 125);
                aCard.Location = new System.Drawing.Point((cardNb * width) + spacing, row);
                aCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                aCard.Image = global::Interface.Properties.Resources.back;
                this.Player3Panel.Controls.Add(aCard);
                cardNb++;
            }
        }
        private System.Windows.Forms.Panel Player2Panel;
        private System.Windows.Forms.Panel Player3Panel;
        private System.Windows.Forms.Panel Player1Panel;
        private System.Windows.Forms.Label label_Player2;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btmHitMe;
        private System.Windows.Forms.Label label_Player1;
        private System.Windows.Forms.Label label_Player3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_balance;
        private System.Windows.Forms.Label label_balance;
        private System.Windows.Forms.PictureBox [] Player1Cards;
        private System.Windows.Forms.PictureBox [] Player2Cards;
        private System.Windows.Forms.PictureBox [] Player3Cards;
    }
}

