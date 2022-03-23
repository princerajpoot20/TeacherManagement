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

public partial class Admin_School : System.Web.UI.Page
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
                    bindGrid();
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


    private void bindGrid()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
        {
            string Query = "select ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS SNo,schoolCode,schoolName,case when updatedDate='' then addedDate  when updatedDate!='' then updatedDate else addedDate end as addedDate  from tblSchool where status=1 order by transId";
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        bindGridSchool.DataSource = dt;
                        bindGridSchool.DataBind();
                    }
                    else
                    {
                        bindGridSchool.DataSource = dt;
                        bindGridSchool.EmptyDataText = "No Record Found";
                        bindGridSchool.DataBind();

                    }
                }
            }
        }
    }
    protected void bindGridSubject_RowEditing(object sender, GridViewEditEventArgs e)
    {
        bindGridSchool.EditIndex = e.NewEditIndex;
        bindGrid();
    }
    protected void bindGridSubject_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        bindGridSchool.EditIndex = -1;
        bindGrid();
    }
    protected void bindGridSubject_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            TextBox txtSName = (TextBox)bindGridSchool.Rows[e.RowIndex].FindControl("txtschoolName");
            Label lblSCode = (Label)bindGridSchool.Rows[e.RowIndex].FindControl("Label2schoolCode");

            if (txtSName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter School');", true);
                txtSName.Focus();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    conn.Open();
                    string Queryupdate = "update tblSchool set schoolName='" + txtSName.Text.Trim() + "',updatedby='" + Session["userid"].ToString() + "',updatedDate=GETDATE() where schoolCode='"+lblSCode.Text+"' and status=1";
                    using (SqlCommand cmd = new SqlCommand(Queryupdate, conn))
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('School Updated Successfully');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('School Not Updated Successfully')", true);
                        }
                        bindGrid();
                        conn.Close();
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
    protected void bindGridSubject_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label lblSCode = (Label)bindGridSchool.Rows[e.RowIndex].FindControl("Label2schoolCode");

           
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    conn.Open();
                    string Queryupdate = "delete from tblSchool where subjectCode='" + lblSCode.Text + "' and status=1";
                    using (SqlCommand cmd = new SqlCommand(Queryupdate, conn))
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('School Deleted Successfully');", true);
                           
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('School Not Updated Successfully')", true);
                           
                        }
                        bindGrid();
                        conn.Close();
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