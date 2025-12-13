using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BonusFood
    {
        public int x, y, dai, rong;
        public bool isVisible;
        private SolidBrush brush;

        public Rectangle bonusR;

        public BonusFood(Random ran)
        {
            dai = 20;
            rong = 20;
            brush = new SolidBrush(Color.Gold);
            isVisible = false;
          
        }

       

        public void taoMoi(Random ran, List<Rectangle> walls, Rectangle teleIn, Rectangle teleOut, Rectangle[] snake)
        {
            while (true)
            {
                x = ran.Next(0, 29) * 20;
                y = ran.Next(0, 29) * 20;

                Rectangle newBonus = new Rectangle(x, y, dai, rong);

                
                if (walls.Any(w => w.IntersectsWith(newBonus)))
                    continue;

               
                if (newBonus.IntersectsWith(teleIn) || newBonus.IntersectsWith(teleOut))
                    continue;

                
                if (snake.Any(s => s.IntersectsWith(newBonus)))
                    continue;

                bonusR = newBonus;

                
                x = bonusR.X;
                y = bonusR.Y;

                break;
            }
        }

        public void veFood(Graphics paper)
        {
            if (isVisible)
            {
                bonusR.X = x;
                bonusR.Y = y;
                paper.FillEllipse(brush, bonusR);
            }
        }
    }
}
