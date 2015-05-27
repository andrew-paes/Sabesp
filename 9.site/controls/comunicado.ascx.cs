using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_comunicado : SmartUserControl
{
	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<Comunicado> Comunicados { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{

	}
	/// <summary>
	/// Bind the repeater control
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		if (this.Comunicados != null && this.Comunicados.Count > 0)
		{
			var hlTodosComunicados = (HyperLink)this.FindControl("hlTodosComunicados");
			hlTodosComunicados.NavigateUrl = String.Concat("~/fique-por-dentro/comunicados-Default.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
			hlTodosComunicados.Text = Resources.Resource.hlTodosComunicados.ToString();

			rptComunicados.DataSource = this.Comunicados;
			rptComunicados.DataBind();
			var li = (HtmlGenericControl)rptComunicados.Items[rptComunicados.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("class", "last");
			}
		}
		else
		{
			this.Visible = false;
		}
	}


	protected void rptComunicados_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlComunicado = (HyperLink)e.Item.FindControl("hlComunicado");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
			var ltrDescricao = (Literal)e.Item.FindControl("ltrDescricao");

			Comunicado comunicado = (Comunicado)e.Item.DataItem;
			ComunicadoIdiomaService comunicadoIdiomaService = new ComunicadoIdiomaService();
			ComunicadoIdioma comunicadoIdioma = comunicadoIdiomaService.Carregar(new ComunicadoIdioma() { Comunicado = comunicado, Idioma = Util.CurrentIdioma });
			if (comunicadoIdioma != null)
			{
				hlComunicado.NavigateUrl = String.Concat("~/fique-por-dentro/Comunicados-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", comunicado.Conteudo.ConteudoId);
				ltrTitulo.Text = comunicadoIdioma.TituloComunicado.ReplaceHtml();
				//recorta para resumir o texto
				ltrDescricao.Text = comunicadoIdioma.TextoComunicado.GenerateResume(85);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
