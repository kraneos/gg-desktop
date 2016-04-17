namespace Seggu.Api.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web;
    internal sealed class Configuration : DbMigrationsConfiguration<Seggu.Api.Data.SegguContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Seggu.Api.Data.SegguContext";
        }

        protected override void Seed(Seggu.Api.Data.SegguContext context)
        {
            if (!context.Banks.Any())
            {
                var path = HttpContext.Current.Server.MapPath(Properties.Settings.Default.InitializationSqlScript);

                if (File.Exists(path))
                {
                    using (var trx = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var scripts = File.ReadAllLines(path);

                            foreach (var script in scripts)
                            {
                                if (script != "GO" && script != "USE [seggu]")
                                {
                                    context.Database.ExecuteSqlCommand(script);
                                }
                            }

                            trx.Commit();
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                            trx.Rollback();
                        }

                    }
                }
            }
        }
    }
}
