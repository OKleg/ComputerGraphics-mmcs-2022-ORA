using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Split_to_RGB
{
    public partial class Form1 : Form
    {
        Image SelectedImage;
        public Form1()
        {
            InitializeComponent();
            //setting thing that picture transform to picturebox size
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SelectedImage = Image.FromFile(dlg.FileName);
                }

            }
            pictureBox1.Image = SelectedImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return; // doing nothing if image didnt selected
            Bitmap bmp = new Bitmap(SelectedImage); //setting main bitmap 
            (int width, int height) = (bmp.Width, bmp.Height); //getting sizes of bitmap (jsut size of working area) 

            //creating array of bitmaps for R,G,B 
            Dictionary<Color, Bitmap> bmps = new Dictionary<Color, Bitmap>();
            bmps.Add(Color.Red, new Bitmap(bmp));;
            bmps.Add(Color.Green, new Bitmap(bmp));
            bmps.Add(Color.Blue, new Bitmap(bmp));

            //get red green blue images
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //get pixel value
                    var rgb = bmp.GetPixel(x, y);

                    //set red green blue bitmaps
                    bmps[Color.Red].SetPixel(x, y, Color.FromArgb(rgb.A, rgb.R, 0, 0));
                    bmps[Color.Green].SetPixel(x, y, Color.FromArgb(rgb.A, 0, rgb.G, 0));
                    bmps[Color.Blue].SetPixel(x, y, Color.FromArgb(rgb.A, 0, 0, rgb.B));

                }
            }

            //set images into imageboxes
            pictureBox2.Image = bmps[Color.Red];
            pictureBox3.Image = bmps[Color.Green];
            pictureBox4.Image = bmps[Color.Blue];


        }
    }
}
