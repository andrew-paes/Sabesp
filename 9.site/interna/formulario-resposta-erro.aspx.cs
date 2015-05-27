using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class interna_resposta_formulario_erro : BasePage
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (Session["ex"] != null)
			{
				Exception ex = Session["ex"] as Exception;
				hdnExceptionForm.Value = String.Concat(ex.ToString(), " |-| ", ex.Message, " |-| ", ex.StackTrace);
				Session["ex"] = null;
			}
			else
			{
				hdnExceptionForm.Value = "vazio";
			}
		}
		catch (Exception ex)
		{
			hdnExceptionForm.Value = String.Concat("Erro ao ler exception de formulario - ", ex.ToString());
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void imgBtnPaginaPrincipal_Click(object sender, ImageClickEventArgs e)
	{
		Response.Redirect("~/site/Default.aspx");
	}
}