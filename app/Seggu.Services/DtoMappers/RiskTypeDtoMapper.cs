using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public class RiskTypeDtoMapper
    {
        public static Data.RiskType ToEnum(string r)
        {
            switch (r)
            {
                case "Automotores": return Data.RiskType.Automotores;
                case "Combinados_Integrales": return Data.RiskType.Combinados_Integrales;
                case "Otros": return Data.RiskType.Otros;
                case "Vida_colectivo_Otros": return Data.RiskType.Vida_colectivo_Otros;
                case "Vida_individual": return Data.RiskType.Vida_individual;
                default: return Data.RiskType.Automotores;
            }
        }

        public static string ToString(Data.RiskType r)
        {
            switch (r)
            {
                case Seggu.Data.RiskType.Automotores:
                    return "Automotores";
                case Seggu.Data.RiskType.Combinados_Integrales:
                    return "Combinados_Integrales";
                case Seggu.Data.RiskType.Otros:
                    return "Otros";
                case Seggu.Data.RiskType.Vida_colectivo_Otros:
                    return "Vida_colectivo_Otros";
                case Seggu.Data.RiskType.Vida_individual:
                    return "Vida_individual";
                default:
                    return "Automotores";
            }
        }
    }
}
