using Seggu.Domain;

namespace Seggu.Services.DtoMappers
{
    public static class MaritalStatusDtoMapper
    {
        public static MaritalStatus ToEnum(string maritalStatus)
        {
            switch (maritalStatus)
            {
                case "Soltero":
                    return MaritalStatus.Soltero;

                case "Casado":
                    return MaritalStatus.Casado;

                case "Divorciado":
                    return MaritalStatus.Divorciado;

                case "Viudo":
                    return MaritalStatus.Viudo;

                case "Concubino":
                    return MaritalStatus.Concubino;

                default:
                    return MaritalStatus.Soltero;
            }
        }

        public static string ToString(MaritalStatus maritalStatus)
        {
            switch (maritalStatus)
            {
                case MaritalStatus.Soltero:
                    return "Soltero";

                case MaritalStatus.Casado:
                    return "Casado";

                case MaritalStatus.Divorciado:
                    return "Divorciado";

                case MaritalStatus.Viudo:
                    return "Viudo";

                case MaritalStatus.Concubino:
                    return "Concubino";

                default:
                    return string.Empty;
            }
        }
    }
}