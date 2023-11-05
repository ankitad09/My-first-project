using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ClassLibrary;
namespace BAL
{
   
    public class TravelReqBAL: ITravelReqBAL
    {
        public static readonly TravelReqDataManager reqData = new TravelReqDataManager();
        public int Raise_Travel_Req_BAL(int req_id,int e_id, string loc_from, string loc_to, approvad_req approval_Status, confirm_booking booking_Status, Req_status current_Status)
        {
            reqData.Raise_Travel_Req_DAL(req_id, e_id, loc_from, loc_to,  approval_Status,  booking_Status,current_Status);
            return 1;
        }
        public int Delete_Travel_Req_BAL(int req_id)
        {
            reqData.Delete_Travel_Req_DAL(req_id);
            return 1;

        }
        public void ViewAll_ReqBAL()
        {
            Console.WriteLine("****************************************************************View Requests**************************************************************");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"R Id\tE Id\tLoc From\tLoc To\t\tApproval Status\t\tBooking Status\t\tCurrent Status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            reqData.ViewAll_ReqDAL();
        }
        public  void Approval_Status_BAL(int req_id, approvad_req approval_Status, Req_status current_Status/*, confirm_booking booking_Status*/)
        {
            reqData.Approval_Status(req_id,approval_Status,current_Status/*,booking_Status*/);
           
        }

        public void Confirm_Booking_Status_BAL(int req_id, confirm_booking booking_Status,Req_status current_Status/*, approvad_req approval_Status*/)
        {
            reqData.Confirm_Booking_Status_DAL(req_id, booking_Status,current_Status/*, approval_Status*/);
        }

        public TravelReq Get_RequestById(int req_id)
        {
            TravelReq req = reqData.Get_RequestById_DAL(req_id);
            return req;
        }

        public int EditTravelReq_BAL(TravelReq req_to_change)
        {
            reqData.EditTravelReq_DAL(req_to_change);
            return 1;
        }

        public void ViewJoinReqBAL()
        {
            //{ req_id}\t{ e_id}\t{ loc_from}\t\t{ loc_to}\t\t{ approval_Status}\t\t{ booking_Status}\t\t{ current_Status}
            
            reqData.ViewJoinReqDAL();
        }

    }
}
