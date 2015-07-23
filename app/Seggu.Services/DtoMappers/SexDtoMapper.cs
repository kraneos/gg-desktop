using Seggu.Data;

namespace Seggu.Services.DtoMappers
{
    public static class SexDtoMapper
    {
        public static Sex ToEnum(string sex)
        {
            switch (sex)
            {
                case "Masculino":
                    return Sex.Male;

                case "Femenino":
                    return Sex.Female;

                default:
                    return Sex.Male;
            }
        }

        public static string ToString(Sex sex)
        {
            switch (sex)
            {
                case Sex.Male: return "Masculino";
                case Sex.Female: return "Femenino";
                default: return string.Empty;
            }
        }
    }
}