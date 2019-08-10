using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Models
{
    public class Challenge
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }
    }
}
