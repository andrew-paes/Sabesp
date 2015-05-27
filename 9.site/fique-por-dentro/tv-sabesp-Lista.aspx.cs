using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using Sabesp.FilterHelper;

public partial class tv_sabesp_Lista : BasePage
{

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.BindVideos();
            this.BindMaisVistos();
            boxZebrado.DataBind(Assuntos.Video);
			segundaColunaDinamica1.DataBind();
		}
	}

	protected void lstVideos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
	{
		DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

		if (IsPostBack)
		{
			BindVideos();
		}
	}

	/// <summary>
	/// Bind list view
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void lstVideos_ItemDataBound(object sender, ListViewItemEventArgs e)
	{
		bool visible = false;
		using (var item = ((ListViewDataItem)e.Item))
		{
			if (item != null)
			{
				var video = (Video)item.DataItem;
				if (video != null)
				{
					var hlVideo = (HyperLink)item.FindControl("hlVideo");
					var lblData = (Label)item.FindControl("lblData");
					var lblTitulo = (Label)item.FindControl("lblTitulo");
					var lblTexto = (Label)item.FindControl("lblTexto");

					VideoIdiomaService videoIdiomaService = new VideoIdiomaService();
					//load the language
					VideoIdioma videoIdioma = videoIdiomaService.Carregar(new VideoIdioma() { Video = video, Idioma = Util.CurrentIdioma });
					//bind the controls
					if (videoIdioma != null)
					{
						hlVideo.NavigateUrl = String.Concat("tv-sabesp-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", video.Conteudo.ConteudoId);
						lblTitulo.Text = videoIdioma.TituloVideo;
                        lblTexto.Text = videoIdioma.DescricaoVideo.StripHTML().ReplaceHtml();
						lblData.Text = video.DataHoraPublicacao.ToString(Util.MaskDate);
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
	protected void BindVideos()
	{
		VideoService videoService = new VideoService();

		string[] dataHoraPublicacao = { "dataHoraPublicacao" };
		string[] orderBy = { "DESC" };

        List<Video> videos = new List<Video>();

        if (TagId > 0)
        {
            videos = (List<Video>)videoService.CarregarTagged(TagId);
        }
        else
        {
            videos = (List<Video>)videoService.RetornaTodosSite(0, dataHoraPublicacao, orderBy, null);
        }
		lstVideos.DataSource = videos;
		lstVideos.DataBind();
	}
    protected void BindMaisVistos()
    {
        VideoService videoService = new VideoService();
        List<Video> videos = new List<Video>();
        videos = (List<Video>)videoService.CarregarMaisVistos(3);
        videoMaisVistos.Videos = videos;
        videoMaisVistos.DataBind();
    }
	#endregion

}