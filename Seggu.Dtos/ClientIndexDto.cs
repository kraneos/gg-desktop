﻿
namespace Seggu.Dtos
{
    public class ClientIndexDto : EntityWithIdDto
    {
        public string Nombre_Completo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tel_Móvil { get; set; }
        public string Mail { get; set; }
        public string Dni { get; set; }
        public int PolicyCount { get; set; }
        public string CUIT { get; set; }
        public string BirthDate { get; set; }
    }
}
