using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgColorChange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Imagem";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGrayScale_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Bitmap originalBmp = (Bitmap)bmp.Clone();
            for (int x = 0; x < bmp.Width; x++)
            {
                for(int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int val = (int)((c.R * 0.299f + c.G * 0.587f + c.B * 0.114f));
                    bmp.SetPixel(x, y, Color.FromArgb(255, val, val, val));
                }
            }
            pictureBox1.Image = (Bitmap)originalBmp;
            pictureBox2.Image = (Bitmap)bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int val = (int)((c.R + c.B + c.G) / 3);
                    bmp.SetPixel(x, y, Color.FromArgb(255, val, val, val));
                }
            }
            pictureBox2.Image = (Bitmap)bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                }
                pictureBox2.Image.Save(sfd.FileName, format);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                }
                pictureBox3.Image.Save(sfd.FileName, format);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox2.Image;
            Bitmap originalBmp = (Bitmap)bmp.Clone();
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);

                    int value = c.R;
                    int upperBound = 255;
                    int lowerBound = 0;
                    if(value < int.Parse(textBoxThreshold.Text))
                    {
                        value = value - int.Parse(textBoxDecrease.Text);
                        if(value < lowerBound)
                        {
                            value = 0;
                        }
                    }
                    else
                    {
                        value = value + int.Parse(textBoxIncrease.Text);
                        if(value > upperBound)
                        {
                            value = 255;
                        }
                    }

                    bmp.SetPixel(x, y, Color.FromArgb(255, value, value, value));
                }
            }
            pictureBox2.Image = (Bitmap)originalBmp;
            pictureBox3.Image = (Bitmap)bmp;
        }
    }
}
