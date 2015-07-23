using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public static class PeriodDtoMapper
    {
        public static Data.Period ToEnum(string p)
        {
            switch (p)
            {
                case "Mensual": return Data.Period.Mensual;
                case "Bimestral": return Data.Period.Bimestral;
                case "Trimestral": return Data.Period.Trimestral;
                case "Cuatrimestral": return Data.Period.Cuatrimestral;
                case "Semestral": return Data.Period.Semestral;
                case "Anual": return Data.Period.Anual;
                default: return Data.Period.Mensual;
            }
        }

        public static string ToString(Data.Period p)
        {
            switch (p)
            {
                case Seggu.Data.Period.Mensual:
                    return "Mensual";
                case Seggu.Data.Period.Bimestral:
                    return "Bimestral";
                case Seggu.Data.Period.Trimestral:
                    return "Trimestral";
                case Seggu.Data.Period.Cuatrimestral:
                    return "Cuatrimestral";
                case Seggu.Data.Period.Semestral:
                    return "Semestral";
                case Seggu.Data.Period.Anual:
                    return "Anual";
                default:
                    return "Mensual";
            }
        }
    }
}
