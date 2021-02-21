using System;

namespace SproutExam.DataAccess.Entities
{
    public partial class Employee
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Tin { get; set; }
        public int EmployeeType { get; set; }
    }
}
