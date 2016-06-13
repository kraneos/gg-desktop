namespace Seggu.Domain
{
    public enum FeeState : int
    {
        Debe = 0,
        Pagado = 1,
        Observado = 2,
        Preliquidado = 3,
        Liquidado = 4,
        Mantener_Cubierto = 5,
        Moroso = 6,
        Sin_Cobertura = 7,
        Debe_y_Preliq = 8,
        otro = 9
    }
}
