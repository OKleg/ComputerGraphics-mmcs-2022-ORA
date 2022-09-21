using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrolOleg_CG_2_1
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
            chart1.Visible = true;
            chart1.Series.Clear();
            chart1.Series.Add("PAL/NTCS");
            chart1.Series["PAL/NTCS"].Color = Color.Gray;
            Dictionary<int, int> h1 = new Dictionary<int, int>();
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
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());

                        float R = (float)((pixel & 0x00FF0000) >> 16);
                        float G = (float)((pixel & 0x0000FF00) >> 8);
                        float B = (float)((pixel & 0x000000FF));

                        
                        float gr1 = 0.299f * R + 0.587f * G + 0.114f * B;
                        float gr2 = 0.2126f * R + 0.7152f * G + 0.0722f * B;
                        float grr = (gr2 - gr1)*10;
                        UInt32 newPixel1 = 0xFF000000 | ((UInt32)gr1 << 16 | (UInt32)gr1 << 8 | (UInt32)gr1);
                        UInt32 newPixel2 = 0xFF000000 | ((UInt32)gr2 << 16 | (UInt32)gr2 << 8 | (UInt32)gr2);
                        UInt32 newPixel3 = 0xFF000000 | ((UInt32)Math.Abs(grr) << 16 | (UInt32)Math.Abs(grr) << 8 | (UInt32)Math.Abs(grr));
                        //int conv1 = Convert.ToInt32(newPixel1);

                        float Rnew1 = (float)((newPixel1 & 0x00FF0000) >> 16);
                        float Gnew1 = (float)((newPixel1 & 0x0000FF00) >> 8);
                        float Bnew1 = (float)((newPixel1 & 0x000000FF));

                        int value1 = ((int)(Rnew1 + Gnew1 + Bnew1)) / 3;

                        float Rnew2 = (float)((newPixel2 & 0x00FF0000) >> 16);
                        float Gnew2 = (float)((newPixel2 & 0x0000FF00) >> 8);
                        float Bnew2 = (float)((newPixel2 & 0x000000FF));

                        int value2 = ((int)(Rnew2 + Gnew2 + Bnew2)) / 3;

                        /*
                        if (h1.ContainsKey((int)newPixel1))  {
                            h1[(int)newPixel1]++;
                        }
                        else
                        {
                            h1[(int)newPixel1] = 0;
                        }*/

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
                        
                        output1.SetPixel(i, j, Color.FromArgb((int)newPixel1));
                        output2.SetPixel(i, j, Color.FromArgb((int)newPixel2));
                        output3.SetPixel(i, j, Color.FromArgb((int)newPixel3));
                    }
                pictureBox2.Image = output1;
                pictureBox3.Image = output2;
                pictureBox4.Image = output3;
                //==========================
                foreach (var i in h1)
                {
                    chart1.CreateGraphics();
                    chart1.Series["PAL/NTCS"].Points.AddXY(i.Key, i.Value);
                }

                foreach (var i in h2)
                {
                    chart2.CreateGraphics();
                    chart2.Series["HDTV"].Points.AddXY(i.Key, i.Value);
                }
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Gray2(object sender, EventArgs e)
        {
            chart2.Series.Clear();
            chart2.Series.Add("Gray2");
            chart2.Series["Gray2"].Color = Color.Gray;
            Dictionary<int, int> h2 = new Dictionary<int, int>();

            if (pictureBox1.Image != null)
            {
                Bitmap input = new Bitmap(pictureBox1.Image);
                Bitmap output = new Bitmap(input.Width, input.Height);
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());

                        float R = (float)((pixel & 0x00FF0000) >> 16);
                        float G = (float)((pixel & 0x0000FF00) >> 8);
                        float B = (float)((pixel & 0x000000FF));
                         
                        R = G = B = 0.2126f * R + 0.7152f * G + 0.0722f * B;
                       
                        UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16 | (UInt32)G << 8 | (UInt32)B);

                        if (h2.ContainsKey((int)newPixel))
                        {
                            h2[(int)newPixel]++;
                        }
                        else
                        {
                            h2[(int)newPixel] = 0;
                        }
                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));

                    }
                pictureBox3.Image = output;
                //==========================
                foreach (var i in h2)
                {
                    chart2.CreateGraphics();
                    chart2.Series["Gray2"].Points.AddXY(i.Key, i.Value);
                }

            }
        }
        

       
    }
}
