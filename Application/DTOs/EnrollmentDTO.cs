using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EnrollmentDTO
    {
        public int QuestId { get; set; }
        public int WarriorId { get; set; }

        public Level? Level { get; set; }
    }
    public enum Level
    {
        SS, S, A, B, C, D
    }
}
