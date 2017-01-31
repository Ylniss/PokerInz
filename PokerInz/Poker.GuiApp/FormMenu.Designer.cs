namespace Poker.GuiApp
{
    partial class FormMenu
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelCash = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelSmallBlind = new System.Windows.Forms.Label();
            this.numericUpDownSmallBlind = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBigBlind = new System.Windows.Forms.NumericUpDown();
            this.labelBigBlind = new System.Windows.Forms.Label();
            this.buttonAddPlayer = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonRemovePlayer = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmallBlind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBigBlind)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.941843F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.22647F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.22647F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.22647F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.37876F));
            this.tableLayoutPanel.Controls.Add(this.labelCash, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.labelName, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.labelType, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 11;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(387, 345);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // labelCash
            // 
            this.labelCash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCash.AutoSize = true;
            this.labelCash.Location = new System.Drawing.Point(251, 9);
            this.labelCash.Name = "labelCash";
            this.labelCash.Size = new System.Drawing.Size(31, 13);
            this.labelCash.TabIndex = 2;
            this.labelCash.Text = "Cash";
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(156, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // labelType
            // 
            this.labelType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(65, 9);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(31, 13);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type";
            // 
            // labelSmallBlind
            // 
            this.labelSmallBlind.AutoSize = true;
            this.labelSmallBlind.Location = new System.Drawing.Point(190, 364);
            this.labelSmallBlind.Name = "labelSmallBlind";
            this.labelSmallBlind.Size = new System.Drawing.Size(57, 13);
            this.labelSmallBlind.TabIndex = 4;
            this.labelSmallBlind.Text = "Small blind";
            // 
            // numericUpDownSmallBlind
            // 
            this.numericUpDownSmallBlind.Location = new System.Drawing.Point(193, 380);
            this.numericUpDownSmallBlind.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSmallBlind.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSmallBlind.Name = "numericUpDownSmallBlind";
            this.numericUpDownSmallBlind.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownSmallBlind.TabIndex = 5;
            this.numericUpDownSmallBlind.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownBigBlind
            // 
            this.numericUpDownBigBlind.Location = new System.Drawing.Point(264, 380);
            this.numericUpDownBigBlind.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownBigBlind.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBigBlind.Name = "numericUpDownBigBlind";
            this.numericUpDownBigBlind.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownBigBlind.TabIndex = 7;
            this.numericUpDownBigBlind.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelBigBlind
            // 
            this.labelBigBlind.AutoSize = true;
            this.labelBigBlind.Location = new System.Drawing.Point(261, 364);
            this.labelBigBlind.Name = "labelBigBlind";
            this.labelBigBlind.Size = new System.Drawing.Size(47, 13);
            this.labelBigBlind.TabIndex = 6;
            this.labelBigBlind.Text = "Big blind";
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Location = new System.Drawing.Point(12, 377);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPlayer.TabIndex = 8;
            this.buttonAddPlayer.Text = "Add player";
            this.buttonAddPlayer.UseVisualStyleBackColor = true;
            this.buttonAddPlayer.Click += new System.EventHandler(this.buttonAddPlayer_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(324, 377);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonRemovePlayer
            // 
            this.buttonRemovePlayer.Location = new System.Drawing.Point(93, 377);
            this.buttonRemovePlayer.Name = "buttonRemovePlayer";
            this.buttonRemovePlayer.Size = new System.Drawing.Size(91, 23);
            this.buttonRemovePlayer.TabIndex = 10;
            this.buttonRemovePlayer.Text = "Remove player";
            this.buttonRemovePlayer.UseVisualStyleBackColor = true;
            this.buttonRemovePlayer.Click += new System.EventHandler(this.buttonRemovePlayer_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 412);
            this.Controls.Add(this.buttonRemovePlayer);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonAddPlayer);
            this.Controls.Add(this.numericUpDownBigBlind);
            this.Controls.Add(this.labelBigBlind);
            this.Controls.Add(this.numericUpDownSmallBlind);
            this.Controls.Add(this.labelSmallBlind);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.Text = "PokerAI Settings";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmallBlind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBigBlind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelCash;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSmallBlind;
        private System.Windows.Forms.NumericUpDown numericUpDownSmallBlind;
        private System.Windows.Forms.NumericUpDown numericUpDownBigBlind;
        private System.Windows.Forms.Label labelBigBlind;
        private System.Windows.Forms.Button buttonAddPlayer;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonRemovePlayer;
    }
}