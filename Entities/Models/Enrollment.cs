using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public enum Level
    {
        SS, S, A, B, C, D
    }


    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        [Required]
        public int QuestId { get; set; }
        [Required]
        public int WarriorId { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Level? Level { get; set; }

        [JsonIgnore]
        public Quest? Quest { get; set; }
        [JsonIgnore]
        public Warrior? Warrior { get; set; }
    }
}
