using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
namespace DAL
{
    public interface IReqDataManager
    {

        int Raise_Travel_Req_DAL(int req_id,int e_id, string loc_from, string loc_to, approvad_req approval_Status, confirm_booking booking_Status, Req_status current_Status);
        //int Edit_Travel_Req_DAL(TravelReq travelReq);
        int Delete_Travel_Req_DAL(int req_id);
        //int Approve_Travel_Req(int travel_id /*,ApprovedStatus appstatus*/);
        //int Confirm_Booking(int travel_id/*, BookingStatus bookstatus*/);
        void ViewAll_ReqDAL();
        void Approval_Status(int req_id, approvad_req approval_Status, Req_status current_Status/*, confirm_booking booking_Status*/);
        void Confirm_Booking_Status_DAL(int req_id, confirm_booking booking_Status, Req_status current_Status/*, approvad_req approval_Status*/);
        TravelReq Get_RequestById_DAL(int req_id);
        int EditTravelReq_DAL(TravelReq travelreq);
        void ViewJoinReqDAL();
    }
}
