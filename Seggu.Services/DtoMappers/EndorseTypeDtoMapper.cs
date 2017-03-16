using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seggu.Domain;

namespace Seggu.Services.DtoMappers
{
    public static class EndorseTypeDtoMapper
    {
        public static EndorseType ToEnum(string endorseType)
        {
            switch(endorseType)
            {
                case "Anulación":
                    return EndorseType.Anulación;
                case "Cambio_Asegurado":
                    return EndorseType.Cambio_Asegurado;
                case "Cambio_Unidad":
                    return EndorseType.Cambio_Unidad;
                case "Cancelación_Póliza":
                    return EndorseType.Cancelación_Póliza;
                case "Otras_Modificaciones":
                    return EndorseType.Otras_Modificaciones;     
                case "Prima_Cero":
                    return EndorseType.Prima_Cero;
                case "Refacturación":
                    return EndorseType.Refacturación;
                case "Rehabilitación":
                    return EndorseType.Rehabilitación;
                case "Reposición_Suma_asegurada":
                    return EndorseType.Reposición_Suma_asegurada;
                case "Alta_Objetos":
                    return EndorseType.Alta_Objetos;
                case "Baja_Objetos":
                    return EndorseType.Baja_Objetos;

                default:
                    return EndorseType.Otras_Modificaciones;
            }
        }

        public static string ToString(EndorseType endorseType)
        {
            switch(endorseType)
            {
                case EndorseType.Anulación:
                    return "Anulación";
                case EndorseType.Cambio_Asegurado:
                    return "Cambio_Asegurado"; 
                case EndorseType.Cambio_Unidad:
                    return "Cambio_Unidad";
                case EndorseType.Cancelación_Póliza:
                    return "Cancelación_Póliza";
                case EndorseType.Otras_Modificaciones:
                    return "Otras_Modificaciones";
                case EndorseType.Prima_Cero:
                    return "Prima_Cero";
                case EndorseType.Refacturación:
                    return "Refacturación";
                case EndorseType.Rehabilitación:
                    return "Rehabilitación";
                case EndorseType.Reposición_Suma_asegurada:
                    return "Reposición_Suma_asegurada";
                case EndorseType.Alta_Objetos:
                    return "Alta_Objetos";
                case EndorseType.Baja_Objetos:
                    return "Baja_Objetos";

                default:
                    return string.Empty;
            }
        }
    }
}
