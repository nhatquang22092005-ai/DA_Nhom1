using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Map
    {
        public List<Rectangle> Walls = new List<Rectangle>();
        public Rectangle TeleIn;
        public Rectangle TeleOut;

        private int wallSize = 20; 

        public void LoadLevel(int level)
        {
            Walls.Clear();


            if (level == 1)
                LoadLevel1();
            else if (level == 2)
                LoadLevel2();
            else if (level == 3)
                LoadLevel3();
            else
                LoadLevel1();

                AddBoundaryWalls();

            Walls.RemoveAll(w => w.IntersectsWith(TeleIn) || w.IntersectsWith(TeleOut));


        }

     
        private void LoadLevel1()
        {
            Walls.Clear();

            
            Walls.Add(new Rectangle(100, 100, 450, wallSize));
            Walls.Add(new Rectangle(100, 400, 300, wallSize));

            
            TeleIn = new Rectangle(20, 350, 20, 20);
            TeleOut = new Rectangle(350, 350, 20, 20);

        }


        private void LoadLevel2()
        {
            Walls.Add(new Rectangle(70, 50, wallSize, 300));
            Walls.Add(new Rectangle(300, 50, wallSize, 300));
            Walls.Add(new Rectangle(70, 330, 230, wallSize));

            TeleIn = new Rectangle(30, 100, 20, 20);
            TeleOut = new Rectangle(350, 50, 20, 20);

            
            Walls.RemoveAll(w => w.IntersectsWith(TeleIn) || w.IntersectsWith(TeleOut));
        }



        private void LoadLevel3()
        {


            Walls.Add(new Rectangle(150, 100, 200, wallSize));  
            Walls.Add(new Rectangle(100, 200, wallSize, 200));  
            Walls.Add(new Rectangle(500, 150, wallSize, 250));  
            Walls.Add(new Rectangle(250, 350, 300, wallSize));  
            Walls.Add(new Rectangle(300, 250, 150, wallSize));  
            Walls.Add(new Rectangle(400, 100, wallSize, 150));  

         
            TeleIn = new Rectangle(20, 350, 20, 20);
            TeleOut = new Rectangle(350, 350, 20, 20);

            
            Walls.RemoveAll(w => w.IntersectsWith(TeleIn) || w.IntersectsWith(TeleOut));
        }

        public void Draw(Graphics g,int level, bool showTele)
        {
            
            foreach (var w in Walls)
            {
                g.FillRectangle(Brushes.Brown, w);
            }

            
            if (!showTele)
            
                return;
            if (level == 1)
            {
                g.FillRectangle(Brushes.Blue, TeleIn);

            }
            else if (level ==2)
            {
                g.FillRectangle(Brushes.Purple, TeleIn);
            }
            else if (level == 3)
            {
                g.FillRectangle(Brushes.Orange, TeleIn);
            }     
            
        }
        private void AddBoundaryWalls()
        {
           

            int w = 800;
            int h = 600;
            int t = 10;

            Walls.Add(new Rectangle(0, 0, w, t));
            Walls.Add(new Rectangle(0, h - t, w, t));
            Walls.Add(new Rectangle(0, 0, t, h));
            Walls.Add(new Rectangle(w - t, 0, t, h));
        }
    }
}

