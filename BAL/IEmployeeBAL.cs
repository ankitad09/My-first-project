using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DAL;
namespace BAL
{
    public interface IEmployeeBAL
    {
        int AddEmployee_BAL(int e_id, string e_Fname, string e_Lname, String e_dob, String e_address);
        int EditEmployee_BAL(Employee emp_to_Change);
        int DeleteEmployee_BAL(int e_id);
        void ViewAllEmployee_BAL();
        Employee GetEmployeeByID_BAL(int e_id);



    }
}
