using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Quest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestId { get; set; }
        public string Description { get; set; }
        public int Reward { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
