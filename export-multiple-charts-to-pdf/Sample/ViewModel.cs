using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Sample
{
    public class ViewModel
    {
        private ICommand exportButtonCommand;

        public List<Model> Data { get; set; }

        public List<Model> Data1 { get; set; }

        public List<Model> Data2 { get; set; }

        public List<Model> Data3 { get; set; }

        public List<Model> Data4 { get; set; }

        public ICommand ExportButtonCommand
        {
            get
            {
                return exportButtonCommand;
            }
            set
            {
                exportButtonCommand = value;
            }
        }

        public ViewModel()
        {
            DateTime JanDateTime = new DateTime(2020, 01, 01); 
            DateTime FebDateTime = new DateTime(2020, 02, 01);
            DateTime MarchDateTime = new DateTime(2020, 03, 01);
            DateTime AprilDateTime = new DateTime(2020, 04, 01);
            DateTime MayDateTime = new DateTime(2020, 04, 01);
            Random random = new Random();
            Data = new List<Model>();
            for (int i = 0; i < 31; i++)
            {
                Data.Add(new Model { XValue = JanDateTime.AddDays(i), YValue = random.Next(0, 100) });
            };

            Data1 = new List<Model>();
            for (int j = 0; j < 28; j++)
            {
                Data1.Add(new Model { XValue = FebDateTime.AddDays(j), YValue = random.Next(0, 100) });
            };
            Data2 = new List<Model>();
            for (int i = 0; i < 31; i++)
            {
                Data2.Add(new Model { XValue = MarchDateTime.AddDays(i), YValue = random.Next(0, 100) });
            };

            Data3 = new List<Model>();
            for (int j = 0; j < 30; j++)
            {
                Data3.Add(new Model { XValue = AprilDateTime.AddDays(j), YValue = random.Next(0, 100) });
            };

            Data4 = new List<Model>();
            for (int j = 0; j < 31; j++)
            {
                Data4.Add(new Model { XValue = MayDateTime.AddDays(j), YValue = random.Next(0, 100) });
            };

            ExportButtonCommand = new ExportCommand(ExportChart);
        }

        private PdfDocument pdfDoc;
        private PdfPage page1;
        private int spacing = 20;
        private int height = 60;
        private int x = 10;

        public void ExportChart(object obj)
        {
            var grid = obj as Grid;
            if (grid != null)
            {
                pdfDoc = new PdfDocument();
                pdfDoc.PageSettings.Size = PdfPageSize.A4;
                pdfDoc.PageSettings.Margins.All = 0;
                page1 = new PdfPage();
                page1 = pdfDoc.Pages.Add();
                float pageWidth = page1.Size.Width - spacing;
                float top = 50;

                for (int i = 0; i < grid.Children.Count - 2; i++)
                {
                    var chart = (grid.Children[i] as StackPanel).Children[0] as SfChart;
                    if (chart == null) return;

                    MemoryStream outStream = new MemoryStream();
                    chart.Save(outStream, new JpegBitmapEncoder());
                    PdfBitmap pdfBitmap1 = new PdfBitmap(outStream);
                    page1.Graphics.DrawImage(pdfBitmap1, new RectangleF(x, top + (i * (height + spacing)), pageWidth, height));
                    outStream.Close();
                }

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
}
