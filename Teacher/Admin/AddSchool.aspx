<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.master" AutoEventWireup="true" CodeFile="AddSchool.aspx.cs" Inherits="Admin_AddSchool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <!--== breadcrumbs ==-->
    <div class="sb2-2-2">
        <ul>
            <li><a href="index.aspx"><i class="fa fa-home" aria-hidden="true"></i>Home</a>
            </li>
            <li class="active-bre"><a href="School.aspx">School</a>
            </li>

             <li class="active-bre"><a href="#">Add School</a>
            </li>
            <li class="page-back"><a href="index.aspx"><i class="fa fa-backward" aria-hidden="true"></i>Back</a>
            </li>
        </ul>
    </div>
    <!--== DASHBOARD INFO ==-->
    <div class="sb2-2-1">
        <h2><i class="fa fa-book"></i>Add School</h2>
        <div class="db-2">

            <div class="row">


                <div class="col-md-12" style="padding-bottom: 10px; border-bottom: 1px solid #ccc">

                    <asp:hyperlink id="Button1" runat="server" style="float: right" cssclass="btn btn-primary " navigateurl="~/Admin/School.aspx">
                       <i class="fa fa-show"></i>
                       Subject</asp:hyperlink>
                </div>


                <div class="col-sm-12"  style="padding-bottom: 10px;">

                    <label>School Name</label>
                    <asp:TextBox ID="txtSchoolName" runat="server" CssClass="col-sm-12 form-control" placeholder="School Name"></asp:TextBox>



                </div>

                <div class="col-sm-11">
                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="pull-right  btn btn-success" OnClick="btnsave_Click" />



                </div>

            </div>


        </div>
    </div>

</asp:Content>

