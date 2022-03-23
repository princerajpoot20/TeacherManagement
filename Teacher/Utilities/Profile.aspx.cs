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

public partial class Utilities_Profile : System.Web.UI.Page
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
                    BindDropListState();
                    BindSubject();
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
            Response.Redirect("../error", false);

        }
    }


    private void BindDropListState()
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
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    string com = "select stateCode,stateName from mstState where status=1 order by stateName ";
                    using (SqlDataAdapter adpt = new SqlDataAdapter(com, con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            adpt.Fill(dt);
                            ddState.DataSource = dt;

                            ddState.DataTextField = "stateName";
                            ddState.DataValueField = "stateCode";
                            ddState.DataBind();
                            ddState.Items.Insert(0, new ListItem("Select State", ""));
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
    private void BindSubject()
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
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    string com = "select subjectCode,subjectName from tblSubject where status=1 order by subjectName";
                    using (SqlDataAdapter adpt = new SqlDataAdapter(com, con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            adpt.Fill(dt);
                            ddSubject.DataSource = dt;
                            ddSubject.DataBind();
                            ddSubject.DataTextField = "subjectName";
                            ddSubject.DataValueField = "subjectCode";
                            ddSubject.DataBind();
                            ddSubject.Items.Insert(0, new ListItem("Select Subject", ""));
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
    private void BindData()
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
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                {
                    string Query = "select userId,userName,(select roleName from mstRole where roleCode=role)role,emailid,mobileNo,aadharNumber,school,subject,qulification,Address,state,city,format(joiningdate,'yyyy-MM-dd')as joiningdate,estimatedDateOfLeaving,addedDate from tblLogin where status=1 and userId='" + Session["userid"].ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                

                                txtName.Value = dt.Rows[0]["userName"].ToString();
                               
                                txtemail.Value = dt.Rows[0]["emailid"].ToString();

                                txtmobile.Value = dt.Rows[0]["mobileNo"].ToString();


                                string subjectS = Server.HtmlEncode(dt.Rows[0]["subject"].ToString());
                                if (subjectS != "")
                                {
                                    ddSubject.Items.FindByValue(subjectS).Selected = true;
                                }
                                else
                                {
                                }
                                txtqualification.Value = dt.Rows[0]["qulification"].ToString();
                                txtAddress.Value = dt.Rows[0]["Address"].ToString();


                                string states = Server.HtmlEncode(dt.Rows[0]["state"].ToString());
                                if (states != "")
                                {
                                    ddState.Items.FindByValue(states).Selected = true;
                                }
                                else
                                {
                                }

                                txtCity.Value = dt.Rows[0]["city"].ToString();
                                txtJoinging.Value = dt.Rows[0]["joiningdate"].ToString();
                                txtName.Attributes.Add("readonly", "false");
                                txtemail.Attributes.Add("readonly", "false");
                                txtmobile.Attributes.Add("readonly", "false");

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
            if (Session["userid"] == null)
            {
                Session.Abandon();
                clearsession();
                Response.Redirect("../index.aspx", false);
            }
            else
            {
                if (btnEdit.Text == "Edit")
                {
                    
                    txtName.Focus();
                    txtmobile.Attributes.Remove("readonly");
                    txtqualification.Attributes.Remove("readonly");
                    txtAddress.Attributes.Remove("readonly");
                    txtCity.Attributes.Remove("readonly");
                    btnEdit.Text = "Update";
                }
                else
                {
                    if (txtName.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Name');", true);
                        txtName.Focus();
                    }
                   

                    else if (txtmobile.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Mobile');", true);
                        txtmobile.Focus();
                    }
                    else if (txtAadhar.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Aadhar Number');", true);
                        txtmobile.Focus();
                    }
                    else if (txtSchool.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter School Name');", true);
                        txtCity.Focus();
                    }
                    else if (txtqualification.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Qulification');", true);
                        txtqualification.Focus();
                    }
                    else if (txtAddress.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter Address');", true);
                        txtAddress.Focus();
                    }
                    else if (ddSubject.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select Subjects');", true);
                        ddSubject.Focus();
                    }
                    else if (ddState.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Select State');", true);
                        ddState.Focus();
                    }


                    else if (txtCity.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Enter City');", true);
                        txtCity.Focus();
                    }
                    
                    
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["trmsConn"].ConnectionString))
                        {
                            conn.Open();

                            string Query = "UPDATE tblLogin SET userName='" + txtName.Value.Trim() + "',mobileNo='" + txtmobile.Value.Trim() + "',aadharNumber='" + txtAadhar.Value.Trim() + "',school='" + txtSchool.Value.Trim() + "',subject='" + ddSubject.SelectedValue.ToString() + "',qulification='" + txtqualification.Value.Trim() + "',Address='" + txtAddress.Value.Trim() + "',state='" + ddState.SelectedValue.ToString() + "',city='" + txtCity.Value.Trim() + "',joiningdate='" + txtJoinging.Value.Trim() + "',updatedBy='" + Session["userid"].ToString().Trim() + "',updatedate=GETDATE() WHERE status=1 and userId='" + Session["userid"].ToString().Trim() + "'";
                            using (SqlCommand cmdinsert = new SqlCommand(Query, conn))
                            {
                                int i = cmdinsert.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Profile Update Successfully');window.location='" + Request.ApplicationPath + "Utilities/Profile.aspx';", true);
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
}
