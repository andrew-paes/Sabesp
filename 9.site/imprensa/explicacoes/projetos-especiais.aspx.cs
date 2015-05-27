
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using Sabesp.Enumerators;


public partial class projetos_especiais : BasePage
{
	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadPage()
	{
		this.BindProjetoEspeciais();
		primeiraColunaDinamica1.DataBind();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptProjetosEspeciais_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var imgDestaque = (Image)e.Item.FindControl("imgDestaque");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");
			var hlProjetosEspeciais = (HyperLink)e.Item.FindControl("hlProjetosEspeciais");
			var lblDescricao = (Label)e.Item.FindControl("lblDescricao");
			var ltrVejaMaisSobreProjeto = (Literal)e.Item.FindControl("ltrVejaMaisSobreProjeto");
			ltrVejaMaisSobreProjeto.Text = Convert.ToString(GetLocalResourceObject(ltrVejaMaisSobreProjeto.ID));

			ProjetoEspecial projetoEspecial = (ProjetoEspecial)e.Item.DataItem;
			ProjetoEspecialIdiomaService projetoEspecialIdiomaService = new ProjetoEspecialIdiomaService();
			ProjetoEspecialIdioma projetoEspecialIdioma = projetoEspecialIdiomaService.Carregar(new ProjetoEspecialIdioma() { ProjetoEspecial = projetoEspecial, Idioma = Util.CurrentIdioma });
			if (projetoEspecialIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();
				Arquivo arquivo = new Arquivo();

				if (projetoEspecial.ArquivoThumbId != null && projetoEspecial.ArquivoThumbId.ArquivoId > 0)
				{
					arquivo.ArquivoId = (int)projetoEspecial.ArquivoThumbId.ArquivoId;
					arquivo = arquivoService.Carregar(arquivo);

					if (arquivo != null)
					{
						imgDestaque.ImageUrl = String.Concat("~/uploads/secao/", arquivo.NomeArquivo);
					}
				}
				else
				{
					//imgDestaque.Attributes.Add("style", "display:none");
					imgDestaque.Visible = false;
				}

				if (projetoEspecial.Url.Contains("www") && !projetoEspecial.Url.Contains("http"))
				{
					hlProjetosEspeciais.NavigateUrl = String.Concat("http://", projetoEspecial.Url);
					hlProjetosEspeciais.Target = "_blank";
				}
				else if (projetoEspecial.Url.Contains("http"))
				{
					hlProjetosEspeciais.NavigateUrl = projetoEspecial.Url;
					hlProjetosEspeciais.Target = "_blank";
				}
				else
				{
					hlProjetosEspeciais.NavigateUrl = projetoEspecial.Url;
				}
				ltrTitulo.Text = projetoEspecialIdioma.TituloProjeto;
				lblDescricao.Text = projetoEspecialIdioma.ChamadaProjeto.ReplaceHtml();
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion

	#region Methods

	/// <summary>
	/// Get the data to bind the listview
	/// </summary>
	protected void BindProjetoEspeciais()
	{
		ProjetoEspecialService projetoEspecialService = new ProjetoEspecialService();
		List<ProjetoEspecial> projetoEspecials = new List<ProjetoEspecial>();

		projetoEspecials = (List<ProjetoEspecial>)projetoEspecialService.CarregarTodos(0, 0, null, null, new ProjetoEspecialFH() { Ativo = "1" });

		rptProjetosEspeciais.DataSource = projetoEspecials;
		rptProjetosEspeciais.DataBind();
		var li = (HtmlGenericControl)rptProjetosEspeciais.Items[rptProjetosEspeciais.Items.Count - 1].FindControl("li");
		if (li != null)
		{
			li.Attributes.Add("class", "last");
		}

	}
	#endregion
}