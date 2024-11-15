using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    /// <summary>
    /// For test DataBase
    /// </summary>
    public static class DbInitializer
    {
        public static void Init(VillageContext context)
        {

            var enrollments = new Enrollment[]
            {
                new Enrollment{WarriorId = 2, QuestId=1010,Level=Level.S},
                new Enrollment{WarriorId = 3, QuestId=1020,Level=Level.A},
                new Enrollment{WarriorId = 4, QuestId=1020,Level=Level.A},
                new Enrollment{WarriorId = 5, QuestId=1020,Level=Level.B},
                new Enrollment{WarriorId = 6, QuestId=1030,Level=Level.B},
                new Enrollment{WarriorId = 7, QuestId=1030,Level=Level.B},
                new Enrollment{WarriorId = 4, QuestId=1030,Level=Level.C},
                new Enrollment{WarriorId = 3, QuestId=1030,Level=Level.D},
                new Enrollment{WarriorId = 2, QuestId=1020,Level=Level.D},
            };
            context.Enrollments.AddRangeAsync(enrollments);
            context.SaveChanges();
        }
    }
}
