<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.master" AutoEventWireup="true" CodeFile="changePassword.aspx.cs" Inherits="Utilities_changePassword" %>

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


    <!--== User Details ==-->
    <div class="sb2-2-3">
        <div class="row">
            <div class="col-md-12">
                <div class="box-inn-sp admin-form">
                    <div class="inn-title">
                        <h4>Change Password</h4>
                        
                    </div>
                    <div class="tab-inn">

                        <div class="row">


                            <div class="input-field col s12">
                                <asp:TextBox ID="txtCurrentPassword" TextMode="Password" runat="server" placeholder="Current Password" CssClass="validate" ValidationGroup="ChangePwd"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCurrentPassword" runat="server" ControlToValidate="txtCurrentPassword" CssClass="text-danger" ErrorMessage="Current Password Is Requied!" ValidationGroup="ChangePwd"></asp:RequiredFieldValidator>

                            </div>

                            <div class="input-field col s12">
                                <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" placeholder="New Password" CssClass="validate" ValidationGroup="ChangePwd"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPassword" runat="server" ControlToValidate="txtNewPassword" CssClass="text-danger" ErrorMessage="New Password Is Requied!" ValidationGroup="ChangePwd"></asp:RequiredFieldValidator>



                            </div>
                            <div class="input-field col s12">
                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" placeholder="Confirm Password" CssClass="validate" ValidationGroup="ChangePwd"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" CssClass="text-danger" ErrorMessage="Confirm Password Is Requied!" ValidationGroup="ChangePwd"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtNewPassword" ControlToCompare="txtConfirmPassword" CssClass="text-danger" runat="server" ErrorMessage="Password does not match!" ValidationGroup="ChangePwd"></asp:CompareValidator>
                            </div>

                        </div>




                        <div class="row">
                            <div class="input-field col s12">

                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass=" btn btn-danger pull-right" OnClick="btnUpdate_Click" ValidationGroup="ChangePwd" />

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>

