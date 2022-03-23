<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Admin_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .imgHight
        {
            vertical-align: middle;
            width: 46px!important;
            height: 47px !important;
            border: 1px solid !important;
            border-radius: 45px !important;
            background-color: #e0e0e0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!--== breadcrumbs ==-->
    <div class="sb2-2-2">
        <ul>
            <li><a href="index.aspx"><i class="fa fa-home" aria-hidden="true"></i>Home</a>
            </li>
            <li class="active-bre"><a href="#">Reports</a>
            </li>
            <li class="page-back"><a href="index.aspx"><i class="fa fa-backward" aria-hidden="true"></i>Back</a>
            </li>
        </ul>
    </div>



    <div class="sb2-2-1">

        <div class="db-2">
            <div class="row">
                <div class="col-md-5">
                    <label>To Date</label>
                    <asp:TextBox ID="txtTodate" runat="server" TextMode="Date"></asp:TextBox>

                </div>

                <div class="col-md-5">
                    <label>From Date</label>
                    <asp:TextBox ID="txtfromDate" runat="server" TextMode="Date"></asp:TextBox>

                </div>
                <div class="col-md-2" style="margin-top: 25px;">

                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger pull-ight" OnClick="btnSubmit_Click" />
                </div>

            </div>


        </div>
    </div>

    <div class="sb2-2-1">
        <h2><i class="fa fa-book"></i>List of Teachers Leaving between selected Time Period </h2>
        <div class="db-2">

            <div class="row">
                <div class="col-md-12 table-responsive table-desi">



                    <asp:GridView ID="GridViewTeachers" CssClass="col-sm-12 table" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="true">
                    </asp:GridView>

                </div>

            </div>


        </div>
    </div>


</asp:Content>



