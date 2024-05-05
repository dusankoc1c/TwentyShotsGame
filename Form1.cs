using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwentyShots
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x1 = 0;
        int y1 = 0;
        bool _try = true; int tries = 0;
        int Time = 5;
        int total = 0;
        int score = 0;
        Random r = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            Width=800;
            Height = 800;
            timer1.Enabled = true;
            tries = 0;
            Time = 5;
            total = 0;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tries < 20)
            {
                vreme.Text = Convert.ToString(Time);
                if(Time == 5)
                {
                    /*Graphics Krug = CreateGraphics();
                    SolidBrush cetka = new SolidBrush(Color.Red);
                    Krug.FillEllipse(cetka, x1, y1, 25, 25);*/
                    x1 = r.Next(5, 695);
                    y1 = r.Next(100, 695);
                    lblx.Text = Convert.ToString(x1);
                    lbly.Text = Convert.ToString(y1);
                    _try = true;
                }
                Time--;
                if (Time < 0)
                {
                    tries++;
                    Time = 5;
                }
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (_try)
            {
                double Razdaljina = Math.Sqrt((e.X - x1) * (e.X - x1) + (e.Y - y1) * (e.Y - y1));
                if (Razdaljina <= 10){ 
                    score = 10; 
                    description.Text = "HIT!"; 
                }
                else if (Razdaljina <= 20){
                    score = 5; 
                    description.Text = "CLOSE!"; 
                } 
                if (Razdaljina <= 50) 
                { 
                    score = 2; 
                    description.Text = "SOMEWHERE THERE...";
                } 
                else if (Razdaljina <= 80)
                { 
                    score = 1; 
                    description.Text = "FAR AWAY!";
                }
                else 
                {
                    description.Text = "OTHER SIDE OF THE MAP!"; 
                    score = 0; 
                }
                _try = false; 
                points.Text = Convert.ToString(score); 
                total += score;
                label4.Text = Convert.ToString(total); 
            }
        }
    }
}
