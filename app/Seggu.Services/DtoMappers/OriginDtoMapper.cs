using Seggu.Domain;

namespace Seggu.Services.DtoMappers
{
    public static class OriginDtoMapper
    {
        public static Origin ToEnum(string origin)
        {
            switch (origin)
            {
                case "Nacional": return Origin.National;
                case "Importado": return Origin.Imported;
                default: return Origin.National;
            }
        }

        public static string ToString(Origin origin)
        {
            switch (origin)
            {
                case Origin.National: return "Nacional";
                case Origin.Imported: return "Importado";
                default: return "Nacionals";
            }
        }
    }
}
