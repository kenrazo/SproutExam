using SproutExam.Common.Enums;
using System;

namespace SproutExam.Service.Dtos
{
    public class EmployeeOutputDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Tin { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
