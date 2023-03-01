using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Commands
{
    public class CommandResponse
    {
        public bool Found { get; set; } = true;
        public bool Check { get; set; } = true;
        public int DbCheck { get; set; }
    }
}
