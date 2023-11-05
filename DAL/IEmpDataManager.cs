using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
namespace DAL
{
    public interface IEmpDataManager
    {

        int AddEmployee_DAL(int e_id, string e_Fname, string e_Lname, String e_dob, String e_address);
        int EditEmployee_DAL(Employee employee);
        int DeleteEmployee_DAL(int e_id);
        void ViewAll();
        Employee GetEmployeeByID_DAL(int id);



    }
}
