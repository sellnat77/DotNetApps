﻿namespace WinFormEvents
{
    partial class bankAccntWindow
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
            this.overDraftCntnr = new System.Windows.Forms.GroupBox();
            this.overDraftDebit = new System.Windows.Forms.Button();
            this.overDraftCredit = new System.Windows.Forms.Button();
            this.overDraftAmountValue = new System.Windows.Forms.TextBox();
            this.overDraftBalValue = new System.Windows.Forms.TextBox();
            this.overDraftAmount = new System.Windows.Forms.Label();
            this.overDraftBal = new System.Windows.Forms.Label();
            this.savCntnr = new System.Windows.Forms.GroupBox();
            this.savDebit = new System.Windows.Forms.Button();
            this.savCredit = new System.Windows.Forms.Button();
            this.savBalance = new System.Windows.Forms.Label();
            this.savAmountValue = new System.Windows.Forms.TextBox();
            this.savAmount = new System.Windows.Forms.Label();
            this.savBalValue = new System.Windows.Forms.TextBox();
            this.overDraftCntnr.SuspendLayout();
            this.savCntnr.SuspendLayout();
            this.SuspendLayout();
            // 
            // overDraftCntnr
            // 
            this.overDraftCntnr.Controls.Add(this.overDraftDebit);
            this.overDraftCntnr.Controls.Add(this.overDraftCredit);
            this.overDraftCntnr.Controls.Add(this.overDraftAmountValue);
            this.overDraftCntnr.Controls.Add(this.overDraftBalValue);
            this.overDraftCntnr.Controls.Add(this.overDraftAmount);
            this.overDraftCntnr.Controls.Add(this.overDraftBal);
            this.overDraftCntnr.Location = new System.Drawing.Point(12, 12);
            this.overDraftCntnr.Name = "overDraftCntnr";
            this.overDraftCntnr.Size = new System.Drawing.Size(506, 213);
            this.overDraftCntnr.TabIndex = 0;
            this.overDraftCntnr.TabStop = false;
            this.overDraftCntnr.Text = "Overdraft";
            // 
            // overDraftDebit
            // 
            this.overDraftDebit.Location = new System.Drawing.Point(327, 143);
            this.overDraftDebit.Name = "overDraftDebit";
            this.overDraftDebit.Size = new System.Drawing.Size(75, 23);
            this.overDraftDebit.TabIndex = 5;
            this.overDraftDebit.Text = "Debit";
            this.overDraftDebit.UseVisualStyleBackColor = true;
            this.overDraftDebit.Click += new System.EventHandler(this.overdraftDebitButton_Click);
            // 
            // overDraftCredit
            // 
            this.overDraftCredit.Location = new System.Drawing.Point(327, 114);
            this.overDraftCredit.Name = "overDraftCredit";
            this.overDraftCredit.Size = new System.Drawing.Size(75, 23);
            this.overDraftCredit.TabIndex = 4;
            this.overDraftCredit.Text = "Credit";
            this.overDraftCredit.UseVisualStyleBackColor = true;
            this.overDraftCredit.Click += new System.EventHandler(this.overdraftCreditButton_Click);
            // 
            // overDraftAmountValue
            // 
            this.overDraftAmountValue.Location = new System.Drawing.Point(176, 122);
            this.overDraftAmountValue.Name = "overDraftAmountValue";
            this.overDraftAmountValue.Size = new System.Drawing.Size(100, 20);
            this.overDraftAmountValue.TabIndex = 3;
            // 
            // overDraftBalValue
            // 
            this.overDraftBalValue.Location = new System.Drawing.Point(176, 67);
            this.overDraftBalValue.Name = "overDraftBalValue";
            this.overDraftBalValue.ReadOnly = true;
            this.overDraftBalValue.Size = new System.Drawing.Size(100, 20);
            this.overDraftBalValue.TabIndex = 2;
            // 
            // overDraftAmount
            // 
            this.overDraftAmount.AutoSize = true;
            this.overDraftAmount.Location = new System.Drawing.Point(54, 129);
            this.overDraftAmount.Name = "overDraftAmount";
            this.overDraftAmount.Size = new System.Drawing.Size(43, 13);
            this.overDraftAmount.TabIndex = 1;
            this.overDraftAmount.Text = "Amount";
            // 
            // overDraftBal
            // 
            this.overDraftBal.AutoSize = true;
            this.overDraftBal.Location = new System.Drawing.Point(51, 67);
            this.overDraftBal.Name = "overDraftBal";
            this.overDraftBal.Size = new System.Drawing.Size(46, 13);
            this.overDraftBal.TabIndex = 0;
            this.overDraftBal.Text = "Balance";
            // 
            // savCntnr
            // 
            this.savCntnr.Controls.Add(this.savDebit);
            this.savCntnr.Controls.Add(this.savCredit);
            this.savCntnr.Controls.Add(this.savBalance);
            this.savCntnr.Controls.Add(this.savAmountValue);
            this.savCntnr.Controls.Add(this.savAmount);
            this.savCntnr.Controls.Add(this.savBalValue);
            this.savCntnr.Location = new System.Drawing.Point(12, 231);
            this.savCntnr.Name = "savCntnr";
            this.savCntnr.Size = new System.Drawing.Size(506, 202);
            this.savCntnr.TabIndex = 1;
            this.savCntnr.TabStop = false;
            this.savCntnr.Text = "Savings";
            // 
            // savDebit
            // 
            this.savDebit.Location = new System.Drawing.Point(327, 150);
            this.savDebit.Name = "savDebit";
            this.savDebit.Size = new System.Drawing.Size(75, 23);
            this.savDebit.TabIndex = 11;
            this.savDebit.Text = "Debit";
            this.savDebit.UseVisualStyleBackColor = true;
            this.savDebit.Click += new System.EventHandler(this.savingsDebitButton_Click);
            // 
            // savCredit
            // 
            this.savCredit.Location = new System.Drawing.Point(327, 121);
            this.savCredit.Name = "savCredit";
            this.savCredit.Size = new System.Drawing.Size(75, 23);
            this.savCredit.TabIndex = 10;
            this.savCredit.Text = "Credit";
            this.savCredit.UseVisualStyleBackColor = true;
            this.savCredit.Click += new System.EventHandler(this.savingsCreditButton_Click);
            // 
            // savBalance
            // 
            this.savBalance.AutoSize = true;
            this.savBalance.Location = new System.Drawing.Point(51, 72);
            this.savBalance.Name = "savBalance";
            this.savBalance.Size = new System.Drawing.Size(46, 13);
            this.savBalance.TabIndex = 6;
            this.savBalance.Text = "Balance";
            // 
            // savAmountValue
            // 
            this.savAmountValue.Location = new System.Drawing.Point(176, 127);
            this.savAmountValue.Name = "savAmountValue";
            this.savAmountValue.Size = new System.Drawing.Size(100, 20);
            this.savAmountValue.TabIndex = 9;
            // 
            // savAmount
            // 
            this.savAmount.AutoSize = true;
            this.savAmount.Location = new System.Drawing.Point(54, 134);
            this.savAmount.Name = "savAmount";
            this.savAmount.Size = new System.Drawing.Size(43, 13);
            this.savAmount.TabIndex = 7;
            this.savAmount.Text = "Amount";
            // 
            // savBalValue
            // 
            this.savBalValue.Location = new System.Drawing.Point(176, 72);
            this.savBalValue.Name = "savBalValue";
            this.savBalValue.ReadOnly = true;
            this.savBalValue.Size = new System.Drawing.Size(100, 20);
            this.savBalValue.TabIndex = 8;
            // 
            // bankAccntWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 445);
            this.Controls.Add(this.savCntnr);
            this.Controls.Add(this.overDraftCntnr);
            this.Name = "bankAccntWindow";
            this.Text = "Banking Application";
            this.Load += new System.EventHandler(this.bankAccntWindow_Load);
            this.overDraftCntnr.ResumeLayout(false);
            this.overDraftCntnr.PerformLayout();
            this.savCntnr.ResumeLayout(false);
            this.savCntnr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox overDraftCntnr;
        private System.Windows.Forms.GroupBox savCntnr;
        private System.Windows.Forms.Button overDraftDebit;
        private System.Windows.Forms.Button overDraftCredit;
        private System.Windows.Forms.TextBox overDraftAmountValue;
        private System.Windows.Forms.TextBox overDraftBalValue;
        private System.Windows.Forms.Label overDraftAmount;
        private System.Windows.Forms.Label overDraftBal;
        private System.Windows.Forms.Button savDebit;
        private System.Windows.Forms.Button savCredit;
        private System.Windows.Forms.Label savBalance;
        private System.Windows.Forms.TextBox savAmountValue;
        private System.Windows.Forms.Label savAmount;
        private System.Windows.Forms.TextBox savBalValue;
    }
}