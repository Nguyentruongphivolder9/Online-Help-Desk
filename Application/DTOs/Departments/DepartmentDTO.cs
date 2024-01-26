using Application.Common.Mapppings;
using Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Departments
{
    public class DepartmentDTO : IMapForm<Department>
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public List<RoomDTO>? Rooms { get; set; }
    }
}
