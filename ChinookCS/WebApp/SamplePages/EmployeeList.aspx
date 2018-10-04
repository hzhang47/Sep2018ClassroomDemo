<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="WebApp.SamplePages.EmployeeList" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:Repeater ID="DTORepeater" runat="server" 
        DataSourceID="DTORpeaterODS"
        ItemType="Chinook.Data.DTOs.SupportEmpolyee">
        <HeaderTemplate>
            <h4>Nested Repeater</h4>
            <table class="table">
                <tr>
                    <th>Employee</th>
                    <th>Client Count</th>
                    <th>Client List</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="width:15%"><%# Item.name %> </td>
                <td style="width:15%"><%# Item.clientcount %> </td>
                <td style="width:70%">
                    <asp:Repeater ID="POCORepeater" runat="server" 
                    DataSource="<%# Item.clientlist %>"
                    ItemType="Chinook.Data.POCOs.PlayListCustomer">
                        <ItemTemplate>
                            <table class="table">
                                <tr>
                                    <th>Last Name</th>
                                    <th>First Name</th>
                                    <th>Phone</th>
                                </tr>
                                <tr>
                                    <td style="width:33%"><%# Item.leastname %> </td>
                                    <td style="width:33%"><%# Item.firstname %> </td>
                                    <td style="width:33%"><%# Item.phone %> </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            &copy; Chinook reserves all right to this data.
        </FooterTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="DTORpeaterODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Employee_GetSupportEmployees" 
        TypeName="ChinookSystem.BLL.EmployeeController"
        OnSelected="CheckForException"></asp:ObjectDataSource>
</asp:Content>
