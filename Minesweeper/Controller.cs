using Minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    internal class Controller
    {
        private Form1 form;
       public int tag;

        public Controller(Form1 formInstance)
        {
            form = formInstance;
        }

        internal void Sweep(int col, int row)
        {

            CheckForWin();
            if (CheckForWin() == true)
            {
                
                tag = 0;
                MessageBox.Show("WINNER");
            }
            if (form.gameOver || form.grid[col, row].Tag != null)
            {

                return;
            }

            int mineCount = 0;


            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {

                    if (x == 0 && y == 0) continue;

                    int newCol = col + x;
                    int newRow = row + y;


                    if (newCol >= 0 && newCol < 10 && newRow >= 0 && newRow < 10)
                    {

                        if (form.grid[newCol, newRow].Tag != null && form.grid[newCol, newRow].Tag.ToString() == "Mine")
                        {
                            mineCount++;
                        }
                    }
                }
            }


            form.grid[col, row].Tag = "Revealed";
            tag++;

            if (mineCount == 0)
            {
                form.grid[col, row].Image = Resources.Blank;


                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        if (x == 0 && y == 0) continue;
                        int newCol = col + x;
                        int newRow = row + y;


                        if (newCol >= 0 && newCol < 10 && newRow >= 0 && newRow < 10)
                        {

                            if (form.grid[newCol, newRow].Tag == null)
                            {
                                Sweep(newCol, newRow);
                            }
                        }
                    }
                }
            }
            else
            {

                if (mineCount == 1)
                {
                    form.grid[col, row].Image = Resources._1;
                }
                if (mineCount == 2)
                {
                    form.grid[col, row].Image = Resources._2;
                }
                if (mineCount == 3)
                {
                    form.grid[col, row].Image = Resources._3;
                }
                if (mineCount == 4)
                {
                    form.grid[col, row].Image = Resources._4;
                }
                if (mineCount == 5)
                {
                    form.grid[col, row].Image = Resources._5;
                }
                if (mineCount == 6)
                {
                    form.grid[col, row].Image = Resources._6;
                }
                if (mineCount == 7)
                {
                    form.grid[col, row].Image = Resources._7;
                }
                if (mineCount == 8)
                {
                    form.grid[col, row].Image = Resources._8;
                }
                
            }
        }


        public void PlaceMines(int numberOfMines)
        {
            Random rand = new Random();
            int minesPlaced = 0;

            while (minesPlaced < numberOfMines)
            {
                int randRow = rand.Next(0, 10);
                int randCol = rand.Next(0, 10);


                if (form.grid[randCol, randRow].Tag == null) //om det inte finns en tag lägger det till en tag med texten Mine
                {
                    form.grid[randCol, randRow].Tag = "Mine";
                    tag++;
                    minesPlaced++;
                }
            }
        }
        public bool CheckForWin()
        {
            if (tag == 100)
            {
               
                return true;
               
            }
            else return false;
        }
    }
}

