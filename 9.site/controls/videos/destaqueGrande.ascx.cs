using System;
using System.Web;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;

public partial class controls_videos_destaqueGrande : SmartUserControl
{
	#region Properties

	private String _cssClass = "newsDestaque";
	/// <summary>
	/// Gets or sets the CssClass of Panel (div)
	/// </summary>
	public String CssClass
	{
		get
		{
			return this._cssClass;
		}
		set
		{
			this._cssClass = value;
		}
	}

	/// <summary>
	/// Id of object "Video" to try to load and bind controls
	/// </summary>
	public int VideoId { get; set; }

	/// <summary>
	/// Object video to bind controls
	/// </summary>
	public Video Video { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.ConfigureControls();
	}

	/// <summary>
	/// configure the properties of this control and your children
	/// </summary>
	protected void ConfigureControls()
	{
		pnlDestaque.CssClass = this.CssClass;
	}

	public override void DataBind()
	{
		base.DataBind();

		//if the object is null, try to load
		if (this.Video == null)
		{
			VideoService videoService = new VideoService();
			this.Video = videoService.Carregar(new Video() { Conteudo = new Conteudo(this.VideoId) });
		}

		//bind the control
		this.BindVideo(this.Video);
	}

	/// <summary>
	/// Bind the control with values of Video
	/// </summary>
	/// <param name="video"></param>
	protected void BindVideo(Video video)
	{
		if (video != null)
		{
			VideoIdiomaService videoIdiomaService = new VideoIdiomaService();
			VideoIdioma videoIdioma = videoIdiomaService.Carregar(new VideoIdioma() { Video = video, Idioma = Util.CurrentIdioma });
			if (videoIdioma != null)
			{
                ltrVideo.Text = RedesSociais.YouTube.BuildYoutubeHtmlString(384, 209, video.UrlYoutube, video.Conteudo.ConteudoId);
				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/tv-sabesp-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", video.Conteudo.ConteudoId);
				ltrTitulo.Text = videoIdioma.TituloVideo;
                lblChamada.Text = videoIdioma.DescricaoVideo.StripHTML().ReplaceHtml(); 
			}
		}
		else
		{
			//if object is null then, hide the control
			this.Visible = false;
		}
	}

	#endregion
}
