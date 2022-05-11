// See https://aka.ms/new-console-template for more information

using ImageResizeApp.Helper;
using System.Drawing;
using System.Drawing.Imaging;

Console.WriteLine("The App is running ....");

var path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"));
var fileNames = Directory.EnumerateFiles(@$"{path}input");

foreach (var fileName in fileNames)
{
    using Image image = Image.FromFile(fileName);
    var width = image.Width;
    var height = image.Height;

    // image has width and height large than or equal 2048
    if (width >= 2048 && height >= 2048)
    {
        var edge = image.Width > image.Height ? image.Height / 2 : image.Width / 2;
        var bmp = ImageHelpers.ChangeImageToSquare(image, edge);
        var newFileName = @$"{path}output\{ImageHelpers.InsertSuffixForFileName(fileName, "-thumb")}";
        bmp.Save(newFileName, ImageFormat.Jpeg);
    }

    // image has width or height less than 2048
    else if ((width < 2048 || height < 2048)
            && (width > height ? (width / height) == 2 : (height / width) == 2))
    {
        var edge = image.Width > image.Height ? image.Height : image.Width;
        var bmp = ImageHelpers.ChangeImageToSquare(image, edge);
        var newFileName1 = @$"{path}output\{ImageHelpers.InsertSuffixForFileName(fileName, "-1")}";
        var newFileName2 = @$"{path}output\{ImageHelpers.InsertSuffixForFileName(fileName, "-2")}";
        bmp.Save(newFileName1, ImageFormat.Jpeg);
        bmp.Save(newFileName2, ImageFormat.Jpeg);
    }

    // others cases
    else
    {
        var bmp = ImageHelpers.ResizeImage(image, width / 2, height / 2);
        var newFileName = @$"{path}output\{ImageHelpers.InsertSuffixForFileName(fileName, string.Empty)}";
        bmp.Save(newFileName, ImageFormat.Jpeg);
    }
}

Console.WriteLine("Successful!!!");


Console.ReadKey();

