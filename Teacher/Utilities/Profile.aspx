<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Utilities_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .inn-title
        {
            padding: 4px 8px !important;
            background: #002147;
            border-radius: 10px;
        }

        .row .col
        {
            float: left;
            box-sizing: border-box;
             padding: 0px 0rem !important; 
            min-height: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="sb2-2-3">
        <div class="row">
            <div class="col-md-12">
                <div class="box-inn-sp admin-form">
                    <div class="inn-title">
                        <h4>Profile Setting</h4>
                       
                    </div>
                    <div class="tab-inn">

                        <div class="row">
                            <div id="panelImage" runat="server" visible="false">
                                 <asp:Image ID="Image1" runat="server" CssClass="pull-right" ImageUrl="#" Style="vertical-align: middle;width: 150px!important; height: 150px !important; border: 1px solid !important; border-radius: 5px !important; background-color: #e0e0e0;" />

                            </div>

                            <div class="file-field input-field col s12" id="panelPic" runat="server" visible="false">

                                <div class="btn admin-upload-btn">
                                    <span>Profile Photo</span>
                                    <asp:FileUpload ID="FileUploadProfilePhoto" runat="server" />

                                </div>
                                <div class="file-path-wrapper">

                                    <input id="txtPhoto" type="text" placeholder="Profile image" class="file-path validate" runat="server" style="width: 98%;" />
                                </div>

                            </div>

                            <div class="input-field col s12">
                                <p>Name</p>
                                <input id="txtName" type="text" placeholder="Name" class="validate" runat="server" />
                            </div>
                           
                            <div class="input-field col s12">
                                  <p>Email</p>
                                <input id="txtemail" type="email" placeholder="Email" class="validate" runat="server"  />

                            </div>
                            <div class="input-field col s12">
                                  <p>Mobile</p>
                                <input id="txtmobile" type="number" placeholder="Mobile" class="validate" runat="server"  />

                            </div>
                            <div class="input-field col s12">
                                  <p>Aadhar Number</p>
                                <input id="txtAadhar" type="number" placeholder="Aadhar Number" class="validate" runat="server"  />

                            </div>

                            <div class="input-field col s12">
                                  <p>Name of School</p>
                                <input id="txtSchool" type="text" placeholder="Name of School" class="validate" runat="server"   />

                            </div>

                            <div class="input-field col s12">
                                <p>Subject</p>

                                <asp:DropDownList ID="ddSubject" runat="server"></asp:DropDownList>                               
                            </div>
                            <div class="input-field col s12">
                                <p>Qualification</p>
                                <input id="txtqualification" type="text" placeholder="Qualification  (Separated By Comma)" class="validate" runat="server"   />

                            </div>

                            <div class="input-field col s12">
                                  <p>Address</p>
                                <textarea id="txtAddress"  placeholder="Address" class="validate" runat="server"  style="height:100px"  ></textarea>


                            </div>

                            <div class="input-field col s12">
                                  <p>State</p>
                                 <asp:DropDownList ID="ddState" runat="server"></asp:DropDownList>
                               


                            </div>

                            <div class="input-field col s12">
                                  <p>City</p>
                                <input id="txtCity" type="text" placeholder="City" class="validate" runat="server"   />

                            </div>

                            

                             <div class="input-field col s12">
                                   <p>Joining Date</p>
                                <input id="txtJoinging" type="date" placeholder="Joining Date" class="validate" runat="server"   />

                            </div>

                            <div class="input-field col s12">
                                   <p>Expected date of Leaving</p>
                                <input id="txtLeaving" type="date" placeholder="Expected date of Leaving" class="validate" runat="server"   />

                            </div>
                        </div>




                        <div class="row">
                            <div class="input-field col s12">
                              
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass=" btn btn-danger pull-right" OnClick="btnEdit_Click" />
                                    
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>

