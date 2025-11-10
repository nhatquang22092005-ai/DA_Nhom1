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
        public Food(Random ranFood)
        {
            x = ranFood.Next(0, 29) * 10;
            y = ranFood.Next(0, 29) * 10;

            brush = new SolidBrush(Color.Red);

            dai = 10;rong = 10;

            foodR = new Rectangle(x,y,dai,rong);
        }
        public void viTriFood(Random ranFood)
        {
            x = ranFood.Next(0, 29) * 10;
           y = ranFood.Next(0, 29) * 10;
        }
        public void veFood(Graphics paper)
        {
            foodR.X = x;
            foodR.Y = y;

            paper.FillEllipse(brush, foodR);
        }
    }
}
