using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
            initButtonClicks();
            initTextBox_TextChanged();
            resetResults();
        }

        private void initButtonClicks() {
            buttonD4.Click += new EventHandler((sender, e) => getDiceRoll(D4, textBoxD4, resultD4));
            buttonD6.Click += new EventHandler((sender, e) => getDiceRoll(D6, textBoxD6, resultD6));
            buttonD8.Click += new EventHandler((sender, e) => getDiceRoll(D8, textBoxD8, resultD8));
            buttonD10.Click += new EventHandler((sender, e) => getDiceRoll(D10, textBoxD10, resultD10));
            buttonD12.Click += new EventHandler((sender, e) => getDiceRoll(D12, textBoxD12, resultD12));
            buttonD20.Click += new EventHandler((sender, e) => getDiceRoll(D20, textBoxD20, resultD20));
        }

        private void initTextBox_TextChanged() {
            textBoxD4.TextChanged += new EventHandler((sender, e) => textBox_TextChanged((TextBox)sender, buttonD4));
            textBoxD6.TextChanged += new EventHandler((sender, e) => textBox_TextChanged((TextBox)sender, buttonD6));
            textBoxD8.TextChanged += new EventHandler((sender, e) => textBox_TextChanged((TextBox)sender, buttonD8));
            textBoxD10.TextChanged += new EventHandler((sender, e) => textBox_TextChanged((TextBox)sender, buttonD10));
            textBoxD12.TextChanged += new EventHandler((sender, e) => textBox_TextChanged((TextBox)sender, buttonD12));
            textBoxD20.TextChanged += new EventHandler((sender, e) => textBox_TextChanged((TextBox)sender, buttonD20));
        }

        private void textBox_TextChanged(TextBox textBox, Button button) {
            textBox.BackColor = textBox.TextLength == textBox.MaxLength ? Color.LightSeaGreen : Color.White;
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
                List<int> result = DiceThrowGenerator.GetResult(diceType, numberOfRolls);
                int range = numberOfRolls > 15 ? 15 : numberOfRolls;
                
                string suffix = numberOfRolls > range ? ", ..." : "";
                textBoxResult.Text = $"[ {string.Join(", ", result.GetRange(0, range))}{suffix} ] = {result.Sum()}";
            }
        }
    }
}
