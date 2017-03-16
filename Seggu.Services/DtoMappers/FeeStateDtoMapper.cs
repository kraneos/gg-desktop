using Seggu.Domain;

namespace Seggu.Services.DtoMappers
{
    public static class FeeStateDtoMapper
    {
        public static FeeState ToEnum(string state)
        {
            switch (state)
            {
                case "Debe":
                    return FeeState.Debe;
                case "Liquidado":
                    return FeeState.Liquidado;
                case "Observado":
                    return FeeState.Observado;
                case "Pagado":
                    return FeeState.Pagado;
                case "Preliquidado":
                    return FeeState.Preliquidado;
                case "Mant. Cubierto":
                    return FeeState.Mantener_Cubierto;
                case "Moroso":
                    return FeeState.Moroso;
                case "Sin Cobertura":
                    return FeeState.Sin_Cobertura;
                case "Debe y Preliq":
                    return FeeState.Debe_y_Preliq;
                default:
                    return FeeState.Debe;
            }
        }

        public static string ToString(FeeState state)
        {
            switch (state)
            {
                case FeeState.Debe:
                    return "Debe";
                case FeeState.Liquidado:
                    return "Liquidado";
                case FeeState.Observado:
                    return "Observado";
                case FeeState.Pagado:
                    return "Pagado";
                case FeeState.Preliquidado:
                    return "Preliquidado";
                case FeeState.Mantener_Cubierto:
                    return "Mant. Cubierto";
                case FeeState.Moroso:
                    return "Moroso";
                case FeeState.Sin_Cobertura:
                    return "Sin Cobertura";
                case FeeState.Debe_y_Preliq:
                    return "Debe y Preliq";
                default:
                    return string.Empty;
            }
        }
    }
}
