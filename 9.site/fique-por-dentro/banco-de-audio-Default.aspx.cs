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

public partial class banco_de_audio_Default : BasePage
{
	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		/************************************************
		Remover a linha abaixo quando habilitar a nova página
		/************************************************/
		Response.Redirect("http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=2&proj=AgenciaNoticias&pub=T&nome=BancoAudios&db=&nivel=BANCO%20DE%20%C3%81UDIOS&pagina=1");

		this.LoadResources();
		this.BindDestaques();
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
		hlTodosbancoAudio.NavigateUrl = String.Concat("banco-de-audio-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		hlTodosbancoAudio.Text = GetLocalResourceObject(hlTodosbancoAudio.ID).ToString();
		ltrTitulo.Text = GetLocalResourceObject(ltrTitulo.ID).ToString();
	}

	protected void BindDestaques()
	{
		PodcastService podcastService = new PodcastService();
		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "ASC" };

		List<Podcast> podcasts = (List<Podcast>)podcastService.RetornaTodosSite(5, dataExibicaoInicio, orderBy, new PodcastFH() { DestaquePodcasts = "1", BancoAudio = "1" });

		if (podcasts != null && podcasts.Count > 0)
		{
			bancoAudioDestaqueGrande1.Podcast = podcasts[0];
			bancoAudioDestaqueGrande1.DataBind();

			podcasts.RemoveAt(0);
			bancoAudioDestaqueLista1.Podcasts = podcasts;
			bancoAudioDestaqueLista1.DataBind();
		}
		else
		{
			bancoAudioDestaqueGrande1.Visible = false;
			bancoAudioDestaqueLista1.Visible = false;
		}
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