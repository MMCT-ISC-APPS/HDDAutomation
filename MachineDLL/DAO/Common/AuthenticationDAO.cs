using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using MachineDLL.Entities;
using Newtonsoft;
using Newtonsoft.Json;

namespace MachineDLL.DAO
{
    public class AuthenticationDAO
    {
        public UserInfoM GetUserDetail(UserInfoM objUser)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    var json = new JavaScriptSerializer().Serialize(objUser);

                    HttpContent inputContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync("API/Authen/GetUserDetail", inputContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        objUser = JsonConvert.DeserializeObject<UserInfoM>(data.ToString());

                        return objUser;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserInfoM getManagerApproved(String sEN)
        {
            getmailinfo.getMailInfoService MailLotusnote = new getmailinfo.getMailInfoService();
            getmailinfo.EMPLOYEEMAILINFO MailInfo = new getmailinfo.EMPLOYEEMAILINFO();
            MailManager.EMPLOYEEMANAGEROFOWNER EmployeeData = new MailManager.EMPLOYEEMANAGEROFOWNER();
            MailManager.getManagerOfOwnerService MailOwner = new MailManager.getManagerOfOwnerService();
            UserInfoM objUser = null;

            try
            {

                objUser = new UserInfoM();
                objUser.userNo = sEN;
                MailInfo = MailLotusnote.READMAILINFO(sEN); //Owner 
                EmployeeData = MailOwner.READMANAGEROFOWNER(sEN); // Manager

                objUser.LOA = MailInfo.APPLEVEL;
                objUser.fullName = MailInfo.USERNAME;
                objUser.Department = MailInfo.DEPARTMENT;
                objUser.logInName = MailInfo.USERNAME;
                objUser.OwnerEmail = MailInfo.EMAIL;
                objUser.ManagerName = EmployeeData.USERNAME;
                objUser.ManagerEN = EmployeeData.EMPLOYEENO;
                objUser.ManagerMail = EmployeeData.EMAIL;

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                MailInfo = null; ;
                EmployeeData = null;
            }

            return objUser;

        }
    
    }
}
