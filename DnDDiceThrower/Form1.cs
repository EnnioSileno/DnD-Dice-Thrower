using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DnDDiceThrower {
    public partial class Form1 : Form {

        private static int D4 = 4;
        private static int D6 = 6;
        private static int D8 = 8;
        private static int D10 = 10;
        private static int D12 = 12;
        private static int D20 = 20;

        public Form1() {
            InitializeComponent();
            resetResults();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void buttonD4_Click(object sender, EventArgs e) {
            getDiceRoll(D4, textBoxD4, resultD4);
        }

        private void buttonD6_Click(object sender, EventArgs e) {
            getDiceRoll(D6, textBoxD6, resultD6);
        }

        private void buttonD8_Click(object sender, EventArgs e) {
            getDiceRoll(D8, textBoxD8, resultD8);
        }

        private void buttonD10_Click(object sender, EventArgs e) {
            getDiceRoll(D10, textBoxD10, resultD10);
        }

        private void buttonD12_Click(object sender, EventArgs e) {
            getDiceRoll(D12, textBoxD12, resultD12);
        }

        private void buttonD20_Click(object sender, EventArgs e) {
            getDiceRoll(D20, textBoxD20, resultD20);
        }

        private void textBoxD4_TextChanged(object sender, EventArgs e) {
            TextBox thisSender = (TextBox)sender;
            if (thisSender.TextLength == thisSender.MaxLength) {
                thisSender.BackColor = Color.LightSeaGreen;
            } else {
                thisSender.BackColor = Color.White;
            }
            enableOrDisableRollButton(buttonD4, textBoxD4);
        }

        private void textBoxD6_TextChanged(object sender, EventArgs e) {
            enableOrDisableRollButton(buttonD6, textBoxD6);
        }

        private void textBoxD8_TextChanged(object sender, EventArgs e) {
            enableOrDisableRollButton(buttonD8, textBoxD8);
        }

        private void textBoxD10_TextChanged(object sender, EventArgs e) {
            enableOrDisableRollButton(buttonD10, textBoxD10);
        }

        private void textBoxD12_TextChanged(object sender, EventArgs e) {
            enableOrDisableRollButton(buttonD12, textBoxD12);
        }

        private void textBoxD20_TextChanged(object sender, EventArgs e) {
            enableOrDisableRollButton(buttonD20, textBoxD20);
        }

        private void enableOrDisableRollButton(Button button, TextBox textBox) {
            button.Enabled = !string.IsNullOrWhiteSpace(textBox.Text);
        }

        private void reset_Click(object sender, EventArgs e) {
            resetResults();
        }

        private void resetResults() {
            resultD4.Text = "";
            resultD6.Text = "";
            resultD8.Text = "";
            resultD10.Text = "";
            resultD12.Text = "";
            resultD20.Text = "";
            textBoxD4.Text = "";
            textBoxD6.Text = "";
            textBoxD8.Text = "";
            textBoxD10.Text = "";
            textBoxD12.Text = "";
            textBoxD20.Text = "";
        }

        private void getDiceRoll(int diceType, TextBox textBox, Label textBoxResult) {
            int numberOfRolls;
            if (Int32.TryParse(textBox.Text, out numberOfRolls) && numberOfRolls > 0) {
                int range = numberOfRolls > 15 ? 15 : numberOfRolls;
                string suffix = numberOfRolls > range ? ", ... " : " ";
                List<int> result = DiceThrowGenerator.GetResult(diceType, numberOfRolls);
                textBoxResult.Text = $"[ {string.Join(", ", result.GetRange(0, range))}{suffix}] = {result.Sum()}";
            }
        }
    }
}
