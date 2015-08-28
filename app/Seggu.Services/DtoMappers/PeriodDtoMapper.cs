using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public static class PeriodDtoMapper
    {
        public static Period ToEnum(string p)
        {
            switch (p)
            {
                case "Mensual": return Period.Mensual;
                case "Bimestral": return Period.Bimestral;
                case "Trimestral": return Period.Trimestral;
                case "Cuatrimestral": return Period.Cuatrimestral;
                case "Semestral": return Period.Semestral;
                case "Anual": return Period.Anual;
                default: return Period.Mensual;
            }
        }

        public static string ToString(Period p)
        {
            switch (p)
            {
                case Period.Mensual:
                    return "Mensual";
                case Period.Bimestral:
                    return "Bimestral";
                case Period.Trimestral:
                    return "Trimestral";
                case Period.Cuatrimestral:
                    return "Cuatrimestral";
                case Period.Semestral:
                    return "Semestral";
                case Period.Anual:
                    return "Anual";
                default:
                    return "Mensual";
            }
        }
    }
}
