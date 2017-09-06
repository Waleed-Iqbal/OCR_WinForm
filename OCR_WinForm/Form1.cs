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
    public partial class OCR : Form
    {
        public OCR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openFileDialog.FileName);
                pbImageBeforeOCR.Image = image;
                this.Text = "OCR in progress";

                image = PreprocesImage(image);
                //image.Save(@"D:\UpWork\OCR_WinForm\Preprocess_BeforeOCR.jpg");
                pbImageBeforeOCR.Image = image;

                var ocr = new TesseractEngine(@"D:\UpWork\OCR_WinForm\OCR_WinForm\bin\Debug\tessdata", "eng", EngineMode.TesseractAndCube);
                var page = ocr.Process(image);
                var result = page.GetText().ToString().ToLower().Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                foreach (var item in result)
                    txtResult.Text += item.Trim() + Environment.NewLine;

                this.Text = "OCR completed";
            }
        }

        private Bitmap PreprocesImage(Bitmap image)
        {
            //You can change your new color here. Red,Green,LawnGreen any..
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
                        newBitmap.SetPixel(i, j, Color.White);
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


        // May need this at some point
        public static Bitmap ImageSharpen(Bitmap image)
        {
            Bitmap sharpenImage = new Bitmap(image.Width, image.Height);

            int filterWidth = 3;
            int filterHeight = 3;
            int w = image.Width;
            int h = image.Height;

            double[,] filter = new double[filterWidth, filterHeight];

            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;

            double factor = 1.0;
            double bias = 0.0;

            Color[,] result = new Color[image.Width, image.Height];

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    //=====[REMOVE LINES]========================================================
                    // Color must be read per filter entry, not per image pixel.
                    //Color imageColor = image.GetPixel(x, y);
                    //===========================================================================

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + w) % w;
                            int imageY = (y - filterHeight / 2 + filterY + h) % h;

                            //=====[INSERT LINES]========================================================
                            // Get the color here - once per fiter entry and image pixel.
                            Color imageColor = image.GetPixel(imageX, imageY);
                            //===========================================================================

                            red += imageColor.R * filter[filterX, filterY];
                            green += imageColor.G * filter[filterX, filterY];
                            blue += imageColor.B * filter[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                        int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                        int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    sharpenImage.SetPixel(i, j, result[i, j]);
                }
            }
            return sharpenImage;
        }
    }
}
