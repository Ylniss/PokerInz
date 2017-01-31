using PokerAPI;
using PokerAPI.Ai;
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

        public FormMenu()
        {
            InitializeComponent();

            controls.Add(tableLayoutPanel);

            foreach (Control control in controls)
                Controls.Add(control);
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            if (playersCount < maxPlayers)
            {
                ++playersCount;

                addRowToPanel(tableLayoutPanel, playersCount);
            }
            else
            {
                MessageBox.Show($"Maximum allowed number of players is {maxPlayers}");
            }
        }

        private void buttonRemovePlayer_Click(object sender, EventArgs e)
        {
            --playersCount;

            removeRowFromPanel(tableLayoutPanel, playersCount);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<IPlayer> players = new List<IPlayer>();

            for (int i = 0; i < playersCount; ++i)
            {
                players.Add(new RandomAi(nameTextBoxes[i].Text, i, (int)cashNumerics[i].Value));
            }

            Form1 gameForm = new Form1(players, (int)numericUpDownSmallBlind.Value, (int)numericUpDownBigBlind.Value);
            gameForm.Show();
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
    }
}
