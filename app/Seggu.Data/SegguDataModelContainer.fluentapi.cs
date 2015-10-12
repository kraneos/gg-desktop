using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Seggu.Data
{
    public partial class SegguDataModelContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureProducerCodeEntity(modelBuilder);
            ConfigureIntegralEntity(modelBuilder);
            ConfigurePolicyEntity(modelBuilder);
            ConfigureBodyworkVehicleTypeEntity(modelBuilder);
            ConfigureVehicleTypeUse(modelBuilder);
            ConfigureVehicleCoverages(modelBuilder);
            ConfigureIntegralCoverages(modelBuilder);
            ConfigureEmployeeCoverages(modelBuilder);            
        }

        private void ConfigureVehicleCoverages(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Vehicle>()
                .HasMany(v => v.Coverages)
                .WithMany(c => c.Vehicles)
                .Map(configurationAction =>
                {
                    configurationAction
                        .MapLeftKey("Vehicles_Id")
                        .MapRightKey("Coverages_Id")
                        .ToTable("VehicleCoverage");
                });
        }

        private void ConfigureIntegralCoverages(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Integral>()
                .HasMany(v => v.Coverages)
                .WithMany(c => c.Integrals)
                .Map(configurationAction =>
                {
                    configurationAction
                        .MapLeftKey("Integrals_Id")
                        .MapRightKey("Coverages_Id")
                        .ToTable("IntegralCoverage");
                });
        }

        private void ConfigureEmployeeCoverages(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .HasMany(v => v.Coverages)
                .WithMany(c => c.Employees)
                .Map(configurationAction =>
                {
                    configurationAction
                        .MapLeftKey("Employees_Id")
                        .MapRightKey("Coverages_Id")
                        .ToTable("EmployeeCoverage");
                });
        }

        private void ConfigureVehicleTypeUse(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<VehicleType>()
                .HasMany(vt => vt.Uses)
                .WithMany(u => u.VehicleType)
                .Map(configurationAction =>
                {
                    configurationAction
                        .MapLeftKey("VehicleType_Id")
                        .MapRightKey("Uses_Id")
                        .ToTable("VehicleTypeUse");
                });
        }

        private void ConfigureBodyworkVehicleTypeEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Bodywork>()
                .HasMany(b => b.VehicleTypes)
                .WithMany(vt => vt.Bodyworks)
                .Map(configurationAction =>
                {
                    configurationAction
                        .MapLeftKey("Bodyworks_Id")
                        .MapRightKey("VehicleTypes_Id")
                        .ToTable("BodyworkVehicleType");
                });
        }

        private void ConfigurePolicyEntity(DbModelBuilder modelBuilder)
        {
            // Collector Property
            modelBuilder
                .Entity<Policy>()
                .HasOptional<Producer>(x => x.Collector)
                .WithMany(x => x.Policies)
                .HasForeignKey(x => x.CollectorId);
        }

        private void ConfigureIntegralEntity(DbModelBuilder modelBuilder)
        {
            // Integral Address One to One
            modelBuilder
                .Entity<Integral>()
                .HasRequired(t => t.Address)
                .WithOptional(a => a.Integral);
        }

        private void ConfigureProducerCodeEntity(DbModelBuilder modelBuilder)
        {
            // ProducerCodes Primary Key
            modelBuilder
                .Entity<ProducerCode>()
                .HasKey(pc => new { pc.CompanyId, pc.ProducerId });
            modelBuilder
                .Entity<ProducerCode>()
                .HasRequired(pc => pc.Company)
                .WithMany(c => c.ProducerCodes)
                .HasForeignKey(pc => pc.CompanyId);
            modelBuilder
                .Entity<ProducerCode>()
                .HasRequired(pc => pc.Producer)
                .WithMany(p => p.ProducerCodes)
                .HasForeignKey(pc => pc.ProducerId);
        }
    }
}
