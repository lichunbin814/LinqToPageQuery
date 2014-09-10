<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinqToSql.aspx.cs" Inherits="LinqToSql" %>

<%@ Register Assembly="MCN.WebControls" Namespace="MCN.WebControls" TagPrefix="cc1" %>

<%@ Register Src="~/UserControl/DataPager.ascx" TagPrefix="uc1" TagName="DataPager" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>　
        <a href="Default.aspx">返回清單頁 .Net3.5</a>
        <H1>LinqToSQL</H1>　
        <cc1:DataPagerGridView runat="server" AutoGenerateColumns="True" DataSourceID="ObjectDataSource1" id="Gv1" AllowPaging="True" AllowSorting="True" EnableTheming="True">            
<PagerSettings Visible="False"></PagerSettings>
        </cc1:DataPagerGridView>
        
        <uc1:DataPager runat="server" ID="DataPager" PagedControlID="Gv1" />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getdata" TypeName="LinqToSqlSample.DAL.CustomersExtention" EnablePaging="True" SelectCountMethod="GetDataCount"  SortParameterName="SortExpression" OnSelecting="ObjectDataSource1_Selecting">
              <SelectParameters>             
                    <asp:Parameter Name="FilterData" Type="Object" />
                </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
