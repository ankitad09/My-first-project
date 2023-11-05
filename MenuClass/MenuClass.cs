using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using ClassLibrary;
namespace MenuClass
{
    //this class contains all static methods to display all menus
    enum menu { manage_employee, manage_travel_request, Exit };
    enum Manage_employee { Add, Edit, Delete, View, Go_back };
    enum travel_employee { Raise_travel_request, view_Travel_requests, Delete_travel_requests,Edit_travel_requests, Approve_travel_requests, Confirm_Booking,View_join, Go_back };
    enum approve_req { Approved, Not_Approved,Pending };
    enum confirm_Booking {Confirm,Not_Confirm,Pending};
    enum req_status { Open,Closed};
    public class Menu
    {
        //MAin menu screen
        public static void ShowMain()
        {

            menu select_menu;
            int choice;
            Console.WriteLine("-----------------------\nMain menu\n-----------------------\n1.Manage Employee,\n2.Manage Travel Request\n3.Exit\n-----------------------");
            Console.WriteLine("Choose a num:");

            try
            {
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        select_menu = menu.manage_employee;
                        Employee_Manage();
                        break;

                    case 2:
                        select_menu = menu.manage_travel_request;
                        Travel_req();
                        break;

                    case 3:
                        select_menu = menu.Exit;
                        Environment.Exit(0);
                        break;

                    default:
                        select_menu = menu.manage_employee;
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric choice.");
            }

        }
        //Employee manage screen
        public static void Employee_Manage()
        {
            Manage_employee Manage;
            int choice;
            Console.WriteLine("---------------------\nManage employee menu\n---------------------\n1.Add\n2.Edit\n3.Delete\n4.View\n5.Go back\n--------------------");
            Console.WriteLine("Choose a choice:");
            choice = int.Parse(Console.ReadLine());
            try {
                switch (choice)
                {
                    case 1:
                        Manage = Manage_employee.Add;
                        Add_Employee();
                        break;
                    case 2:
                        Manage = Manage_employee.Edit;
                        Edit_Employee();
                        break;
                    case 3:
                        Manage = Manage_employee.Delete;
                        Delete_Employee();
                        break;
                    case 4:
                        Manage = Manage_employee.View;
                        View_Employee();
                        break;
                    case 5:
                        Manage = Manage_employee.Go_back;
                        ShowMain();
                        break;
                    default:
                        Manage = Manage_employee.Add;
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric choice.");
            }

        }
        //travel req screen
        public static void Travel_req()
        {
            travel_employee travel;
            int choice;
            Console.WriteLine("---------------------\nManage travel request menu\n---------------------\n1.Raise travel request\n2.view Travel requests\n3.Delete travel requests\n4.Edit Travel Requests\n5.Approve travel requests\n6.Confirm Booking\n7.View All Join\n8.Go back\n--------------------");
            Console.WriteLine("Choose a choice:");
            choice = int.Parse(Console.ReadLine());
            try {
                switch (choice)
                {
                    case 1:
                        travel = travel_employee.Raise_travel_request;
                        Raise_Travel_Req();
                        break;
                    case 2:
                        travel = travel_employee.view_Travel_requests;
                        View_Travel_Req();
                        break;
                    case 3:
                        travel = travel_employee.Delete_travel_requests;
                        Delete_Travel_Req();
                        break;
                    case 4:
                        travel = travel_employee.Edit_travel_requests;
                        Edit_Travel_Req();
                        break;
                    case 5:
                        travel = travel_employee.Approve_travel_requests;
                        Approve_Travel_Req();
                        break;
                    case 6:
                        travel = travel_employee.Confirm_Booking;
                        Confirm_Booking();
                        break;
                    case 7:
                        travel = travel_employee.View_join;
                        View_AllEmpTravel();
                        break;

                    case 8:
                        travel = travel_employee.Go_back;
                        ShowMain();
                        break;
                    default:
                        travel = travel_employee.Raise_travel_request;
                        break;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric choice.");
            }

        }
        //add employee screen
        public static void Add_Employee()
        {
            int e_id;
            String e_Fname;
            String e_Lname;
            String e_dob;
            String e_address;

            EmployeeBAL emp = new EmployeeBAL();

            //String e_contact;
            try
            {
                Console.WriteLine("*********Add Employee**********");


                Console.WriteLine("Enter your ID:");
                e_id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter your First Name:");
                e_Fname = Console.ReadLine();

                Console.WriteLine("Enter your Last Name:");
                e_Lname = Console.ReadLine();

                Console.WriteLine("Enter your DOB:");
                e_dob = Console.ReadLine();

                Console.WriteLine("Enter your Address:");
                e_address = Console.ReadLine();

                emp.AddEmployee_BAL(e_id, e_Fname, e_Lname, e_dob, e_address);

                EmployeeBAL view = new EmployeeBAL();
                view.ViewAllEmployee_BAL();
                //Console.WriteLine("Enter your Contact No:");
                //e_contact = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            }

        }
        //edit employee screen
        public static void Edit_Employee()
        {
            EmployeeBAL view = new EmployeeBAL();
            view.ViewAllEmployee_BAL();

            int edit_choice,e_id;
            string e_Fname;
            string e_Lname;
            string e_DOB;
            string e_Address;
            Employee emp_to_Change;
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Enter Employee ID for editing Data:");
                e_id = int.Parse(Console.ReadLine());

                // get the emp to change from BAL
                emp_to_Change = view.GetEmployeeByID_BAL(e_id);

                Console.WriteLine("*********Edit Employee**********");
                Console.WriteLine("1.First Name\n2.Last Name\n3.DOB\n4.Address");

                Console.WriteLine("Choose a Num to edit:");
                edit_choice = int.Parse(Console.ReadLine());

                switch (edit_choice)
                {
                    case 1:
                        Console.WriteLine("Enter your first Name:");
                        e_Fname = Console.ReadLine();
                        emp_to_Change.e_Fname = e_Fname;
                        break;

                    case 2:
                        Console.WriteLine("Enter your Last Name:");
                        e_Lname = Console.ReadLine();
                        emp_to_Change.e_Lname = e_Lname;
                        break;

                    case 3:
                        Console.WriteLine("Enter your DOB:");
                        e_DOB = Console.ReadLine();
                        emp_to_Change.e_DOB = e_DOB;
                        break;

                    case 4:
                        Console.WriteLine("Enter your Address:");
                        e_Address = Console.ReadLine();
                        emp_to_Change.e_Address = e_Address;
                        break;

                    default:
                        Console.WriteLine("Please select valid number");
                        break;
                }
                Console.WriteLine("****************************************************************View Employees**************************************************************");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("E Id\t\tFname\t\tLname\t\tDOB\t\tAddress");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                view.EditEmployee_BAL(emp_to_Change);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            }
        }
        //delete employee - screen
        public static void Delete_Employee()
        {
            int e_id;
            Console.WriteLine("*********Delete Employee**********");
            EmployeeBAL view = new EmployeeBAL();
            view.ViewAllEmployee_BAL();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Enter Employee ID:");
                e_id = int.Parse(Console.ReadLine());

                //Console.WriteLine("****************************************************************View Employees**************************************************************");
               
                EmployeeBAL delete = new EmployeeBAL();
                delete.DeleteEmployee_BAL(e_id);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            }
        }
        //view employee
        public static void View_Employee()
        {
            
            EmployeeBAL view = new EmployeeBAL();
            view.ViewAllEmployee_BAL();


        }
        //raise travel req screen
        public static void Raise_Travel_Req()
        {
            TravelReqBAL travel_req = new TravelReqBAL();
            int req_id;
            int e_id;
            string loc_from;
            string loc_to;
            approve_req Approve;
            confirm_Booking book;
            req_status req;

            Console.WriteLine("*********Raise Travel Request**********");
            try
            {
                Console.WriteLine("Enter Request Id:");
                req_id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter employee Id:");
                e_id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter location from:");
                loc_from = Console.ReadLine();

                Console.WriteLine("Enter location to:");
                loc_to = Console.ReadLine();

                travel_req.Raise_Travel_Req_BAL(req_id, e_id, loc_from, loc_to, approvad_req.Pending, confirm_booking.Pending, Req_status.Open);

                //TravelReqBAL req = new TravelReqBAL();
                travel_req.ViewAll_ReqBAL();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            }
        }
        //view travel requests
        public static void View_Travel_Req()
        {
            TravelReqBAL req = new TravelReqBAL();
            req.ViewAll_ReqBAL();
            
        }
        //delete travel request
        public static void Delete_Travel_Req()
        {
            int req_id;
            Console.WriteLine("*********Delete Travel Request**********");
            Console.WriteLine("Show all Requests");
            TravelReqBAL req = new TravelReqBAL();
            req.ViewAll_ReqBAL();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Enter Request ID to delete Request:");
                req_id = int.Parse(Console.ReadLine());
               // Console.WriteLine("****************************************************************View Requests**************************************************************");
                
                TravelReqBAL del = new TravelReqBAL();
                del.Delete_Travel_Req_BAL(req_id);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            }

        }
        public static void Edit_Travel_Req()
        {
            TravelReqBAL request = new TravelReqBAL();
            request.ViewAll_ReqBAL();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            int choice;
            int req_id;
            int e_id;
            string loc_from;
            string loc_to;
            approve_req Approve;
            confirm_Booking book;
            req_status req;
            TravelReq req_to_change;
            try
            {
                Console.WriteLine("Enter Reuest Id to Edit Travel request");
                req_id = int.Parse(Console.ReadLine());

                req_to_change = request.Get_RequestById(req_id);

                Console.WriteLine("*********************Edit travel Requests************************");
                Console.WriteLine("1.Employee ID\n2.Location From\n3.Location To");

                Console.WriteLine("Choose a Num to edit:");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Employee Id:");
                        e_id = int.Parse(Console.ReadLine());
                        req_to_change.e_id = e_id;
                        break;
                    case 2:
                        Console.WriteLine("Enter Location From:");
                        loc_from = Console.ReadLine();
                        req_to_change.loc_from = loc_from;
                        break;
                    case 3:
                        Console.WriteLine("Enter Location To:");
                        loc_to = Console.ReadLine();
                        req_to_change.loc_to = loc_to;
                        break;
                }
                Console.WriteLine("****************************************************************View Requests**************************************************************");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                request.EditTravelReq_BAL(req_to_change);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
            }

        }
        public static void Approve_Travel_Req()
        {
            TravelReqBAL RequestBAL = new TravelReqBAL();
            approve_req Approve;

            int choice;
            int req_id;

            RequestBAL.ViewAll_ReqBAL();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            try
            {
                Console.WriteLine("Enter Request Id to change Approval Status:");
                req_id = int.Parse(Console.ReadLine());

                Console.WriteLine("Do you want to Approved Travel Request\n-----------------------\n1.Approved,\n2.Not Approved\n-----------------------");
                Console.WriteLine("Choose 1 to Approved and 2 to Not approved:");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("****************************************************************View Requests**************************************************************");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        RequestBAL.Approval_Status_BAL(req_id, approvad_req.Approved, Req_status.Close/*, confirm_booking.Confirm*/);
                        break;

                    case 2:
                        Console.WriteLine("****************************************************************View Requests**************************************************************");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        RequestBAL.Approval_Status_BAL(req_id, approvad_req.Not_Approved, Req_status.Open/*, confirm_booking.Not_Confirm*/);
                        break;

                    default:
                        Console.WriteLine("****************************************************************View Requests**************************************************************");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        RequestBAL.Approval_Status_BAL(req_id, approvad_req.Approved, Req_status.Close/*, confirm_booking.Confirm*/);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value for Request ID and choice.");
            }
        }
        public static void Confirm_Booking()
        {
            TravelReqBAL booking = new TravelReqBAL();
            confirm_Booking book;
            int choice;
            int req_id;
            booking.ViewAll_ReqBAL();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Enter Request Id to change Booking Status:");
                req_id = int.Parse(Console.ReadLine());

                Console.WriteLine("Do you want to change booking status\n-----------------------\n1.Confirm,\n2.Not Confirm\n-----------------------");
                Console.WriteLine("Choose 1 to Confirm and 2 to Not Confirm:");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        booking.Confirm_Booking_Status_BAL(req_id, confirm_booking.Confirm, Req_status.Close/*, approvad_req.Approved*/);
                        break;
                    case 2:

                        booking.Confirm_Booking_Status_BAL(req_id, confirm_booking.Not_Confirm, Req_status.Open/*, approvad_req.Not_Approved*/);
                        break;

                    default:
                        Console.WriteLine("****************************************************************View Requests**************************************************************");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        booking.Confirm_Booking_Status_BAL(req_id, confirm_booking.Confirm, Req_status.Close/*, approvad_req.Approved*/);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value for Request ID and choice.");
            }

        }
        public static void View_AllEmpTravel()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Emp Id\tReq Id\tFName\t\tLname\t\tLoc from\tLoc to\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            TravelReqBAL ViewJoin =new  TravelReqBAL();
            ViewJoin.ViewJoinReqBAL();
        }
    }
}
