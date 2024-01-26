using Application.Common.Mapppings;
using Application.DTOs.Requests;
using Domain.Entities.Departments;
using Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Departments
{
    public class RoomDTO : IMapForm<Room>
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomStatus { get; set; }
        public DepartmentDTOWithoutRoomList? Departments { get; set; }
    }
}
