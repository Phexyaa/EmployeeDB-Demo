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

        private int _salary;
        public int Salary
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

    }
}
