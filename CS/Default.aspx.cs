using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    public string ActivePageSymbol {
        get {
            if (Session["letter"] == null)
                Session["letter"] = string.Empty;
            return (string)Session["letter"];
        }
        set { Session["letter"] = value; }
    }

    protected void Page_Init(object sender, EventArgs e) {
        if (!IsCallback && !IsPostBack) {
            Session.Remove("Letter");
            CreatePager();
        }
        if (Session["letter"] !=null){
            SqlDataSource1.SelectParameters[0].DefaultValue = String.Format("{0}%", ActivePageSymbol);
            DataViewAlphabet.DataBind();
        }
       
    }
    protected void MyCallbackPanel_Callback(object sender, CallbackEventArgsBase e) {
        ActivePageSymbol = e.Parameter;
        ChangeDataSource();
        CreatePager();
    }
  
    public void ChangeDataSource() {
        SqlDataSource1.SelectParameters[0].DefaultValue = String.Format("{0}%", ActivePageSymbol);
        DataViewAlphabet.DataBind();
    }

    public void CreatePager() {
        List<string> alphabet = new List<string>(27);
        int startCharIndex = Convert.ToInt32('A');
        int endChartIndex = Convert.ToInt32('Z');
        for (int i = startCharIndex; i <= endChartIndex; i++)
            alphabet.Add(Convert.ToChar(i).ToString());

        WebControl div = new WebControl(HtmlTextWriterTag.Div);
        PanelPager.Controls.Add(div);
        div.Attributes["class"] = "container";
        foreach (string item in alphabet) {
            HtmlAnchor anchor = new HtmlAnchor();
            div.Controls.Add(anchor);
            anchor.HRef = string.Format("javascript:MoveToPage('{0}')", item);
            anchor.InnerText = item;
            anchor.Attributes["class"] = "anchor";
            if (item == ActivePageSymbol)
                anchor.Attributes["class"] += " active";
        }
    }
   
}
