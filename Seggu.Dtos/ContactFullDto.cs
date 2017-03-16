﻿using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class ContactFullDto : KeyValueDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bussiness { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Notes { get; set; }
        public long CompanyId { get; set; }
    }
}
