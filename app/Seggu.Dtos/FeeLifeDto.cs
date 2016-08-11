using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class FeeLifeDto
    {
        public string CompanyName { get; set; }
        public string ReceiptNumber { get; set; }
        public string PolicyNumber { get; set; }
        public string FeeNumber { get; set; }
        public string Value { get; set; }
        public string ValueInWords { get; set; }

        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientDNI { get; set; }
        public string ClientCUIT { get; set; }
        public string ClientBirthDate { get; set; }
        public string ClientEnsuranceValue { get; set; }

        public string EmployerCompanyName { get; set; }
        public string EmployerLastName { get; set; }
        public string EmployerName { get; set; }
        public string EmployerDNI { get; set; }
        public string EmployerCUIT { get; set; }

        public string BeneficiaryLastName { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryDNI { get; set; }
        public string BeneficiaryCUIT { get; set; }
        public string BeneficiaryKinship { get; set; }
        public string BeneficiaryPercent { get; set; }

        public string Producer { get; set; }
        public string ProducerCode { get; set; }
        public string ProducerComission { get; set; }
        public string CollectType { get; set; }
        public string FeeCount { get; set; }
    }
}
