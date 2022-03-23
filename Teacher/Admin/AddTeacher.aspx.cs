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

public partial class Admin_AddTeacher : System.Web.UI.Page
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
                    txtName.Focus();
                    BindDropListState();
                    BindDropSubject();
                    BindDropSchool();
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
    private void BindDropSubject()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
        {
            string com = "select subjectCode,subjectName from tblSubject where status=1 order by subjectName ";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, con))
            {
                using (DataTable dt = new DataTable())
                {
                    adpt.Fill(dt);
                    DDSubjects.DataSource = dt;
                    DDSubjects.DataBind();
                    DDSubjects.DataTextField = "subjectName";
                    DDSubjects.DataValueField = "subjectCode";
                    DDSubjects.DataBind();
                    DDSubjects.Items.Insert(0, new ListItem("Select Subject", ""));
                }
            }
        }
    }

    private void BindDropSchool()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
        {
            string com = "select schoolCode,schoolName from tblSchool where status=1 order by schoolName ";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, con))
            {
                using (DataTable dt = new DataTable())
                {
                    adpt.Fill(dt);
                    DDSchool.DataSource = dt;
                    DDSchool.DataBind();
                    DDSchool.DataTextField = "schoolName";
                    DDSchool.DataValueField = "schoolCode";
                    DDSchool.DataBind();
                    DDSchool.Items.Insert(0, new ListItem("Select School", ""));
                }
            }
        }
    }
    private void BindDropListState()
    {
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
            {
                string com = "select stateCode,stateName from mstState where status=1 order by stateName ";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        adpt.Fill(dt);
                        DDstate.DataSource = dt;

                        DDstate.DataTextField = "stateName";
                        DDstate.DataValueField = "stateCode";
                        DDstate.DataBind();
                        DDstate.Items.Insert(0, new ListItem("Select State", ""));

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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Name');", true);
                txtName.Focus();
            }

            else if (txtEmailId.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Email Id');", true);
                txtEmailId.Focus();
            }
            else if (txtQulification.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Qulification');", true);
                txtQulification.Focus();
            }
            else if (txtMobileNumber.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Mobile No.');", true);
                txtMobileNumber.Focus();
            }
            else if (DDSubjects.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select Subjects');", true);
                DDSubjects.Focus();
            }

            else if (txtAddress.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Address');", true);
                txtAddress.Focus();
            }
            else if (DDstate.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select State');", true);
                DDstate.Focus();
            }
            else if (DDSchool.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select School');", true);
                DDSchool.Focus();
            }
            else if (txtCity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter City');", true);
                txtCity.Focus();
            }
            else if (txtPassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Password');", true);
                txtPassword.Focus();
            }

            else if (txtJoiningDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Joining Date');", true);
                txtJoiningDate.Focus();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    conn.Open();
                    string QueryEmail = "select * from tblLogin where emailId='" + txtEmailId.Text.Trim() + "'";
                    using (SqlCommand cmdemail = new SqlCommand(QueryEmail, conn))
                    {
                        using (SqlDataAdapter daemail = new SqlDataAdapter(cmdemail))
                        {
                            DataTable dtemail = new DataTable();
                            daemail.Fill(dtemail);
                            if (dtemail.Rows.Count == 0)
                            {
                                string Query = "select count(transId)+1 as SNo from tbllogin where status=1";
                                using (SqlCommand cmd = new SqlCommand(Query, conn))
                                {
                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                    {
                                        DataTable dt = new DataTable();
                                        da.Fill(dt);
                                        int code = Convert.ToInt32(dt.Rows[0]["SNo"].ToString());
                                        string Queryinsert = "INSERT INTO tblLogin(role,userId,userName,mobileNo,emailId,subject,school,qulification,address,state,city,password,addedDate,joiningdate,status)VALUES(100,'U00" + code + "','" + txtName.Text.Trim() + "','" + txtMobileNumber.Text.Trim() + "','" + txtEmailId.Text.Trim() + "','" + DDSubjects.SelectedValue + "','" + DDSchool.SelectedValue + "','" + txtQulification.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + DDstate.SelectedValue.ToString() + "','" + txtCity.Text.Trim() + "','" + txtPassword.Text.Trim() + "',getdate(),'" + txtJoiningDate.Text.Trim() + "',1)";
                                        using (SqlCommand cmdinsert = new SqlCommand(Queryinsert, conn))
                                        {
                                            int i = cmdinsert.ExecuteNonQuery();
                                            if (i > 0)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Teacher Added Successfully');window.location='" + Request.ApplicationPath + "Admin/Teacher.aspx';", true);
                                            }
                                            conn.Close();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Email Id Already Register');", true);
                                txtEmailId.Focus();
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