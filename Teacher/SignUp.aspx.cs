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

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindSubject();
                BindSchool();
                BindDropListState();
               

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
            Response.Redirect("error.aspx", false);

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
    private void BindSubject()
    {
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
            {
                string com = "select subjectCode,subjectName from tblSubject where status=1 order by subjectName";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        adpt.Fill(dt);
                        DDSubject.DataSource = dt;
                        DDSubject.DataBind();
                        DDSubject.DataTextField = "subjectName";
                        DDSubject.DataValueField = "subjectCode";
                        DDSubject.DataBind();
                        DDSubject.Items.Insert(0, new ListItem("Select Subject", ""));
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

    private void BindSchool()
    {
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
            {
                string com = "select schoolCode,schoolName from tblSchool where status=1 order by schoolName";
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
            Response.Redirect("error.aspx", false);
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Name');", true);
                txtname.Focus();
            }


            else if (txtContactNumber.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Mobile');", true);
                txtContactNumber.Focus();

            }
            else if (txtContactNumber.Text.Length != 10)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Valid Mobile');", true);
                txtContactNumber.Focus();

            }

            else if (txtemail.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Email');", true);
                txtemail.Focus();
            }
            else if (txtAadhar.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Aadhar Number');", true);
                txtAadhar.Focus();

            }
            else if (txtAadhar.Text.Length != 12)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Valid Aadhar Number');", true);
                txtAadhar.Focus();

            }
            else if (DDSubject.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select Subjects');", true);
                DDSubject.Focus();
            }
            else if (txtGender.Text == "Select Gender")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter gender');", true);
                txtGender.Focus();
            }
            else if (txtQuali.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Qulification');", true);
                txtQuali.Focus();
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
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    conn.Open();

                    string QueryEmail = "select * from tblLogin where emailId='" + txtemail.Text.Trim() + "'";
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
                                        string Queryinsert = "INSERT INTO tblLogin(role,userId,userName,mobileNo,emailId,aadharNumber,school,subject,qulification,address,state,city,joiningdate,estimatedDateOfLeaving,password,addedDate,updatedBy,status)VALUES(100,'U00" + code + "','" + txtname.Text.Trim() + "','" + txtContactNumber.Text.Trim() + "','" + txtemail.Text.Trim() + "','" + txtAadhar.Text.Trim() + "','"  + DDSchool.SelectedValue + "','" + DDSubject.SelectedValue + "','" + txtQuali.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + DDstate.SelectedValue.ToString() + "','" + txtCity.Text.Trim() + "','" + txtJoining.Text.Trim() + "','" + txtLeaving.Text.Trim() + "','" + txtPassword.Text.Trim()+ "'," + "getdate(), 'self', 1)";


                                        using (SqlCommand cmdinsert = new SqlCommand(Queryinsert, conn))
                                        {
                                            int i = cmdinsert.ExecuteNonQuery();
                                            if (i > 0)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('User Registed Successfully');window.location='" + Request.ApplicationPath + "Signin.aspx';", true);
                                            }
                                            conn.Close();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Email Id Already Register');", true);
                                txtemail.Focus();
                            }
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
