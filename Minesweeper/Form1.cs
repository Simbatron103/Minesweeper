using Minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
       
    
       
        Controller control;
        public PictureBox[,] grid = new PictureBox[10, 10]; //ops kommer bara fungera med 10 x 10...
       public bool gameOver = false;
        int tid = 0;
        public Form1()
        {
           
           InitializeComponent();
            InitializeGrid();
         
            control = new Controller(this); 
            control.PlaceMines(10);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void InitializeGrid()
        {
            
           
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    PictureBox lbl = new PictureBox();
                    lbl.Size = new Size(40, 40);
                    lbl.Location = new Point(x * 40, y * 40);
                    lbl.SizeMode = PictureBoxSizeMode.StretchImage;
                    lbl.Image = Resources.Unrevealed;
                   
                    
                    lbl.Click += new EventHandler(Label_Click);
                    grid[x, y] = lbl;
                    Controls.Add(lbl);
                }
            }
        }
        public void Label_Click(object sender, EventArgs e)
        {
          
            if (gameOver) return;
           if (control.CheckForWin() == true)
            {
            
            }
            PictureBox clickedLabel = sender as PictureBox;
            int row = (clickedLabel.Location.Y / 40);
            int col = (clickedLabel.Location.X / 40);
            control.Sweep(col, row);
            if (clickedLabel.Tag != null && clickedLabel.Tag.ToString() == "Mine")
            {
             
                for (int x = 0; x <10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (grid[x,y].Tag == "Mine")
                        {
                            grid[x, y].Image = Resources.Bomb;
                        }
                    }
                    button1.BackgroundImage = Resources.Dead;
                    control.tag = 0;
                   gameOver = true;
                }
                MessageBox.Show("Boom! Game Over!");
            }

            else
            {
               control.Sweep(col, row);
            }
          
             
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = control.tag.ToString();
            tid++;
            label1.Text = tid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            tid = 0; label1.Text = "0";
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (grid[x, y].Tag != null)
                    {
                        grid[x, y].Tag = null;
                        grid[x, y].Image = Resources.Unrevealed;
                    }
                }
               
            }
            gameOver = false;
            button1.BackgroundImage = Resources.smile;
            control.PlaceMines(10);
        }
       


    }
}

 