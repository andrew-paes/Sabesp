using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Enumerators;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using Sabesp.BO;

public partial class tv_sabesp_Default : BasePage
{
	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadResources();
		this.BindDestaques();
        this.BindMaisVistos();
        this.BindUltimasObras();
        boxZebrado.DataBind(Assuntos.Video);
		segundaColunaDinamica1.DataBind();
	}

	#endregion 

	#region Methods

	/// <summary>
	/// Load the resources based in current language
	/// </summary>
	protected void LoadResources()
	{
		hlTodosVideos.NavigateUrl = String.Concat("tv-sabesp-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		hlTodosVideos.Text = GetLocalResourceObject(hlTodosVideos.ID).ToString();
	}


	protected void BindDestaques()
	{
		VideoService videoService = new VideoService();
		string[] dataHoraPublicacao = { "dataHoraPublicacao" };
		string[] orderBy = { "DESC" };

		List<Video> videos = (List<Video>)videoService.RetornaTodosSite(0, dataHoraPublicacao, orderBy, new VideoFH() { DestaqueVideos = "1" });

		if (videos != null && videos.Count > 0)
		{
			videoDestaqueGrande1.Video = videos[0];
			videoDestaqueGrande1.DataBind();

			videos.RemoveAt(0);
			videoDestaqueLista1.Videos = videos;
			videoDestaqueLista1.DataBind();

		}
		else
		{
			videoDestaqueGrande1.Visible = false;
			videoDestaqueLista1.Visible = false;
		}
	}
    protected void BindMaisVistos()
    {
        VideoService videoService = new VideoService();
        List<Video> videos = new List<Video>();
        videos = (List<Video>)videoService.CarregarMaisVistos(3);
        videoMaisVistos.Videos = videos;
        videoMaisVistos.DataBind();
    }
    protected void BindUltimasObras()
    {
        VideoService videoService = new VideoService();
        List<Video> videos = new List<Video>();
        videos = (List<Video>)videoService.CarregarTagged(4, "obra");

        videoUltimasObras.Videos = videos;
        videoUltimasObras.DataBind();
    }
	#endregion
}