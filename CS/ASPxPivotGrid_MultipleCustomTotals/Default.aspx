<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="ASPxPivotGrid_MultipleCustomTotals._Default" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v14.2, Version=14.2.17.0,
    Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid"
    TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" 
            DataSourceID="AccessDataSource1" 
            oncustomcellvalue="ASPxPivotGrid1_CustomCellValue" onload="ASPxPivotGrid1_Load" 
            OptionsPager-RowsPerPage="20" Theme="Metropolis"> 
            <Fields>
                <dx:PivotGridField ID="fieldProductName" Area="RowArea" AreaIndex="1"
                Caption="Product Name" FieldName="ProductName" GroupIndex="1" 
                    InnerGroupIndex="1">
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldShippedYear" Area="ColumnArea" AreaIndex="0" Caption="Year"
                    FieldName="ShippedDate" GroupInterval="DateYear" GroupIndex="0" 
                    InnerGroupIndex="0" UnboundFieldName="fieldShippedYear">
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldProductSales" Area="DataArea" AreaIndex="0" Caption="Sales"
                    FieldName="ProductSales">
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldCategoryName" Area="RowArea" AreaIndex="0"
                Caption="Category Name" FieldName="CategoryName" GroupIndex="1" 
                    InnerGroupIndex="0">
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldShippedQuarter" Area="ColumnArea" AreaIndex="1"
                Caption="Quarter" FieldName="ShippedDate" 
                GroupInterval="DateQuarter" 
                ValueFormat-FormatString="Quarter {0}"
                ValueFormat-FormatType="Custom" GroupIndex="0" InnerGroupIndex="1" 
                    UnboundFieldName="fieldShippedQuarter">
                </dx:PivotGridField>
            </Fields>
            <Groups>
                <dx:PivotGridWebGroup Caption="Date" ShowNewValues="True" />
                <dx:PivotGridWebGroup Caption="Category-Product" ShowNewValues="True" />
            </Groups>
        </dx:ASPxPivotGrid>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/nwind.mdb"
            SelectCommand="SELECT [CategoryName], [ProductName], [ProductSales],
            [ShippedDate] FROM [ProductReports]">
        </asp:AccessDataSource>
    
    </div>
    </form>
</body>
</html>
