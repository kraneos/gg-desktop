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
                case "Combinados_Integrales": return RiskType.Combinados_Integrales;
                case "Otros": return RiskType.Otros;
                case "Vida_colectivo_Otros": return RiskType.Vida_colectivo_Otros;
                case "Vida_individual": return RiskType.Vida_individual;
                default: return RiskType.Automotores;
            }
        }

        public static string ToString(RiskType r)
        {
            switch (r)
            {
                case RiskType.Automotores:
                    return "Automotores";
                case RiskType.Combinados_Integrales:
                    return "Combinados_Integrales";
                case RiskType.Otros:
                    return "Otros";
                case RiskType.Vida_colectivo_Otros:
                    return "Vida_colectivo_Otros";
                case RiskType.Vida_individual:
                    return "Vida_individual";
                default:
                    return "Automotores";
            }
        }
    }
}
