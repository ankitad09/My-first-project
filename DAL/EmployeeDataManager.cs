using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
namespace DAL
{
    public class EmployeeDataManager:IEmpDataManager
    {
       public List<Employee> lstEmployees = new List<Employee>()
        {
            new Employee(){e_id=1,e_Fname="Ankita",e_Lname="Dhondge",e_DOB="16-06-2002",e_Address="Nashik"},
            new Employee(){e_id=2,e_Fname="Anisha",e_Lname="Dhondge",e_DOB="25-06-2004",e_Address="Nashik"},
            new Employee(){e_id=3,e_Fname="Snehal",e_Lname="Thoke",e_DOB="14-01-2002",e_Address="Ashoknagar"},
            new Employee(){e_id=4,e_Fname="Kanchan",e_Lname="Ghule",e_DOB="16-01-2002",e_Address="Nashik"}
        };
        public  int AddEmployee_DAL(int e_id, string e_Fname, string e_Lname, String e_dob, String e_address)
        {

            foreach (Employee emp in lstEmployees)
            {
                if (emp.e_id == e_id)
                {
                    Console.WriteLine("This Id already Exists");
                    return 0;
                   
                }
                else
                {
                    lstEmployees.Add(new Employee() { e_id = e_id, e_Fname = e_Fname, e_Lname = e_Lname, e_DOB = e_dob, e_Address = e_address });
                    //Console.WriteLine(emp.ToString());
                    return 1;
                }
                 
            }

            return 1;
        }
        //public int EditEmployee_DAL(Employee employee)
        //{
        //    Employee emp_Main = lstEmployees.FirstOrDefault(x => x.e_id == employee.e_id);

        //    int index = lstEmployees.IndexOf(emp_Main);
        //    lstEmployees[index].e_Fname = employee.e_Fname;
        //    lstEmployees[index].e_Lname = employee.e_Lname;
        //    lstEmployees[index].e_DOB = employee.e_DOB;
        //    lstEmployees[index].e_Address = employee.e_Address;
        //    ViewAll();
        //    return 1;
        //}
        public int EditEmployee_DAL(Employee employee)
        {
            Employee emp_Main = lstEmployees.FirstOrDefault(x => x.e_id == employee.e_id);

            if (emp_Main != null)
            {
                
                int index = lstEmployees.IndexOf(emp_Main);
                lstEmployees[index].e_Fname = employee.e_Fname;
                lstEmployees[index].e_Lname = employee.e_Lname;
                lstEmployees[index].e_DOB = employee.e_DOB;
                lstEmployees[index].e_Address = employee.e_Address;
                ViewAll();
                return 1;

            }
            Console.WriteLine("This ID does not exist in the list");
            return 0;
        }
        public int DeleteEmployee_DAL(int e_id)
        {
            var employeeToDelete = lstEmployees.FirstOrDefault(emp => emp.e_id == e_id);

            if (employeeToDelete != null)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("E Id\t\tFname\t\tLname\t\tDOB\t\tAddress");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                lstEmployees.Remove(employeeToDelete);
                ViewAll(); // Assuming this method displays the updated list or performs some relevant action.

                return 1; // Success
            }

            Console.WriteLine("Employee with ID {0} not found.", e_id);
            return 0; // Failure
        }

        public void ViewAll()
        {
            foreach (Employee e in lstEmployees)
            {
                Console.WriteLine("{0}", e.ToString());
               
            }
            //Console.WriteLine(ToString());
            //Console.ReadLine();
        }

        public Employee GetEmployeeByID_DAL(int e_id)
        {
            Employee employee = lstEmployees.FirstOrDefault(e => e.e_id == e_id);
            if (employee != null)
            {
                return employee;
            }
            return null;
        }
    }
}

