using System;
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
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
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

                    iconLabel.ForeColor = iconLabel.BackColor; //this line makes the icons hide from the player by setting the forecolor to be the same as the backcolor.

                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
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


            }
        }
    }

}
