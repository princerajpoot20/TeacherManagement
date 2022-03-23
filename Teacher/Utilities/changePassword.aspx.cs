using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Utilities_changePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userid"] == null)
            {
                Session.Abandon();
                clearsession();
                Response.Redirect("../index.aspx", false);
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["userid"] == null)
            {
                Session.Abandon();
                clearsession();
                Response.Redirect("../index.aspx", false);
            }
            else
            {
                if (txtCurrentPassword.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Current Password');", true);
                    txtCurrentPassword.Focus();
                }


                else if (txtNewPassword.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter New Password');", true);
                    txtNewPassword.Focus();
                }
                else if (txtConfirmPassword.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Confirm Password');", true);
                    txtConfirmPassword.Focus();
                }

                else
                {
                    if (txtNewPassword.Text == txtConfirmPassword.Text)
                    {
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                        {
                            conn.Open();


                            string Query = "UPDATE tblLogin SET password='" + txtNewPassword.Text.Trim() + "',updatedBy='" + Session["userid"].ToString().Trim() + "',updatedate=GETDATE() WHERE status=1 and userId='" + Session["userid"].ToString().Trim() + "' and password='" + txtCurrentPassword.Text.Trim() + "'";
                            using (SqlCommand cmd = new SqlCommand(Query, conn))
                            {
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Password Change Successfully');window.location='" + Request.ApplicationPath + "../index.aspx';", true);
                                }
                                conn.Close();
                            }

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Password does not match!');", true);
                        txtConfirmPassword.Focus();
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
