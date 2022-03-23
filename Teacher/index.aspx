<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .com-sp
        {
             padding: 0px 0px !important; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <!-- SLIDER -->
    <section>
        <div id="myCarousel" class="carousel slide" data-ride="carousel" style="margin-top: -35px;">
            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item slider1 active">
                    <img src="../images/slider/300.jpg" alt=""/>
                    <div class="carousel-caption slider-con">
                  <!--  <h2>Teachers <span>Management</span></h2>-->
       
                    </div>
                </div>
         
        
            </div>

          </div>
        </section>




    <section>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="search-form">
                        <div>
                            <div class="sf-type">
                                <div class="sf-input">
                                    <input type="text" id="txtSearch" placeholder="Search Subject and Teacher Name" runat="server" />
                                </div>

                            </div>
                            <div class="sf-submit">
                                <asp:Button ID="btnSearch" runat="server" Text="Search Course" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             <div class="row" style="padding-top:20px;">
                <div class="col-md-12">
                    <asp:GridView ID="GridViewSearch" runat="server" CssClass="table table-bordered" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>

                        <HeaderStyle  Font-Bold="True" ForeColor="White"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510"></PagerStyle>

                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510"></RowStyle>

                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                        <SortedAscendingCellStyle BackColor="#FFF1D4"></SortedAscendingCellStyle>

                        <SortedAscendingHeaderStyle BackColor="#B95C30"></SortedAscendingHeaderStyle>

                        <SortedDescendingCellStyle BackColor="#F1E5CE"></SortedDescendingCellStyle>

                        <SortedDescendingHeaderStyle BackColor="#93451F"></SortedDescendingHeaderStyle>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>


       

</asp:Content>

