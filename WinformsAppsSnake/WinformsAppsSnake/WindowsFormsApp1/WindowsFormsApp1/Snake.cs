using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class Snake
    {
        private Rectangle[] snakeRec;
        
        public Rectangle[] SnakeRec // tao o ngoai de lam dai con ran
        {
            get { return snakeRec; }
        }
        
     
        private SolidBrush brush;
        private int x, y, rong, dai;

        public Snake()
        {
            snakeRec = new Rectangle[5];
            brush = new SolidBrush(Color.Green);

            x = 50;
            y = 0;
            dai = 10;
            rong = 10;
            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, dai, rong);
                x -= 10;
            }
        }
        public void veSnake(Graphics paper)
        {
            paper.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

      
            using (SolidBrush headBrush = new SolidBrush(Color.Green))
            {
             
                paper.FillRectangle(headBrush, snakeRec[0]);

              
                using (SolidBrush eyeBrush = new SolidBrush(Color.White))
                {
                  
                    paper.FillRectangle(eyeBrush, snakeRec[0].X + 2, snakeRec[0].Y + 2, 2, 2);
                  
                    paper.FillRectangle(eyeBrush, snakeRec[0].X + 6, snakeRec[0].Y + 2, 2, 2);
                }
            }

            for (int i = 1; i < snakeRec.Length; i++)
            {
               
                paper.FillRectangle(brush, snakeRec[i]);
            }
        }
        public void drawSnakeRun()
        {
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }
        public void moveDown()
        {
            drawSnakeRun();
            snakeRec[0].Y += 10;
        }
        public void moveUp()
        {
            drawSnakeRun();
            snakeRec[0].Y -= 10;
        }
        public void moveRight()
        {
            drawSnakeRun();
            snakeRec[0].X += 10;
        }
        public void moveLeft()
        {
            drawSnakeRun();
            snakeRec[0].X -= 10;
        }
        public void growSnake()
        {
            List<Rectangle> rec= snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, dai, rong));
            snakeRec= rec.ToArray();
        }
    }
}
