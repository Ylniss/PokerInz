﻿using PokerAPI;
using PokerAPI.Ai;
using PokerAPI.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker.GuiApp
{
    public partial class FormMenu : Form
    {
        private List<Control> controls = new List<Control>();

        private List<Label> labelsNum = new List<Label>(10);
        private List<ComboBox> typeComboBoxes = new List<ComboBox>(10);
        private List<TextBox> nameTextBoxes = new List<TextBox>(10);
        private List<NumericUpDown> cashNumerics = new List<NumericUpDown>(10);

        private int playersCount = 0;

        private const int maxPlayers = 10;
        private const int minPlayers = 2;

        public FormMenu()
        {
            InitializeComponent();

            controls.Add(tableLayoutPanel);

            foreach (Control control in controls)
                Controls.Add(control);

            for (int i = 0; i < minPlayers; ++i)
                addPlayer();
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            if (playersCount < maxPlayers)
            {
                addPlayer();
            }
            else
            {
                MessageBox.Show($"Maximum allowed number of players is {maxPlayers}");
            }
        }

        private void buttonRemovePlayer_Click(object sender, EventArgs e)
        {
            if (playersCount > minPlayers)
            {
                removePlayer();
            }
            else
            {
                MessageBox.Show($"Minimum allowed number of players is {minPlayers}");
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<IPlayer> players = new List<IPlayer>();

            for (int i = 0; i < playersCount; ++i)
            {
                //TEST
                float min = 0;
                float max = 0;

                //if (i == 0) { min = 0.00f; max = 0.05f; }
                //if (i == 1) { min = 0.05f; max = 0.20f; }
                //if (i == 2) { min = 0.50f; max = 0.70f; }
                //if (i == 3) { min = 0.50f; max = 0.95f; }
                //if (i == 4) { min = 0.65f; max = 0.70f; }
                //if (i == 5) { min = 0.65f; max = 0.90f; }
                //if (i == 6) { min = 0.55f; max = 0.90f; }
                //if (i == 7) { min = 0.00f; max = 1.00f; }
                //if (i == 8) { min = 0.40f; max = 0.60f; }
                //if (i == 9) { min = 0.70f; max = 0.80f; }

                //if (i == 0) { min = 0.00f; max = 0.90f; } //dane z pracy pisemnej
                //if (i == 1) { min = 0.00f; max = 0.75f; }
                //if (i == 2) { min = 0.00f; max = 0.50f; }
                //if (i == 3) { min = 0.00f; max = 0.30f; }
                //if (i == 4) { min = 0.05f; max = 0.90f; }
                //if (i == 5) { min = 0.10f; max = 0.90f; }
                //if (i == 6) { min = 0.15f; max = 0.90f; }
                //if (i == 7) { min = 0.05f; max = 0.75f; }
                //if (i == 8) { min = 0.10f; max = 0.75f; }
                //if (i == 9) { min = 0.15f; max = 0.75f; }

                if (i == 0) { min = 0.05f; max = 1.00f; }
                if (i == 1) { min = 0.05f; max = 0.90f; }
                if (i == 2) { min = 0.05f; max = 0.80f; }
                if (i == 3) { min = 0.05f; max = 0.70f; }
                if (i == 4) { min = 0.05f; max = 0.60f; }
                if (i == 5) { min = 0.05f; max = 0.50f; }
                if (i == 6) { min = 0.05f; max = 0.40f; }
                if (i == 7) { min = 0.05f; max = 0.30f; }
                if (i == 8) { min = 0.05f; max = 0.20f; }
                if (i == 9) { min = 0.05f; max = 0.10f; }
                //TEST

                if (typeComboBoxes[i].Text == "Random AI")
                {
                    players.Add(new Player(nameTextBoxes[i].Text, i, (int)cashNumerics[i].Value, new TestAi(min, max)));
                }

                if (typeComboBoxes[i].Text == "VarRiskRand AI")
                {
                    players.Add(new Player(nameTextBoxes[i].Text, i, (int)cashNumerics[i].Value, new VarRiskRandAi(min, max, 3, 0.95f, 1.00f)));
                }
            }

            IDictionary<IPlayer, int> startingCash = new Dictionary<IPlayer, int>();

            foreach (var player in players)
                startingCash[player] = player.Chips;

            int numOfGames = (int)numericNumOfGames.Value;

            if (!checkBoxPerformance.Checked)
                numOfGames = 1;

            FormGameTable gameForm = new FormGameTable(players, new GameSettings(startingCash, 
                (int)numericUpDownSmallBlind.Value, 
                (int)numericUpDownBigBlind.Value, 
                checkBoxPerformance.Checked,
                numOfGames));
        }

        private void checkBoxPerformance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPerformance.Checked)
                numericNumOfGames.Enabled = true;
            else
                numericNumOfGames.Enabled = false;
        }

        private void addRowToPanel(TableLayoutPanel panel, int row)
        {
            Label labelNum = new Label();
            labelNum.Text = row.ToString() + '.';
            labelNum.Anchor = AnchorStyles.Bottom;
            labelsNum.Add(labelNum);
            panel.Controls.Add(labelNum, 0, row);

            ComboBox typeComboBox = new ComboBox();
            typeComboBox.Items.Add("Random AI");
            typeComboBox.Items.Add("VarRiskRand AI");
            typeComboBox.SelectedIndex = 0;
            typeComboBoxes.Add(typeComboBox);
            panel.Controls.Add(typeComboBox, 1, row);

            TextBox nameTextBox = new TextBox();
            nameTextBox.Text = "Player" + row;
            nameTextBoxes.Add(nameTextBox);
            panel.Controls.Add(nameTextBox, 2, row);

            NumericUpDown cashNumeric = new NumericUpDown();
            cashNumeric.Minimum = 100.0M;
            cashNumeric.Maximum = 9000.0M;
            cashNumeric.Value = 1000.0M;
            cashNumerics.Add(cashNumeric);
            panel.Controls.Add(cashNumeric, 3, row);
        }

        private void removeRowFromPanel(TableLayoutPanel panel, int row)
        {
            panel.Controls.Remove(labelsNum[row]);
            panel.Controls.Remove(typeComboBoxes[row]);
            panel.Controls.Remove(nameTextBoxes[row]);
            panel.Controls.Remove(cashNumerics[row]);

            labelsNum.RemoveAt(row);
            typeComboBoxes.RemoveAt(row);
            nameTextBoxes.RemoveAt(row);
            cashNumerics.RemoveAt(row);
        }

        private void addPlayer()
        {
            ++playersCount;
            addRowToPanel(tableLayoutPanel, playersCount);
        }

        private void removePlayer()
        {
            --playersCount;
            removeRowFromPanel(tableLayoutPanel, playersCount);
        }
    }
}
