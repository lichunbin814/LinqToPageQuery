<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DataPager.ascx.cs" Inherits="DataPager" %>
<asp:DataPager ID="dpIndex" runat="server" OnPreRender="dpIndex_PreRender"  >
    <Fields>
        <asp:NumericPagerField ButtonCount="10" NextPageText=">>" PreviousPageText="<<" />
        <asp:TemplatePagerField OnPagerCommand="TemplatePagerField_OnPagerCommand">
            <PagerTemplate>
                |
                <asp:Label ID="lblRowCount" runat="server" Text="<%# Container.TotalRowCount %>"></asp:Label>
                筆資料 | 每頁
                <asp:TextBox ID="txtPageSize" runat="server" Text="<%# Container.PageSize %>" OnTextChanged="txtPageSize_TextChanged" Width="40" AutoPostBack="true"></asp:TextBox>
                筆 | 頁數
                <asp:Label runat="server" ID="CurrentPageLabel" Text="<%# Container.TotalRowCount > 0 ? (Container.StartRowIndex / Container.PageSize) + 1 : 0 %>" />
                /
                <asp:Label runat="server" ID="TotalPagesLabel" Text="<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>" />
                |
                <asp:LinkButton ID="LinkButton1" CommandName="First" runat="server">第一頁</asp:LinkButton>
                |
                <asp:LinkButton ID="LinkButton2" CommandName="Previous" runat="server">上一頁</asp:LinkButton>
                |
                <asp:LinkButton ID="LinkButton3" CommandName="Next" runat="server">下一頁</asp:LinkButton>
                |
                <asp:LinkButton ID="LinkButton4" CommandName="Last" runat="server">最後一頁</asp:LinkButton>
            </PagerTemplate>
        </asp:TemplatePagerField>
        

    </Fields>
</asp:DataPager>