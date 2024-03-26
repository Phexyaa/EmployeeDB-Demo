using Shared.Enums;
using Shared.Models;

namespace API.Data;

public class DataService
{
    internal List<Employee> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    internal List<Employee> SearchEmployees(SearchCriteria criteria, string keyword)
    {
        throw new NotImplementedException();

        //switch (criteria)
        //{
        //    case SearchCriteria.FirstName:
        //        break;
        //    case SearchCriteria.LastName:
        //        break;
        //    case SearchCriteria.HireDate:
        //        break;
        //    case SearchCriteria.Age:
        //        break;
        //    case SearchCriteria.Title:
        //        break;
        //    case SearchCriteria.Salary:
        //        break;
        //    default:
        //        throw new ArgumentOutOfRangeException(nameof(criteria));
        //}



    }
}
