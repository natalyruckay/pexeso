using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uloha7_pexeso
{
    public partial class Form1 : Form
    {
        //kontrola, či sú stlačené
        Label firstClicked = null;
        Label secondClicked = null;
        Label thirdClicked = null;

        // vyber random obrazkov
        Random random = new Random();
        start s;

        List<string> icons = new List<string>() { "u", "u", "f", "f", "o", "o", "k", "k", "b", "b", "v", "v", "j", "j", "h", "h", "p", "p", "t", "t" };

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                if (secondClicked == null)
                {
                    secondClicked = clickedLabel;
                    secondClicked.ForeColor = Color.Black;
                    return;
                }
                if (firstClicked.Text == secondClicked.Text)
                {

                    //zmením farbu, aby kartičky zmizli
                    firstClicked.BackColor = Color.White;
                    firstClicked.ForeColor = Color.White;
                    secondClicked.BackColor = Color.White;
                    secondClicked.ForeColor = Color.White;

                    CheckForWinner();

                    // nastavim hodnoty na null
                    firstClicked = null;
                    secondClicked = null;

                    return;
                }
                if (thirdClicked == null)
                {
                    thirdClicked = clickedLabel;

                    //shovám prvu a druhu karticku
                    firstClicked.ForeColor = firstClicked.BackColor;
                    secondClicked.ForeColor = secondClicked.BackColor;

                    //nastavím hodnoty na null
                    firstClicked = null;
                    secondClicked = null;
                    thirdClicked = null;

                    return;
                }
            }
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if ((iconLabel.ForeColor != Color.White) && (iconLabel.BackColor != Color.White))
                        return;
                }
            }
            MessageBox.Show("Gratulujem! Vyhral/a si!");
            s = new start();
            s.Show();
            Hide();
        }
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
    }
}
