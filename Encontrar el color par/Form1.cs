using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
       Label PrimerClick = null;        
       Label SegundoClick = null;
       int Puntos = 0;

        Random random = new Random();

        
        
       
        private void AssignarColoresAEtiquetas()
        {
            try
            {
                List<Color> colores = new List<Color>()
                                                  {
                  Color.Green, Color.Green, Color.Red, Color.Red, Color.Yellow, Color.Yellow, Color.Fuchsia, Color.Fuchsia,Color.Blue, Color.Blue, Color.Brown, Color.Brown, Color.Pink, Color.Pink, Color.Violet, Color.Violet
                    };

                foreach (Control control in tableLayoutPanel1.Controls)

                {
                    Label colorLabel = control as Label;

                    if (colorLabel != null)
                    {
                        int randomNumber = random.Next(colores.Count);
                        colorLabel.BackColor = colores[randomNumber];
                        colorLabel.ForeColor = colorLabel.BackColor;
                        colorLabel.Image = Properties.Resources.Captura1;
                        colores.RemoveAt(randomNumber);
                    }
                }
            }
            catch
            {

            }
        }
        public Form1()
        {
            InitializeComponent();
            AssignarColoresAEtiquetas();
        }

        private void label_Click(object sender, EventArgs e)
        {           
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;
            

            if (clickedLabel != null)
            {                
                if (clickedLabel.ForeColor == Color.Black)                    
                    return;                
                if (PrimerClick == null)
                {
                    PrimerClick = clickedLabel;
                    PrimerClick.ForeColor = Color.Black;
                    PrimerClick.Image = null;                    
                    return;
                }               
                SegundoClick = clickedLabel;
                SegundoClick.ForeColor = Color.Black;
                SegundoClick.Image = null;               
                CheckForWinner();
              
                if (PrimerClick.BackColor == SegundoClick.BackColor)
                {
                    PrimerClick = null;
                    SegundoClick = null;
                    Puntos++;
                    lblPuntos.Text = Convert.ToString(Puntos) + " :-)";
                    return;
                }              
                timer1.Start();
            }
        }
              
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Stop();           
            PrimerClick.ForeColor = PrimerClick.BackColor;
            SegundoClick.ForeColor = SegundoClick.BackColor;
            PrimerClick.Image = Properties.Resources.Captura1;
            SegundoClick.Image = Properties.Resources.Captura1;
            Puntos--;
            lblPuntos.Text = Convert.ToString(Puntos) + " :-(";        
            PrimerClick = null;
            SegundoClick = null;
        }
       
        private void CheckForWinner()
        {
          foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label colorLabel = control as Label;

                if (colorLabel != null)
                {
                    if (colorLabel.ForeColor == colorLabel.BackColor)
                        return;
                }
            }             
            lblPuntos.Text = Convert.ToString(Puntos);
            MessageBox.Show("Ganaste!");


        }

   
        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            AssignarColoresAEtiquetas();
            Puntos = 0;
            lblPuntos.Text = Convert.ToString(Puntos);
            
        }
    }
}
