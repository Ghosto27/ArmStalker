using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;


namespace ArmStalkerCutter
{
    class Program
    {
        static void Main(string[] args)
        {
            //[C# Code Sample]
            // create an instance of Rasterization options
            EmfRasterizationOptions emfRasterizationOptions = new EmfRasterizationOptions();
            emfRasterizationOptions.BackgroundColor = Aspose.Imaging.Color.WhiteSmoke;
            // create an instance of PNG options
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.VectorRasterizationOptions = emfRasterizationOptions;
            //Declare variables to store file paths for input and output images
            string filePath = @"E:\armstalker.emf";
            string outPath = filePath + ".pdf";
            //Load an existing image into an instance of EMF class
            using (Aspose.Imaging.FileFormats.Emf.EmfImage image = (Aspose.Imaging.FileFormats.Emf.EmfImage)Aspose.Imaging.Image.Load(filePath))
            {
                using (FileStream outputStream = new FileStream(outPath, FileMode.Create))
                {
                    //Create an instance of Rectangle class with desired size
                    //Perform the crop operation on object of Rectangle class
                    image.Crop(new Aspose.Imaging.Rectangle(0, 4100, 10000, 1500));
                    // Set height and width
                    pdfOptions.VectorRasterizationOptions.PageWidth = image.Width;
                    pdfOptions.VectorRasterizationOptions.PageHeight = image.Height;
                    //Save the results to disk
                    image.Save(outputStream, pdfOptions);
                }
            }
        }
    }
}
