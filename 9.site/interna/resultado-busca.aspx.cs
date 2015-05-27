using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;

public partial class resultado_busca : BasePage
{

	#region Properties

	public string TermoBuscado
	{
		get
		{
			return Convert.ToString(ViewState["TermoBuscado"]);
		}
		set
		{
			ViewState["TermoBuscado"] = value;
		}
	}

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadProperties();
			this.LoadResources();
			this.BindBuscaConteudo(this.TermoBuscado);
		}
	}

	protected void LoadResources()
	{
		HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
		body.Attributes.Add("class", "interna");
		ltrTermoBuscado.Text = this.TermoBuscado;
		ltrTermoBuscadoNaoEncontrado.Text = String.Format(Convert.ToString(GetLocalResourceObject(ltrTermoBuscadoNaoEncontrado.ID)), this.TermoBuscado);
		hlFacaNovaPesquisa.Text = Convert.ToString(GetLocalResourceObject(hlFacaNovaPesquisa.ID));

	}

	protected void LoadProperties()
	{
		//se contém um termo buscado (pelo topo)
		if (Session["TermoBuscado"] != null)
		{
			//armazena na viewstate
			this.TermoBuscado = Convert.ToString(Session["TermoBuscado"]);
			//limpa a sessão
			Session.Remove("TermoBuscado");
		}
		else if (Request.QueryString["search"] != null)
		{
			this.TermoBuscado = Convert.ToString(Request.QueryString["search"]);
		}
	}

	protected void lstConteudos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
	{
		DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

		if (IsPostBack)
		{
			BindBuscaConteudo(this.TermoBuscado);
		}
	}

	/// <summary>
	/// Bind list view
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void lstConteudos_ItemDataBound(object sender, ListViewItemEventArgs e)
	{
		using (var item = ((ListViewDataItem)e.Item))
		{
			if (item != null)
			{
				var buscaConteudo = (BuscaConteudo)item.DataItem;
				if (buscaConteudo != null)
				{
					var hlConteudo = (HyperLink)item.FindControl("hlConteudo");
					var lblDescricao = (Label)item.FindControl("lblDescricao");

					lblDescricao.Text = buscaConteudo.Descricao.GenerateResume(120);

					hlConteudo.Text = buscaConteudo.Titulo.ReplaceHtml().StripHTML();

					Conteudos tipoConteudo = (Conteudos)Enum.Parse(typeof(Conteudos), buscaConteudo.ConteudoTipo.ConteudoTipoId.ToString());

					switch (tipoConteudo)
					{
						case Conteudos.Secao:
							SecaoService secaoService = new SecaoService();
							Secao secao = secaoService.Carregar(new Secao() { SecaoId = buscaConteudo.ConteudoId });
							if (secao != null)
							{
								ModeloService modeloService = new ModeloService();
								secao.Modelo = modeloService.Carregar(secao.Modelo);
								if (secao.Modelo != null)
								{
									hlConteudo.NavigateUrl = String.Concat(secao.Modelo.Arquivo, "?secaoId=", secao.SecaoId);
								}
							}
							break;
						case Conteudos.Noticia:
							hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/noticias-Detalhes.aspx?secaoId=", MenuPrincipal.Noticias.GetHashCode(), "&id=", buscaConteudo.ConteudoId);
							break;
						case Conteudos.Evento:
							hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/eventos-Detalhes.aspx?secaoId=", MenuPrincipal.Eventos.GetHashCode(), "&id=", buscaConteudo.ConteudoId);
							break;
						case Conteudos.Comunicado:
							hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/comunicados-Detalhes.aspx?secaoId=", MenuPrincipal.Comunicados.GetHashCode(), "&id=", buscaConteudo.ConteudoId);
							break;
						case Conteudos.Video:
							hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/tv-sabesp-Detalhes.aspx?secaoId=", MenuPrincipal.TVSabesp.GetHashCode(), "&id=", buscaConteudo.ConteudoId);
							break;
						case Conteudos.Podcast:
							hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.Podcasts.GetHashCode(), "&id=", buscaConteudo.ConteudoId);
							break;
						case Conteudos.Release:
							hlConteudo.NavigateUrl = String.Concat("~/imprensa/releases-Detalhes.aspx?secaoId=", MenuPrincipal.Releases.GetHashCode(), "&id=", buscaConteudo.ConteudoId);
							break;
						case Conteudos.Glossario:
							hlConteudo.NavigateUrl = String.Concat("~/sociedade-meioambiente/glossario.aspx?secaoId=", MenuPrincipal.Glossario.GetHashCode(), "&palavra=", buscaConteudo.Titulo);
							break;
						case Conteudos.Infografico:
							//hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro.aspx?secaoId=", MenuPrincipal.Infograficos.GetHashCode(), "&id=", buscaConteudo.ConteudoId);
							break;
						case Conteudos.Municipio:
							hlConteudo.NavigateUrl = String.Concat("~/interna/Municipio.aspx?secaoId=18&id=", buscaConteudo.ConteudoId);
							break;
						case Conteudos.BancoDeAudio:
							hlConteudo.NavigateUrl = String.Concat("~/fique-por-dentro/banco-de-audio-Detalhes.aspx?secaoId=", MenuPrincipal.BancoDeAudio.GetHashCode(), "&id=", buscaConteudo.ConteudoId);
							break;
						default:
							break;
					}
				}
			}
		}
	}

	#endregion

	#region Methods

	/// <summary>
	/// Get the data to bind the listview
	/// </summary>
	protected void BindBuscaConteudo(string search)
	{
		BuscaConteudoService buscaConteudoService = new BuscaConteudoService();

		List<BuscaConteudo> buscaConteudos = buscaConteudoService.Carregar(Util.CurrentIdioma, search, search.EncodeToHtmlEntity().EncodeToHtmlEntity());

		if (buscaConteudos != null && buscaConteudos.Count > 0)
		{
			pnlBuscaNaoEncontrada.Visible = false;
			pnlBusca.Visible = true;

			lstConteudos.DataSource = buscaConteudos;
			lstConteudos.DataBind();

			ltrResultadosEncontrados.Text = String.Format(ltrResultadosEncontrados.Text, buscaConteudos.Count);
		}
		else
		{
			pnlBuscaNaoEncontrada.Visible = true;
			pnlBusca.Visible = false;
		}
	}

	#endregion
}