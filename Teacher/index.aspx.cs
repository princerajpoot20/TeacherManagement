using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
                if (!IsPostBack)
                {
                    BindDate();

                }

            
        }
        catch (Exception er)
        {
            WriteErrorLog(er);
           
            Response.Redirect("error.aspx", false);

        }
    }
    public void WriteErrorLog(Exception ex)
    {
        try
        {
            string webPageName = Path.GetFileName(Request.Path);
            string errorLogFilename = "ErrorLog_" + Server.HtmlEncode(DateTime.Now.ToString("dd-MM-yyyy") + ".txt");
            string path = Server.MapPath("~/ErrorLogFiles/" + errorLogFilename);
            if (File.Exists(path))
            {
                using (StreamWriter stwriter = new StreamWriter(Server.HtmlEncode(path), true))
                {
                    stwriter.WriteLine("Error Log Start as on " + Server.HtmlEncode(DateTime.Now.ToString("hh:mm tt")));
                    stwriter.WriteLine("WebPage Name :" + webPageName);
                    stwriter.WriteLine("Message:" + Server.HtmlEncode(ex.Message.ToString()));
                    stwriter.WriteLine("Line:" + Server.HtmlEncode(ex.StackTrace.ToString()));
                    stwriter.WriteLine("Line:" + Server.HtmlEncode(ex.GetType().Name.ToString()));
                    stwriter.WriteLine("End");
                }
            }
            else
            {
                StreamWriter stwriter = File.CreateText(Server.HtmlEncode(path));
                stwriter.WriteLine("Error Log Start as on " + Server.HtmlEncode(DateTime.Now.ToString("hh:mm tt")));
                stwriter.WriteLine("WebPage Name :" + webPageName);
                stwriter.WriteLine("Message:" + Server.HtmlEncode(ex.Message.ToString()));
                stwriter.WriteLine("Line:" + Server.HtmlEncode(ex.StackTrace.ToString()));
                stwriter.WriteLine("Line:" + Server.HtmlEncode(ex.GetType().Name.ToString()));
                stwriter.WriteLine("End");
                stwriter.Close();
            }
        }
        catch (System.Threading.ThreadAbortException)
        {

        }
        catch (Exception er)
        {
            WriteErrorLog(er);
            Response.Redirect("../error.aspx", false);

        }
    }
    private void BindDate()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
            {
                string Query = "select t1.userName as Name,emailId as 'Email-ID',mobileNo as 'Mobile No.',t2.subjectName as 'Subject',t1.qulification as 'Qulification',t1.Address as 'Address',(CASE WHEN t1.joiningdate IS NULL THEN convert(varchar(10),t1.addedDate,103) ELSE convert(varchar(10),t1.joiningdate,103) END) as 'Joing Date ' from tblLogin as t1 join tblSubject as t2 on t1.subject=t2.subjectCode  where t1.status=1  and t1.role=100";
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            GridViewSearch.DataSource = dt;
                            GridViewSearch.DataBind();
                        }
                    }
                }


            }
        }
        catch (Exception er)
        {
            WriteErrorLog(er);

            Response.Redirect("error.aspx", false);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
            {
                string Query = "select t1.userName as Name,emailId as 'Email-ID',mobileNo as 'Mobile No.',t2.subjectName as 'Subject',t1.qulification as 'Qulification',t1.Address as 'Address',convert(varchar(10),t1.joiningdate,103) as 'Joing Date ' from tbllogin as t1 join tblSubject as t2 on t1.subject=t2.subjectCode  where t1.userName like '%" + txtSearch.Value.Trim() + "%' or t2.subjectName like '%" + txtSearch.Value.Trim() + "%'";
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            GridViewSearch.DataSource = dt;
                            GridViewSearch.DataBind();
                        }
                    }
                }


            }
        }
        catch (Exception er)
        {
            WriteErrorLog(er);
           
            Response.Redirect("error.aspx", false);
        }
    }
}