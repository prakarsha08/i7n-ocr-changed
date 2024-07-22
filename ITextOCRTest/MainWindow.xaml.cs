using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using iText.Kernel.Pdf;
using iText.Pdfocr;
using iText.Pdfocr.Tesseract4;

namespace ITextOCRTest
{
    public partial class MainWindow : Window
    {
        private static string OUTPUT_PDF = "C:\\Users\\prakarsha08\\Downloads\\std_pre1.pdf"; // Add desired file path
        private static readonly Tesseract4OcrEngineProperties tesseract4OcrEngineProperties = new Tesseract4OcrEngineProperties();

        private static IList<FileInfo> LIST_IMAGES_OCR = new List<FileInfo>
        {
            new FileInfo("C:\\Users\\prakarsha08\\Downloads\\std_pre.png") // Add desired image path 
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartOcrButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tesseractReader = new Tesseract4LibOcrEngine(tesseract4OcrEngineProperties);
                tesseract4OcrEngineProperties.SetPathToTessData(new FileInfo(@"Dependencies\Ocr")); // Corrected path

                var properties = new OcrPdfCreatorProperties();
                var ocrPdfCreator = new OcrPdfCreator(tesseractReader);

                IList<Stream> imageStreams = ConvertFileInfoListToStreamList(LIST_IMAGES_OCR);

                using (var writer = new PdfWriter(OUTPUT_PDF))
                {
                    var documentProperties = new DocumentProperties();
                    ocrPdfCreator.CreatePdf(LIST_IMAGES_OCR, imageStreams, writer, documentProperties).Close();
                }

                ResultTextBlock.Text = "PDF created successfully at " + OUTPUT_PDF;
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = "Error: " + ex.Message;
            }
        }
        private IList<Stream> ConvertFileInfoListToStreamList(IList<FileInfo> fileInfoList)
        {
            IList<Stream> streamList = new List<Stream>();
            foreach (var fileInfo in fileInfoList)
            {
                streamList.Add(new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read));
            }
            return streamList;
        }
    }
}
