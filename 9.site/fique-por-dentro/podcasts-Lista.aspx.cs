using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using Sabesp.FilterHelper;

public partial class podcasts_Lista : BasePage
{
	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		/************************************************
		Remover a linha abaixo quando habilitar a nova página
		/************************************************/
		//Response.Redirect("http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=2&temp2=3&proj=AgenciaNoticias&pub=T&nome=podcast_teste&db=&nivel=&contini=0&pagina=1");

		if (!IsPostBack)
		{
			this.BindPodcasts();
			this.BindMaisVistos();
			boxZebrado.DataBind(Assuntos.Podcast);
			segundaColunaDinamica1.DataBind();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void lstPodcasts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
	{
		DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

		if (IsPostBack)
		{
			BindPodcasts();
		}
	}

	/// <summary>
	/// Bind list view
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void lstPodcasts_ItemDataBound(object sender, ListViewItemEventArgs e)
	{
		bool visible = false;
		using (var item = ((ListViewDataItem)e.Item))
		{
			if (item != null)
			{
				var podcast = (Podcast)item.DataItem;

				if (podcast != null)
				{
					var ltrPodcastCategoria = (Literal)item.FindControl("ltrPodcastCategoria");
					var hlPodcast = (HyperLink)item.FindControl("hlPodcast");
					var lblData = (Label)item.FindControl("lblData");
					var lblTitulo = (Label)item.FindControl("lblTitulo");
					var lblTexto = (Label)item.FindControl("lblTexto");

					PodcastIdiomaService podcastIdiomaService = new PodcastIdiomaService();
					//load the language
					PodcastIdioma podcastIdioma = podcastIdiomaService.Carregar(new PodcastIdioma() { Podcast = podcast, Idioma = Util.CurrentIdioma });
					
					//bind the controls
					if (podcastIdioma != null)
					{
						PodcastCategoriaIdiomaService podcastCategoriaIdiomaService = new PodcastCategoriaIdiomaService();

						PodcastCategoriaIdioma entidadePodcastCategoriaIdioma = new PodcastCategoriaIdioma();
						entidadePodcastCategoriaIdioma.PodcastCategoria = new PodcastCategoria();
						entidadePodcastCategoriaIdioma.PodcastCategoria.PodcastCategoriaId = podcast.PodcastCategoria.PodcastCategoriaId;
						entidadePodcastCategoriaIdioma.Idioma = Util.CurrentIdioma;
						entidadePodcastCategoriaIdioma = podcastCategoriaIdiomaService.Carregar(entidadePodcastCategoriaIdioma);

						if (entidadePodcastCategoriaIdioma != null)
						{
							ltrPodcastCategoria.Text = entidadePodcastCategoriaIdioma.Descricao.ReplaceHtml();
						}
						else
						{
							ltrPodcastCategoria.Text = "Boletim";
						}

						hlPodcast.NavigateUrl = String.Concat("Podcasts-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
						lblTitulo.Text = podcastIdioma.TituloPodcast;

						//recorta para resumir o texto
						lblTexto.Text = podcastIdioma.DescricaoPodcast.GenerateResume(85);

						lblData.Text = podcast.DataHoraPublicacao.ToString(Util.MaskDate);
						visible = true;
					}
				}
			}
		}
		e.Item.Visible = visible;
	}

	#endregion

	#region Methods

	/// <summary>
	/// Get the data to bind the listview
	/// </summary>
	protected void BindPodcasts()
	{
		PodcastService podcastService = new PodcastService();

		PodcastFH filter = new PodcastFH() { BancoAudio = "0" };
		////dataHoraPublicacao <= NOW
		//filter.DataHoraPublicacaoPeriodoFinal = DateTime.Now.ToString("yyyy/MM/dd");

		////dataExibicaoFim >= NOW
		//filter.DataHoraPodcastFimPeriodoFinal = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "ASC" };

		List<Podcast> podcasts = new List<Podcast>();

		if (TagId > 0)
		{
			podcasts = (List<Podcast>)podcastService.CarregarTagged(TagId);
		}
		else
		{
			podcasts = (List<Podcast>)podcastService.RetornaTodosSite(0, dataExibicaoInicio, orderBy, filter);
		}
		lstPodcasts.DataSource = podcasts;
		lstPodcasts.DataBind();
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
	#endregion
}