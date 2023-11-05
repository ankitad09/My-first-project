using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public enum approvad_req {Pending, Approved, Not_Approved};
   public  enum confirm_booking{Pending, Confirm, Not_Confirm};
   public enum Req_status {Open,Close};
    public class TravelReq
    {
        public int req_id { get; set; }
        public int e_id { get; set; }
        public string loc_from { get; set; }
        public string loc_to { get; set; }
        public approvad_req approval_Status { get; set; }
        public confirm_booking booking_Status { get; set; }
        public Req_status current_Status { get; set; }


        //public TravelReq(int reqId = 1, int id = 1, string locFrom = "pune", string locTo = "Mumbai", approvalStatus= approvad_req.Approved, bookingStatus= confirm_booking.Confirm, currentStatus= Req_status.Close)
        //{
        //    req_id = reqId;
        //    e_id = id;
        //    loc_from = locFrom;
        //    loc_to = locTo;
        //    approval_Status = approvalStatus;
        //    booking_Status = confirmBooking;
        //    current_Status = ReqStatus;

        //}
        public override string ToString()
        {

            //return string.Format($"{req_id}\t{e_id}\t{loc_from}\t\t{loc_to}\t\t{approval_Status}\t\t\t{booking_Status}\t\t\t{current_Status}");
            return string.Format($"{req_id}      {e_id}         {loc_from}         {loc_to}              {approval_Status}               {booking_Status}                 {current_Status}");
            Console.ReadLine();
        }

    }
}
