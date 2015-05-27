using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using Sabesp.FilterHelper;

public partial class banco_de_audio_Lista : BasePage
{

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		/************************************************
		Remover a linha abaixo quando habilitar a nova página
		/************************************************/
		Response.Redirect("http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=2&proj=AgenciaNoticias&pub=T&nome=BancoAudios&db=&nivel=BANCO%20DE%20%C3%81UDIOS&pagina=1");


		if (!IsPostBack)
		{
			this.LoadResources();
			this.BindPodcasts();
			this.BindMaisVistos();
			boxZebrado.DataBind(Assuntos.Podcast);
			segundaColunaDinamica1.DataBind();
		}
	}


	/// <summary>
	/// Load the resources based in current language
	/// </summary>
	protected void LoadResources()
	{
		ltrTitulo.Text = GetLocalResourceObject(ltrTitulo.ID).ToString();
	}

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
						hlPodcast.NavigateUrl = String.Concat("banco-de-audio-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", podcast.Conteudo.ConteudoId);
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

		PodcastFH filter = new PodcastFH() { BancoAudio = "1" };
		////dataHoraPublicacao <= NOW
		//filter.DataHoraPublicacaoPeriodoFinal = DateTime.Now.ToString("yyyy/MM/dd");

		////dataExibicaoFim >= NOW
		//filter.DataHoraPodcastFimPeriodoFinal = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "ASC" };

		List<Podcast> podcasts = new List<Podcast>();

		if (TagId > 0)
		{
			podcasts = (List<Podcast>)podcastService.CarregarTagged(TagId, true);
		}
		else
		{
			podcasts = (List<Podcast>)podcastService.RetornaTodosSite(0, dataExibicaoInicio, orderBy, filter);
		}
		lstPodcasts.DataSource = podcasts;
		lstPodcasts.DataBind();
	}
	protected void BindMaisVistos()
	{
		PodcastService podcastService = new PodcastService();
		List<Podcast> podcasts = new List<Podcast>();
		podcasts = (List<Podcast>)podcastService.CarregarMaisVistos(3, true);
		bancoAudioMaisVistos.Podcasts = podcasts;
		bancoAudioMaisVistos.DataBind();
	}
	#endregion

}