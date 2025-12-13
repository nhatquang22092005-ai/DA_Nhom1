using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Food
    {
        private int x, y, dai, rong;
        private SolidBrush brush;
        public Rectangle foodR;
        public Food()
        {
          
            brush = new SolidBrush(Color.Red);

            dai = 10; rong = 10;

            foodR = Rectangle.Empty;
            
        }
     
        public void viTriFood(Random ran, List<Rectangle> walls, Rectangle teleIn, Rectangle teleOut, Rectangle[] snake)
        {
            while (true)
            {
                x = ran.Next(0, 29) * 20;
                y = ran.Next(0, 29) * 20;

                Rectangle newFood = new Rectangle(x, y, dai, rong);

                
                if (walls.Any(w => w.IntersectsWith(newFood)))
                    continue;

                
                if (newFood.IntersectsWith(teleIn) || newFood.IntersectsWith(teleOut))
                    continue;

               
                if (snake.Any(s => s.IntersectsWith(newFood)))
                    continue;

                x=newFood.X;
                y=newFood.Y;
                foodR = newFood;
                break;
            }
        }
        public void veFood(Graphics paper)
        {
            foodR.X = x;
            foodR.Y = y;

            paper.FillEllipse(brush, foodR);
        }
    }
}
