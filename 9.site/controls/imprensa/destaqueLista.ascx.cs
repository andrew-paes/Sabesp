using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class controls_imprensa_destaqueLista : SmartUserControl
{
	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<Secao> Secoes { get; set; }

	#endregion

	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// Bind the repeater control
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		if (this.Secoes != null && this.Secoes.Count > 0)
		{
			rptDestaques.DataSource = this.Secoes;
			rptDestaques.DataBind();
		}
		else
		{
			this.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptDestaques_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var imgDestaque = (Image)e.Item.FindControl("imgDestaque");
			var hlTitulo = (HyperLink)e.Item.FindControl("hlTitulo");
			var lblTexto = (Label)e.Item.FindControl("lblTexto");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
			var divImg = (HtmlGenericControl)e.Item.FindControl("divImg");
			var ltrConheca = (Literal)e.Item.FindControl("ltrConheca");
			ltrConheca.Text = Resources.Resource.ltrConheca.ToString();

			Secao secao = (Secao)e.Item.DataItem;
			SecaoIdiomaService secaoIdiomaService = new SecaoIdiomaService();
			SecaoIdioma secaoIdioma = secaoIdiomaService.Carregar(new SecaoIdioma() { Secao = secao, Idioma = Util.CurrentIdioma });
			if (secao != null)
			{
				ModeloService modeloService = new ModeloService();

				if (secao.Modelo != null && secao.Modelo.ModeloId > 0)
				{
					secao.Modelo = modeloService.Carregar(secao.Modelo);
				}
				if (secao.Modelo != null)
				{
					hlTitulo.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);
				}

				lblTexto.Text = secaoIdioma.Texto.GenerateResume(85);

				if (!String.IsNullOrEmpty(secaoIdioma.TituloArquivos))
				{
					imgDestaque.ImageUrl = String.Concat("~/uploads/secao/", secaoIdioma.TituloArquivos);
				}
				else
				{
					imgDestaque.Visible = false;
				}

				ltrTitulo.Text = secaoIdioma.Titulo.ReplaceHtml();
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}