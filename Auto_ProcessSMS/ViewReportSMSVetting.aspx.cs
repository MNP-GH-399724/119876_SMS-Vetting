using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HoApps.Auto_ProcessSMS
{
    public partial class ViewReportSMSVetting : System.Web.UI.Page
    {
        string  user;
        DataSet ds, ds1 = new DataSet();

        Helper.Oracle.OracleHelper helper = new Helper.Oracle.OracleHelper();
        CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = HttpContext.Current.Session["username"].ToString();
            this.hdUserId.Value = user;   
        }

        public class getDropDownData
        {
            public string id { get; set; }
            public string name { get; set; }
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
        public class RespStatus
        {
            public string code { get; set; }
            public string msg { get; set; }
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
            return "something went wrong, Not hit auth flag";
        }


        // load get Drop down
        [WebMethod(EnableSession = true)]
        public static List<getDropDownData> getOptionLists()
        {
            DataSet ds;
            List<getDropDownData> getData = new List<getDropDownData>();
            CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();
            ds = obj.CommonSelect("SMS_REQUEST", "getAproveLists", "", "");
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


        [WebMethod(EnableSession = true)]
        protected void DataTableToHTMLTable(DataTable inTable,string DepID)
        {
            System.Text.StringBuilder dString = new System.Text.StringBuilder();
            dString.Append("<table id='example' class='display' cellpadding='0' cellspacing='0' border='0'>");
            dString.Append(GetHeader(inTable));
            dString.Append(GetBody(inTable, DepID));
            dString.Append("</table>");
            MyTable.InnerHtml = dString.ToString();
            //return "";
        }

        private static string GetHeader(DataTable dTable)
        {
            System.Text.StringBuilder dString = new System.Text.StringBuilder();
            dString.Append("<thead><tr>");
            foreach (DataColumn dColumn in dTable.Columns)
            {
                dString.AppendFormat("<th>{0}</th>", dColumn.ColumnName);
            }
            dString.Append("</tr></thead>");
            return dString.ToString();
        }

        [WebMethod(EnableSession = true)]
        protected void btnTest_Click(object sender, EventArgs e)
        {
            DataSet ds1;

            RespStatus st = new RespStatus();
            string DepID = this.HdnDepId.Value;
            CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();
            ds1 = obj.CommonSelect("SMS_REQUEST", "viewDetailReport", DepID, "");
            try
             {
                
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DataTableToHTMLTable(ds1.Tables[0], DepID);
                }
                else
                {
                    st.code = "404";
                    st.msg = "No Data Found !";
                }

            }
            catch (Exception ex)
            {
                st.code = "444";
                st.msg = ex.Message.ToString();
            }
        }

        [WebMethod(EnableSession = true)]
        public void getInpTBLReport(DataTable inTable, string DepID)
        {
            DataTableToHTMLTable(inTable, DepID);
        }


        private static string GetBody(DataTable dTable, string DepID)
        {

            DataSet ds1;
            System.Text.StringBuilder dString = new System.Text.StringBuilder();
            CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();
            ds1 = obj.CommonSelect("SMS_REQUEST", "viewDetailReport", DepID, "");

            dString.Append("<tbody>");
            foreach (DataRow dRow in dTable.Rows)
            {
                dString.Append("<tr class='odd_gradeX'>");
                for (int dCount = 0; dCount < dTable.Columns.Count; dCount++)
                {
                    if (dCount == 10)
                    {
                        dString.AppendFormat("<td style=text-align:left><a href = javascript:GetASORPT("+ dRow[0] + ")> {0} </a></td>", dRow[dCount]);
                        
                    }
                    else
                    {
                        dString.AppendFormat("<td style=text-align:left>{0}</td>", dRow[dCount]);
                    }
                }
                dString.Append("</tr>");
            }
            dString.Append("</tbody>");
            return dString.ToString();
        }

        /////////////////////////////
    }
}