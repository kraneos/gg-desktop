﻿using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class PolicyFullDto : EntityWithIdDto
    {
        public string AnnulationDate { get; set; }
        public string Asegurado { get; set; }
        
        public decimal Bonus { get; set; }
        
        public List<CasualtyDto> Casualties { get; set; }
        public int ClientId { get; set; }
        public string Compañía { get; set; }
        public int CompanyId { get; set; }
        public int CollectorId { get; set; }

        public IEnumerable<EndorseFullDto> Endorses { get; set; }
        public IEnumerable<string> FilePaths { get; set; }
        public int EndorseCount { get; set; }
        public string Vence { get; set; }
        public string EmissionDate { get; set; }
        public bool IsAnnulled { get; set; }
        public bool IsRenovated { get; set; }
        public bool IsRemoved { get; set; }

        public string Notes { get; set; }
        public string Número { get; set; }

        public string Objeto { get; set; }

        public string Patente { get; set; }
        public string Period { get; set; }
        public decimal Premium { get; set; }
        public string PreviousNumber { get; set; }
        public decimal Prima { get; set; }
        public int ProducerId { get; set; }

        public int RiskId { get; set; }
        public string RequestDate { get; set; }
        public string ReceptionDate { get; set; }
        
        public string StartDate { get; set; }
        public decimal Surcharge { get; set; }
        
        public string TipoRiesgo { get; set; }
        
        public decimal Value { get; set; }
        public IEnumerable<FeeDto> Fees { get; set; }
        public IEnumerable<VehicleDto> Vehicles { get; set; }
        public IEnumerable<AttachedFileDto> AttachedFiles { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }
        public IEnumerable<IntegralDto> Integrals { get; set; }
        public int? PaymentDay { get; set; }
        public decimal? PaymentBonus { get; set; }
        public decimal? NetCharge { get; set; }
    }
}
