using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


namespace HoApps.Auto_ProcessSMS
{
    public partial class ViewApprove_ContentSMS : System.Web.UI.Page
    {
        //string empName, empCode, empMob, empDep, typedLength;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class empdtls
        {
            public string tradt { get; set; }
            public string empcode { get; set; }
            public string empname { get; set; }
            public string empdep { get; set; }
            public string createcharlen { get; set; }
            public string textcontent { get; set; }

            public string updatetradt { get; set; }
            public string updatedempcode { get; set; }
            public string updatedempname { get; set; }
            public string updatedempdep { get; set; }

            public string updatedempRmk { get; set; }

            public string updatecharlen { get; set; }
            public string updatetextcontent { get; set; }
        }

        [WebMethod(EnableSession = true)]
        public static  empdtls get_ReportDtl(string val)

        {
                empdtls ep = new empdtls();
                DataSet ds;
                CommonService.CommonServiceClient obj = new CommonService.CommonServiceClient();
                ds = obj.CommonSelect("SMS_REQUEST", "GetDownReport", val, "");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //User text decoding
                    var base64EncodedBytes = System.Convert.FromBase64String(ds.Tables[0].Rows[0][6].ToString());
                    string DecodeFromSMS = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    //Approver text decoding
                    var base64EncodedBytes2 = System.Convert.FromBase64String(ds.Tables[0].Rows[0][12].ToString());
                    string DecodeApproveSMS2 = System.Text.Encoding.UTF8.GetString(base64EncodedBytes2);
                    // Approver Remark
                    var base64EncodedBytes3 = System.Convert.FromBase64String(ds.Tables[0].Rows[0][13].ToString());
                    string DecodeApproveRemk = System.Text.Encoding.UTF8.GetString(base64EncodedBytes3);

                    ep.tradt = ds.Tables[0].Rows[0][1].ToString();
                    ep.empcode = ds.Tables[0].Rows[0][2].ToString();
                    ep.empname = ds.Tables[0].Rows[0][3].ToString();

                    ep.empdep = ds.Tables[0].Rows[0][4].ToString();
                    ep.createcharlen = ds.Tables[0].Rows[0][5].ToString();
                    ep.textcontent = DecodeFromSMS;

                    ep.updatetradt = ds.Tables[0].Rows[0][7].ToString();
                    ep.updatedempcode = ds.Tables[0].Rows[0][8].ToString();
                    ep.updatedempname = ds.Tables[0].Rows[0][9].ToString();
                    ep.updatedempdep = ds.Tables[0].Rows[0][10].ToString();

                    ep.updatedempRmk = DecodeApproveRemk;

                    ep.updatecharlen = ds.Tables[0].Rows[0][11].ToString();
                    ep.updatetextcontent = DecodeApproveSMS2;
                }
                else
                {
                    ep.empcode = "";
                }
            }
            catch (Exception e)
            {
                
            }
            return ep;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            
            Response.End();
        }

    }
}