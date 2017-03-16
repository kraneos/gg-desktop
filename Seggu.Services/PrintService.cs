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
        private IFeeService feeService;
        private ICompanyService companyService;
        private IPolicyService policyService;

        public PrintService(IClientService clientService,
            IProducerService producerService, IFeeService feeService,
            ICompanyService companyService, IPolicyService policyService)
        {
            this.clientService = clientService;
            this.producerService = producerService;
            this.feeService = feeService;
            this.companyService = companyService;
            this.policyService = policyService;
        }

        static string currentMonthString = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[DateTime.Today.Month - 1];
        static string nextMonthString = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[DateTime.Today.Month];

        string currentDate = DateTime.Today.Year.ToString() + "-" + currentMonthString.ToString() + "-" + DateTime.Today.Day.ToString();

        private static void PopulateClient(ClientFullDto clientFull, AcroFields form)
        {
            form.SetField("Teléfono", clientFull.Tel_Móvil);
            form.SetField("DNI", clientFull.DNI);
            form.SetField("Domicilio", clientFull.HomeStreet + " " + clientFull.HomeNumber + ", " + clientFull.HomeLocality);
            form.SetField("EstadoCivil", clientFull.MaritalStatus);
            form.SetField("CódigoPostal", clientFull.HomePostalCode);
            form.SetField("IVA", clientFull.Iva);
            form.SetField("Nacionalidad", "Argentino");
            form.SetField("Nacimiento", clientFull.BirthDate);
            form.SetField("Actividad", clientFull.Occupation);
        }
        private static void PopulateProducer(ProducerCompanyDto producer, AcroFields form)
        {
            form.SetField("Productor", producer.Name);
            form.SetField("CódigoCia", producer.Code);
            form.SetField("Comisión", producer.commission.ToString("P1", CultureInfo.InvariantCulture));
            form.SetField("Cobranza", "Directa");
        }

        #region Liquidaciones
        public void CreateFeesPdf(List<FeeDto> fees)
        {
            var receipt = new Rectangle(300, 400);
            var document = new Document(receipt);
            string path = AppDomain.CurrentDomain.BaseDirectory + "/ReceiptTemplate.pdf";
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.OpenOrCreate));
            document.Open();
            var table = new PdfPTable(2);
            document.Add(table);
            document.Close();
        }
        #endregion

        #region Recibo
        public void VehicleReceipt(FeeChargeDto printFee)
        {
            string clientPath = PathBuilder.ValidateClientPath("Recibos", currentDate, printFee.FullClientName);
            string PDFPath = Path.Combine(clientPath, printFee.VehiclePlate
                + " Pol-" + printFee.Items.FirstOrDefault().PolicyNumber
                + " cuota-" + printFee.Items.FirstOrDefault().FeeNumber + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Recibo_SeGGu);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            PopulateVehicleReceiptHeader(printFee, form);
            PopulateVehicleReceipt(printFee, form);

            stamp.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }
        public void LifeReceiptPDF(FeeLifeDto printFee)
        {
            string clientPath = PathBuilder.ValidateClientPath("Recibos", currentDate, printFee.ClientLastName);
            string PDFPath = Path.Combine(clientPath, "Vida-Pol-" + printFee.PolicyNumber
                + " cuota-" + printFee.FeeNumber + ".pdf");

            PdfReader reader = new PdfReader(Resources.Recibo_Vida);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            form.SetField("fecha", currentDate);
            form.SetField("Compañía", printFee.CompanyName);
            form.SetField("Recibo", printFee.ReceiptNumber);
            form.SetField("PolizaNum", printFee.PolicyNumber);
            form.SetField("Cuota", printFee.FeeNumber);
            form.SetField("Total", printFee.Value);
            form.SetField("TotalLetras", printFee.ValueInWords);

            form.SetField("AsegApellido", printFee.ClientLastName);
            form.SetField("AsegNombre", printFee.ClientName);
            form.SetField("AsegDNI", printFee.ClientDNI);
            form.SetField("AsegCUIT", printFee.ClientCUIT);
            form.SetField("AsegNacimiento", printFee.ClientBirthDate);
            form.SetField("AsegSuma", printFee.ClientEnsuranceValue);

            form.SetField("EmpresaEmpleador", printFee.EmployerCompanyName);
            form.SetField("ApellidoEmpleador", printFee.EmployerLastName);
            form.SetField("NombreEmpleador", printFee.EmployerName);
            form.SetField("DNIEmpleador", printFee.EmployerDNI);
            form.SetField("CUITEmpleador", printFee.EmployerCUIT);

            form.SetField("BenefApellido1", printFee.BeneficiaryLastName);
            form.SetField("BenefNombre1", printFee.BeneficiaryName);
            form.SetField("BenefDNI1", printFee.BeneficiaryDNI);
            form.SetField("BenefCUIT1", printFee.BeneficiaryCUIT);
            form.SetField("BenefParentesco1", printFee.BeneficiaryKinship);
            form.SetField("Benef%1", printFee.BeneficiaryPercent);

            form.SetField("Productor", printFee.Producer);
            form.SetField("CódigoCia", printFee.ProducerCode);
            form.SetField("Comisión", printFee.ProducerComission);
            form.SetField("Cobranza", "Directa");// printFee.CollectType);
            form.SetField("Cuotas", printFee.FeeCount);


            //PopulateReceiptHeader(printFee, form);
            //PopulateLiveReceipt(policy, form);
            //PopulateProducer(producer, form);

            stamp.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }

        private void PopulateReceiptHeader(PolicyFullDto pol, AcroFields form)
        {
        }

        public void IntegralReceiptPDF(FeeDto printFee)
        {
            var pol = policyService.GetById(printFee.PolicyId);

        }

        private void PopulateVehicleReceiptHeader(FeeChargeDto printFee, AcroFields form)
        {
            string feeExpirationDate = printFee.PolicyExpirationDate.Day.ToString()
                + " de " + nextMonthString
                + " de " + printFee.PolicyExpirationDate.Year.ToString();
            string amountInLetters = Convert.ToDouble(printFee.ChargeTotal).ToSpanishTextWithDecimals();
            form.SetField("Fecha", currentDate);
            form.SetField("Compañía", printFee.Company);
            form.SetField("Recibo", printFee.NºRecibo);
            form.SetField("RecibimosDe", printFee.FullClientName);
            form.SetField("TotalLetras", amountInLetters);
            form.SetField("PolizaNum", printFee.Items.FirstOrDefault().PolicyNumber);
            form.SetField("Cuota", printFee.Items.FirstOrDefault().FeeNumber);
            form.SetField("Cobertura", printFee.Coverage);
            form.SetField("VálidoHasta", feeExpirationDate);
            form.SetField("Total", printFee.ChargeTotal.ToString());
        }
        private void PopulateVehicleReceipt(FeeChargeDto printFee, AcroFields form1)
        {
            form1.SetField("Asegurado", printFee.FullClientName);
            form1.SetField("Póliza", printFee.Items.FirstOrDefault().PolicyNumber);
            form1.SetField("Vigencia", printFee.PolicyExpirationDate.ToShortDateString());
            form1.SetField("Vehículo", printFee.VehicleBrand + " " + printFee.VehicleModel);
            form1.SetField("Dominio", printFee.VehiclePlate);
            form1.SetField("Motor", printFee.VehicleEngine);
            form1.SetField("Chasis", printFee.VehicleChasis);
        }
        private void PopulateLiveReceipt(PolicyFullDto policy, AcroFields form)
        {
            form.SetField("AsegApellido1", policy.Employees.First().Apellido);
            form.SetField("AsegNombre1", policy.Employees.First().Nombre);
            form.SetField("AsegDNI1", policy.Employees.First().DNI);
            form.SetField("AsegCUIT1", policy.Employees.First().CUIT);
            form.SetField("AsegNacimiento1", policy.Employees.First().CUIT);
            form.SetField("AsegSuma1", policy.Employees.First().Suma.ToString());
        }
        #endregion

        #region Polizas
        public void PolicyVehiclePDF(PolicyFullDto policy, string selectedPlate)
        {
            string clientPath = PathBuilder.ValidateClientPath("Pólizas", currentDate, policy.Asegurado);
            string PDFPath = Path.Combine(clientPath, policy.Vehicles.First().Plate + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Póliza);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            ClientFullDto clientFull = clientService.GetById(policy.ClientId);
            VehicleDto vehicle = policy.Vehicles.First(v => v.Plate == selectedPlate);
            ProducerCompanyDto producer = producerService.GetByIdAndCompanyId(policy.ProducerId, policy.CompanyId);

            PopulatePolicyHeader(policy, form);
            PopulateClient(clientFull, form);
            PopulatePolicyVehicle(vehicle, form);
            PopulateProducer(producer, form);

            stamp.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }
        public void PolicyIntegralPDF(PolicyFullDto policy, string province, string district)
        {
            string clientPath = PathBuilder.ValidateClientPath("Pólizas", currentDate, policy.Asegurado);
            string address = policy.Integrals.FirstOrDefault().Address.Street + " " + policy.Integrals.FirstOrDefault().Address.Number;
            string PDFPath = Path.Combine(clientPath, address + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Póliza_Integral);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            ClientFullDto clientFull = clientService.GetById(policy.ClientId);
            IntegralDto integral = policy.Integrals.First();
            ProducerCompanyDto producer = producerService.GetByIdAndCompanyId(policy.ProducerId, policy.CompanyId);

            PopulatePolicyHeader(policy, form);
            PopulateClient(clientFull, form);
            PopulatePolicyIntegral(integral, province, district, form);
            PopulateProducer(producer, form);

            stamp.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }
        public void PolicyLifePDF(PolicyFullDto policy)
        {
            string clientPath = PathBuilder.ValidateClientPath("Pólizas", currentDate, policy.Asegurado);
            string PDFPath = Path.Combine(clientPath, "vida.pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Póliza_Vida);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            ClientFullDto clientFull = clientService.GetById(policy.ClientId);
            ProducerCompanyDto producer = producerService.GetByIdAndCompanyId(policy.ProducerId, policy.CompanyId);

            PopulatePolicyHeader(policy, form);
            PopulateClient(clientFull, form);
            PopulatePolicyEmployees(policy, form);
            PopulateProducer(producer, form);

            stamp.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }

        private void PopulatePolicyHeader(PolicyFullDto policy, AcroFields form)
        {
            form.SetField("Compañía", policy.Compañía);
            form.SetField("Riesgo", policy.TipoRiesgo);
            form.SetField("Vigencia", policy.StartDate + " al " + policy.Vence);
            form.SetField("Solicitada", policy.RequestDate);

            form.SetField("Asegurado", policy.Asegurado);
            form.SetField("Notas", policy.Notes);
            form.SetField("Suma", policy.Value.ToString());
            string feesCount = this.feeService.GetByPolicyId(policy.Id).Count().ToString();
            form.SetField("Cuotas", feesCount);
        }
        private static void PopulatePolicyEmployees(PolicyFullDto policy, AcroFields form)
        {
            //hacer un foreach para lista empleados
            form.SetField("AsegApellido1", policy.Employees.First().Apellido);
            form.SetField("AsegNombre1", policy.Employees.First().Nombre);
            form.SetField("AsegDNI1", policy.Employees.First().DNI);
            form.SetField("AsegCUIT1", policy.Employees.First().CUIT);
            form.SetField("AsegNacimiento1", policy.Employees.First().CUIT);
            form.SetField("AsegSuma1", policy.Employees.First().Suma.ToString());

            form.SetField("AsegApellido2", policy.Employees.Last().Apellido);
            form.SetField("AsegNombre2", policy.Employees.Last().Nombre);
            form.SetField("AsegDNI2", policy.Employees.Last().DNI);
            form.SetField("AsegCUIT2", policy.Employees.Last().CUIT);
            form.SetField("AsegNacimiento2", policy.Employees.Last().CUIT);
            form.SetField("AsegSuma2", policy.Employees.Last().Suma.ToString());
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
        private static void PopulatePolicyIntegral(IntegralDto integral, string province, string district, AcroFields form)
        {
            form.SetField("Calle", integral.Address.Street);
            form.SetField("Número", integral.Address.Number);
            form.SetField("Piso", integral.Address.Floor);
            form.SetField("Dpto", integral.Address.Appartment);
            form.SetField("Provincia", province);
            form.SetField("Distrito", district);
            form.SetField("Localidad", integral.locality);
            form.SetField("CodPostalInmueble", integral.Address.PostalCode);
            // form.SetField("Cubre", integral);
            var coberturas = string.Empty;

            if (integral.Coverages.Any())
            {
                coberturas = string.Join("\n", integral.Coverages.Select(x => x.Name));
            }
            form.SetField("Coberturas", coberturas);
        }
        #endregion

        #region Endosos
        public void EndorseIntegralPDF(EndorseFullDto endorse, string province, string district)
        {
            string clientPath = PathBuilder.ValidateClientPath("Endosos", currentDate, endorse.Asegurado);
            string address = endorse.Integrals.FirstOrDefault().Address.Street + " " + endorse.Integrals.FirstOrDefault().Address.Number;
            string PDFPath = Path.Combine(clientPath, address + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Endoso_Integral);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            ClientFullDto clientFull = clientService.GetById(endorse.ClientId);
            IntegralDto integral = endorse.Integrals.First();
            ProducerCompanyDto producer = producerService.GetByIdAndCompanyId(endorse.ProducerId, endorse.CompanyId);
            string company = companyService.GetById(endorse.CompanyId).Name;

            PopulateEndorseHeader(endorse, form, company);
            PopulateClient(clientFull, form);
            PopulateEndorseIntegral(integral, province, district, form);
            PopulateProducer(producer, form);

            stamp.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }
        public void EndorseLifePDF(EndorseFullDto endorse)
        {
            string clientPath = PathBuilder.ValidateClientPath("Endosos", currentDate, endorse.Asegurado);
            string PDFPath = Path.Combine(clientPath, "vida.pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Endoso_Vida);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            ClientFullDto clientFull = clientService.GetById(endorse.ClientId);
            ProducerCompanyDto producer = producerService.GetByIdAndCompanyId(endorse.ProducerId, endorse.CompanyId);
            string company = companyService.GetById(endorse.CompanyId).Name;

            PopulateEndorseHeader(endorse, form, company);
            PopulateClient(clientFull, form);
            PopulateEndorseEmployees(endorse, form);
            PopulateProducer(producer, form);

            stamp.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }
        public void EndorseVehiclePDF(EndorseFullDto endorse)
        {
            string clientPath = PathBuilder.ValidateClientPath("Endosos", currentDate, endorse.Asegurado);
            string PDFPath = Path.Combine(clientPath, endorse.Vehicles.FirstOrDefault().Plate + ".pdf");

            PdfReader reader = new PdfReader(Resources.Plantilla_Solicitud_Endoso);
            PdfStamper stamp1 = new PdfStamper(reader, new FileStream(PDFPath, FileMode.Create));
            AcroFields form = stamp1.AcroFields;

            ClientFullDto clientFull = clientService.GetById(endorse.ClientId);
            ProducerCompanyDto producer = producerService.GetByIdAndCompanyId(endorse.ProducerId, endorse.CompanyId);
            string company = companyService.GetById(endorse.CompanyId).Name;

            PopulateEndorseHeader(endorse, form, company);
            PopulateClient(clientFull, form);
            PopulateEndorseVehicle(endorse, form);
            PopulateProducer(producer, form);

            stamp1.Close();
            reader.Close();
            System.Diagnostics.Process.Start(PDFPath);
        }

        private void PopulateEndorseHeader(EndorseFullDto endorse, AcroFields form, string company)
        {
            form.SetField("Compañía", company);// sacar compañía de otro lado para no pasar policyFullDto
            form.SetField("Riesgo", endorse.TipoRiesgo);
            form.SetField("Vigencia", endorse.StartDate + " al " + endorse.EndDate);
            form.SetField("NumPóliza", endorse.PolicyNumber);
            form.SetField("Solicitado", endorse.RequestDate);
            form.SetField("Motivo", endorse.Motivo);

            form.SetField("Nombre", endorse.Asegurado);
            form.SetField("Notas", endorse.Notes);
            string feesCount = this.feeService.GetByEndorseId(endorse.Id).Count().ToString();
            form.SetField("Cuotas", feesCount);
        }
        private static void PopulateEndorseVehicle(EndorseFullDto endorse, AcroFields form)
        {
            var vehicle = endorse.Vehicles.FirstOrDefault();
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
            form.SetField("Patente", endorse.Vehicles.First().Plate);
            form.SetField("Suma", endorse.Value.ToString());
            form.SetField("TipoVehiculo", vehicle.VehicleType);
            form.SetField("Carrocería", vehicle.Bodywork);
            form.SetField("Uso", vehicle.Uso);
            form.SetField("Origen", vehicle.Origin);
        }
        private static void PopulateEndorseIntegral(IntegralDto integral, string province, string district, AcroFields form)
        {
            form.SetField("Calle", integral.Address.Street);
            form.SetField("Número", integral.Address.Number);
            form.SetField("Piso", integral.Address.Floor);
            form.SetField("Dpto", integral.Address.Appartment);
            form.SetField("Provincia", province);
            form.SetField("Distrito", district);
            form.SetField("Localidad", integral.locality);
            form.SetField("CodPostalInmueble", integral.Address.PostalCode);
            // form.SetField("Cubre", integral);
            var coberturas = string.Empty;

            if (integral.Coverages.Any())
            {
                coberturas = string.Join("\n", integral.Coverages.Select(x => x.Name));
            }
            form.SetField("Coberturas", coberturas);
        }
        private void PopulateEndorseEmployees(EndorseFullDto endorse, AcroFields form)
        {
            //haccer un foreach para lista empleados
            form.SetField("AsegApellido1", endorse.Employees.First().Apellido);
            form.SetField("AsegNombre1", endorse.Employees.First().Nombre);
            form.SetField("AsegDNI1", endorse.Employees.First().DNI);
            form.SetField("AsegCUIT1", endorse.Employees.First().CUIT);
            form.SetField("AsegNacimiento1", endorse.Employees.First().CUIT);
            form.SetField("AsegSuma1", endorse.Employees.First().Suma.ToString());

            form.SetField("AsegApellido2", endorse.Employees.Last().Apellido);
            form.SetField("AsegNombre2", endorse.Employees.Last().Nombre);
            form.SetField("AsegDNI2", endorse.Employees.Last().DNI);
            form.SetField("AsegCUIT2", endorse.Employees.Last().CUIT);
            form.SetField("AsegNacimiento2", endorse.Employees.Last().CUIT);
            form.SetField("AsegSuma2", endorse.Employees.Last().Suma.ToString());
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
