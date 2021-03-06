﻿using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class ProvinceDao : IdParseEntityDao<Province>, IProvinceDao
    {
        public ProvinceDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public override void Update(Province obj)
        {
         //provincias no se editan 
        }
    }
}
