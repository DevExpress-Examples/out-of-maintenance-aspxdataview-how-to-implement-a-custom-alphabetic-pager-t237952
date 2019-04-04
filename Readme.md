<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxDataView - How to implement a custom alphabetic pager 


<p>A custom pager is created by putting anchor elements with alphabet letters in ASPxPanel. ASPxDataView and ASPxPanel are wrapped in ASPxCallbackPanel to send a callback, and change their content when a letter anchor is clicked. The <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebScriptsASPxClientCallbackPanel_PerformCallbacktopic">ASPxClientCallbackPanel.PerformCallback</a> method is used to send the callback to the server. ASPxDataView does not provide filtering, so it is necessary to change the data source select query and bind ASPxDataView in the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxCallbackPanel_Callbacktopic">ASPxCallbackPanel.Callback</a> event handler.</p>
<br /><strong>See also: </strong><a href="https://www.devexpress.com/Support/Center/p/E1820">ASPxGridView with alphabetic pager</a>

<br/>


