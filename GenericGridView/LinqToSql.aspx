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
         <h3>全部的資料</h3>
             <cc1:DataPagerGridView runat="server" DataSourceID="ObjectDataSource1" AllowPaging="True" AllowSorting="True" ID="Gv1"></cc1:DataPagerGridView>
            <uc1:DataPager runat="server" ID="DataPager1" PagedControlID="Gv1" />

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="LinqToSqlSample.DAL.CustomersExtention" EnablePaging="True" SelectCountMethod="GetDataCount" SortParameterName="SortExpression" >
                <SelectParameters>             
                    <asp:Parameter Name="FilterData" Type="Object" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <hr />

          <h3>資料來源類別當作篩選條件</h3>
        <cc1:DataPagerGridView runat="server" AutoGenerateColumns="True" DataSourceID="ObjectDataSource2" id="Gv2" AllowPaging="True" AllowSorting="True" EnableTheming="True">            
<PagerSettings Visible="False"></PagerSettings>
        </cc1:DataPagerGridView>
        
        <uc1:DataPager runat="server" ID="DataPager2" PagedControlID="Gv2" />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getdata" TypeName="LinqToSqlSample.DAL.CustomersPartialExtention" EnablePaging="True" SelectCountMethod="GetDataCount"  SortParameterName="SortExpression" OnSelecting="ObjectDataSource2_Selecting">
              <SelectParameters>             
                    <asp:Parameter Name="FilterData" Type="Object" />
                </SelectParameters>
        </asp:ObjectDataSource>
        <hr />
        <h3>自訂篩選類別</h3>
        <cc1:DataPagerGridView runat="server" AutoGenerateColumns="True" DataSourceID="ObjectDataSource3" id="Gv3" AllowPaging="True" AllowSorting="True" EnableTheming="True">            
<PagerSettings Visible="False"></PagerSettings>
        </cc1:DataPagerGridView>
        
        <uc1:DataPager runat="server" ID="DataPager3" PagedControlID="Gv3" />
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getdata" TypeName="LinqToSqlSample.DAL.CustomersFilterPartialExtention" EnablePaging="True" SelectCountMethod="GetDataCount"  SortParameterName="SortExpression" OnSelecting="ObjectDataSource3_Selecting">
              <SelectParameters>             
                    <asp:Parameter Name="FilterData" Type="Object" />
                </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
