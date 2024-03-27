namespace Shared.Models
{
    public class Employee : Person
    {
        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set => SetProperty(ref _salary, value);
        }

        private DateTime _hireDate;
        public DateTime HireDate
        {
            get => _hireDate;
            set => SetProperty(ref _hireDate, value);
        }
        private Guid _employeeId;
        public Guid EmployeeId
        {
            get => _employeeId; 
            set => SetProperty(ref _employeeId, value);
        }

    }
}
