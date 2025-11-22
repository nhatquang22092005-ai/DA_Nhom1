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
        public int x, y, dai, rong;           // công khai để form truy cập
        public bool isVisible;     // flag bonus
        private SolidBrush brush;

        public Rectangle bonusR;

        public BonusFood(Random ran)
        {
            dai = 20;
            rong = 20;
            brush = new SolidBrush(Color.Gold);
            isVisible = false;  
            taoMoi(ran);
        }

        public void taoMoi(Random ran)
        {
            x = ran.Next(0, 29) * 10;
            y = ran.Next(0, 29) * 10;

            bonusR = new Rectangle(x, y, dai, rong);
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
