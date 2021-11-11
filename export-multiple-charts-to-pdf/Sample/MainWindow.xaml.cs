using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.Win32;
using System.Drawing;

namespace Sample1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PdfDocument pdfDoc;
        private PdfPage page1;
        private int spacing = 20;
        private int height = 60;
        private int x = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            pdfDoc = new PdfDocument();
            pdfDoc.PageSettings.Size = PdfPageSize.A4;
            pdfDoc.PageSettings.Margins.All = 0;
            page1 = new PdfPage();
            page1 = pdfDoc.Pages.Add();
            float pageWidth = page1.Size.Width - spacing;

            MemoryStream outStream1 = new MemoryStream();
            chart1.Save(outStream1, new JpegBitmapEncoder());
            PdfBitmap pdfBitmap1 = new PdfBitmap(outStream1);
            page1.Graphics.DrawImage(pdfBitmap1, new RectangleF(x, 50, pageWidth, height));
            outStream1.Close();

            MemoryStream outStream2 = new MemoryStream();
            chart2.Save(outStream2, new JpegBitmapEncoder());
            PdfBitmap pdfBitmap2 = new PdfBitmap(outStream2);
            page1.Graphics.DrawImage(pdfBitmap2, new RectangleF(x, 130, pageWidth, height));
            outStream2.Close();

            MemoryStream outStream3 = new MemoryStream();
            chart3.Save(outStream3, new JpegBitmapEncoder());
            PdfBitmap pdfBitmap3 = new PdfBitmap(outStream3);
            page1.Graphics.DrawImage(pdfBitmap3, new RectangleF(x, 210, pageWidth, height));
            outStream3.Close();

            MemoryStream outStream4 = new MemoryStream();
            chart4.Save(outStream4, new JpegBitmapEncoder());
            PdfBitmap pdfBitmap4 = new PdfBitmap(outStream4);
            page1.Graphics.DrawImage(pdfBitmap4, new RectangleF(x, 290, pageWidth, height));
            outStream4.Close();

            MemoryStream outStream5 = new MemoryStream();
            chart5.Save(outStream5, new JpegBitmapEncoder());
            PdfBitmap pdfBitmap5 = new PdfBitmap(outStream5);
            page1.Graphics.DrawImage(pdfBitmap5, new RectangleF(x, 370, pageWidth, height));
            outStream5.Close();

            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "PDF document (*.pdf)|*.pdf"
            };
            Boolean? result = dialog.ShowDialog();
            string fileName = dialog.FileName;
            if ((bool)result)
            {
                pdfDoc.Save(fileName);
            }
            pdfDoc.Dispose();
        }
    }
}

