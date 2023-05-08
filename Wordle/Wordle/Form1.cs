using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            letters[0, 0] = label1;
            letters[0, 1] = label2;
            letters[0, 2] = label3;
            letters[0, 3] = label4;
            letters[0, 4] = label5;
            letters[1, 0] = label6;
            letters[1, 1] = label7;
            letters[1, 2] = label8;
            letters[1, 3] = label9;
            letters[1, 4] = label10;

            letters[2, 0] = label11;
            letters[2, 1] = label12;
            letters[2, 2] = label13;
            letters[2, 3] = label14;
            letters[2, 4] = label15;
            letters[3, 0] = label16;
            letters[3, 1] = label17;
            letters[3, 2] = label18;
            letters[3, 3] = label19;
            letters[3, 4] = label20;

            letters[4, 0] = label21;
            letters[4, 1] = label22;
            letters[4, 2] = label23;
            letters[4, 3] = label24;
            letters[4, 4] = label25;
            letters[5, 0] = label26;
            letters[5, 1] = label27;
            letters[5, 2] = label28;
            letters[5, 3] = label29;
            letters[5, 4] = label30;
            getRandomWord();
        }

        Label[,] letters = new Label[6,5];
        string the_word = "";
        int row = 0;

        private void getRandomWord()
        {
            string[] words = System.IO.File.ReadAllLines(@"C:\Users\TheBoss\OneDrive\Desktop\Atestate\Wordle\Wordle\word.txt");
            int nr = new Random().Next(0, 2309);
            the_word = words[nr];
        }

        private void label58_Click(object sender, EventArgs e)
        {
            int i, j = 4;
            bool found = false;
            for (i = 5; i >= 0 && found == false; i--)
                for (j = 4; j >= 0 && found == false; j--)
                    if (letters[i, j].Text != "")
                        found = true;
            letters[i + 1, j + 1].Text = "";
        }

        private void label31_Click(object sender, EventArgs e)
        {
            
            Label label = sender as Label;
            int i, j = 0;
            bool found = false;
            for (j = 0; j < 5 && !found; j++)
                if (letters[row, j].Text == "")
                    found = true;
            letters[row, j - 1].Text = label.Text;      
        }

        private void label57_Click(object sender, EventArgs e)
        {
            string[] words = System.IO.File.ReadAllLines(@"C:\Users\TheBoss\OneDrive\Desktop\Atestate\Wordle\Wordle\word.txt");
            string word = "";
            bool ok = false;
            for (int j = 0; j < 5; j++)
                word += letters[row, j].Text;
            if (word == the_word)
            {
                gameOver(true);
            }
            for (int j = 0; j < words.Length; j++)
                if (word == words[j])
                    ok = true;
            if (row < 5 && ok)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Convert.ToChar(letters[row, j].Text) == the_word[j])
                        letters[row, j].BackColor = Color.Lime;
                    else
                    {
                        bool is_in = false;
                        for (int i = 0; i < the_word.Length && !is_in; i++)
                            if (the_word[i] == Convert.ToChar(letters[row, j].Text))
                                is_in = true;
                        if (is_in)
                            letters[row, j].BackColor = Color.Yellow;
                    }
                }
                row++;
            }
            else if (!ok)
            {
                for (int j = 0; j < 5; j++)
                    letters[row, j].Text = "";
                MessageBox.Show("Enter a valid word!");
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            menu.Enabled = false;
            menu.Visible = false;

            title.Enabled = false;
            title.Visible = false;

            start_button.Enabled = false;
            start_button.Visible = false;

            quit_button.Enabled = false;
            quit_button.Visible = false;
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (row > 6)
                gameOver(false);
        }

        private void gameOver(bool win)
        {
            menu.Enabled = true;
            menu.Visible = true;

            if (win)
                title.Text = "You Win!";
            else
                title.Text = "Game Over!";
            title.Enabled = true;
            title.Visible = true;

            start_button.Text = "Play Again!";
            start_button.Enabled = true;
            start_button.Visible = true;

            quit_button.Enabled = true;
            quit_button.Visible = true;
        }
    }
}
