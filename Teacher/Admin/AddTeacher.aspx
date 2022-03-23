<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.master" AutoEventWireup="true" CodeFile="AddTeacher.aspx.cs" Inherits="Admin_AddTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!--== breadcrumbs ==-->
    <div class="sb2-2-2">
        <ul>
            <li><a href="index.aspx"><i class="fa fa-home" aria-hidden="true"></i>Home</a>
            </li>
            <li class="active-bre"><a href="Teacher.aspx">Teacher</a>
            </li>

             <li class="active-bre"><a href="#">Add Teacher</a>
            </li>
            <li class="page-back"><a href="index.aspx"><i class="fa fa-backward" aria-hidden="true"></i>Back</a>
            </li>
        </ul>
    </div>
    <!--== DASHBOARD INFO ==-->
    <div class="sb2-2-1">
        <h2><i class="fa fa-book"></i>Add Teacher</h2>
        <div class="db-2">
            <div class="row">
                <div class="col-md-12" style="padding-bottom: 10px; border-bottom: 1px solid #ccc">

                    <asp:hyperlink id="btnTeacher" runat="server" style="float: right" cssclass="btn btn-primary " navigateurl="~/Admin/Teacher.aspx">
                       <i class="fa fa-show"></i>
                       Teacher</asp:hyperlink>
                </div>


                <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label> Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="col-sm-12"></asp:TextBox>
                </div>

                 <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label> Email Id</label>
                    <asp:TextBox ID="txtEmailId" TextMode="Email" runat="server" CssClass="col-sm-12"></asp:TextBox>
                </div>

                  <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label> Qulification(Separated by comma)</label>
                    <asp:TextBox ID="txtQulification" runat="server" CssClass="col-sm-12" TextMode="MultiLine"></asp:TextBox>
                </div>

                 <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label> Mobile Number</label>
                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="col-sm-12" MaxLength="10" TextMode="Number"></asp:TextBox>
                </div>
                 <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label> School</label>
                      <asp:DropDownList ID="DDSchool" runat="server" CssClass="col-sm-12 "></asp:DropDownList>
                    
                </div>
                  <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label> Subjects</label>
                      <asp:DropDownList ID="DDSubjects" runat="server" CssClass="col-sm-12 "></asp:DropDownList>
                    
                </div>

                 <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label> Address</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="col-sm-12 form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                </div>

              <div class="col-sm-12"  style="padding-bottom: 10px;">
                  <label>State</label>
                    <asp:DropDownList ID="DDstate" runat="server"></asp:DropDownList>

                </div>
                <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label>City</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" ></asp:TextBox>

                </div>
              <div class="col-sm-12"  style="padding-bottom: 10px;">
                  <label>
                      Password
                  </label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                </div>


                 <div class="col-sm-12"  style="padding-bottom: 10px;">
                    <label> Joining Date</label>
                    <asp:TextBox ID="txtJoiningDate" runat="server" CssClass="col-sm-12 form-control" TextMode="Date"></asp:TextBox>
                </div>



                <div class="col-sm-11">
                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="pull-right  btn btn-success" OnClick="btnsave_Click" />
                </div>

            </div>


        </div>
    </div>


</asp:Content>

