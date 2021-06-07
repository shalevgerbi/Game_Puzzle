using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Puzzle : Form
    {

        public static int N = 16;
        public Puzzle()
        {
            InitializeComponent();


        }

        private void shuffle()
        {
            //Random rnd = new Random();


            int[] arr = new int[N - 1];
            int i = 0;
            for (i = 0; i < N - 1; i++)
                arr[i] = i + 1;
            Random myRand = new Random();
            for (i = N - 2; i >= 0; i--)
            {
                int R = myRand.Next(i);

                int temp = arr[i];
                arr[i] = arr[R];
                arr[R] = temp;
            }
            int ctr = 0;
            foreach (Control control in Controls)
            {
                if (control.Visible == false)
                {
                    control.Visible = true;
                    control.Text = button16.Text;
                    control.BackColor = button16.BackColor;
                    button16.Visible = false;

                    continue;
                }


                if (ctr == 15)
                {
                    break;
                }



                control.Text = arr[ctr].ToString();
                control.BackColor = Color.FromArgb(myRand.Next(256), myRand.Next(256), myRand.Next(256));


                ctr++;

            }
        }
        private void Puzzle_Load(object sender, EventArgs e)
        {

            shuffle();
        }
      
        private void swap(Button current)
        {
            Button empty = null;
            foreach (Control control in Controls)
            {
                if (control.Visible == false)
                {
                    empty = (Button)control;
                }

            }
            if (current.TabIndex == empty.TabIndex - 1 || current.TabIndex == empty.TabIndex - 4 || current.TabIndex == empty.TabIndex + 1 || current.TabIndex == empty.TabIndex + 4)
            {
                empty.Visible = true;
                empty.Text = current.Text;
                empty.BackColor = current.BackColor;
                current.Visible = false;

            }
        }
        private void checkBoard()
        {

            int ctr = 1;
            //for easy test
            if (button1.Text.Equals("1") && button2.Text.Equals("2"))
            {
                DialogResult dialogResult = MessageBox.Show("You Won!\n             New Game?", "You Won!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    shuffle();
                }
                else
                {
                    Close();
                }
                //for the whole game test
                foreach (Control control in Controls)
                {

                    if (ctr == 14)
                    {
                        if (button14.Text.Equals("15") && button15.Text.Equals("14"))
                        {
                            DialogResult dialogResult2 = MessageBox.Show("You Lose! \n    New Game? ", "You Lose", MessageBoxButtons.YesNo);
                            if (dialogResult2 == DialogResult.Yes)
                            {
                                shuffle();
                            }
                            else
                            {
                                Close();
                            }
                        }
                    }





                    if (ctr == 16)
                    {
                        MessageBox.Show("YOU WON!");
                    }
                    if (!control.Text.Equals((control.TabIndex + 1).ToString()))
                    {
                        return;
                    }
                    ctr++;


                }

            }
        }
        private void AnyButton_Click(object sender, EventArgs e)
        {
            Button current = (Button)sender;
            swap(current);
            checkBoard();
        }


        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shuffle();
        }
    }
}
