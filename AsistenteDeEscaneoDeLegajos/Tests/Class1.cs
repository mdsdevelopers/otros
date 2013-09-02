using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;


namespace TestAsistenteDeEscaneoDeLegajos
{
    class Class1
    {
        private Font printFont;
        private StreamReader streamToPrint;
        private Image Orig;
        private Image Converted;
        private Hashtable m_knownColors = new Hashtable((int)Math.Pow(2, 20), 1.0f); 
 
        public Class1()
        {
            //InitializeComponent();
        }
 
 
        private int GetPixelInfoSize(PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.Format24bppRgb:
                    {
                        return 3;
                    }
                default:
                    {
                        throw new ApplicationException("Only 24bit colors supported now");
                    }
            }
 
        }
 
 
        // The PrintPage event is raised for each page to be printed.
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
 
            ev.Graphics.PageScale = 25;// Print at 100% or 1:1 ratio 
            //ev.PageSettings.PrinterSettings.
            ev.Graphics.DrawImageUnscaled(System.Drawing.Image.FromFile("..\\..\\..\\TestManipulacionImagenes\\Imagenes\\120dpi24bitsLZW.tif"),0,0);
            ev.HasMorePages = false;
            return;
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
 
            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);
 
            // Print each line of the file.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }
 
            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        //private void browseFile1_PathChanged(object sender, Saint.Controls.BrowseFile.TextChangedEventArgs e)
        //{
        //    Orig = Saint.GDI.Graphics.ImageFromFile(browseFile1.Text);
        //    pbOrig.Image = Orig;
        //    pbOrig.SizeMode = PictureBoxSizeMode.Zoom;
        //    Converted = (Image)ConvertTo8bppFormat((Bitmap)Orig);
        //    Converted = pbConverted.Image = Converted;
        //    pbConverted.SizeMode = PictureBoxSizeMode.Zoom;
        //}
 
   
        public Bitmap ConvertTo8bppFormat(Bitmap bmpSource)
        {
            int imageWidth = bmpSource.Width;
            int imageHeight = bmpSource.Height;
 
            Bitmap bmpDest = null;
            BitmapData bmpDataDest = null;
            BitmapData bmpDataSource = null;
 
            try
            {
                // Create new image with 8BPP format
                bmpDest = new Bitmap(
                    imageWidth,
                    imageHeight,
                    PixelFormat.Format8bppIndexed
                    );
 
                // Lock bitmap in memory
                bmpDataDest = bmpDest.LockBits(
                    new Rectangle(0, 0, imageWidth, imageHeight),
                    ImageLockMode.ReadWrite,
                    bmpDest.PixelFormat
                    );
 
                bmpDataSource = bmpSource.LockBits(
                    new Rectangle(0, 0, imageWidth, imageHeight),
                    ImageLockMode.ReadOnly,
                    bmpSource.PixelFormat
                );
 
                int pixelSize = GetPixelInfoSize(bmpDataSource.PixelFormat);
                byte[] buffer = new byte[imageWidth * imageHeight * pixelSize];
                byte[] destBuffer = new byte[imageWidth * imageHeight];
 
                // Read all data to buffer
                ReadBmpData(bmpDataSource, buffer, pixelSize, imageWidth, imageHeight);
 
                // Get color indexes
                MatchColors(buffer, destBuffer, pixelSize, bmpDest.Palette);
 
                // Copy all colors to destination bitmaps
                WriteBmpData(bmpDataDest, destBuffer, imageWidth, imageHeight);
 
                return bmpDest;
            }
            finally
            {
                if (bmpDest != null) bmpDest.UnlockBits(bmpDataDest);
                if (bmpSource != null) bmpSource.UnlockBits(bmpDataSource);
            }
        }
 
        /// <summary>
        /// Reads all bitmap data at once
        /// </summary>
        private void ReadBmpData(
            BitmapData bmpDataSource,
            byte[] buffer,
            int pixelSize,
            int width,
            int height)
        {
            // Get unmanaged data start address
            int addrStart = bmpDataSource.Scan0.ToInt32();
 
            for (int i = 0; i < height; i++)
            {
                // Get address of next row
                IntPtr realByteAddr = new IntPtr(addrStart +
                    System.Convert.ToInt32(i * bmpDataSource.Stride)
                    );
 
                // Perform copy from unmanaged memory
                // to managed buffer
                Marshal.Copy(
                    realByteAddr,
                    buffer,
                    (int)(i * width * pixelSize),
                    (int)(width * pixelSize)
                );
            }
        }
 
        /// <summary>
        /// Writes bitmap data to unmanaged memory
        /// </summary>
        private void WriteBmpData(
            BitmapData bmpDataDest,
            byte[] destBuffer,
            int imageWidth,
            int imageHeight)
        {
            // Get unmanaged data start address
            int addrStart = bmpDataDest.Scan0.ToInt32();
 
            for (int i = 0; i < imageHeight; i++)
            {
                // Get address of next row
                IntPtr realByteAddr = new IntPtr(addrStart +
                    System.Convert.ToInt32(i * bmpDataDest.Stride)
                    );
 
                // Perform copy from managed buffer
                // to unmanaged memory
                Marshal.Copy(
                    destBuffer,
                    i * imageWidth,
                    realByteAddr,
                    imageWidth
                );
            }
        }
 
        /// <summary>
        /// This method matches indices from pallete ( 256 colors )
        /// for each given 24bit color
        /// </summary>
        /// <param name="buffer">Buffer that contains color for each pixel</param>
        /// <param name="destBuffer">Destination buffer that will contain index 
        /// for each color</param>
        /// <param name="pixelSize">Size of pixel info ( 24bit colors supported )</param>
        /// <param name="pallete">Colors pallete ( 256 colors )</param>
        private void MatchColors(
            byte[] buffer,
            byte[] destBuffer,
            int pixelSize,
            ColorPalette pallete)
        {
            int length = destBuffer.Length;
 
            // Temp storage for color info
            byte[] temp = new byte[pixelSize];
 
            int palleteSize = pallete.Entries.Length;
 
            int mult_1 = 256;
            int mult_2 = 256 * 256;
 
            int currentKey = 0;
 
            // For each color
            for (int i = 0; i < length; i++)
            {
                // Get next color
                Array.Copy(buffer, i * pixelSize, temp, 0, pixelSize);
 
                // Build key for hash table
                currentKey = temp[0] + temp[1] * mult_1 + temp[2] * mult_2;
 
                // If hash table already contains such color - fetch it
                // Otherwise perform calculation of similar color and save it to HT
                if (!m_knownColors.ContainsKey(currentKey))
                {
                    destBuffer[i] = GetSimilarColor(pallete, temp, palleteSize);
                    m_knownColors.Add(currentKey, destBuffer[i]);
                }
                else
                {
                    destBuffer[i] = (byte)m_knownColors[currentKey];
                }
            }// for
        }
 
        /// <summary>
        /// Returns Similar color
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private byte GetSimilarColor(ColorPalette palette, byte[] color, int palleteSize)
        {
            byte minDiff = byte.MaxValue;
            byte index = 0;
 
            if (color.Length == 3)// Implemented for 24bpp color
            {
                // Loop all pallete ( 256 colors )
                for (int i = 0; i < palleteSize - 1; i++)
                {
                    // Calculate similar color
                    byte currentDiff = GetMaxDiff(color, palette.Entries[i]);
 
                    if (currentDiff < minDiff)
                    {
                        minDiff = currentDiff;
                        index = (byte)i;
                    }
                } // for
            }
            else// TODO implement it for other color types
            {
                throw new ApplicationException("Only 24bit colors supported now");
            }
 
            return index;
        }
 
        /// <summary>
        /// Return similar color
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static byte GetMaxDiff(byte[] a, Color b)
        {
            // Get difference between components ( red green blue )
            // of given color and appropriate components of pallete color
            byte bDiff = a[0] > b.B ? (byte)(a[0] - b.B) : (byte)(b.B - a[0]);
            byte gDiff = a[1] > b.G ? (byte)(a[1] - b.G) : (byte)(b.G - a[1]);
            byte rDiff = a[2] > b.R ? (byte)(a[2] - b.R) : (byte)(b.R - a[2]);
 
            // Get max difference
            byte max = bDiff > gDiff ? bDiff : gDiff;
            max = max > rDiff ? max : rDiff;
 
            return max;
        }
    }
}
 
    