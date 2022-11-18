using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public class UserInfoM : EntityBase
    {
        public String userID { get; set; }
        public String userNo { get; set; }
        public String titleName { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String nickName { get; set; }
        public String fullName { get; set; }
        public String position { get; set; }
        public String phoneNo { get; set; }
        public String mobile { get; set; }
        public String fax { get; set; }
        public String gender { get; set; }

        public String idCard { get; set; }
        public Int64 idCardImgFileID { get; set; }

        public String userRole { get; set; }
        public String logInName { get; set; }

        public String openFromApp { get; set; }

        public String lastAction { get; set; }
        public String Role { get; set; }
        public String Department { get; set; }
        public DateTime lastActionDateTime { get; set; }
        public String ManagerName { get; set; }
        public String OwnerEmail { get; set; }
        public String LOA { get; set; }
        public String ManagerMail { get; set; }
        public String ManagerEN { get; set; }

    }
}
