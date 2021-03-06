﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            this.btnHitMe = new System.Windows.Forms.Button();
            this.label_Player2 = new System.Windows.Forms.Label();
            this.label_Player1 = new System.Windows.Forms.Label();
            this.label_Player3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.player2Status = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.currentPot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBet = new System.Windows.Forms.Button();
            this.textBox_Bet = new System.Windows.Forms.TextBox();
            this.labelBet = new System.Windows.Forms.Label();
            this.turnPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.player2Status.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turnPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Player2Panel
            // 
            this.Player2Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player2Panel.Location = new System.Drawing.Point(12, 72);
            this.Player2Panel.Name = "Player2Panel";
            this.Player2Panel.Size = new System.Drawing.Size(359, 274);
            this.Player2Panel.TabIndex = 1;
            this.Player2Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Player2Panel_Paint);
            // 
            // Player3Panel
            // 
            this.Player3Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player3Panel.Location = new System.Drawing.Point(593, 72);
            this.Player3Panel.Name = "Player3Panel";
            this.Player3Panel.Size = new System.Drawing.Size(359, 274);
            this.Player3Panel.TabIndex = 1;
            // 
            // Player1Panel
            // 
            this.Player1Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1Panel.Location = new System.Drawing.Point(318, 383);
            this.Player1Panel.Name = "Player1Panel";
            this.Player1Panel.Size = new System.Drawing.Size(321, 284);
            this.Player1Panel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_balance);
            this.panel1.Controls.Add(this.label_balance);
            this.panel1.Location = new System.Drawing.Point(669, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 48);
            this.panel1.TabIndex = 6;
            // 
            // textBox_balance
            // 
            this.textBox_balance.Enabled = false;
            this.textBox_balance.Location = new System.Drawing.Point(7, 16);
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
            this.label_balance.Click += new System.EventHandler(this.label_balance_Click);
            // 
            // btnStand
            // 
            this.btnStand.Enabled = false;
            this.btnStand.Location = new System.Drawing.Point(377, 673);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(66, 25);
            this.btnStand.TabIndex = 1;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.BtnStand_Click);
            // 
            // btnHitMe
            // 
            this.btnHitMe.Enabled = false;
            this.btnHitMe.Location = new System.Drawing.Point(318, 673);
            this.btnHitMe.Name = "btnHitMe";
            this.btnHitMe.Size = new System.Drawing.Size(53, 25);
            this.btnHitMe.TabIndex = 0;
            this.btnHitMe.Text = "Hit me!";
            this.btnHitMe.UseVisualStyleBackColor = true;
            this.btnHitMe.Click += new System.EventHandler(this.BtnHitMe_Click);
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
            this.label_Player1.Location = new System.Drawing.Point(312, 349);
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
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 28);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Playing";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(97, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 28);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Stand";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // player2Status
            // 
            this.player2Status.Controls.Add(this.radioButton1);
            this.player2Status.Controls.Add(this.radioButton2);
            this.player2Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Status.Location = new System.Drawing.Point(171, 20);
            this.player2Status.Name = "player2Status";
            this.player2Status.Size = new System.Drawing.Size(200, 49);
            this.player2Status.TabIndex = 11;
            this.player2Status.TabStop = false;
            this.player2Status.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(752, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 49);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(89, 28);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Playing";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(97, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(76, 28);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Stand";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.currentPot);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(398, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 106);
            this.panel2.TabIndex = 13;
            // 
            // currentPot
            // 
            this.currentPot.Enabled = false;
            this.currentPot.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPot.Location = new System.Drawing.Point(15, 30);
            this.currentPot.Name = "currentPot";
            this.currentPot.Size = new System.Drawing.Size(145, 40);
            this.currentPot.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current pot";
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(600, 681);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(67, 19);
            this.btnBet.TabIndex = 14;
            this.btnBet.Text = "Bet";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // textBox_Bet
            // 
            this.textBox_Bet.Location = new System.Drawing.Point(531, 680);
            this.textBox_Bet.Name = "textBox_Bet";
            this.textBox_Bet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Bet.Size = new System.Drawing.Size(63, 20);
            this.textBox_Bet.TabIndex = 15;
            // 
            // labelBet
            // 
            this.labelBet.AutoSize = true;
            this.labelBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBet.Location = new System.Drawing.Point(446, 677);
            this.labelBet.Name = "labelBet";
            this.labelBet.Size = new System.Drawing.Size(80, 20);
            this.labelBet.TabIndex = 16;
            this.labelBet.Text = "Your Bet :";
            this.labelBet.Click += new System.EventHandler(this.labelBet_Click);
            // 
            // turnPictureBox
            // 
            this.turnPictureBox.Location = new System.Drawing.Point(37, 405);
            this.turnPictureBox.Name = "turnPictureBox";
            this.turnPictureBox.Size = new System.Drawing.Size(162, 245);
            this.turnPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.turnPictureBox.TabIndex = 17;
            this.turnPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(984, 706);
            this.Controls.Add(this.turnPictureBox);
            this.Controls.Add(this.labelBet);
            this.Controls.Add(this.textBox_Bet);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.player2Status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_Player3);
            this.Controls.Add(this.btnHitMe);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.label_Player1);
            this.Controls.Add(this.label_Player2);
            this.Controls.Add(this.Player1Panel);
            this.Controls.Add(this.Player2Panel);
            this.Controls.Add(this.Player3Panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.player2Status.ResumeLayout(false);
            this.player2Status.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turnPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public void NewGame()
        {
            this.Player1Panel.Controls.Clear();
            this.Player2Panel.Controls.Clear();
            this.Player3Panel.Controls.Clear();
            this.currentPot.Text = "0";
            //this.btnHitMe.Enabled = true;
        }
        public void DisplayPlayers(CardUtils.Player actualPlayer, CardUtils.Player player2, CardUtils.Player player3, bool gameFinished = false)
        {
            if (actualPlayer != null)
            {
                this.ShowPlayerCards(actualPlayer, this.Player1Panel, this.client.Game.isPlaying(actualPlayer), null, null, gameFinished);
                this.DisplayActualPlayer(actualPlayer);
            }
            if (player2 != null)
                this.ShowPlayerCards(player2, this.Player2Panel, this.client.Game.isPlaying(player2), this.radioButton1, this.radioButton2, gameFinished);
            if (player3 != null)
                this.ShowPlayerCards(player3, this.Player3Panel, this.client.Game.isPlaying(player3), this.radioButton3, this.radioButton4, gameFinished);
        }
        public void DisplayActualPlayer(CardUtils.Player actualPlayer)
        {
            textBox_balance.Invoke((MethodInvoker)delegate {
                this.textBox_balance.Text = "" + actualPlayer.Bourse;

            });

            btnHitMe.Invoke((MethodInvoker)delegate {
                //this.btnHitMe.Enabled = this.client.Game.isPlaying(actualPlayer);

            });
            btnStand.Invoke((MethodInvoker)delegate {
                //this.btnStand.Enabled = this.client.Game.isPlaying(actualPlayer);

            });
        }
        public void DisplayGameState()
        {
            CardUtils.Game game = this.client.Game;

            float pot = game.Pot;
            bool finished = game.Finished;

            //this.currentPot.Text = "" + pot;
            currentPot.Invoke((MethodInvoker)delegate { currentPot.Text = "" + pot; });

        }

        public void ShowPlayerCards(
                CardUtils.Player player,
                Panel playerPanel,
                bool isPlaying = false,
                RadioButton playingRadio = null,
                RadioButton standingRadio = null,
                bool gameFinished = false)
        {
            List<CardUtils.Card> playerCards = player.Hand.getCards();
            int width = 65;
            int spacing = 5;
            int row = 11;
            int cardNb = 0; // when the number of cards is 4 we reset to 0 so we can start the new row
                            //            playerPanel.Controls.Clear();
            playerPanel.Invoke((MethodInvoker)delegate {
                playerPanel.Controls.Clear();
            });


            if (playingRadio != null)
                playingRadio.Invoke((MethodInvoker)delegate {
                    playingRadio.Checked = isPlaying;
                });
            if (standingRadio != null)
                standingRadio.Invoke((MethodInvoker)delegate {
                    standingRadio.Checked = !isPlaying;
                });


            for (int i = 0; i < playerCards.Count; i++)
            {
                if (i == 4) { row = 142; cardNb = 0; }
                string cardImage = playerCards[i].ImagePath();
                PictureBox aCard = new PictureBox();
                aCard.Size = new System.Drawing.Size(65, 125);
                aCard.Location = new System.Drawing.Point((cardNb * width) + spacing, row);
                aCard.SizeMode = PictureBoxSizeMode.StretchImage;
                if (!gameFinished && !(this.client.playerID == player.ID))
                {
                    cardImage = "_back";
                }
                aCard.Image = (System.Drawing.Image)global::Interface.Properties.Resources.ResourceManager.GetObject(cardImage + "");

                //called from client thread, causing error

                playerPanel.Invoke((MethodInvoker)delegate { playerPanel.Controls.Add(aCard); });


                cardNb++;

            }
        }

        private Panel Player2Panel;
        private Panel Player3Panel;
        private Panel Player1Panel;
        private Label label_Player2;
        private Button btnStand;
        private Button btnHitMe;
        private Label label_Player1;
        private Label label_Player3;
        private Panel panel1;
        private TextBox textBox_balance;
        private Label label_balance;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox player2Status;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Panel panel2;
        private TextBox currentPot;
        private Label label1; private Button btnBet;
        private TextBox textBox_Bet;
        private Label labelBet;
        private PictureBox turnPictureBox;
    }
}

