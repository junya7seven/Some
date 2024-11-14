using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Warrior
    {
        public int WarriorId { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public HashSet<Enrollment> Enrollments { get; set; }
    }
}
