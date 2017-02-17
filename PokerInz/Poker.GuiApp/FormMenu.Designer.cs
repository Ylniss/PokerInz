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
            this.checkBoxPerformance = new System.Windows.Forms.CheckBox();
            this.numericNumOfGames = new System.Windows.Forms.NumericUpDown();
            this.labelNumOfGames = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelParams = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxPlayerParams = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmallBlind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBigBlind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumOfGames)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.95529F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.68157F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.68157F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.68157F));
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
            this.tableLayoutPanel.Size = new System.Drawing.Size(306, 344);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // labelCash
            // 
            this.labelCash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCash.AutoSize = true;
            this.labelCash.Location = new System.Drawing.Point(244, 9);
            this.labelCash.Name = "labelCash";
            this.labelCash.Size = new System.Drawing.Size(31, 13);
            this.labelCash.TabIndex = 2;
            this.labelCash.Text = "Cash";
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(150, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // labelType
            // 
            this.labelType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(62, 9);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(31, 13);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type";
            // 
            // labelSmallBlind
            // 
            this.labelSmallBlind.AutoSize = true;
            this.labelSmallBlind.Location = new System.Drawing.Point(3, 121);
            this.labelSmallBlind.Name = "labelSmallBlind";
            this.labelSmallBlind.Size = new System.Drawing.Size(57, 13);
            this.labelSmallBlind.TabIndex = 4;
            this.labelSmallBlind.Text = "Small blind";
            // 
            // numericUpDownSmallBlind
            // 
            this.numericUpDownSmallBlind.Location = new System.Drawing.Point(6, 137);
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
            this.numericUpDownSmallBlind.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownSmallBlind.TabIndex = 5;
            this.numericUpDownSmallBlind.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownBigBlind
            // 
            this.numericUpDownBigBlind.Location = new System.Drawing.Point(6, 185);
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
            this.numericUpDownBigBlind.Size = new System.Drawing.Size(90, 20);
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
            this.labelBigBlind.Location = new System.Drawing.Point(3, 169);
            this.labelBigBlind.Name = "labelBigBlind";
            this.labelBigBlind.Size = new System.Drawing.Size(47, 13);
            this.labelBigBlind.TabIndex = 6;
            this.labelBigBlind.Text = "Big blind";
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Location = new System.Drawing.Point(6, 229);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(90, 35);
            this.buttonAddPlayer.TabIndex = 8;
            this.buttonAddPlayer.Text = "Add player";
            this.buttonAddPlayer.UseVisualStyleBackColor = true;
            this.buttonAddPlayer.Click += new System.EventHandler(this.buttonAddPlayer_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 311);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(90, 23);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonRemovePlayer
            // 
            this.buttonRemovePlayer.Location = new System.Drawing.Point(6, 270);
            this.buttonRemovePlayer.Name = "buttonRemovePlayer";
            this.buttonRemovePlayer.Size = new System.Drawing.Size(90, 35);
            this.buttonRemovePlayer.TabIndex = 10;
            this.buttonRemovePlayer.Text = "Remove player";
            this.buttonRemovePlayer.UseVisualStyleBackColor = true;
            this.buttonRemovePlayer.Click += new System.EventHandler(this.buttonRemovePlayer_Click);
            // 
            // checkBoxPerformance
            // 
            this.checkBoxPerformance.AutoSize = true;
            this.checkBoxPerformance.Location = new System.Drawing.Point(6, 15);
            this.checkBoxPerformance.MaximumSize = new System.Drawing.Size(90, 0);
            this.checkBoxPerformance.MinimumSize = new System.Drawing.Size(0, 30);
            this.checkBoxPerformance.Name = "checkBoxPerformance";
            this.checkBoxPerformance.Size = new System.Drawing.Size(90, 30);
            this.checkBoxPerformance.TabIndex = 11;
            this.checkBoxPerformance.Text = "Performance mode";
            this.checkBoxPerformance.UseVisualStyleBackColor = true;
            this.checkBoxPerformance.CheckedChanged += new System.EventHandler(this.checkBoxPerformance_CheckedChanged);
            // 
            // numericNumOfGames
            // 
            this.numericNumOfGames.Enabled = false;
            this.numericNumOfGames.Location = new System.Drawing.Point(6, 75);
            this.numericNumOfGames.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericNumOfGames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNumOfGames.Name = "numericNumOfGames";
            this.numericNumOfGames.Size = new System.Drawing.Size(90, 20);
            this.numericNumOfGames.TabIndex = 12;
            this.numericNumOfGames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelNumOfGames
            // 
            this.labelNumOfGames.AutoSize = true;
            this.labelNumOfGames.Location = new System.Drawing.Point(3, 58);
            this.labelNumOfGames.Name = "labelNumOfGames";
            this.labelNumOfGames.Size = new System.Drawing.Size(75, 13);
            this.labelNumOfGames.TabIndex = 13;
            this.labelNumOfGames.Text = "Num of games";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxPerformance);
            this.groupBoxSettings.Controls.Add(this.buttonStart);
            this.groupBoxSettings.Controls.Add(this.labelNumOfGames);
            this.groupBoxSettings.Controls.Add(this.labelSmallBlind);
            this.groupBoxSettings.Controls.Add(this.numericNumOfGames);
            this.groupBoxSettings.Controls.Add(this.numericUpDownSmallBlind);
            this.groupBoxSettings.Controls.Add(this.labelBigBlind);
            this.groupBoxSettings.Controls.Add(this.buttonRemovePlayer);
            this.groupBoxSettings.Controls.Add(this.numericUpDownBigBlind);
            this.groupBoxSettings.Controls.Add(this.buttonAddPlayer);
            this.groupBoxSettings.Location = new System.Drawing.Point(432, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(102, 344);
            this.groupBoxSettings.TabIndex = 14;
            this.groupBoxSettings.TabStop = false;
            // 
            // flowLayoutPanelParams
            // 
            this.flowLayoutPanelParams.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelParams.Location = new System.Drawing.Point(324, 48);
            this.flowLayoutPanelParams.Name = "flowLayoutPanelParams";
            this.flowLayoutPanelParams.Size = new System.Drawing.Size(102, 308);
            this.flowLayoutPanelParams.TabIndex = 1;
            // 
            // comboBoxPlayerParams
            // 
            this.comboBoxPlayerParams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayerParams.FormattingEnabled = true;
            this.comboBoxPlayerParams.Location = new System.Drawing.Point(324, 21);
            this.comboBoxPlayerParams.Name = "comboBoxPlayerParams";
            this.comboBoxPlayerParams.Size = new System.Drawing.Size(55, 21);
            this.comboBoxPlayerParams.TabIndex = 0;
            this.comboBoxPlayerParams.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayerParams_SelectedIndexChanged);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 365);
            this.Controls.Add(this.flowLayoutPanelParams);
            this.Controls.Add(this.comboBoxPlayerParams);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.Text = "PokerAI Settings";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmallBlind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBigBlind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumOfGames)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox checkBoxPerformance;
        private System.Windows.Forms.NumericUpDown numericNumOfGames;
        private System.Windows.Forms.Label labelNumOfGames;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.ComboBox comboBoxPlayerParams;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelParams;
    }
}