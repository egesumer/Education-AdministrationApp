using MediatR;
using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Queries.GetAllSchools
{
    public class GetAllSchoolsQueryRequest : IRequest<List<School>>
    {
    }
}
