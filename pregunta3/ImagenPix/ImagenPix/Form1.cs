using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagenPix
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Color c = new Color();
        Color cleido = new Color();

        int x = 0, y = 0;
        int mR = 0, mG = 0, mB = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
       
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            textBox4.Text = x.ToString();
            textBox5.Text = y.ToString();
            
            mR = 0; mG = 0; mB = 0;
            for (int i = x; i < x + 10; i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            textBox1.Text = mR.ToString();
            textBox2.Text = mG.ToString();
            textBox3.Text = mB.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c = bmp.GetPixel(10, 10);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            cleido = bmp.GetPixel(x, y);
            GrabarDatos();
            Bitmap bmp3 = new Bitmap(bmp.Width, bmp.Height);
            //Color c = new Color();
            for (int i = 0; i < bmp3.Width; i++)
                for (int j = 0; j < bmp3.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10)))
                    {
                        bmp3.SetPixel(i, j, Color.Yellow);
                    }
                    else
                    {
                        bmp3.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }

                }
            pictureBox1.Image = bmp3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cleido = bmp.GetPixel(x, y);
            GrabarDatos();
            Bitmap bmp3 = new Bitmap(bmp.Width, bmp.Height);
            //Color c = new Color();
            for (int i = 0; i < bmp3.Width; i++)
                for (int j = 0; j < bmp3.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10)))
                    {
                        bmp3.SetPixel(i, j, Color.Blue);
                    }
                    else
                    {
                        bmp3.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }

                }
            pictureBox1.Image = bmp3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cleido = bmp.GetPixel(x, y);
            GrabarDatos();
            Bitmap bmp3 = new Bitmap(bmp.Width, bmp.Height);
            //Color c = new Color();
            for (int i = 0; i < bmp3.Width; i++)
                for (int j = 0; j < bmp3.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10)))
                    {
                        bmp3.SetPixel(i, j, Color.Cyan);
                    }
                    else
                    {
                        bmp3.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }

                }
            pictureBox1.Image = bmp3;
        }

        private void GrabarDatos()
        {
            c = bmp.GetPixel(10, 10);
            StreamWriter archivo = new StreamWriter("pintura.txt", true);
            archivo.WriteLine(x.ToString());
            archivo.WriteLine(y.ToString());

            archivo.WriteLine(c.R.ToString());
            archivo.WriteLine(c.G.ToString());
            archivo.WriteLine(c.B.ToString());

            archivo.Close();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("pintura.txt"))
            {
                StreamWriter archivo = new StreamWriter("pintura.txt");
                archivo.Close();

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //**********IMPRIMIR EN CELDA-GRID LOS DATOS X,Y,R,G,B**********
            StreamReader archivo = new StreamReader("pintura.txt");
            while (!archivo.EndOfStream)
            {
                string xx = archivo.ReadLine();
                string yy = archivo.ReadLine();

                string PR = archivo.ReadLine();
                string PG = archivo.ReadLine();
                string PB = archivo.ReadLine();

                dataGridView1.Rows.Add(xx, yy, PR, PG, PB);

            }
            archivo.Close();

            //-----------PARA EL PRIMERA FILA 1------------------
            int punto_x1 = 0, punto_y1 = 0;

            punto_x1 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            punto_y1 = Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value);

            cleido = bmp.GetPixel(punto_x1, punto_y1);
            Bitmap bmp_x1_y1 = new Bitmap(pictureBox1.Image);
            Bitmap bmpxy1 = new Bitmap(bmp_x1_y1.Width, bmp_x1_y1.Height);
            //Color c = new Color();
            for (int i = 0; i < bmpxy1.Width; i++)
                for (int j = 0; j < bmpxy1.Height; j++)
                {
                    c = bmp_x1_y1.GetPixel(i, j);
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10)))
                    {
                        bmpxy1.SetPixel(i, j, Color.Yellow);
                    }
                    else
                    {
                        bmpxy1.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }

                }
            pictureBox1.Image = bmpxy1;

            //-----------PARA LA SEGUNDA FILA 2------------------
            int punto_x2 = 0, punto_y2 = 0;

            punto_x2 = Convert.ToInt32(dataGridView1.Rows[1].Cells[0].Value);
            punto_y2 = Convert.ToInt32(dataGridView1.Rows[1].Cells[1].Value);

            cleido = bmp.GetPixel(punto_x2, punto_y2);
            Bitmap bmp_x2_y2 = new Bitmap(pictureBox1.Image);
            Bitmap bmpxy2 = new Bitmap(bmp_x2_y2.Width, bmp_x2_y2.Height);
            //Color c = new Color();
            for (int i = 0; i < bmpxy2.Width; i++)
                for (int j = 0; j < bmpxy2.Height; j++)
                {
                    c = bmp_x2_y2.GetPixel(i, j);
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10)))
                    {
                        bmpxy2.SetPixel(i, j, Color.Blue);
                    }
                    else
                    {
                        bmpxy2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }

                }
            pictureBox1.Image = bmpxy2;

            //-----------PARA LA TERCERA FILA 3------------------
            int punto_x3 = 0, punto_y3 = 0;

            punto_x3 = Convert.ToInt32(dataGridView1.Rows[2].Cells[0].Value);
            punto_y3 = Convert.ToInt32(dataGridView1.Rows[2].Cells[1].Value);

            cleido = bmp.GetPixel(punto_x3, punto_y3);
            Bitmap bmp_x3_y3 = new Bitmap(pictureBox1.Image);
            Bitmap bmpxy3 = new Bitmap(bmp_x3_y3.Width, bmp_x3_y3.Height);
            //Color c = new Color();
            for (int i = 0; i < bmpxy3.Width; i++)
                for (int j = 0; j < bmpxy3.Height; j++)
                {
                    c = bmp_x3_y3.GetPixel(i, j);
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10)))
                    {
                        bmpxy3.SetPixel(i, j, Color.Cyan);
                    }
                    else
                    {
                        bmpxy3.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }

                }
            pictureBox1.Image = bmpxy3;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPEG|*.jpg|Archivos GIF|*.gif";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;

          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
