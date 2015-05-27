using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Enumerators;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using System.Web.UI.HtmlControls;

public partial class podcasts_Default : BasePage
{
	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		/************************************************
		Remover a linha abaixo quando habilitar a nova página
		/************************************************/
		//Response.Redirect("http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=2&temp2=3&proj=AgenciaNoticias&pub=T&nome=podcast_teste&db=&nivel=&contini=0&pagina=1");

		this.LoadResources();
		this.BindPodcast();
		this.BindMaisVistos();
		this.BindMaisVistos();
		boxZebrado.DataBind(Assuntos.Podcast);
		segundaColunaDinamica1.DataBind();
	}

	#endregion

	#region Methods

	/// <summary>
	/// Load the resources based in current language
	/// </summary>
	protected void LoadResources()
	{
		hlTodosPodcasts.NavigateUrl = String.Concat("Podcasts-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		hlTodosPodcasts.Text = GetLocalResourceObject(hlTodosPodcasts.ID).ToString();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void BindMaisVistos()
	{
		PodcastService podcastService = new PodcastService();
		List<Podcast> podcasts = new List<Podcast>();
		podcasts = (List<Podcast>)podcastService.CarregarMaisVistos(3);
		podcastMaisVistos.Podcasts = podcasts;
		podcastMaisVistos.DataBind();
	}

	protected void BindPodcast()
	{
		this.BindDiario();
		this.BindSemanal();
		this.BindQuinzenal();
	}

	#region [ Podcast Diario ]

	/// <summary>
	/// 
	/// </summary>
	protected void BindDiario()
	{
		PodcastService podcastService = new PodcastService();

		Podcast entidadePodcast = new Podcast();
		entidadePodcast.PodcastCategoria = new PodcastCategoria();
		entidadePodcast.PodcastCategoria.PodcastCategoriaId = EnumPodcastCategoria.BoletimDiario.GetHashCode();
		entidadePodcast.DestaquePodcasts = true;

		List<Podcast> entidadePodcastList = new List<Podcast>();
		entidadePodcastList = (List<Podcast>)podcastService.CarregarMaisRecentes(3, entidadePodcast);

		if (entidadePodcastList != null && entidadePodcastList.Count > 0)
		{
			PodcastCategoriaIdiomaService podcastCategoriaIdiomaService = new PodcastCategoriaIdiomaService();

			PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
			entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
			entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = 1;
			entidadePodcastCategoriaIdioma.Idioma = Util.CurrentIdioma;
			entidadePodcastCategoriaIdioma = podcastCategoriaIdiomaService.Carregar(entidadePodcastCategoriaIdioma);

			if (entidadePodcastCategoriaIdioma != null)
			{
				this.ltrDiario.Text = entidadePodcastCategoriaIdioma.Descricao.ReplaceHtml();
			}
			else
			{
				this.ltrDiario.Text = "Boletins Diários";
			}

			Podcast podcast = new Podcast();
			podcast = entidadePodcastList[0];
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });

			if (podcastIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();

				if (podcastIdioma.ArquivoPodcast != null && podcastIdioma.ArquivoPodcast.ArquivoId > 0)
				{
					podcastIdioma.ArquivoPodcast = arquivoService.Carregar(podcastIdioma.ArquivoPodcast);
				}

				hlTituloDiario.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTituloDiario.Text = podcastIdioma.TituloPodcast;
				lblChamadaDiario.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);
			}
			else
			{
				this.divDiario.Visible = false;
			}

			entidadePodcastList.RemoveAt(0);

			if (entidadePodcastList != null && entidadePodcastList.Count > 0)
			{
				rptDiario.DataSource = entidadePodcastList;
				rptDiario.DataBind();

				if (rptDiario.Items.Count > 0)
				{
					HtmlGenericControl li = (HtmlGenericControl)rptDiario.Items[rptDiario.Items.Count - 1].FindControl("li");

					if (li != null)
					{
						li.Attributes.Add("style", "display:none");
					}
				}
			}
		}
		else
		{
			this.divDiario.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptDiario_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlTitulo = (HyperLink)e.Item.FindControl("hlTitulo");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

			Podcast podcast = (Podcast)e.Item.DataItem;
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
			
			if (podcastIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();
				
				if (podcastIdioma.ArquivoPodcast != null && podcastIdioma.ArquivoPodcast.ArquivoId > 0)
				{
					podcastIdioma.ArquivoPodcast = arquivoService.Carregar(podcastIdioma.ArquivoPodcast);
				}

				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTitulo.Text = podcastIdioma.TituloPodcast;
				lblChamada.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion

	#region [ Podcast Semanal ]

	/// <summary>
	/// 
	/// </summary>
	protected void BindSemanal()
	{
		PodcastService podcastService = new PodcastService();

		Podcast entidadePodcast = new Podcast();
		entidadePodcast.PodcastCategoria = new PodcastCategoria();
		entidadePodcast.PodcastCategoria.PodcastCategoriaId = EnumPodcastCategoria.BoletimSemanal.GetHashCode();
		entidadePodcast.DestaquePodcasts = true;

		List<Podcast> entidadePodcastList = new List<Podcast>();
		entidadePodcastList = (List<Podcast>)podcastService.CarregarMaisRecentes(1, entidadePodcast);

		if (entidadePodcastList != null && entidadePodcastList.Count > 0)
		{
			PodcastCategoriaIdiomaService podcastCategoriaIdiomaService = new PodcastCategoriaIdiomaService();

			PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
			entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
			entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = 2;
			entidadePodcastCategoriaIdioma.Idioma = Util.CurrentIdioma;
			entidadePodcastCategoriaIdioma = podcastCategoriaIdiomaService.Carregar(entidadePodcastCategoriaIdioma);

			if (entidadePodcastCategoriaIdioma != null)
			{
				this.ltrSemanal.Text = entidadePodcastCategoriaIdioma.Descricao.ReplaceHtml();
			}
			else
			{
				this.ltrSemanal.Text = "Boletim Semanal";
			}

			Podcast podcast = new Podcast();
			podcast = entidadePodcastList[0];
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });

			if (podcastIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();

				if (podcastIdioma.ArquivoPodcast != null && podcastIdioma.ArquivoPodcast.ArquivoId > 0)
				{
					podcastIdioma.ArquivoPodcast = arquivoService.Carregar(podcastIdioma.ArquivoPodcast);
				}

				hlTituloSemanal.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTituloSemanal.Text = podcastIdioma.TituloPodcast;
				lblChamadaSemanal.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);
			}
			else
			{
				this.divSemanal.Visible = false;
			}
		}
		else
		{
			this.divSemanal.Visible = false;
		}
	}

	#endregion

	#region [ Podcast Quinzenal ]

	/// <summary>
	/// 
	/// </summary>
	protected void BindQuinzenal()
	{
		PodcastService podcastService = new PodcastService();

		Podcast entidadePodcast = new Podcast();
		entidadePodcast.PodcastCategoria = new PodcastCategoria();
		entidadePodcast.PodcastCategoria.PodcastCategoriaId = EnumPodcastCategoria.BoletimQuinzenal.GetHashCode();
		entidadePodcast.DestaquePodcasts = true;

		List<Podcast> entidadePodcastList = new List<Podcast>();
		entidadePodcastList = (List<Podcast>)podcastService.CarregarMaisRecentes(2, entidadePodcast);

		if (entidadePodcastList != null && entidadePodcastList.Count > 0)
		{
			PodcastCategoriaIdiomaService podcastCategoriaIdiomaService = new PodcastCategoriaIdiomaService();

			PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
			entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
			entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = 3;
			entidadePodcastCategoriaIdioma.Idioma = Util.CurrentIdioma;
			entidadePodcastCategoriaIdioma = podcastCategoriaIdiomaService.Carregar(entidadePodcastCategoriaIdioma);

			if (entidadePodcastCategoriaIdioma != null)
			{
				this.ltrQuinzenal.Text = entidadePodcastCategoriaIdioma.Descricao.ReplaceHtml();
			}
			else
			{
				this.ltrQuinzenal.Text = "Boletim Semanal";
			}

			Podcast podcast = new Podcast();
			podcast = entidadePodcastList[0];
			PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
			PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });

			if (podcastIdioma != null)
			{
				ArquivoService arquivoService = new ArquivoService();

				if (podcastIdioma.ArquivoPodcast != null && podcastIdioma.ArquivoPodcast.ArquivoId > 0)
				{
					podcastIdioma.ArquivoPodcast = arquivoService.Carregar(podcastIdioma.ArquivoPodcast);
				}

				hlTituloQuinzenal1.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
				ltrTituloQuinzenal1.Text = podcastIdioma.TituloPodcast;
				lblChamadaQuinzenal1.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);
			}

			entidadePodcastList.RemoveAt(0);

			if (entidadePodcastList != null && entidadePodcastList.Count > 0)
			{
				podcast = entidadePodcastList[0];
				podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });

				if (podcastIdioma != null)
				{
					ArquivoService arquivoService = new ArquivoService();

					if (podcastIdioma.ArquivoPodcast != null && podcastIdioma.ArquivoPodcast.ArquivoId > 0)
					{
						podcastIdioma.ArquivoPodcast = arquivoService.Carregar(podcastIdioma.ArquivoPodcast);
					}

					hlTituloQuinzenal2.NavigateUrl = String.Concat("~/fique-por-dentro/Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
					ltrTituloQuinzenal2.Text = podcastIdioma.TituloPodcast;
					lblChamadaQuinzenal2.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);
				}
			}
			else
			{
				this.divQuinzenal2.Visible = false;
			}
		}
		else
		{
			this.divQuinzenal.Visible = false;
		}
	}

	#endregion

	#endregion
}