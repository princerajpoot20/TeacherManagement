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

public partial class Admin_TeacherDetails : System.Web.UI.Page
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
                    txtTeacherName.Focus();
                    BindDropListSubject();
                    BindDropListSchool();
                    BindDropListState();
                    BindData();
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

    private void BindDropListSchool()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
            {
                string com = "select schoolCode,schoolName from tblSchool where status=1";
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
        catch (Exception er)
        {
            WriteErrorLog(er);
            clearsession();
            Response.Redirect("../error.aspx", false);
        }
    }
    private void BindDropListSubject()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
            {
                string com = "select subjectCode,subjectName from tblSubject where status=1";
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
        catch (Exception er)
        {
            WriteErrorLog(er);
            clearsession();
            Response.Redirect("../error.aspx", false);
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



    private void BindData()
    {
        try
        {
            if (Request.QueryString["tecode"] != null)
            {
                string TeacodeS = Request.QueryString["tecode"].ToString();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    string Query = "select userId,userName,emailid,qulification,mobileno,subject,school,address,state,city,format (joiningdate,'yyyy-MM-dd')as joiningdate  from tbllogin where status=1 and userId='" + TeacodeS + "'";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                txtTeacherName.Text = dt.Rows[0]["userName"].ToString();
                                txtTeacherName.ReadOnly = true;


                                txtEmailId.Text = dt.Rows[0]["emailid"].ToString();
                                txtEmailId.ReadOnly = true;


                                txtQulification.Text = dt.Rows[0]["qulification"].ToString();
                                txtQulification.ReadOnly = true;



                                txtMobileNumber.Text = dt.Rows[0]["mobileno"].ToString();
                                txtMobileNumber.ReadOnly = true;


                                string subjectS = Server.HtmlEncode(dt.Rows[0]["subject"].ToString());
                                if (subjectS != "")
                                {
                                    DDSubjects.Items.FindByValue(subjectS).Selected = true;


                                }
                                else
                                {
                                }

                                string schoolS = Server.HtmlEncode(dt.Rows[0]["school"].ToString());
                                if (schoolS != "")
                                {
                                    DDSchool.Items.FindByValue(schoolS).Selected = true;
                                }
                                else
                                {
                                }

                                txtAddress.Text = dt.Rows[0]["address"].ToString();
                                txtAddress.ReadOnly = true;

                                string states = Server.HtmlEncode(dt.Rows[0]["state"].ToString());
                                if (states != "")
                                {
                                    DDstate.Items.FindByValue(states).Selected = true;
                                }
                                else
                                {
                                }
                                txtCity.Text = dt.Rows[0]["city"].ToString();
                                txtJoiningDate.Text = dt.Rows[0]["joiningdate"].ToString();
                                txtJoiningDate.ReadOnly = true;


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


   
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnEdit.Text == "Edit")
            {

                txtTeacherName.ReadOnly = false;
                txtEmailId.ReadOnly = false;
                txtQulification.ReadOnly = false;
                txtMobileNumber.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtJoiningDate.ReadOnly = false;
                btnEdit.Text = "Update";
            }
            else
            {
                if (Request.QueryString["tecode"] != null)
                {
                    string TeacodeS = Request.QueryString["tecode"].ToString();


                    if (txtTeacherName.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Subject');", true);
                        txtTeacherName.Focus();
                    }
                    else if (txtTeacherName.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Subject');", true);
                        txtTeacherName.Focus();
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

                    else if (txtJoiningDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Joining Date');", true);
                        txtJoiningDate.Focus();
                    }


                    else if (DDstate.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select State');", true);
                        DDstate.Focus();
                    }
                    else if (txtCity.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter city');", true);
                        txtCity.Focus();
                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                        {
                            conn.Open();
                            string Query = "update tbllogin set userName='" + txtTeacherName.Text.Trim() + "',emailid='" + txtEmailId.Text.Trim() + "',qulification='" + txtQulification.Text.Trim() + "',mobileno='" + txtMobileNumber.Text.Trim() + "',subject='" + DDSubjects.SelectedValue.ToString() + "',school='" + DDSchool.SelectedValue.ToString() + "',address='" + txtAddress.Text.Trim() + "',state='" + DDstate.SelectedValue.ToString() + "',city='" + txtCity.Text.Trim() + "',joiningdate='" + txtJoiningDate.Text.Trim() + "',updatedby='" + Session["userid"].ToString() + "',updatedate=GETDATE() where userId='" + TeacodeS + "'";
                            using (SqlCommand cmdinsert = new SqlCommand(Query, conn))
                            {
                                int i = cmdinsert.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Teacher Update Successfully');window.location='" + Request.ApplicationPath + "Admin/Teacher.aspx';", true);
                                }
                                conn.Close();
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
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        try
        {  if (Request.QueryString["tecode"] != null)
            {
                string TeacodeS = Request.QueryString["tecode"].ToString();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    conn.Open();
                    string Query = "delete from tbllogin where userId='"+TeacodeS+"'";
                    using (SqlCommand cmdinsert = new SqlCommand(Query, conn))
                    {
                        int i = cmdinsert.ExecuteNonQuery();
                        if (i > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Teacher Delete Successfully');window.location='" + Request.ApplicationPath + "Admin/Teacher.aspx';", true);
                        } conn.Close();

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