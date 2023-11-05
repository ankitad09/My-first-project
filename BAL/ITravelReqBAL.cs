using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BAL
{
    public interface ITravelReqBAL
    {
        //int Raise_Travel_Req_BAL(int req_id,int e_id, string loc_from, string loc_to, approvad_req approval_Status, confirm_booking booking_Status, Req_status current_Status);
        void ViewAll_ReqBAL();
        //void Approval_Status_BAL(int req_id, approvad_req approval_Status);
        int Delete_Travel_Req_BAL(int req_id);

    }
}
