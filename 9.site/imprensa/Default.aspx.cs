using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sabesp.FilterHelper;
using Sabesp.Data.Services;
using Sabesp.BO;
using AG2.Sabesp.HotWords;
using Sabesp.Enumerators;

public partial class imprensa : BasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		/************************************************
		Remover a linha abaixo quando habilitar a nova página
		/************************************************/
		//Response.Redirect("http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=0&proj=AgenciaNoticias&pub=T&db=");


		HtmlGenericControl body = (HtmlGenericControl)Master.FindControl("body");
		body.Attributes.Add("class", "interna");
		this.LoadDescrSessao();
		this.BindDestaques();
		this.BindUltimosReleases();
	}

	private void LoadDescrSessao()
	{
		Secao entidadeSecao = new Secao();
		entidadeSecao.SecaoId = SecaoId;
		entidadeSecao = new SecaoService().Carregar(entidadeSecao);

		SecaoIdioma entidadeSecaoIdioma = new SecaoIdioma();
		entidadeSecaoIdioma.Secao = new Secao();
		entidadeSecaoIdioma.Secao = entidadeSecao;
		entidadeSecaoIdioma.Idioma = new Idioma();
		entidadeSecaoIdioma.Idioma.IdiomaId = Util.CurrentIdioma.IdiomaId;
		entidadeSecaoIdioma = new SecaoIdiomaService().Carregar(entidadeSecaoIdioma);
		if (entidadeSecaoIdioma != null)
		{
			this.ltrImprensa.Text = entidadeSecaoIdioma.Titulo;
			this.lblDescrImprensa.Text = WordsInjector.Hotword(entidadeSecaoIdioma.Texto).ReplaceHtml();
		}
	}

	protected void BindDestaques()
	{
		Secao entidadeSecaoSobre = new Secao();
		entidadeSecaoSobre.SecaoId = MenuPrincipal.SobreAMarca.GetHashCode();
		Secao entidadeSecaoExplicacoes = new Secao();
		entidadeSecaoExplicacoes.SecaoId = MenuPrincipal.Explicacoes.GetHashCode();

		entidadeSecaoSobre = new SecaoService().Carregar(entidadeSecaoSobre);
		entidadeSecaoExplicacoes = new SecaoService().Carregar(entidadeSecaoExplicacoes);
		List<Secao> secoes = new List<Secao>();
		secoes.Add(entidadeSecaoSobre);
		secoes.Add(entidadeSecaoExplicacoes);

		imprensaDestaqueLista.Secoes = secoes;
		imprensaDestaqueLista.DataBind();

	}
	protected void BindUltimosReleases()
	{
		ReleaseService releaseService = new ReleaseService();
		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "DESC" };

		List<Release> releases = (List<Release>)releaseService.CarregarTodosSite(5, dataExibicaoInicio, orderBy, null);

		if (releases != null && releases.Count > 0)
		{
			releaseUltimosReleases.Releases = releases;
			releaseUltimosReleases.DataBind();
		}
		else
		{
			releaseUltimosReleases.Visible = false;
		}
	}
}