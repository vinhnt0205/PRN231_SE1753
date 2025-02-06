using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.DB.Entity;

namespace WebAPICodeFirst.DB
{
    public static class DBSeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstrumentType>().HasData(
                new InstrumentType { InstrumentTypeId = 1, Name = "Acoustic Guitar" },
                new InstrumentType { InstrumentTypeId = 2, Name = "Electric Guitar" },
                new InstrumentType { InstrumentTypeId = 3, Name = "Drums" },
                new InstrumentType { InstrumentTypeId = 4, Name = "Bass" },
                new InstrumentType { InstrumentTypeId = 5, Name = "Keyboard" },
                new InstrumentType { InstrumentTypeId = 6, Name = "Violin" },
                new InstrumentType { InstrumentTypeId = 7, Name = "Saxophone" }
            );
            //modelBuilder.Entity<Player>().HasData(
            //    new Player { PlayerId = 1, NickName = "John", JoinedDate = new System.DateTime(2021, 1, 1) },

            //);
        }
    }
}
