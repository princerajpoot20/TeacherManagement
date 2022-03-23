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

public partial class Signin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void WriteErrorLog(Exception ex)
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
                stwriter.WriteLine("End");
            }
        }
        else
        {
            StreamWriter stwriter = File.CreateText(Server.HtmlEncode(path));
            stwriter.WriteLine("Error Log Start as on " + Server.HtmlEncode(DateTime.Now.ToString("hh:mm tt")));
            stwriter.WriteLine("WebPage Name :" + webPageName);
            stwriter.WriteLine("Message: " + Server.HtmlEncode(ex.Message.ToString()));
            stwriter.WriteLine("End");
            stwriter.Close();
        }
    }



    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUserId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Email/Mobile');", true);
                txtUserId.Focus();
            }
            else if (txtPassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Password');", true);
                txtPassword.Focus();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select userId,userName,role,emailId,mobileNo,password from tblLogin where role=100 and (emailid='" + txtUserId.Text.Trim() + "' or mobileNo='" + txtUserId.Text.Trim() + "')", conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataSet DS = new DataSet())
                            {
                                da.Fill(DS);
                                if (DS.Tables[0].Rows.Count > 0)
                                {
                                    string password = DS.Tables[0].Rows[0]["password"].ToString();

                                    if (txtPassword.Text.Trim() == password)
                                    {
                                        Session["userid"] = DS.Tables[0].Rows[0]["userId"].ToString();
                                        Session["userName"] = DS.Tables[0].Rows[0]["userName"].ToString();
                                        Session["role"] = DS.Tables[0].Rows[0]["Role"].ToString();
                                        Response.Redirect("~/User/index.aspx", false);
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Invalid UserId and Password');", true);

                                        txtPassword.Focus();
                                    }

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Invalid UserId and Password');", true);

                                    txtUserId.Focus();
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            WriteErrorLog(ex);
            Response.Redirect("error.aspx");
        }

    }

}