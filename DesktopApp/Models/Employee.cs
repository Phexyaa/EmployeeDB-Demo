using CommunityToolkit.Mvvm.ComponentModel;
using EmpDemoApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    class Employee : Person
    {
        private string _title = "Boss";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

    }
}
