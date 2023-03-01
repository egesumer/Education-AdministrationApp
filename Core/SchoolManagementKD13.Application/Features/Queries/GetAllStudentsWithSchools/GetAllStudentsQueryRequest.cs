using MediatR;
using SchoolManagementKD13.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Application.Features.Queries.GetAllStudentsWithSchools
{
    public class GetAllStudentsQueryRequest : IRequest<List<Student>>
    {
        //varsa parametreleri property olarak ekle.
    }
}
