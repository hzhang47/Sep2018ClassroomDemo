﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumsTracksDetail.aspx.cs" Inherits="WebApp.SamplePages.AlbumsTracksDetail" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:Repeater ID="DTORepeater" runat="server" 
        DataSourceID="DTORpeaterODS"
        ItemType="Chinook.Data.DTOs.AlbumInfo">
        <HeaderTemplate>
            <h4>Nested Repeater</h4>
            <table class="table">
                <tr>
                    <th>Artist</th>
                    <th>Album</th>
                    <th>Songs</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.artist %> </td>
                <td><%# Item.title %> </td>
                <td>
                    <asp:Repeater ID="POCORepeater" runat="server" 
                    DataSource="<%# Item.song %>"
                    ItemType="Chinook.Data.POCOs.TracksInfo">
                        <ItemTemplate>
                            <table class="table">
                                <tr>
                                    <th>Title</th>
                                    <th>Length</th>
                                </tr>
                                <tr>
                                    <td style="width:50%"><%# Item.name %> </td>
                                    <td style="width:50%"><%# Item.length %> </td>
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
        SelectMethod="Album_GetAlbumDetail" 
        TypeName="ChinookSystem.BLL.AlbumDetailController"
        OnSelected="CheckForException"></asp:ObjectDataSource>
</asp:Content>
