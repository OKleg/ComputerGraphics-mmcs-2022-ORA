using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace CG_lab_2_1
{
    public partial class Form1 : Form
    {
        
        public float Y1,Y2;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        { 
  
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                  
                    
                    Gray( sender,  e);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }
 


        private void Gray(object sender, EventArgs e)
        {
            
            //1
            chart1.Visible = true;
            chart1.Series.Clear();
            chart1.Series.Add("PAL/NTCS");
            chart1.Series["PAL/NTCS"].Color = Color.Gray;
            Dictionary<int, int> h1 = new Dictionary<int, int>();
            //2
            chart2.Visible = true;
            chart2.Series.Clear();
            chart2.Series.Add("HDTV");
            chart2.Series["HDTV"].Color = Color.Gray;
            Dictionary<int, int> h2 = new Dictionary<int, int>();

            if (pictureBox1.Image != null)
            {
                Bitmap input = new Bitmap(pictureBox1.Image);
                Bitmap output1 = new Bitmap(input.Width, input.Height);
                Bitmap output2 = new Bitmap(input.Width, input.Height);
                Bitmap output3 = new Bitmap(input.Width, input.Height);

                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        int R = input.GetPixel(i, j).R;
                        int G = input.GetPixel(i, j).G;
                        int B = input.GetPixel(i, j).B;


                        int gr1 = (int)Math.Round(0.299f * R + 0.587f * G + 0.114f * B);
                        int gr2 = (int)Math.Round(0.2126f * R + 0.7152f * G + 0.0722f * B);
                        int grr = Math.Abs(gr2 - gr1);
                        
                        Color newPixel1 = Color.FromArgb(255, gr1, gr1, gr1);
                        Color newPixel2 = Color.FromArgb(255, gr2, gr2, gr2);
                        Color newPixel3 = Color.FromArgb(255, grr, grr, grr);


                        int value1 = (newPixel1.R)+1;
                        int value2 = (newPixel2.R)+1;
                       
                        if (h1.ContainsKey(value1))
                        {
                            h1[value1]++;
                        }
                        else
                        {
                            h1[value1] = 0;
                        }

                        if (h2.ContainsKey(value2))
                        {
                            h2[value2]++;
                        }
                        else
                        {
                            h2[value2] = 0;
                        }
                        
                        output1.SetPixel(i, j, newPixel1);
                        output2.SetPixel(i, j, newPixel2);
                        output3.SetPixel(i, j, newPixel3);
                    }
                pictureBox2.Image = output1;
                pictureBox3.Image = output2;
                pictureBox4.Image = output3;
                //==========================
                foreach (var i in h1)
                {
                    //chart1.CreateGraphics();
                    chart1.Series["PAL/NTCS"].Points.AddXY(i.Key, i.Value);
                }

                foreach (var i in h2)
                {
                    //chart2.CreateGraphics();
                    chart2.Series["HDTV"].Points.AddXY(i.Key, i.Value);
                }
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
