using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public partial class Form1 : Form
    {
        Bitmap SCR_IMG, DEST_IMG, TEMP_IMG;



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox3.Load("C:/Users/enesa/OneDrive/Masaüstü/image2/nat1.jpg");
            SCR_IMG = new Bitmap(pictureBox3.Image);
            DEST_IMG = new Bitmap(SCR_IMG.Width, SCR_IMG.Height);
            TEMP_IMG = new Bitmap(SCR_IMG.Width, SCR_IMG.Height);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 0.0275; K[0, 1] = 0.1102; K[0, 2] = 0.0275;
            K[1, 0] = 0.1102; K[1, 1] = 0.4421; K[1, 2] = 0.1102;
            K[2, 0] = 0.0275; K[2, 1] = 0.1102; K[2, 2] = 0.0275;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 0; K[0, 1] = -1; K[0, 2] = 0;
            K[1, 0] = -1; K[1, 1] = 4; K[1, 2] = -1;
            K[2, 0] = 0; K[2, 1] = -1; K[2, 2] = 0;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = -1; K[0, 1] = -1; K[0, 2] = -1;
            K[1, 0] = -1; K[1, 1] = 8; K[1, 2] = -1;
            K[2, 0] = -1; K[2, 1] = -1; K[2, 2] = -1;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 0; K[0, 1] = -1; K[0, 2] = 0;
            K[1, 0] = -1; K[1, 1] = 5; K[1, 2] = -1;
            K[2, 0] = 0; K[2, 1] = -1; K[2, 2] = 0;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = -1; K[0, 1] = -1; K[0, 2] = -1;
            K[1, 0] = -1; K[1, 1] = 9; K[1, 2] = -1;
            K[2, 0] = -1; K[2, 1] = -1; K[2, 2] = -1;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = pictureBox2.Image;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = hScrollBar1.Value.ToString();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = hScrollBar2.Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < pictureBox3.Image.Width; x++)
                for (int y = 0; y < pictureBox3.Image.Height; y++)
                {
                    int ResR;
                    int ResG;
                    int ResB;
                    ResR = hScrollBar1.Value + SCR_IMG.GetPixel(x, y).R;
                    ResG = hScrollBar1.Value + SCR_IMG.GetPixel(x, y).G;
                    ResB = hScrollBar1.Value + SCR_IMG.GetPixel(x, y).B;

                    if (ResR > 255) ResR = 255;
                    if (ResR < 0) ResR = 0;
                    if (ResG > 255) ResG = 255;
                    if (ResG < 0) ResG = 0;
                    if (ResB > 255) ResB = 255;
                    if (ResB < 0) ResB = 0;

                    DEST_IMG.SetPixel(x, y, Color.FromArgb(ResR, ResG, ResB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int C = hScrollBar2.Value;
            double F = (259.0 * (C + 255.0)) / (255.0 * (259.0 - C));
            for (int x = 0; x < pictureBox3.Image.Width; x++)
                for (int y = 0; y < pictureBox3.Image.Height; y++)
                {
                    double ResR, ResG, ResB;

                    ResR = F * (SCR_IMG.GetPixel(x, y).R - 128) + 128;
                    ResG = F * (SCR_IMG.GetPixel(x, y).G - 128) + 128;
                    ResB = F * (SCR_IMG.GetPixel(x, y).B - 128) + 128;
                    if (ResR > 255) ResR = 255;
                    if (ResR < 0) ResR = 0;
                    if (ResG > 255) ResG = 255;
                    if (ResG < 0) ResG = 0;
                    if (ResB > 255) ResB = 255;
                    if (ResB < 0) ResB = 0;

                    DEST_IMG.SetPixel(x, y, Color.FromArgb((int)ResR, (int)ResG, (int)ResB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            textBox4.Text = (hScrollBar3.Value/10.0).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            double Y = hScrollBar3.Value/10.0;
            
            for (int x = 0; x < pictureBox3.Image.Width; x++)
                for (int y = 0; y < pictureBox3.Image.Height; y++)
                {
                    double ResR, ResG, ResB;

                    ResR = 255 * Math.Pow(SCR_IMG.GetPixel(x, y).R / 255.0, 1 / Y);
                    ResG = 255 * Math.Pow(SCR_IMG.GetPixel(x, y).G / 255.0, 1 / Y);
                    ResB = 255 * Math.Pow(SCR_IMG.GetPixel(x, y).B / 255.0, 1 / Y);


                    DEST_IMG.SetPixel(x, y, Color.FromArgb((int)ResR, (int)ResG, (int)ResB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DEST_IMG.SetResolution(pictureBox3.Image.Width / 2, pictureBox3.Image.Height / 2);
            for(int x = 0;x< pictureBox3.Image.Width-2;x+=2)
                for( int y = 0; y<pictureBox3.Image.Height -2; y+=2)
                {
                    int PivotR = (SCR_IMG.GetPixel(x, y).R + SCR_IMG.GetPixel(x + 1, y).R +
            SCR_IMG.GetPixel(x, y + 1).R + SCR_IMG.GetPixel(x + 1, y + 1).R) / 4;
                    int PivotG = (SCR_IMG.GetPixel(x, y).G + SCR_IMG.GetPixel(x + 1, y).G +
            SCR_IMG.GetPixel(x, y + 1).G + SCR_IMG.GetPixel(x + 1, y + 1).G) / 4;
                    int PivotB = (SCR_IMG.GetPixel(x, y).B + SCR_IMG.GetPixel(x + 1, y).B +
            SCR_IMG.GetPixel(x, y + 1).B + SCR_IMG.GetPixel(x + 1, y + 1).B) / 4;

                    DEST_IMG.SetPixel(x / 2, y / 2, Color.FromArgb(PivotR, PivotG, PivotB));

                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < (pictureBox3.Image.Width - 2)/2; x++)
                for (int y = 0; y < (pictureBox3.Image.Height - 2)/2; y++)
                {
                    int PivotR = SCR_IMG.GetPixel(x, y).R;
                    int PivotG = SCR_IMG.GetPixel(x, y).G;
                    int PivotB = SCR_IMG.GetPixel(x, y).B;

                    DEST_IMG.SetPixel(x * 2, y * 2, Color.FromArgb(PivotR, PivotG, PivotB));
                    DEST_IMG.SetPixel(x * 2+1, y * 2, Color.FromArgb(PivotR, PivotG, PivotB));
                    DEST_IMG.SetPixel(x * 2, y * 2+1, Color.FromArgb(PivotR, PivotG, PivotB));
                    DEST_IMG.SetPixel(x * 2+1, y * 2+1, Color.FromArgb(PivotR, PivotG, PivotB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int x = 1; x < (pictureBox3.Image.Width - 2) / 2; x++)
                for (int y = 1; y < (pictureBox3.Image.Height - 2) / 2; y++)
                {
                    int PivotR = SCR_IMG.GetPixel(x, y).R;
                    int PivotG = SCR_IMG.GetPixel(x, y).G;
                    int PivotB = SCR_IMG.GetPixel(x, y).B;

                    TEMP_IMG.SetPixel(x * 2, y * 2, Color.FromArgb(PivotR, PivotG, PivotB));
                    TEMP_IMG.SetPixel(x * 2 + 1, y * 2, Color.FromArgb(PivotR, PivotG, PivotB));
                    TEMP_IMG.SetPixel(x * 2, y * 2 + 1, Color.FromArgb(PivotR, PivotG, PivotB));
                    TEMP_IMG.SetPixel(x * 2 + 1, y * 2 + 1, Color.FromArgb(PivotR, PivotG, PivotB));
                }
                    double[,] K = new double[3, 3];
                    K[0, 0] = 0.0275; K[0, 1] = 0.1102; K[0, 2] = 0.0275;
                    K[1, 0] = 0.1102; K[1, 1] = 0.4421; K[1, 2] = 0.1102;
                    K[2, 0] = 0.0275; K[2, 1] = 0.1102; K[2, 2] = 0.0275;

                    for (int x = 1; x < pictureBox3.Image.Width - 1; x++)
                        for (int y = 1; y < pictureBox3.Image.Height - 1; y++)
                        {
                            double ResR = 0;
                            double ResG = 0;
                            double ResB = 0;

                            for (int i = 0; i<3;i++)
                                for(int j = 0; j < 3; j++)
                                {
                                    ResR += K[i, j] * TEMP_IMG.GetPixel(x + i - 1, y + j - 1).R;
                                    ResG += K[i, j] * TEMP_IMG.GetPixel(x + i - 1, y + j - 1).G;
                                    ResB += K[i, j] * TEMP_IMG.GetPixel(x + i - 1, y + j - 1).B;

                                }
                    

                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button3_Click(object sender, EventArgs e)
            {
                double[,] K = new double[3, 3];
                K[0, 0] = 1 / 11.0; K[0, 1] = 1 / 11.0; K[0, 2] = 1 / 11.0;
                K[1, 0] = 1 / 11.0; K[1, 1] = 3 / 11.0; K[1, 2] = 1 / 11.0;
                K[2, 0] = 1 / 11.0; K[2, 1] = 1 / 11.0; K[2, 2] = 1 / 11.0;
                Convolution(K);
                pictureBox2.Image = DEST_IMG;


            }
            private void Convolution(double[,] K)
            {
                for (int x = 1; x < pictureBox3.Image.Width - 1; x++)
                    for (int y = 1; y < pictureBox3.Image.Height - 1; y++)
                    {
                        int ResR = 0;
                        int ResG = 0;
                        int ResB = 0;
                        // convolution
                        for (int i = 0; i < 3; i++)
                            for (int j = 0; j < 3; j++)
                            {
                                ResR += (int)(K[i, j] * SCR_IMG.GetPixel(x + i - 1, y + j - 1).R);
                                ResG += (int)(K[i, j] * SCR_IMG.GetPixel(x + i - 1, y + j - 1).G);
                                ResB += (int)(K[i, j] * SCR_IMG.GetPixel(x + i - 1, y + j - 1).B);
                            }
                        //assign to new image
                        if (ResR > 255) ResR = 255;
                        if (ResR < 0) ResR = 0;
                        if (ResG > 255) ResG = 255;
                        if (ResG < 0) ResG = 0;
                        if (ResB > 255) ResB = 255;
                        if (ResB < 0) ResB = 0;
                        DEST_IMG.SetPixel(x, y, Color.FromArgb(ResR, ResG, ResB));
                    }
            }
        }
    }
