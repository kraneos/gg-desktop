using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Seggu.Dtos;
using Seggu.Helpers;
using Seggu.Services.Interfaces;
using System;

namespace Seggu.Services
{
    public class CollectionService : ICollectionService
    {
        public Document CreatePdfReceiptTemplate(FeeChargeDto feeChargeDto)
        {
            var header = new Paragraph();
            header.Add(new Chunk("RECIBO\tNro: " + feeChargeDto.NºRecibo + "\n", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
            header.Add(new Chunk("CENTRO SEGUROS\n", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD)));
            header.Add(new Chunk("Ruta 197 1355 - Talar de Pacheco\n", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
            header.Add(new Chunk("Tel: 4715-4096\n", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
            header.Add(new Chunk("(B 1617 FSA) - Pcia. de Bs. Aires\n", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
            var body = new Paragraph();

            var monthString =
                System.Globalization.CultureInfo
                .CurrentCulture.DateTimeFormat
                .MonthNames[feeChargeDto.CollectionDate.Month - 1];

            var amountInLetters = Convert.ToDouble(feeChargeDto.ChargeTotal).ToSpanishTextWithDecimals();

            var bodyDetail =
                "Buenos Aires, "
                + feeChargeDto.CollectionDate.Day.ToString()
                + " de " + monthString
                + " de " + feeChargeDto.CollectionDate.Year.ToString() + "\n"
                + "Recibimos de " + feeChargeDto.FullClientName + "\n"
                + "la cantidad de pesos " + amountInLetters;

            body.Add(new Chunk(bodyDetail, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));

            var table = new PdfPTable(3);
            table.AddCell(new PdfPCell(new Phrase("Poliza", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))));
            table.AddCell(new PdfPCell(new Phrase("Cuota", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))));
            table.AddCell(new PdfPCell(new Phrase("Importe", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))));
            foreach (var item in feeChargeDto.Items)
            {
                table.AddCell(new PdfPCell(new Phrase(item.PolicyNumber, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL))));
                table.AddCell(new PdfPCell(new Phrase(item.FeeNumber, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL))));
                table.AddCell(new PdfPCell(new Phrase(item.Value.ToString(), new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL))));
            }
            var totalCell = new PdfPCell(new Phrase("Total con gestion de cobranza", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
            totalCell.Colspan = 2;
            totalCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            table.AddCell(totalCell);
            table.AddCell(new PdfPCell(new Phrase(feeChargeDto.ChargeTotal.ToString(), new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL))));
            var vehicleCell = new PdfPCell(new Phrase("Vehiculo: " + feeChargeDto.VehicleModel, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
            vehicleCell.Colspan = 3;
            vehicleCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            table.AddCell(vehicleCell);
            var plateCell = new PdfPCell(new Phrase("Patente: " + feeChargeDto.VehiclePlate, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
            plateCell.Colspan = 3;
            plateCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            table.AddCell(plateCell);
            var nextExpirationText =
                "Proxima cuota vence\n"
                + feeChargeDto.PolicyExpirationDate.Day + " de "
                + feeChargeDto.PolicyExpirationDate.Month + " de "
                + feeChargeDto.PolicyExpirationDate.Year;
            var nextExpirationCell = new PdfPCell(new Phrase(nextExpirationText, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
            nextExpirationCell.Colspan = 3;
            nextExpirationCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            table.AddCell(nextExpirationCell);
            
            body.Add(table);
            
            var receipt = new Rectangle(300, 400);
            var document = new Document(receipt);
            //string path = AppDomain.CurrentDomain.BaseDirectory + "/ReceiptTemplate.pdf";
            string path = "C:/Users/Ezequiel G.Montes/Desktop/pdfsSeggu/ReceiptTemplate.pdf";
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.OpenOrCreate));
            document.Open();

            document.Add(header);
            document.Add(body);

            document.Close();

            return document;
        }
    }
}
