﻿using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleModelDao : IdParseEntityDao<VehicleModel>, IVehicleModelDao
    {
        public VehicleModelDao()
            : base()
        {

        }

        public bool GetByName(string name)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.VehicleModels.Any(c => c.Name == name);
            }
        }

        public List<VehicleModel> GetWithReferences()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.VehicleModels.Include("Brand").Include("VehicleType").ToList();
            }
        }

        public bool ExistsByBrand(int brandId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.VehicleModels.Any(x => x.BrandId == brandId);
            }
        }

        public override void Update(VehicleModel obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.VehicleModels.Find(obj.Id);
                Mapper.Map<VehicleModel, VehicleModel>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
