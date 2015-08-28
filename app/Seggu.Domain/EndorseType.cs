namespace Seggu.Domain
{
    using System;
    
    public enum EndorseType : short
    {
        Cambio_Asegurado = 1,
        Cambio_Unidad = 2,
        Prima_Cero = 3,
        Reposición_Suma_asegurada = 4,
        Otras_Modificaciones = 5,
        Refacturación = 6,
        Anulación = 7,
        Rehabilitación = 8,
        Cancelación_Póliza = 9,
        Alta_Objetos = 10,
        Baja_Objetos = 11
    }
}
