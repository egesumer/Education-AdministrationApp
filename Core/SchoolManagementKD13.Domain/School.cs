using SchoolManagementKD13.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Domain
{
    public class School : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
