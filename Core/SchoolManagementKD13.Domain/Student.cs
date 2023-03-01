using SchoolManagementKD13.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Domain
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? SchoolId { get; set; }
        public School? School { get; set; }
        public string? PhotoPath { get; set; }
    }
}
