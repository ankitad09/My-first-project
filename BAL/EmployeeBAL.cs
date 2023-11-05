using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DAL;
namespace BAL
{

    public class EmployeeBAL:IEmployeeBAL
    {
        public static readonly EmployeeDataManager empData = new EmployeeDataManager();
        public int AddEmployee_BAL(int e_id, string e_Fname, string e_Lname, String e_dob, String e_address)
        {
            empData.AddEmployee_DAL(e_id,e_Fname, e_Lname, e_dob, e_address);
            return 1;
        }

        public int EditEmployee_BAL(Employee emp_to_Change)
        {
            
            empData.EditEmployee_DAL(emp_to_Change);

            return 1;
        }
        public int DeleteEmployee_BAL(int e_id)
        {
            //EmployeeDataManager delete = new EmployeeDataManager();
            empData.DeleteEmployee_DAL(e_id);
            return 1;
        }

        public void ViewAllEmployee_BAL()
        {
            // EmployeeDataManager view = new EmployeeDataManager();
            Console.WriteLine("****************************************************************View Employees**************************************************************");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("E Id\t\tFname\t\tLname\t\tDOB\t\tAddress");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            empData.ViewAll();

        }

        public Employee GetEmployeeByID_BAL(int e_id)
        {
            //EmployeeDataManager emp_m= new EmployeeDataManager();
            Employee emp = empData.GetEmployeeByID_DAL(e_id);
            return emp;
        }

    }
}
