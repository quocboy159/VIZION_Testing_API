using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageResizeApp.Helper
{
    public static class ImageHelpers
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var resultImage = new Bitmap(width, height);
            resultImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(resultImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using var wrapMode = new ImageAttributes();
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
            return resultImage;
        }

        // Find the center of the image by dividing its width/height by 2.
        // Then subtract from those x/y values, half the width/height(edge) of the image(square)
        public static Bitmap ChangeImageToSquare(Image image, int edge)
        {
            int x = (image.Width / 2) - (edge / 2);
            int y = (image.Height / 2) - (edge / 2);

            Rectangle cropRect = new(x, y, edge, edge);
            Bitmap destination = new(cropRect.Width, cropRect.Height);

            using Graphics graphics = Graphics.FromImage(destination);
            graphics.DrawImage(image, new Rectangle(0, 0, destination.Width, destination.Height), cropRect, GraphicsUnit.Pixel);

            return destination;
        }

        public static string InsertSuffixForFileName(string fileName, string suffix, string extension = "jpeg")
        {
            var name = fileName.Split("\\").Last().Split(".").First();
            return $"{name}{suffix}.{extension}";
        }
    }
}
