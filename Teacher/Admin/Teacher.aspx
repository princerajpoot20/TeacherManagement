<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.master" AutoEventWireup="true" CodeFile="Teacher.aspx.cs" Inherits="Admin_Teacher" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <!--== breadcrumbs ==-->
    <div class="sb2-2-2">
        <ul>
            <li><a href="index.aspx"><i class="fa fa-home" aria-hidden="true"></i>Home</a>
            </li>
            <li class="active-bre"><a href="#">Teacher Details</a>
            </li>
            <li class="page-back"><a href="index.aspx"><i class="fa fa-backward" aria-hidden="true"></i>Back</a>
            </li>
        </ul>
    </div>
    <!--== DASHBOARD INFO ==-->
    <div class="sb2-2-1">
        <h2><i class="fa fa-book"></i>List of Teacher</h2>
        <div class="db-2">

            <div class="row">


                <div class="col-md-12" style="padding-bottom: 10px; border-bottom: 1px solid #ccc">

                    <asp:HyperLink ID="btnAddTeacher" runat="server" Style="float: right" CssClass="btn btn-primary " NavigateUrl="~/Admin/AddTeacher.aspx">
                       <i class="fa fa-plus"></i>
                       Add Teacher</asp:HyperLink>
                </div>
                <hr />

                <div class="col-md-12 table-responsive table-desi">



                    <asp:GridView ID="bindGridTeacher" CssClass="col-sm-12 table" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="School">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("schoolname") %>' ID="Label6School"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teacher Code" Visible="false">

                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("userId") %>' ID="Label2userId"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teacher Name">

                                <ItemTemplate>
                                  
                                    <asp:Label runat="server" Text='<%# Bind("userName") %>' ID="Label3TeacherName"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">


                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("emailid") %>' ID="Label5emailid"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Subject">

                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("subjectName") %>' ID="Label6Subject"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Joining Date">

                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("joiningdate", "{0:dd-MM-yyyy}") %>' ID="Label7joiningdate"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Leaving Date">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("estimatedDateOfLeaving", "{0:dd-MM-yyyy}") %>' ID="Label4"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                         
                         

                            <asp:TemplateField>

                                <ItemTemplate>
                                    
                                         <asp:HyperLink runat="server" Target="_blank"
                                            NavigateUrl='<%# string.Format("~/Admin/TeacherDetails.aspx?tecode={0}",HttpUtility.UrlEncode(Eval("userId").ToString())) %>'
                                            Text="View and download"
                                            ID="HyperLinkcertificate"><i class="fa fa-eye"></i></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </div>

            </div>


        </div>
    </div>


</asp:Content>

