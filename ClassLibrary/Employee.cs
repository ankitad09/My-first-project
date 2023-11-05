using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Employee
    {
        public  int e_id
        {
            get;set;
        }

        public string e_Fname
        {
            get; set;
        }

        public string e_Lname
        {
            get; set;
        }

        public string e_DOB
        {
            get; set;
        }

        public string e_Address
        {
            get; set;
        }

        //public Employee(int id,string Fname, string Lname,string DOB,string Address)
        //{
        //    e_id=id;
        //    e_Fname = Fname;
        //    e_Lname = Lname;
        //    e_DOB = DOB;
        //    e_Address = Address;

        //}

        public override string ToString()
        {
            
            return string.Format($"{e_id}\t\t{e_Fname}\t\t{e_Lname}\t\t{e_DOB}\t{e_Address}");

            Console.ReadLine();
        }
    }
}
