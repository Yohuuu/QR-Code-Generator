using System.Drawing;
using System.Windows;
using Microsoft.Win32;
using QRCoder;

namespace QR_Code_Generator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
               
        private void generateButton_Click(object sender, RoutedEventArgs e)
        {           
            // QR code data
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox.Text, QRCodeGenerator.ECCLevel.Q);

            // Make QR code graphic
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".jpg";
            saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            
            if (saveFileDialog.ShowDialog() == true)
            {
                qrCodeImage.Save(saveFileDialog.FileName);
            }
        }
    }
}
