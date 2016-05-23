using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public class RiskTypeDtoMapper
    {
        public static RiskType ToEnum(string r)
        {
            switch (r)
            {
                case "Automotores": return RiskType.Automotores;
                case "Integral de Comercio": return RiskType.IntegralComercio;
                case "Otros": return RiskType.Otros;
                case "Vida": return RiskType.Vida;
                default: return RiskType.Automotores;
            }
        }

        public static string ToString(RiskType r)
        {
            switch (r)
            {
                case RiskType.Automotores:
                    return "Automotores";
                case RiskType.IntegralComercio:
                    return "Integral de Comercio";
                case RiskType.Otros:
                    return "Otros";
                case RiskType.Vida:
                    return "Vida";
                default:
                    return "Automotores";
            }
        }
    }
}
