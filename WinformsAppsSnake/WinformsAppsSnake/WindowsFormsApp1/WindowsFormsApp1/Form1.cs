using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Label scoreLabel = new Label();
        private Label highScoreLabel = new Label();
        Random ranFood = new Random();

        Food food;

        Graphics paper;

        Snake snake = new Snake();
        Boolean left = false, right = false, up = false, down = false, esc=false;
        private int score = 0;
        public static int highScore = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up && down == false)
            {
                up = true;
                down = false;
                right = false;
                left = false;
                esc = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                up = false;
                down = true;
                right = false;
                left = false;
                esc = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                up = false;
                down = false;
                right = true;
                left = false;
                esc = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                up = false;
                down = false;
                right = false;
                left = true;
                esc = false;
            }if(e.KeyData== Keys.Escape)
            {
                esc = true;
                DialogResult kq=MessageBox.Show("Bạn muốn thoát game hả?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(kq == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (down == true)
            {
                snake.moveDown();
            }
            if (up == true)
            {
                snake.moveUp();
            }
            if (right == true)
            {
                snake.moveRight();
            }
            if (left == true)
            {
                snake.moveLeft();
            }
            this.Invalidate();
        }

        public Form1()
        {
            InitializeComponent();
            food = new Food(ranFood);
            scoreLabel.Text = "Score: 0";
            scoreLabel.Location = new Point(10, 20);
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            scoreLabel.ForeColor = Color.Black; 
            this.Controls.Add(scoreLabel);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.veFood(paper);
            snake.veSnake(paper);

            for (int i = 0; i < snake.SnakeRec.Length; i++)

            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodR))
                {
                    snake.growSnake();
                    food.viTriFood(ranFood);
                    score += 10; 
                    scoreLabel.Text = "Score: " + score;
                    if (timer1.Interval > 70)
                        timer1.Interval -= 50;
                    else
                        timer1.Interval = 70;
                }
            }
            
            collision();
        }
        public void collision()
        {
            
            for (int i = 1; i < snake.SnakeRec.Length; i++)
            {
              
                if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                 if (score > highScore)
                    {
                    highScore = score;
                    }
                    timer1.Enabled = false;
                    DialogResult kq = MessageBox.Show("Tự đâm rồi kìa ní!!", "Muốn chơi lại khum??", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    if (kq == DialogResult.OK)
                    {
                        this.Close();

                    }

                }

            }
            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > this.ClientSize.Height)
            {
             if (score > highScore)
                {
                highScore = score;
                }
                timer1.Enabled = false;
                DialogResult kq = MessageBox.Show("Đâm dô tường rồi kìa", "Muốn chơi lại khum??", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (kq == DialogResult.OK)
                {
                    this.Close();
                
                }
            }
            if (snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > this.ClientSize.Width)
            {
             if (score > highScore)
                {
                highScore = score;
                }
                timer1.Enabled = false;
                DialogResult kq = MessageBox.Show("Đâm dô tường rồi kìa", "Muốn chơi lại khum??", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (kq == DialogResult.OK)
                {
                    this.Close();

                }
            }


        }
    }
}

