using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int window_width;
        private int window_height;

        Color ColorMap(double value)
        {
            double R;
            double G;
            double B;

            int dark = 150;

            if(value >=-1 && value < -0.5)
            {
                B = 255;
                G = ((2 * value) + 2) * 255;
                R = 0;
            }
            else if(value >= -0.5 && value < 0)
            {
                B = -2 * value * 255;
                G = 255;
                R = 0;
            }
            else if (value >= 0 && value < 0.5)
            {
                B = 0;
                G = 255;
                R = 2 * value * 255;
            }
            else if (value >= 0.5 && value <= 1)
            {
                B = 0;
                G = ((-2 * value) + 2) * 255;
                R = 255;
            }
            else
            {
                R = 255;
                G = 255;
                B = 255;
            }

            R = (R / 255) * dark;
            G = (G / 255) * dark;
            B = (B / 255) * dark;

            return Color.FromArgb((int)R, (int)G, (int)B);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            window_width = pictureBox1.Width;
            window_height = pictureBox1.Height;

            Bitmap bitmap = new Bitmap(window_width, window_height);

            for (int i = 0; i < window_width; i++)
            {
                Color color = ColorMap(((((double)i) / window_width) * 2) - 1);

                for (int j = 0; j < window_height; j++)
                {
                    bitmap.SetPixel(i, j, color);
                }
            }

            pictureBox1.Image = bitmap;

            pictureBox1.Refresh();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap img = new Bitmap(txtBoxPath.Text);

                Bitmap newImg = new Bitmap(img);

                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        int R = img.GetPixel(i, j).R;
                        newImg.SetPixel(i, j, ColorMap((((double)R / 255) * 2) - 1));
                    }
                }
                Bitmap resized = new Bitmap(newImg, pictureBox2.Width, pictureBox2.Height);
                pictureBox2.Image = resized;

                pictureBox2.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
