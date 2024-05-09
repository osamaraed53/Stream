





using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Migration.Models;
using MySql.Data.MySqlClient;

namespace MigrationApp.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x=>x.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();


            builder.HasData(LoadSchedule());

        }

        private static  List<Schedule> LoadSchedule()
        {
            return new List<Schedule>
            {
                new Schedule { Id = 1, Title = "Daily",        SUN = true,  MON = true,  TUE = true,  WED = true,  THU = true,  FRI = false, SAT = false },
                new Schedule { Id = 2, Title = "DayAfterDay",  SUN = true,  MON = false, TUE = true,  WED = false, THU = true,  FRI = false, SAT = false },
                new Schedule { Id = 3, Title = "Twice-a-Week", SUN = false, MON = true,  TUE = false, WED = true,  THU = false, FRI = false, SAT = false },
                new Schedule { Id = 4, Title = "Weekend",      SUN = false, MON = false, TUE = false, WED = false, THU = false, FRI = true,  SAT = true },
                new Schedule { Id = 5, Title = "Compact",      SUN = true,  MON = true,  TUE = true,  WED = true,  THU = true,  FRI = true,  SAT = true }
            };
        }
    }
}
