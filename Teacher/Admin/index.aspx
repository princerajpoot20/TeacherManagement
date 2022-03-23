<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Admin_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .dash-book h5
        {
            font-size: 15px !important;
            color: #fff;
            padding-bottom: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <!--== breadcrumbs ==-->
                <div class="sb2-2-2">
                    <ul>
                        <li><a href="index.aspx"><i class="fa fa-home" aria-hidden="true"></i> Home</a>
                        </li>
                        <li class="active-bre"><a href="#"> Dashboard</a>
                        </li>
                        <li class="page-back"><a href="index.aspx"><i class="fa fa-backward" aria-hidden="true"></i> Back</a>
                        </li>
                    </ul>
                </div>
                <!--== DASHBOARD INFO ==-->
                <div class="sb2-2-1">
                    <h2>Admin Dashboard</h2>
                  
                    <div class="db-2">
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="dash-book dash-b-1">
                                    <h5>Total Subjects</h5>
                                    <h4>
                                        <asp:Label ID="lblTotalSubjects" runat="server" Text="0" Font-Size="15px" Font-Bold="true" ForeColor="White"></asp:Label></h4>
                                    <a href="Subject.aspx">View more</a>
                                </div>
                            </div>
                          <div class="col-sm-4">
                                <div class="dash-book dash-b-2">
                                    <h5>Total Teachers</h5>
                                    <h4><asp:Label ID="lblTotalTeachers" runat="server" Text="0" Font-Size="15px" Font-Bold="true" ForeColor="White"></asp:Label></h4>
                                    <a href="Teacher.aspx">View more</a>
                                </div>
                           </div>
                         
                            <div class="col-sm-4">
                                <div class="dash-book dash-b-4">
                                    <h5>Last 7 Days User Register</h5>
                                       <h4><asp:Label ID="lbllast7daysUser" runat="server" Text="0" Font-Size="15px" Font-Bold="true" ForeColor="White"></asp:Label></h4>
                                    <a href="#">View more</a>
                                </div>
                          </div>


                              
                        </div>
                    </div>
                </div>

             
				
</asp:Content>

