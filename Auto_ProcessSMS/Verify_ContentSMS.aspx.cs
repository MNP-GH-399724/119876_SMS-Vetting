using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Services;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HoApps.Auto_ProcessSMS
{
    public partial class Verify_ContentSMS : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string usr;
            usr = Session["username"].ToString();

            this.hdUserId.Value = usr;
        }

        public class getDropDownData
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        [WebMethod(EnableSession = true)]
        public static string checkAuth()
        {
            DataSet ds = new DataSet();
            
            string Resp;
            string user = HttpContext.Current.Session["username"].ToString();
            CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();
            ds = obj.CommonSelect("SMS_REQUEST", "checkAuth", user, "");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Resp = ds.Tables[0].Rows[0][0].ToString();
                    return Resp;
                }
            }
            catch (Exception e)
            {
            }
            return "something went wrong";
        }

        // load get Drop down
        [WebMethod(EnableSession = true)]
        public static List<getDropDownData> getFillData()
        {
            DataSet ds;
            List<getDropDownData> getData = new List<getDropDownData>();
            CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();
            ds = obj.CommonSelect("SMS_REQUEST", "getListData", "", "");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        getData.Add(new getDropDownData()
                        {
                            id = dr[0].ToString(),
                            name = dr[1].ToString() //DecodeSMSCOntentt
                        });
                    }
                }
            }
            catch (Exception e)
            {
                //return e.Message = 'Exeption hitted';
            }
            return getData;
        }

        public class empdtls
        {
            public string empcode { get; set; }
            public string empname { get; set; }
            public string empmob { get; set; }
            public string creted_char_length { get; set; }
            public string initialContent { get; set; }
            public string empdep { get; set; }

        }

        [WebMethod(EnableSession = true)]
        public static empdtls Load_Select_Data(string val)
        {
            DataSet dt;

            empdtls ep = new empdtls();
            // status st = new status();
            string user = HttpContext.Current.Session["username"].ToString();
            CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();
            dt = obj.CommonSelect("SMS_REQUEST", "getVerifyLoadData", val, "");
            try
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(dt.Tables[0].Rows[0][4].ToString());
                    string DecodeSMSCOntentt = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);


                    ep.empcode = dt.Tables[0].Rows[0][0].ToString();
                    ep.empname = dt.Tables[0].Rows[0][1].ToString();
                    ep.empmob = dt.Tables[0].Rows[0][2].ToString();
                    ep.creted_char_length = dt.Tables[0].Rows[0][3].ToString();
                    ep.initialContent = DecodeSMSCOntentt;
                    ep.empdep = dt.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    ep.empcode = "";
                    ep.empname = "";
                    ep.empdep = "";
                }

            }
            catch (Exception e)
            {
                ep.empcode = "";
                ep.empname = "";
                ep.empdep = "";
            }
            // ep.Status = st;
            return ep;
        }



        // send Mail
        [WebMethod(EnableSession = true)]
        public static string SendMail(string toMail, string cc, string body, string subject)
        {
            string exp = "";

            try
            {
                SmtpClient server = new SmtpClient("smtp.office365.com");
                server.Port = 587;
                server.EnableSsl = true;
                server.UseDefaultCredentials = false;
                //server.Credentials = new System.Net.NetworkCredential("itportal@manappuram.com", "PLMokn@789", "smtp.office365.com");
                server.Credentials = new System.Net.NetworkCredential("smsverification@manappuram.com", "Qplm@3399", "smtp.office365.com");
                server.Timeout = 10000;
                server.TargetName = "STARTTLS/smtp.office365.com";
                server.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(toMail));
                //mail.From = new MailAddress("itportal@manappuram.com");
                mail.From = new MailAddress("smsverification@manappuram.com");
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body;
                // if (cc != "" || cc != null) mail.CC.Add(new MailAddress(cc));
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
                mail.IsBodyHtml = true;
                server.Send(mail);
            }
            catch (Exception e)
            {
                exp = "NA";
                return exp;
                throw e;
            }
            return exp;

        }

        // Get IMAGE URL
        [WebMethod(EnableSession = true)]
        public static string GetImageUrl(string imagePath)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(imagePath));
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            Byte[] bytes = new Byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(bytes, 0, (int)bytes.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            string imageUrl = "data:image/png;base64," + base64String;
            return imageUrl;
        }


        [WebMethod(EnableSession = true)]
        public static string UpdateSMSTOTable(string val, string val1)
        {
            DataSet ds;
            string result, EncodeTxt;
            String[]  spl;
            spl= val1.Split('~');

            Helper.Oracle.OracleHelper helper = new Helper.Oracle.OracleHelper();
            CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();

            // text encoding
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(spl[0]);
            string EncodeSMSContent = System.Convert.ToBase64String(plainTextBytes);
            var plainRmkBytes = System.Text.Encoding.UTF8.GetBytes(spl[1]);
            string EncodeSMSRmk = System.Convert.ToBase64String(plainRmkBytes);
            
            // text decoding
            var base64EncodedBytes = System.Convert.FromBase64String(EncodeSMSContent);
            string DecodeSMSCOntentt = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            EncodeTxt = EncodeSMSContent + '~' + EncodeSMSRmk;
            ds = obj.CommonSelect("SMS_REQUEST", "UpdateSMSTOTable", val, EncodeTxt);

            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    result = ds.Tables[0].Rows[0][0].ToString();
                    try
                    {
                        DataTable dt1;
                        string user = HttpContext.Current.Session["username"].ToString();

                        dt1 = obj.CommonSelect("SMS_REQUEST", "getToMailDetails", "", "").Tables[0];
                        string reqmailid = dt1.Rows[0][0].ToString() + "@manappuram.com";
                        string reqname = dt1.Rows[0][1].ToString(); // No but ok
                        string reqDept = dt1.Rows[0][2].ToString();



                        //../App_Themes/Theme/assets/img/logo.png
                        string imageUrlLog = GetImageUrl("../App_Themes/Theme/assets/img/logo.png");
                            string imageContentLog = "<img src='" + imageUrlLog + "' alt='Manappuram Logo' />";
                            string imageUrlPaperless = GetImageUrl("../App_Themes/Theme/assets/img/logo.png");
                            //string imageContentPaperless = "<img src='" + imageUrlPaperless + "' alt='Alternate Text' />";

                            string bdy = "<p style='font-family: Calibri,Arial,Helvetica,sans-serif;font-size:12pt;color:rgb(0,0,0);'><b>Dear Sir,</b><br/>" +
                             " <br/><br/><u>A new SMS-Content  <b> '"  + DecodeSMSCOntentt + "'</b> From <i> <b>CORPORATE COMMUNICATION Dept</b></i><br/><br/> Has been Forwarded to <i><b>SMS team</b></i> </br></br</u><br/> "
                             + " <br/><br/><br/><br/>  Thanks & Regards,<br/>team SMS Verification<br/><span style = 'font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif; color:gray' lang='EN-IN'>" +
                             "Please do not reply to this email ID as this is an automatically generated email and reply to this ID is not being monitored</span></p>"
                             + imageContentLog + "<p><span style = 'color:rgb(105,105,105); font-size:7pt; font-family:arial,sans-serif; line-height:normal; background-color:rgba(0,0,0,0)' >Please be aware that this email/attachment contains MAFIL confidential/sensitive data. You are requested to follow MAFIL Information Security and data sharing policies in case the data is shared further. Feel free to contact AGM Information Security when youare in doubt.</span></p>";

                            string subj = "New Assign SMS_CONTENT From CORPORATE COMMUNICATION Dept";    //"CRF -: " + noteid + " - Need to edit content";
                                                                                                  //string dtls = "10µ" + reqmailid + "µµµ" + subj + "µ" + noteid + "µAMS";  

                            //SendMail("399724@manappuram.com", "", bdy, subj);
                        SendMail("sms.sales@manappuramfinance.onmicrosoft.com", "", bdy, subj); // sales team
                        SendMail("326845@manappuram.com", "", bdy, subj); // akhil kt
                        //SendMail(reqmailid, "", bdy, subj);


                    }

                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }

                }
                else
                {
                    result = "not inserted ";
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

    }
}