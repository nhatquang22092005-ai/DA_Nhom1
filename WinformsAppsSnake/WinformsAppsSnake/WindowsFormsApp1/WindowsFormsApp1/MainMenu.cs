using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        private Label lblHighScore = new Label();
        public MainMenu()
        {
            InitializeComponent();
            lblHighScore.Location = new Point(20, 20); 
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Arial", 16, FontStyle.Bold);
            lblHighScore.Text = "Điểm Cao Nhất: " + Form1.highScore;
            this.Controls.Add(lblHighScore);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Form1 gameshow= new Form1();
            this.Hide();
            gameshow.ShowDialog();
            this.Show();
            lblHighScore.Text = "Điểm Cao Nhất: " + Form1.highScore;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq= MessageBox.Show("Bạn muốn thoát game hả?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

