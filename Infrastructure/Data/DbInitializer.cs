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
            if (!context.Warriors.Any())
            {
                return;
            }
            var warriors = new Warrior[]
            {
                new Warrior{FirstName="Alex", NickName="Tank",EnrollmentDate=DateTime.Parse("2024-03-05")},
                new Warrior{FirstName="Max", NickName="Mid",EnrollmentDate=DateTime.Parse("2024-01-05")},
                new Warrior{FirstName="Bob", NickName="Bot",EnrollmentDate=DateTime.Parse("2024-05-02")},
                new Warrior{FirstName="Richard", NickName="Top",EnrollmentDate=DateTime.Parse("2024-06-08")},
                new Warrior{FirstName="Angel", NickName="Forest",EnrollmentDate=DateTime.Parse("2024-06-07")},
                new Warrior{FirstName="Grey", NickName="Pusher",EnrollmentDate=DateTime.Parse("2024-07-05")},
                new Warrior{FirstName="Bredfort", NickName="Tank",EnrollmentDate=DateTime.Parse("2024-08-01")},
                new Warrior{FirstName="Nick", NickName="Tank",EnrollmentDate=DateTime.Parse("2024-01-03")},
                new Warrior{FirstName="Micky", NickName="Tank",EnrollmentDate=DateTime.Parse("2024-02-02")},
                new Warrior{FirstName="Michael", NickName="Tank",EnrollmentDate=DateTime.Parse("2024-05-08")},
                new Warrior{FirstName="Thomas", NickName="Tank",EnrollmentDate=DateTime.Parse("2024-03-09")}
            };
            context.Warriors.AddRangeAsync(warriors);
            context.SaveChanges();

            var quests = new Quest[]
            {
                new Quest{QuestId=1010, Description="Murder",Reward=10},
                new Quest{QuestId=1020, Description="Help",Reward=5},
                new Quest{QuestId=1030, Description="Build",Reward=20},
                new Quest{QuestId=1040, Description="Search",Reward=7}
            };
            context.Quests.AddRange(quests);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{WarriorId = 1, QuestId=1010,Level=Level.SS},
                new Enrollment{WarriorId = 2, QuestId=1010,Level=Level.S},
                new Enrollment{WarriorId = 3, QuestId=1020,Level=Level.A},
                new Enrollment{WarriorId = 4, QuestId=1020,Level=Level.A},
                new Enrollment{WarriorId = 5, QuestId=1020,Level=Level.B},
                new Enrollment{WarriorId = 6, QuestId=1030,Level=Level.B},
                new Enrollment{WarriorId = 7, QuestId=1030,Level=Level.B},
                new Enrollment{WarriorId = 4, QuestId=1030,Level=Level.C},
                new Enrollment{WarriorId = 1, QuestId=1040,Level=Level.D},
                new Enrollment{WarriorId = 3, QuestId=1030,Level=Level.D},
                new Enrollment{WarriorId = 2, QuestId=1020,Level=Level.D},
                new Enrollment{WarriorId = 1, QuestId=1010,Level=Level.D}
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
