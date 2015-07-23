using Seggu.Data;

namespace Seggu.Services.DtoMappers
{
    public static class IvaDtoMapper
    {
        public static IVA ToEnum(string iva)
        {
            switch (iva)
            {
                case "Consumidor Final":
                    return IVA.Consumidor_final;
                case "Responsable Monotributo":
                    return IVA.Resp_Monotributo;
                case "Responsable Inscripto":
                    return IVA.Resp_Inscripto;
                case "Responsable No Inscripto":
                    return IVA.Resp_No_Inscripto;
                case "Gran Contribuyente":
                    return IVA.Gran_Contribuyente;
                case "No Responsable":
                    return IVA.No_Responsable;
                case "Exento":
                    return IVA.Exento;
                case "No Grabado":
                    return IVA.No_Grabado;
                default:
                    return IVA.Consumidor_final;
            }
        }

        public static string ToString(IVA iva)
        {
            switch (iva)
            {
                case IVA.Consumidor_final:
                    return "Consumidor Final";
                case IVA.Resp_Monotributo:
                    return "Responsable Monotributo";
                case IVA.Resp_Inscripto:
                    return "Responsable Inscripto";
                case IVA.Resp_No_Inscripto:
                    return "Responsable No Inscripto";
                case IVA.Gran_Contribuyente:
                    return "Gran Contribuyente";
                case IVA.No_Responsable:
                    return "No Responsable";
                case IVA.Exento:
                    return "Exento";
                case IVA.No_Grabado:
                    return "No Grabado";
                default:
                    return string.Empty;
            }
        }
    }
}