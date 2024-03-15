using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace HomeAPI
{
    public class Sensor
    {

        public int Id { get; set; }

        public required string AssignedPlant { get; set; }
    }

    [Table("MoistureLevelLogs", Schema = "dbo")]
    public class SensorInformation
    {
        [Key]
        public int Id { get; set; }
        public int SensorId { get; set; }
        public DateTime Date  { get; set; }
        public int MoistureLevel { get; set; }
        public required string Plant { get; set; }

    }


    public class SensorInfoContext : DbContext
    {
        public DbSet<SensorInformation> Info { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String dbUserName = Environment.GetEnvironmentVariable("DB_USER");
            String dbPass = Environment.GetEnvironmentVariable("DB_PASS");

            optionsBuilder.UseSqlServer($"Server=HomeStuffServer;Database=SmartyPlants;TrustServerCertificate=True;User Id={dbUserName};Password={dbPass};");
        }

    }

}
