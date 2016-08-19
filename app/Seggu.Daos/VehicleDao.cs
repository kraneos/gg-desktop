using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleDao : IdParseEntityDao<Vehicle>, IVehicleDao
    {
        public VehicleDao()
            : base()
        {

        }

        public Vehicle GetByPolicyId(long policyId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Vehicles.First(x => x.PolicyId == policyId); 
            }
        }
        public IEnumerable<Vehicle> GetByPlate(string plate)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Vehicles.Where(x => x.Plate == plate);
            }
        }
        public void SaveVehicle(Vehicle newVehicle)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var coverages = new List<Coverage>(newVehicle.Coverages).ToList();
                var dbVehicle = context.Vehicles
                                        .Include("Coverages")
                                        .FirstOrDefault(c => c.Id == newVehicle.Id) ?? newVehicle;

                dbVehicle.Coverages.Clear();
                context.Entry(dbVehicle).State = EntityState.Added;

                newVehicle.Id = dbVehicle.Id;
                //context.Entry(dbVehicle).CurrentValues.SetValues(newVehicle);
                Mapper.Map<Vehicle, Vehicle>(newVehicle, dbVehicle);

                foreach (var dbCover in context.Coverages)
                {
                    if (coverages.Any(cov => cov.Id == dbCover.Id))
                    {
                        context.Coverages.Attach(dbCover);
                        dbVehicle.Coverages.Add(dbCover);
                    }
                    //else
                    //dbVehicle.Coverages.Remove(dbCover);
                }
                context.SaveChanges();
            }
        }

        public override void Update(Vehicle obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Vehicles.Find(obj.Id);
                Mapper.Map<Vehicle, Vehicle>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
