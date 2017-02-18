using PokerAPI;
using PokerAPI.Ai;
using PokerAPI.Game;
using PokerAPI.Interfaces;
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
        private IList<Control> controls = new List<Control>();

        private IList<Label> labelsNum = new List<Label>(10);
        private IList<ComboBox> typeComboBoxes = new List<ComboBox>(10);
        private IList<TextBox> nameTextBoxes = new List<TextBox>(10);
        private IList<NumericUpDown> cashNumerics = new List<NumericUpDown>(10);

        private List<NumericUpDown>[] paramsNumerics = new List<NumericUpDown>[10];

        IList<PlayerAi> playersAi = new List<PlayerAi>(10);

        private int playersCount = 0;

        private const int maxPlayers = 10;
        private const int minPlayers = 2;

        public FormMenu()
        {
            InitializeComponent();

            controls.Add(tableLayoutPanel);
            controls.Add(flowLayoutPanelParams);

            foreach (Control control in controls)
                Controls.Add(control);

            for (int i = 0; i < minPlayers; ++i)
                addPlayer();

            comboBoxPlayerParams.SelectedIndex = 0;
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
                players.Add(new Player(nameTextBoxes[i].Text, i, (int)cashNumerics[i].Value, playersAi[i]));
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
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.SelectedIndexChanged += TypeComboBox_SelectedIndexChanged;
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

            comboBoxPlayerParams.Items.Add(playersCount);

            playersAi.Add(new TestAi());

            paramsNumerics[playersCount - 1] = new List<NumericUpDown>();
        }

        private void removePlayer()
        {
            --playersCount;
            removeRowFromPanel(tableLayoutPanel, playersCount);

            comboBoxPlayerParams.Items.RemoveAt(playersCount);

            playersAi.RemoveAt(playersCount);

            paramsNumerics[playersCount] = new List<NumericUpDown>();
        }

        private void comboBoxPlayerParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxPlayerParams.SelectedIndex;
            flowLayoutPanelParams.Controls.Clear();

            if (index >= 0)
            {
                var ai = playersAi[index];
                List<NumericUpDown> numerics = new List<NumericUpDown>();

                foreach (var parameter in ai.Parameters)
                {
                    Label labelParam = new Label();
                    labelParam.Text = parameter.Name;
                    labelParam.Margin = new Padding(0);

                    flowLayoutPanelParams.Controls.Add(labelParam);

                    string incString = parameter.ValueIncrease.ToString();
                    int decimalPlaces = incString.Substring(incString.LastIndexOf(',') + 1).Count();

                    NumericUpDown numeric = new NumericUpDown();
                    numeric.Value = (decimal)parameter.Value;
                    numeric.DecimalPlaces = decimalPlaces;
                    numeric.Increment = (decimal)parameter.ValueIncrease;
                    numeric.Minimum = (decimal)parameter.MinValue;
                    numeric.Maximum = (decimal)parameter.MaxValue;
                    numeric.Size = new Size(90, 5);
                    numeric.Margin = new Padding(0, 0, 0, 15);
                    numeric.ValueChanged += Numeric_ValueChanged;

                    numerics.Add(numeric);

                    flowLayoutPanelParams.Controls.Add(numeric);
                }

                paramsNumerics[index] = numerics;
            }
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                NumericUpDown currentNumeric = sender as NumericUpDown;

                int paramIndex = paramsNumerics.Where(x => x.Contains(currentNumeric)).First().IndexOf(currentNumeric);
                int playerIndex = paramsNumerics.ToList().IndexOf(paramsNumerics.Where(x => x.Contains(currentNumeric)).First());

                playersAi[playerIndex].Parameters[paramIndex].Value = (float)currentNumeric.Value;
            }
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox currentComboBox = sender as ComboBox;

                int index = typeComboBoxes.IndexOf(currentComboBox);

                playersAi.RemoveAt(index);

                if (currentComboBox.Text == "Random AI")
                    playersAi.Insert(index, new TestAi());
                else if (currentComboBox.Text == "VarRiskRand AI")
                    playersAi.Insert(index, new VarRiskRandAi());
         
                comboBoxPlayerParams.SelectedIndex = -1;
                comboBoxPlayerParams.SelectedIndex = index;

            }
        }
    }
}
