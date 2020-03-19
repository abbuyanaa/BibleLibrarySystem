using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace BibleLibrarySystem.Controllers
{
    class BookController
    {
        Random rand = new Random();
        public Image qrgen(string qrcode)
        {
            if (qrcode.Equals(""))
            {
                int first_qr = rand.Next(10000, 99999);
                int second_qr = rand.Next(10000, 99999);
                qrcode = first_qr.ToString() + second_qr.ToString();
            }
            else
            {
                qrcode = qrcode.ToString();
            }
            QRCoder.QRCodeGenerator qrCodeGenerator = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrcode, QRCoder.QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
            Image img = qrCode.GetGraphic(2);
            return img;
        }
    }
}
