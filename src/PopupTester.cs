using System;
using System.Text;

namespace MattBerther.Web.UI.WebControls
{
	public class PopupTester : System.Web.UI.WebControls.Panel
	{
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            this.Attributes.Add("style", "display:none");

            Page.RegisterClientScriptBlock("popupTester", ScriptHandler.GetScript("PopupTester.js"));
            Page.RegisterClientScriptBlock("OnLoad_popupTester", GetOnLoadScript());
            Page.RegisterStartupScript("StartUp_popupTester", GetStartupScript());
        }

        private string GetOnLoadScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript'>\r\n\tfunction OnLoad_PopupTester() {\r\n");
            sb.Append("\t\tif (showBlockerWarning()) {\r\n");
            sb.Append("\t\t\ttoggleVisibility('");
            sb.Append(this.ClientID);
            sb.Append("');\r\n");
            sb.Append("\t\t}\r\n");
            sb.Append("\t}\r\n</script>");

            return sb.ToString();
                
        }

        private string GetStartupScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript'>\r\n\tinit();OnLoad_PopupTester();\r\n</script>");

            return sb.ToString();
        }
	}
}
