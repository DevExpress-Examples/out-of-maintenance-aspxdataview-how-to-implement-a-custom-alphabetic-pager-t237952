Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Public Property ActivePageSymbol() As String
        Get
            If Session("letter") Is Nothing Then
                Session("letter") = String.Empty
            End If
            Return DirectCast(Session("letter"), String)
        End Get
        Set(ByVal value As String)
            Session("letter") = value
        End Set
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        If (Not IsCallback) AndAlso (Not IsPostBack) Then
            Session.Remove("Letter")
            CreatePager()
        End If
        If Session("letter") IsNot Nothing Then
            SqlDataSource1.SelectParameters(0).DefaultValue = String.Format("{0}%", ActivePageSymbol)
            DataViewAlphabet.DataBind()
        End If

    End Sub
    Protected Sub MyCallbackPanel_Callback(ByVal sender As Object, ByVal e As CallbackEventArgsBase)
        ActivePageSymbol = e.Parameter
        ChangeDataSource()
        CreatePager()
    End Sub

    Public Sub ChangeDataSource()
        SqlDataSource1.SelectParameters(0).DefaultValue = String.Format("{0}%", ActivePageSymbol)
        DataViewAlphabet.DataBind()
    End Sub

    Public Sub CreatePager()
        Dim alphabet As New List(Of String)(27)
        Dim startCharIndex As Integer = Convert.ToInt32("A"c)
        Dim endChartIndex As Integer = Convert.ToInt32("Z"c)
        For i As Integer = startCharIndex To endChartIndex
            alphabet.Add(Convert.ToChar(i).ToString())
        Next i

        Dim div As New WebControl(HtmlTextWriterTag.Div)
        PanelPager.Controls.Add(div)
        div.Attributes("class") = "container"
        For Each item As String In alphabet
            Dim anchor As New HtmlAnchor()
            div.Controls.Add(anchor)
            anchor.HRef = String.Format("javascript:MoveToPage('{0}')", item)
            anchor.InnerText = item
            anchor.Attributes("class") = "anchor"
            If item = ActivePageSymbol Then
                anchor.Attributes("class") &= " active"
            End If
        Next item
    End Sub

End Class
