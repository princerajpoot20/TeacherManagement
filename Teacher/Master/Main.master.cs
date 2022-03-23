using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userid"] == null )
            {
                Session.Abandon();
                clearsession();
                Response.Redirect("../index.aspx", false);
            }
            else
            {
                LbluserName.Text = Server.HtmlEncode(Session["userName"].ToString());
                lblAdminUser.Text = Server.HtmlEncode(Session["userName"].ToString());
                //User Role
                if (Session["role"].ToString() == "100")
                {
                    PanelUser.Visible = true;
                    PanelAdmin.Visible = false;
                }
                //Admin Role
                else if (Session["role"].ToString() == "101")
                {
                    PanelUser.Visible = false;
                    PanelAdmin.Visible = true;
                }

            }
        }
        catch (Exception er)
        {
            WriteErrorLog(er);
            clearsession();
            Response.Redirect("../error.aspx", false);

        }
        finally
        {
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
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["userid"] == null )
            {
                Session.Abandon();
                clearsession();
                Response.Redirect("../index.aspx", false);
            }
            
            else
            {
                //User Role
                if (Session["role"].ToString() == "100")
                {
                    clearsession();
                    Session.Abandon();
                    Response.Redirect("../Signin.aspx", false);
                }
                //Admin Role
                else if (Session["role"].ToString() == "101")
                {
                    clearsession();
                    Session.Abandon();
                    Response.Redirect("../AdminLogin.aspx", false);
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