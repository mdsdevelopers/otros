using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net.Mime;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TestAsistenteDeEscaneoDeLegajos
{
    [TestClass]
    public class TestManipulacionDeImagenes
    {
        [TestMethod]
        public void deberia_poder_abrir_una_imagen_tiff_y_guardarla_en_png_8_bits()
        {
            var c = new Class1();

            //var tmp = new Bitmap(Bitmap.FromFile("..\\..\\..\\..\\TestAsistenteDeEscaneoDeLegajos\\Imagenes\\SKMBT_28313082018550.tif", true));
            var tmp = Bitmap.FromFile("..\\..\\..\\..\\TestAsistenteDeEscaneoDeLegajos\\Imagenes\\SKMBT_28313082018550.tif");
            //var tmp = new Bitmap(Bitmap.FromFile("..\\..\\..\\TestAsistenteDeEscaneoDeLegajos\\Imagenes\\120dpi24bitsLZW.tif", true));

            //Bitmap origen = changePixelFormat(tmp, PixelFormat.Format24bppRgb, 200);
            //Bitmap origen = new Bitmap(5, 5, PixelFormat.Format24bppRgb);

            //var destino = c.ConvertTo8bppFormat(origen);
            tmp.Save("..\\..\\..\\..\\TestAsistenteDeEscaneoDeLegajos\\Imagenes\\e.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }


        private static Bitmap changePixelFormat(Bitmap input, PixelFormat format, int destinationResolution)
        {
            var resolution_ratio = destinationResolution / input.HorizontalResolution;
            var new_width = input.Width * resolution_ratio;
            var new_height = input.Height * resolution_ratio;


            Bitmap retval = new Bitmap((int)new_width, (int)new_height, format);

            //retval.SetResolution(input.HorizontalResolution, input.VerticalResolution);
            
            retval.SetResolution(destinationResolution, destinationResolution);
            Graphics g = Graphics.FromImage(retval);
            g.DrawImage(input, 0, 0);
            g.Dispose();
            return retval;
        }
    }
}
