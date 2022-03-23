<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.master" AutoEventWireup="true" CodeFile="School.aspx.cs" Inherits="Admin_School" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--== breadcrumbs ==-->
    <div class="sb2-2-2">
        <ul>
            <li><a href="index.aspx"><i class="fa fa-home" aria-hidden="true"></i>Home</a>
            </li>
            <li class="active-bre"><a href="#">School</a>
            </li>
            <li class="page-back"><a href="index.aspx"><i class="fa fa-backward" aria-hidden="true"></i>Back</a>
            </li>
        </ul>
    </div>
    <!--== DASHBOARD INFO ==-->
    <div class="sb2-2-1">
        <h2><i class="fa fa-book"></i>List of School</h2>
        <div class="db-2">

            <div class="row">


                <div class="col-md-12" style="padding-bottom: 10px; border-bottom: 1px solid #ccc">

                    <asp:HyperLink ID="Button1" runat="server" Style="float: right" CssClass="btn btn-primary " NavigateUrl="~/Admin/AddSchool.aspx">
                       <i class="fa fa-plus"></i>
                       Add School</asp:HyperLink>
                </div>
                <hr />

                <div class="col-md-12 table-responsive table-desi">



                    <asp:GridView ID="bindGridSchool" CssClass="col-sm-12 table" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="False" OnRowEditing="bindGridSubject_RowEditing" OnRowCancelingEdit="bindGridSubject_RowCancelingEdit" OnRowUpdating="bindGridSubject_RowUpdating" OnRowDeleting="bindGridSubject_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="S.no.">

                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("SNo") %>' ID="Label1SNo"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Code" Visible="false">

                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("schoolCode") %>' ID="Label2schoolCode"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Name">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# Bind("schoolName") %>' ID="txtschoolName"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("schoolName") %>' ID="Label3schoolName"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created Date">

                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("addedDate", "{0:dd-MM-yyyy}") %>' ID="Label4"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField  ShowHeader="False" >
                                <EditItemTemplate>
                                    <asp:LinkButton runat="server" Text="Update" CommandName="Update" CausesValidation="True" ID="LinkButton1Update"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" ID="LinkButton2"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" ID="LinkButton1Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" ID="LinkButton2Delete" ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </div>

            </div>


        </div>
    </div>

</asp:Content>

