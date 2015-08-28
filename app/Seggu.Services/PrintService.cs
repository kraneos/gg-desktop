using iTextSharp.text;
using iTextSharp.text.pdf;
using Seggu.Data;
using Seggu.Dtos;
using Seggu.Helpers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace Seggu.Services
{
    public class PrintService : IPrintService
    {
        private IClientService clientService;
        private IProducerService producerService;

        public PrintService(IClientService clientService, IProducerService producerService)
        {
            this.clientService = clientService;
            this.producerService = producerService;
        }

        static string currentMonthString = System.Globalization.CultureInfo
            .CurrentCulture.DateTimeFormat.MonthNames[DateTime.Today.Month - 1];
        static string nextMonthString = System.Globalization.CultureInfo
            .CurrentCulture.DateTimeFormat.MonthNames[DateTime.Today.Month];

        string currentDate = DateTime.Today.Day.ToString()
            + " de " + currentMonthString
            + " de " + DateTime.Today.Year.ToString();

        public void CreateFeesPdf(List<FeeDto> fees)
        {
            var receipt = new Rectangle(300, 400);
            var document = new Document(receipt);
            //string path = AppDomain.CurrentDomain.BaseDirectory + "/ReceiptTemplate.pdf";
            string path = "C:/Users/Ezequiel G.Montes/Desktop/pdfsSeggu/CuotasLiquidación.pdf";
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.OpenOrCreate));
            document.Open();

            var table = new PdfPTable(2);

            //document.Add(header);
            document.Add(table);

            document.Close();
        }

        public void PrintReceipt(FeeChargeDto printFee)
        {

            string pathDateFolder = ValidatePaths("Recibos");
            string PDFPath = System.IO.Path.Combine(pathDateFolder, printFee.VehiclePlate
                + " Pol-" + printFee.Items.FirstOrDefault().PolicyNumber
                + " cuota-" + printFee.Items.FirstOrDefault().FeeNumber + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Recibo_SeGGu);
            PdfStamper stamp1 = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form1 = stamp1.AcroFields;
            //form1.SetFieldProperty("RecibimosDe", "textsize", ,null);
            PopulateReceiptPDF(printFee, form1);
            stamp1.Close();
            reader.Close();

            System.Diagnostics.Process.Start(PDFPath);
        }
        private void PopulateReceiptPDF(FeeChargeDto printFee, AcroFields form1)
        {

            string feeExpirationDate = printFee.PolicyExpirationDate.Day.ToString()
                + " de " + nextMonthString
                + " de " + printFee.PolicyExpirationDate.Year.ToString();
            string amountInLetters = Convert.ToDouble(printFee.ChargeTotal).ToSpanishTextWithDecimals();
            form1.SetField("Recibo", printFee.NºRecibo);
            form1.SetField("Fecha", currentDate);

            form1.SetField("RecibimosDe", printFee.FullClientName);
            form1.SetField("TotalLetras", amountInLetters);
            form1.SetField("Cuota", printFee.Items.FirstOrDefault().FeeNumber);
            form1.SetField("Cobertura", printFee.Coverage);
            form1.SetField("VálidoHasta", feeExpirationDate);
            form1.SetField("Total", printFee.ChargeTotal.ToString());

            form1.SetField("Asegurado", printFee.FullClientName);
            form1.SetField("Póliza", printFee.Items.FirstOrDefault().PolicyNumber);
            form1.SetField("Vigencia", printFee.PolicyExpirationDate.ToShortDateString());
            form1.SetField("Vehículo", printFee.VehicleBrand + " " + printFee.VehicleModel);
            form1.SetField("Dominio", printFee.VehiclePlate);
            form1.SetField("Motor", printFee.VehicleEngine);
            form1.SetField("Chasis", printFee.VehicleChasis);
        }

        public void PolicyPDF(ClientIndexDto client, PolicyFullDto policy, string selectedPlate)
        {
            var clientFull = clientService.GetById(policy.ClientId);
            var producer = producerService.GetByIdAndCompanyId(policy.ProducerId, policy.CompanyId);
            string pathDateFolder = ValidatePaths("Pólizas");
            string PDFPath = System.IO.Path.Combine(pathDateFolder, policy.Vehicles.First().Plate +
                " " + client.FullName + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Póliza);
            PdfStamper stamp1 = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form1 = stamp1.AcroFields;

            PopulatePolicyPDF(clientFull, policy, producer, form1, selectedPlate);

            stamp1.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }
        private static void PopulatePolicyPDF(ClientFullDto clientFull, PolicyFullDto policy, ProducerCompanyDto producer, AcroFields form1, string selectesPlate)
        {
            var currentVehicle = policy.Vehicles.First(v => v.Plate == selectesPlate);
            form1.SetField("Compañía", policy.Compañía);
            form1.SetField("Riesgo", policy.TipoRiesgo);
            form1.SetField("Vigencia", policy.StartDate + " al " + policy.Vence);
            form1.SetField("Solicitada", policy.RequestDate);

            form1.SetField("Asegurado", policy.Asegurado);

            form1.SetField("Teléfono", clientFull.Tel_Móvil);
            form1.SetField("DNI", clientFull.DNI);
            form1.SetField("Domicilio", clientFull.HomeStreet + " " + clientFull.HomeNumber + ", " + clientFull.HomeLocality);
            form1.SetField("EtadoCivil", clientFull.MaritalStatus);
            form1.SetField("CódigoPostal", clientFull.HomePostalCode);
            form1.SetField("IVA", clientFull.Iva);
            form1.SetField("Nacionalidad", "Argentino");
            form1.SetField("Nacimiento", clientFull.BirthDate);
            form1.SetField("Actividad", clientFull.Occupation);

            form1.SetField("Marca", currentVehicle.Brand);
            form1.SetField("Modelo", currentVehicle.Model);
            form1.SetField("Año", currentVehicle.Year);
            form1.SetField("Cobertura", currentVehicle.Coverages.FirstOrDefault().CoveragesPacks.FirstOrDefault().Name);

            form1.SetField("Motor", currentVehicle.Engine);
            form1.SetField("Chasis", currentVehicle.Chassis);
            form1.SetField("Patente", currentVehicle.Plate);
            form1.SetField("Suma", policy.Value.ToString());
            form1.SetField("Tipo", currentVehicle.VehicleType);
            form1.SetField("Carrocería", currentVehicle.Bodywork);
            form1.SetField("Uso", currentVehicle.Uso);
            form1.SetField("Origen", currentVehicle.Origin);
            form1.SetField("Notas", policy.Notes);

            form1.SetField("Productor", producer.Name);
            form1.SetField("CódigoCia", producer.Code);
            form1.SetField("Cobranza", "Directa");
            form1.SetField("Cuotas", "");
            form1.SetField("Comisión", producer.commission.ToString("P1", CultureInfo.InvariantCulture));

        }


        public void EndorsePDF(EndorseFullDto endorse, ClientIndexDto client, PolicyFullDto policy)
        {
            var clientFull = clientService.GetById(policy.ClientId);
            string pathDateFolder = ValidatePaths("Endosos");
            string PDFPath = System.IO.Path.Combine(pathDateFolder, endorse.Vehicles.First().Plate +
                " " + client.FullName + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Endoso);
            PdfStamper stamp1 = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form1 = stamp1.AcroFields;

            PopulateEndorsePDF(endorse, clientFull, policy, form1);

            stamp1.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }
        private static void PopulateEndorsePDF(EndorseFullDto endorse, ClientFullDto clientFull, PolicyFullDto policy, AcroFields form1)
        {
            form1.SetField("Compañía", policy.Compañía);
            form1.SetField("Riesgo", endorse.TipoRiesgo);
            form1.SetField("Vigencia", endorse.StartDate + " al " + endorse.EndDate);
            form1.SetField("Solicitado", endorse.RequestDate);
            form1.SetField("Motivo", endorse.Motivo);

            form1.SetField("Nombre", endorse.Asegurado);

            form1.SetField("Teléfono", clientFull.Tel_Móvil);
            form1.SetField("DNI", clientFull.DNI);
            form1.SetField("Domicilio", clientFull.HomeStreet + " " + clientFull.HomeNumber + ", " + clientFull.HomeLocality);
            form1.SetField("EtadoCivil", clientFull.MaritalStatus);
            form1.SetField("CódigoPostal", clientFull.HomePostalCode);
            form1.SetField("IVA", clientFull.Iva);
            form1.SetField("Nacionalidad", "Argentino");
            form1.SetField("Nacimiento", clientFull.BirthDate);
            form1.SetField("Actividad", clientFull.Occupation);

            form1.SetField("Marca", endorse.Vehicles.FirstOrDefault().Brand);
            form1.SetField("Modelo", endorse.Vehicles.FirstOrDefault().Model);
            form1.SetField("Año", endorse.Vehicles.FirstOrDefault().Year);
            //form1.SetField("Cobertura", policy.Coverage); // ????

            form1.SetField("Motor", endorse.Vehicles.FirstOrDefault().Engine);
            form1.SetField("Chasis", endorse.Vehicles.FirstOrDefault().Chassis);
            form1.SetField("Patente", endorse.Vehicles.First().Plate);
            form1.SetField("Suma", endorse.Value.ToString());
            form1.SetField("TipoVehiculo", endorse.Vehicles.FirstOrDefault().VehicleType);
            form1.SetField("Carrocería", endorse.Vehicles.FirstOrDefault().Bodywork);
            form1.SetField("Uso", endorse.Vehicles.FirstOrDefault().Uso);
            form1.SetField("Origen", endorse.Vehicles.FirstOrDefault().Origin);
            form1.SetField("Notas", endorse.Notes);
        }
        private string ValidatePaths(string PDFcategory)
        {
            var path = Properties.Settings.Default.FileServerPath + @"\SeGGu PDFs";
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + @"\SeGGu PDFs";
            if (!(Directory.Exists(path))) Directory.CreateDirectory(path);

            string pathDateFolder = path + @"\" + PDFcategory + @"\"
                + DateTime.Today.Year + "-" + currentMonthString + "-" + DateTime.Today.Day;
            if (!(Directory.Exists(pathDateFolder)))
            {
                Directory.CreateDirectory(pathDateFolder);
            }
            return pathDateFolder;
        }


        //public Document CreatePdfReceiptTemplate(FeeChargeDto feeChargeDto)
        //{
        //    var header = new Paragraph();
        //    header.Add(new Chunk("RECIBO\tNro: " + feeChargeDto.Recibo + "\n", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
        //    header.Add(new Chunk("CENTRO SEGUROS\n", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD)));
        //    header.Add(new Chunk("Ruta 197 1355 - Talar de Pacheco\n", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
        //    header.Add(new Chunk("Tel: 4715-4096\n", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
        //    header.Add(new Chunk("(B 1617 FSA) - Pcia. de Bs. Aires\n", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
        //    var body = new Paragraph();

        //    var monthString =
        //        System.Globalization.CultureInfo
        //        .CurrentCulture.DateTimeFormat
        //        .MonthNames[feeChargeDto.CollectionDate.Month - 1];

        //    var amountInLetters = Convert.ToDouble(feeChargeDto.ChargeTotal).ToSpanishTextWithDecimals();

        //    var bodyDetail =
        //        "Buenos Aires, "
        //        + feeChargeDto.CollectionDate.Day.ToString()
        //        + " de " + monthString
        //        + " de " + feeChargeDto.CollectionDate.Year.ToString() + "\n"
        //        + "Recibimos de " + feeChargeDto.FullClientName + "\n"
        //        + "la cantidad de pesos " + amountInLetters;

        //    body.Add(new Chunk(bodyDetail, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));

        //    var table = new PdfPTable(3);
        //    table.AddCell(new PdfPCell(new Phrase("Poliza", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))));
        //    table.AddCell(new PdfPCell(new Phrase("Cuota", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))));
        //    table.AddCell(new PdfPCell(new Phrase("Importe", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))));
        //    foreach (var item in feeChargeDto.Items)
        //    {
        //        table.AddCell(new PdfPCell(new Phrase(item.PolicyNumber, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL))));
        //        table.AddCell(new PdfPCell(new Phrase(item.FeeNumber, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL))));
        //        table.AddCell(new PdfPCell(new Phrase(item.Value.ToString(), new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL))));
        //    }
        //    var totalCell = new PdfPCell(new Phrase("Total con gestion de cobranza", new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
        //    totalCell.Colspan = 2;
        //    totalCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
        //    table.AddCell(totalCell);
        //    table.AddCell(new PdfPCell(new Phrase(feeChargeDto.ChargeTotal.ToString(), new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL))));
        //    var vehicleCell = new PdfPCell(new Phrase("Vehiculo: " + feeChargeDto.VehicleModel, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
        //    vehicleCell.Colspan = 3;
        //    vehicleCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //    table.AddCell(vehicleCell);
        //    var plateCell = new PdfPCell(new Phrase("Patente: " + feeChargeDto.VehiclePlate, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
        //    plateCell.Colspan = 3;
        //    plateCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //    table.AddCell(plateCell);
        //    var nextExpirationText =
        //        "Proxima cuota vence\n"
        //        + feeChargeDto.PolicyExpirationDate.Day + " de "
        //        + feeChargeDto.PolicyExpirationDate.Month + " de "
        //        + feeChargeDto.PolicyExpirationDate.Year;
        //    var nextExpirationCell = new PdfPCell(new Phrase(nextExpirationText, new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL)));
        //    nextExpirationCell.Colspan = 3;
        //    nextExpirationCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //    table.AddCell(nextExpirationCell);

        //    body.Add(table);

        //    var receipt = new Rectangle(300, 400);
        //    var document = new Document(receipt);
        //    //string path = AppDomain.CurrentDomain.BaseDirectory + "/ReceiptTemplate.pdf";
        //    string path = "C:/Users/Ezequiel G.Montes/Desktop/pdfsSeggu/ReceiptTemplate.pdf";
        //    PdfWriter.GetInstance(document, new FileStream(path, FileMode.OpenOrCreate));
        //    document.Open();

        //    document.Add(header);
        //    document.Add(body);

        //    document.Close();

        //    return document;
        //}
    }
}
