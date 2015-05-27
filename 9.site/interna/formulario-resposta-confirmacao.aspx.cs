using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class interna_formulario_resposta_confirmacao : BasePage
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
		
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