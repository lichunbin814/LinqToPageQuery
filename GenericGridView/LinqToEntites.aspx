<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinqToEntites.aspx.cs" Inherits="LinqToEntites" %>

<%@ Register Assembly="MCN.WebControls" Namespace="MCN.WebControls" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/DataPager.ascx" TagPrefix="uc1" TagName="DataPager" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>　
            <a href="Default.aspx">返回清單頁 .Net3.5</a>
     　
            <h1>EntityFrameWork(使用QueryAble)</h1>
            <cc1:DataPagerGridView runat="server" DataSourceID="ObjectDataSource2" AllowPaging="True" AllowSorting="True" ID="Gv2"></cc1:DataPagerGridView>
            <uc1:DataPager runat="server" ID="DataPager1" PagedControlID="Gv2" />

            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="LinqToEntitySample.DAL.CustomersQueryAbleExtention" EnablePaging="True" SelectCountMethod="GetDataCount" SortParameterName="SortExpression" OnSelecting="ObjectDataSource2_Selecting">
                <SelectParameters>             
                    <asp:Parameter Name="FilterData" Type="Object" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
