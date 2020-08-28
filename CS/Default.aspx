<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPxDataView with alphabetic pager</title>
    <style type="text/css">
        .noData {
            padding: 40px;
        }

        .container {
            padding: 0px 40px;
            font-size: 13pt;
        }

        .anchor {
            padding: 0 10px;
        }

        .active {
            color: red !important;
        }
    </style>
    <script type="text/javascript">
        function MoveToPage(symbol) {
            MyCallbackPanel.PerformCallback(symbol);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxCallbackPanel ID="MyCallbackPanel" ClientInstanceName="MyCallbackPanel" runat="server" OnCallback="MyCallbackPanel_Callback">
                <PanelCollection>
                    <dx:PanelContent runat="server">
                        <dx:ASPxDataView ID="DataViewAlphabet" ClientInstanceName="DataViewAlphabet" runat="server" DataSourceID="SqlDataSource1">
                            <PagerSettings ShowNumericButtons="False"></PagerSettings>
                            <ItemTemplate>
                                <b>ProductID</b>:
                <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
                                <br />
                                <b>ProductName</b>:
                <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                                <br />
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="720px" Height="200px" BackColor="WhiteSmoke" CssClass="noData">
                                    <PanelCollection>
                                        <dx:PanelContent>
                                            <asp:Label ID="LabelNoData" runat="server" Text="No data to display" />
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxPanel>
                            </EmptyDataTemplate>
                        </dx:ASPxDataView>
                        <dx:ASPxPanel ID="PanelPager" runat="server">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxPanel>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>" SelectCommand="SELECT  [ProductID], [ProductName] FROM [Products] WHERE ([ProductName] LIKE @ProductName )">
            <SelectParameters>
                <asp:Parameter Name="ProductName" Type="String" DefaultValue="%" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
