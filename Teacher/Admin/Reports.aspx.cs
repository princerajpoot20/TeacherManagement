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

public partial class Admin_Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userid"] == null || Session["role"].ToString() != "101")
            {
                Session.Abandon();
                clearsession();
                Response.Redirect("../AdminLogin.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                  
                }

            }
        }
        catch (Exception er)
        {
            WriteErrorLog(er);
            clearsession();
            Response.Redirect("../error.aspx", false);

        }

    }

    private void clearsession()
    {
        Session.Clear();
        Session.RemoveAll();
        Session["userid"] = null;
        Session["role"] = null;

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


   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTodate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('To Date is Requied!');", true);
                txtTodate.Focus();
            }
            else if (txtfromDate.Text == "")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('From Date is Requied!');", true);
                txtfromDate.Focus();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {

                    //Teacher
                    string QueryTeacher = "select t1.userName as Name,emailId as 'Email-ID',mobileNo as 'Mobile No.',t2.subjectName as 'Subject',t1.qulification as 'Qulification',t1.Address as 'Address',convert(varchar(10),t1.estimatedDateOfLeaving,103) as 'Leaving Date' from tbllogin as t1 join tblSubject as t2 on t1.subject=t2.subjectCode where CONVERT(date,t1.estimatedDateOfLeaving, 103)  BETWEEN '" + txtTodate.Text.Trim() + "' AND '" + txtfromDate.Text.Trim() + "'";
                    using (SqlCommand cmdTeacher = new SqlCommand(QueryTeacher, conn))
                    {
                        using (SqlDataAdapter daTeacher = new SqlDataAdapter(cmdTeacher))
                        {
                            DataTable dtTeacher = new DataTable();
                            daTeacher.Fill(dtTeacher);

                            if (dtTeacher.Rows.Count > 0)
                            {
                                GridViewTeachers.DataSource = dtTeacher;
                                GridViewTeachers.DataBind();

                            }

                        }
                    }
                }
            }
        }
        catch (Exception er)
        {
            WriteErrorLog(er);
            clearsession();
            Response.Redirect("../error.aspx", false);
        }
    }
}