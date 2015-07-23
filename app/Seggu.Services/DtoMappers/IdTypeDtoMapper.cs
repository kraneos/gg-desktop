using Seggu.Data;

namespace Seggu.Services.DtoMappers
{
    public static class IdTypeDtoMapper
    {
        public static IdType ToEnum(string idType)
        {
            switch (idType)
            {
                case "D.N.I.":
                    return IdType.DNI;

                case "LE":
                    return IdType.LE;

                case "LC":
                    return IdType.LC;

                case "CI":
                    return IdType.CI;

                case "Pasaporte":
                    return IdType.Pasaporte;

                default:
                    return IdType.DNI;
            }
        }

        public static string ToString(IdType idType)
        {
            switch (idType)
            {
                case IdType.DNI:
                    return "D.N.I.";

                case IdType.LE:
                    return "LE";

                case IdType.LC:
                    return "LC";

                case IdType.CI:
                    return "CI";

                case IdType.Pasaporte:
                    return "Pasaporte";

                default:
                    return string.Empty;
            }
        }
    }
}