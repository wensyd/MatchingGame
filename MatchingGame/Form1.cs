﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;

        Label secondClicked = null;

        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }
       
        // selects random items for the squares            
        Random random = new Random();

            // Each of these letters is an interesting icon
            // in the Webdings font,
            // and each icon appears twice in this list

        List<string> icons = new List<string>()
    {
        "!", "!", "N", "N", "B", "B", "o", "o",
        "b", "b", "v", "v", "w", "w", "Y", "Y"
    };

        private void AssignIconsToSquares()
        {
            
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    //this line makes the icons hide from the player by setting the forecolor to be the same as the backcolor.

                    iconLabel.ForeColor = iconLabel.BackColor;

                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click

                if (clickedLabel.ForeColor == Color.Black)
                 return;

                //clickedLabel.ForeColor = Color.Black;


                // If firstClicked is null, this is the first icon 
                // in the pair that the player clicked,
                // so set firstClicked to the label that the player 
                // clicked, change its color to black, and return

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;


                // check to see if player won game
                CheckForWinner();


                // this keeps two matching icons visible
                if(firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // stops timer
            timer1.Stop();

            //Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            //reset firstClicked and secondClicked

            firstClicked = null;
            secondClicked = null;

        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("Congratulations, You matched all the icons!");
            Close();
        }
    }

}
