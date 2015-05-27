using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using System.Text;

public partial class fckeditor_editor_filemanager_connectors_aspx_foDelete : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		String sCommand = Request.QueryString["Command"];

		//If command string is empty redirect page

		if (string.IsNullOrEmpty(sCommand))
		{
			Response.Redirect("~/");
		}

		switch (sCommand)
		{
			case "DeleteFile":
				String sFileName = Request.QueryString["FileName"];
				String sSiteURL = this.GetFullPath();
				String sRootFolder = ""; //Use "" if you are not using a subfolder as your web sites root
				String sManagementFolder = ""; //Use "" if you had put FCKEditor directly under your root folder

				//If no filename is defined redirect page

				if (string.IsNullOrEmpty(sFileName))
				{
					Response.Redirect("~/");
				}
				try
				{
					sFileName = Server.MapPath(sFileName);
					DeleteFile(sFileName);
					StringBuilder sJava = new StringBuilder();
					sJava.AppendLine("window.onload=");
					sJava.AppendLine("function()");
					sJava.AppendLine("{");
					sJava.Append("window.parent.document.location.href='");

					//sSiteURL = sSiteURL.ToLower(new CultureInfo("en-US"));
					sManagementFolder = sManagementFolder.ToLower(new CultureInfo("en-US"));
					sRootFolder = sRootFolder.ToLower(new CultureInfo("en-US"));

					string url = sSiteURL;
					//if (!String.IsNullOrEmpty(sRootFolder))
					//{
					//    url = sSiteURL.Replace(sRootFolder, sManagementFolder);
					//}

					sJava.Append(url);
					sJava.Append("FCKeditor/editor/filemanager/browser/default/browser.html?Type=Image&Connector=");
					sJava.Append(Server.UrlEncode(url));
					sJava.Append("%2FFCKeditor%2Feditor%2Ffilemanager%2Fconnectors%2Faspx%2Fconnector.aspx';");
					sJava.AppendLine("};");


					ScriptManager.RegisterStartupScript(pJava, pJava.GetType(), "jsRefresh", sJava.ToString(), true);
				}
				catch (Exception ex)
				{
					Response.Write(ex.Message);
				}

				break;
			default:
				//Unrecognized command so redirect
				Response.Redirect("~/");
				break;
		}

	}

	protected bool DeleteFile(string sFileName)
	{
		try
		{
			File.Delete(sFileName);
			return true;
		}
		catch
		{
			return false;
		}
	}

	protected string GetFullPath()
	{
		//string url = String.Concat("unescape('",Request.Url.ToString() ,"')",".replace(unescape('", Convert.ToString(Request.RawUrl), "'), '')");
		string url = String.Concat(Request.Url.Scheme, "://",
					Request.Url.Host,
					Request.Url.Port != 80 ? ":" + Request.Url.Port.ToString() : "",
					Request.ApplicationPath, "/");

		return url;
	}
}
