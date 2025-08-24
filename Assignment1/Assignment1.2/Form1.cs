using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1._2
{
    public partial class Form1 : Form
    {
        int max_time = 60; // Maximum amount of time on the timer
        int time_left = 60; // The amount of time left on the timer

        public Form1()
        {
            InitializeComponent();
        }

        // Add button: Add 1 to the counter once clicked. Only works while timer is not zero
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (time_left > 0)
            {
                int num = int.Parse(lblNumCount.Text);
                num++;
                lblNumCount.Text = num.ToString();
            }
        }

        // Subtract button: Subtract 1 to the counter once clicked. Only works while timer is not zero
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (time_left > 0)
            {
                int num = int.Parse(lblNumCount.Text);
                num--;
                lblNumCount.Text = num.ToString();
            }
        }

        // Update every second the timer tool ticked
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time_left >= 0 && timer1.Enabled)
            {
                // Count down the timer label every second from the max time to zero
                lblTimer.Text = time_left.ToString() + " seconds left";
                time_left--;
            }
            else
            {
                // Once the timer reaches 0, a messagebox will appear announcing the winner or draw

                DialogResult retryResult;
                timer1.Enabled = false;
                int num = int.Parse(lblNumCount.Text);
                if (num > 0)
                {
                    // Positive number won
                    retryResult = MessageBox.Show(
                        $"Positive number won. {num} is a positive number. Do you want to play again?",
                        "Game Ended",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information                        
                        );
                }
                else if (num < 0)
                {
                    // Negative number won
                    retryResult = MessageBox.Show(
                        $"Negative number won. {num} is a negative number. Do you want to play again?",
                        "Game Ended",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                        );
                }
                else
                {
                    // Draw
                    retryResult = MessageBox.Show(
                        $"It's a draw. {num} is a neutral number. Do you want to play again?",
                        "Game Ended",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                        );
                }

                // Play again action: There will be a yes or no options in the messagebox to retry the game or not.
                if (retryResult == DialogResult.Yes)
                {
                    // Reset the game if yes
                    timer1.Enabled = true;
                    time_left = max_time;
                    lblNumCount.Text = "0";
                }
                else
                {
                    // Close the game if no
                    Application.Exit();
                }
            }
        }
    }
}
