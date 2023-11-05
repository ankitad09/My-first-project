using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
namespace DAL
{
    public class TravelReqDataManager:IReqDataManager
    {
        List<TravelReq> lstTravelReq = new List<TravelReq>()
        {
           new TravelReq(){ req_id=1,e_id=1,loc_from="Pune",loc_to="Nashik",approval_Status=approvad_req.Pending,booking_Status=confirm_booking.Pending,current_Status=Req_status.Open},
           new TravelReq(){ req_id=2,e_id=2,loc_from="Nashik",loc_to="Mumbai",approval_Status=approvad_req.Pending,booking_Status=confirm_booking.Pending,current_Status=Req_status.Open},
           new TravelReq(){ req_id=3,e_id=3,loc_from="Pune",loc_to="Delhi",approval_Status=approvad_req.Pending,booking_Status=confirm_booking.Pending,current_Status=Req_status.Open},
           new TravelReq(){ req_id=4,e_id=4,loc_from="Delhi",loc_to="Nashik",approval_Status=approvad_req.Pending,booking_Status=confirm_booking.Pending,current_Status=Req_status.Open}
        };

        public int Raise_Travel_Req_DAL(int req_id, int e_id, string loc_from, string loc_to, approvad_req approval_Status, confirm_booking booking_Status, Req_status current_Status)
        {

            foreach (TravelReq travel in lstTravelReq)
            {
                if (travel.req_id == req_id)
                {
                    Console.WriteLine("This Id already Exists");
                    return 0;
                }
                else
                {
                    lstTravelReq.Add(new TravelReq() { req_id = req_id, e_id = e_id, loc_from = loc_from, loc_to = loc_to, approval_Status = approval_Status, booking_Status = booking_Status, current_Status = current_Status });

                    return 1;
                }
            }
            //lstTravelReq.Add(new TravelReq() { req_id = req_id, e_id = e_id, loc_from = loc_from, loc_to = loc_to, approval_Status = approval_Status, booking_Status = booking_Status, current_Status = current_Status });

            return 1;
        }

            public int Delete_Travel_Req_DAL(int req_id)
        {
            var ReqToDelete = lstTravelReq.FirstOrDefault(req => req.req_id == req_id);
            if (ReqToDelete != null)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                lstTravelReq.Remove(ReqToDelete);
                ViewAll_ReqDAL();
                return 1;
            }
            Console.WriteLine("Travel request with ID {0} not found.", req_id);
            return 0;

        }
        public void ViewAll_ReqDAL()
        {
            foreach(TravelReq t in lstTravelReq)
            {
                Console.WriteLine("{0}", t.ToString());
            }
        }

        public void Approval_Status(int req_id, approvad_req approval_Status, Req_status current_Status/*,confirm_booking booking_Status*/)
        {
            TravelReq reqToApproval = lstTravelReq.FirstOrDefault(req => req.req_id == req_id);
            if (reqToApproval != null)
            {
                if (approval_Status == approvad_req.Approved)
                {
                    reqToApproval.approval_Status = approvad_req.Approved;
                    ViewAll_ReqDAL();
                }
                else if(approval_Status == approvad_req.Not_Approved)
                {
                    reqToApproval.approval_Status = approvad_req.Not_Approved;
                    reqToApproval.current_Status = Req_status.Close;
                    ViewAll_ReqDAL();
                }
            }
            else
            {
                ViewAll_ReqDAL();
            }
        }

        public void Confirm_Booking_Status_DAL(int req_id, confirm_booking booking_Status, Req_status current_Status/*, approvad_req approval_Status*/)
        {

            TravelReq reqToConfirmBooking = lstTravelReq.FirstOrDefault(req => req.req_id == req_id);
            if (reqToConfirmBooking != null)
            {
               if(booking_Status == confirm_booking.Confirm && reqToConfirmBooking.approval_Status == approvad_req.Approved)
                {
                    Console.WriteLine("****************************************************************View Requests**************************************************************");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    reqToConfirmBooking.booking_Status = confirm_booking.Confirm;
                    //  reqToConfirmBooking.approval_Status = approval_Status;
                    reqToConfirmBooking.current_Status = Req_status.Close;
                    ViewAll_ReqDAL();
                }
                else if (booking_Status == confirm_booking.Not_Confirm && reqToConfirmBooking.approval_Status == approvad_req.Approved)
                {
                    Console.WriteLine("****************************************************************View Requests**************************************************************");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    reqToConfirmBooking.booking_Status = confirm_booking.Not_Confirm;
                    //  reqToConfirmBooking.approval_Status = approval_Status;
                    reqToConfirmBooking.current_Status = Req_status.Open;
                    ViewAll_ReqDAL();
                }
                else if (booking_Status == confirm_booking.Not_Confirm && reqToConfirmBooking.approval_Status == approvad_req.Not_Approved)
                {
                    Console.WriteLine("****************************************************************View Requests**************************************************************");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    reqToConfirmBooking.booking_Status = confirm_booking.Not_Confirm;
                    //  reqToConfirmBooking.approval_Status = approval_Status;
                    reqToConfirmBooking.current_Status = Req_status.Close;
                    ViewAll_ReqDAL();
                }
                else if(reqToConfirmBooking.approval_Status == approvad_req.Pending)
                {

                    Console.WriteLine("Please first Approved Request");
                }


                //else if (reqToConfirmBooking.approval_Status == approvad_req.Pending)
                //{
                //    reqToConfirmBooking.booking_Status = confirm_booking.Pending;
                //    //  reqToConfirmBooking.approval_Status = approval_Status;
                //    reqToConfirmBooking.current_Status = Req_status.Open;
                //    ViewAll_ReqDAL();
                //}
            }
            else
            {

                ViewAll_ReqDAL();
            }

        }



        public TravelReq Get_RequestById_DAL(int req_id)
        {
            TravelReq travelreq = lstTravelReq.FirstOrDefault(e =>e.req_id == req_id);
            if(travelreq != null)
            {
                return travelreq;
            }
            return null;
        }

        public int EditTravelReq_DAL(TravelReq travelreq)
        {
            TravelReq req_Main = lstTravelReq.FirstOrDefault(x => x.req_id == travelreq.req_id);
            int index = lstTravelReq.IndexOf(req_Main);
            lstTravelReq[index].e_id = travelreq.e_id;
            lstTravelReq[index].loc_from = travelreq.loc_from;
            lstTravelReq[index].loc_to = travelreq.loc_to;
            //lstTravelReq[index].approval_Status = approvad_req.Pending;
            //lstTravelReq[index].booking_Status = confirm_booking.Pending;
            //lstTravelReq[index].current_Status = Req_status.Open;
            ViewAll_ReqDAL();
            return 1;
        }

        EmployeeDataManager employee = new EmployeeDataManager();
        public void ViewJoinReqDAL()
        {
            var AllJoinReq = from emp in employee.lstEmployees
                             join travel in lstTravelReq
                             on emp.e_id equals travel.e_id
                             select new
                             {
                                 e_id = emp.e_id,
                                 req_id = travel.req_id,
                                 e_Fname = emp.e_Fname,
                                 e_Lname = emp.e_Lname,
                                 loc_from = travel.loc_from,
                                 loc_to = travel.loc_to,
                                 approval_Status = travel.approval_Status,
                                 booking_Status = travel.booking_Status,
                                 current_Status = travel.current_Status

                             };
            foreach(var emp in AllJoinReq)
            {
                
                Console.WriteLine($"{emp.e_id}\t{emp.req_id}\t{emp.e_Fname}\t\t{emp.e_Lname}\t\t{emp.loc_from}\t\t{emp.loc_to}\t\t{emp.approval_Status}\t\t\t{emp.booking_Status}\t\t\t{emp.current_Status}");
                 
            }

        }

    }
}