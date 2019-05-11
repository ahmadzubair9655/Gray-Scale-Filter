using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoStar
{
    public partial class Gray_Scale_Filiter : Form
    {
        
        public Gray_Scale_Filiter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()==DialogResult.OK)
            {
                OriginalPictureBox.Image = new Bitmap(file.FileName);
                OriginalPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                FilterPictureBox.Image = new Bitmap(file.FileName);
                FilterPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(FilterPictureBox.Image);

            for(int i=0;i<bmp.Width;i++)
                for(int j=0;j<bmp.Height;j++)
                {
                    int red = bmp.GetPixel(i, j).R;
                    int green = bmp.GetPixel(i, j).G;
                    int blue = bmp.GetPixel(i, j).B;


                    int avg = (green + red + blue) / 3;

                    bmp.SetPixel(i, j, Color.FromArgb(avg,avg,avg));

                }

            FilterPictureBox.Image = bmp;


        }
    }
}
