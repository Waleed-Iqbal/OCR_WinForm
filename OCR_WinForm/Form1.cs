using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace OCR_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openFileDialog.FileName);
                image = PreprocesImage(image);
                //image.Save(@"D:\UpWork\OCR_WinForm\Preprocess_BeforeOCR.jpg");

                var ocr = new TesseractEngine(@"D:\UpWork\OCR_WinForm\OCR_WinForm\bin\Debug\tessdata", "eng", EngineMode.TesseractAndCube);
                var page = ocr.Process(image);
                var result = page.GetText().ToString().ToLower().Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                foreach (var item in result)
                    txtResult.Text += item.Trim() + Environment.NewLine;
            }
        }

        private Bitmap PreprocesImage(Bitmap image)
        {
            //You can change your new color here. Red,Green,LawnGreen any..
            Color newColor = Color.White;
            Color actualColor;
            //make an empty bitmap the same size as scrBitmap
            image = ResizeImage(image, image.Width * 5, image.Height * 5);
            //image.Save(@"D:\UpWork\OCR_WinForm\Preprocess_Resize.jpg");


            Bitmap newBitmap = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    //get the pixel from the scrBitmap image
                    actualColor = image.GetPixel(i, j);
                    // > 150 because.. Images edges can be of low pixel colr. if we set all pixel color to new then there will be no smoothness left.
                    if (actualColor.R > 135 && actualColor.G > 135 && actualColor.B > 135)
                        newBitmap.SetPixel(i, j, newColor);
                    else
                        newBitmap.SetPixel(i, j, Color.Black);
                }
            }
            return newBitmap;
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution , image.VerticalResolution * 2);//2,3
            //image.Save(@"D:\UpWork\OCR_WinForm\Preprocess_HighRes.jpg");
            
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceOver;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.Clamp);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
