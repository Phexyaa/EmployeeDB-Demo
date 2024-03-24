using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Global;
public class Defaults
{
    public List<string> Titles { get; } =
    new List<string>()
    {
        "Executive",
        "Manager",
        "Assistant Manager",
        "Secretary",
        "N/A"
    };

    public List<string> SearchCriteria { get; } = new List<string>()
    {
        "First Name",
        "Last Name",
        "Hire Date",
        "Age",
        "Title",
        "Salary"
    };
}
