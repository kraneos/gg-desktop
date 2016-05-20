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

        static string currentMonthString = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[DateTime.Today.Month - 1];
        static string nextMonthString = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[DateTime.Today.Month];

        string currentDate = DateTime.Today.Day.ToString() + " de " + currentMonthString + " de " + DateTime.Today.Year.ToString();

        private string ValidatePaths(string PDFcategory)
        {
            //var path = Properties.Settings.Default.FileServerPath + @"\SeGGu PDFs";
            var path = AppDomain.CurrentDomain.BaseDirectory + @"SeGGu PDFs";
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

        private static void PopulateClient(ClientFullDto clientFull, AcroFields form)
        {
            form.SetField("Teléfono", clientFull.Tel_Móvil);
            form.SetField("DNI", clientFull.DNI);
            form.SetField("Domicilio", clientFull.HomeStreet + " " + clientFull.HomeNumber + ", " + clientFull.HomeLocality);
            form.SetField("EtadoCivil", clientFull.MaritalStatus);
            form.SetField("CódigoPostal", clientFull.HomePostalCode);
            form.SetField("IVA", clientFull.Iva);
            form.SetField("Nacionalidad", "Argentino");
            form.SetField("Nacimiento", clientFull.BirthDate);
            form.SetField("Actividad", clientFull.Occupation);
        }
        private static void PolpulateProducer(ProducerCompanyDto producer, AcroFields form)
        {
            form.SetField("Productor", producer.Name);
            form.SetField("CódigoCia", producer.Code);
            form.SetField("Comisión", producer.commission.ToString("P1", CultureInfo.InvariantCulture));
        }

        #region Liquidaciones
        public void CreateFeesPdf(List<FeeDto> fees)
        {
            var receipt = new Rectangle(300, 400);
            var document = new Document(receipt);
            string path = AppDomain.CurrentDomain.BaseDirectory + "/ReceiptTemplate.pdf";
            //string path = "C:/Users/Ezequiel G.Montes/Desktop/pdfsSeggu/CuotasLiquidación.pdf";
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.OpenOrCreate));
            document.Open();

            var table = new PdfPTable(2);

            //document.Add(header);
            document.Add(table);

            document.Close();
        }
        #endregion

        #region Recibo
        public void PrintReceipt(FeeChargeDto printFee)
        {
            string pathDateFolder = ValidatePaths("Recibos");
            string PDFPath = System.IO.Path.Combine(pathDateFolder, printFee.VehiclePlate
                + " Pol-" + printFee.Items.FirstOrDefault().PolicyNumber
                + " cuota-" + printFee.Items.FirstOrDefault().FeeNumber + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Recibo_SeGGu);
            PdfStamper stamp1 = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form1 = stamp1.AcroFields;

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
        #endregion

        #region Polizas
        public void PolicyVehiclePDF(PolicyFullDto policy, string selectedPlate)
        {
            string pathDateFolder = ValidatePaths("Pólizas");

            string PDFPath = System.IO.Path.Combine(pathDateFolder, policy.Vehicles.First().Plate +
                " " + policy.Asegurado + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Póliza);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            ClientFullDto clientFull = clientService.GetById(policy.ClientId);
            VehicleDto vehicle = policy.Vehicles.First(v => v.Plate == selectedPlate);
            ProducerCompanyDto producer = producerService.GetByIdAndCompanyId(policy.ProducerId, policy.CompanyId);

            PopulatePolicy(policy, form);
            PopulateClient(clientFull, form);
            PopulatePolicyVehicle(vehicle, form);
            PolpulateProducer(producer, form);

            stamp.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }

        private static void PopulatePolicy(PolicyFullDto policy, AcroFields form)
        {
            form.SetField("Compañía", policy.Compañía);
            form.SetField("Riesgo", policy.TipoRiesgo);
            form.SetField("Vigencia", policy.StartDate + " al " + policy.Vence);
            form.SetField("Solicitada", policy.RequestDate);

            form.SetField("Asegurado", policy.Asegurado);
            form.SetField("Notas", policy.Notes);
            form.SetField("Suma", policy.Value.ToString());
            form.SetField("Cobranza", "Directa");
            form.SetField("Cuotas", "");
        }
        private static void PopulatePolicyVehicle(VehicleDto vehicle, AcroFields form)
        {
            form.SetField("Marca", vehicle.Brand);
            form.SetField("Modelo", vehicle.Model);
            form.SetField("Año", vehicle.Year);
            var cobertura = string.Empty;
            if (vehicle.Coverages.Any() && vehicle.Coverages.First().CoveragesPacks.Any())
            {
                cobertura = vehicle.Coverages.First().CoveragesPacks.First().Name;
            }
            form.SetField("Cobertura", cobertura);
            form.SetField("Motor", vehicle.Engine);
            form.SetField("Chasis", vehicle.Chassis);
            form.SetField("Patente", vehicle.Plate);
            form.SetField("Tipo", vehicle.VehicleType);
            form.SetField("Carrocería", vehicle.Bodywork);
            form.SetField("Uso", vehicle.Uso);
            form.SetField("Origen", vehicle.Origin);
        }

        public void PolicyLifePDF(PolicyFullDto policy)
        {

        }
        public void PolicyIntegralPDF(PolicyFullDto policy)
        {

        }
        #endregion

        #region Endosos
        public void EndorsePDF(EndorseFullDto endorse, ClientIndexDto client, PolicyFullDto policy)
        {
            var clientFull = clientService.GetById(policy.ClientId);
            string pathDateFolder = ValidatePaths("Endosos");
            string PDFPath = System.IO.Path.Combine(pathDateFolder, endorse.Vehicles.First().Plate +
                " " + client.FullName + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Endoso);
            PdfStamper stamp1 = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp1.AcroFields;

            PopulateEndorsePDF(endorse, clientFull, policy, form);

            stamp1.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }
        private static void PopulateEndorsePDF(EndorseFullDto endorse, ClientFullDto clientFull, PolicyFullDto policy, AcroFields form)
        {
            form.SetField("Compañía", policy.Compañía);// sacar compañía de otro lado para no pasar policyFullDto
            form.SetField("Riesgo", endorse.TipoRiesgo);
            form.SetField("Vigencia", endorse.StartDate + " al " + endorse.EndDate);
            form.SetField("Solicitado", endorse.RequestDate);
            form.SetField("Motivo", endorse.Motivo);

            form.SetField("Nombre", endorse.Asegurado);
            form.SetField("Notas", endorse.Notes);

            PopulateClient(clientFull, form);
            PopulateEndorseVehicle(endorse, form);
        }
        private static void PopulateEndorseVehicle(EndorseFullDto endorse, AcroFields form)
        {
            form.SetField("Marca", endorse.Vehicles.FirstOrDefault().Brand);
            form.SetField("Modelo", endorse.Vehicles.FirstOrDefault().Model);
            form.SetField("Año", endorse.Vehicles.FirstOrDefault().Year);
            //form1.SetField("Cobertura", policy.Coverage); // ????

            form.SetField("Motor", endorse.Vehicles.FirstOrDefault().Engine);
            form.SetField("Chasis", endorse.Vehicles.FirstOrDefault().Chassis);
            form.SetField("Patente", endorse.Vehicles.First().Plate);
            form.SetField("Suma", endorse.Value.ToString());
            form.SetField("TipoVehiculo", endorse.Vehicles.FirstOrDefault().VehicleType);
            form.SetField("Carrocería", endorse.Vehicles.FirstOrDefault().Bodywork);
            form.SetField("Uso", endorse.Vehicles.FirstOrDefault().Uso);
            form.SetField("Origen", endorse.Vehicles.FirstOrDefault().Origin);
        }
        #endregion

        //public void GetNames()
        //{
        //    string pathDateFolder = ValidatePaths("Pólizas");

        //    string PDFPath = System.IO.Path.Combine(pathDateFolder, "algo.pdf");
        //    PdfReader reader = new PdfReader(Resources.Solicitud_Inscripcion_Seguro_Colectivo_2);
        //    PdfStamper stamp1 = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create)) ;
        //    AcroFields form1 = stamp1.AcroFields;

        //    var list = form1.Fields;
        //    stamp1.Close();
        //    reader.Close();
        //}
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
