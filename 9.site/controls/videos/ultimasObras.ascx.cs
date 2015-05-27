using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_videos_ultimasObras : SmartUserControl
{
	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<Video> Videos { get; set; }

	#endregion

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{

	}
	/// <summary>
	/// Bind the repeater control
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		if (this.Videos != null && this.Videos.Count > 0)
		{
			rptVideos.DataSource = this.Videos;
			rptVideos.DataBind();
			var li = (HtmlGenericControl)rptVideos.Items[rptVideos.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("class", "last");
			}
		}
		else
		{
			this.Visible = false;
		}
	}

	protected void rptVideos_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlVideo = (HyperLink)e.Item.FindControl("hlVideo");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var lblDataHoraPublicacao = (Label)e.Item.FindControl("lblDataHoraPublicacao");

			Video video = (Video)e.Item.DataItem;
			VideoIdiomaService videoIdiomaService = new VideoIdiomaService();
			VideoIdioma videoIdioma = videoIdiomaService.Carregar(new VideoIdioma() { Video = video, Idioma = Util.CurrentIdioma });
			if (videoIdioma != null)
			{
				hlVideo.NavigateUrl = String.Concat("~/fique-por-dentro/tv-sabesp-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", video.Conteudo.ConteudoId);
				lblDataHoraPublicacao.Text = video.DataHoraPublicacao.ToString();
				//recorta para resumir o texto
				lblChamada.Text = videoIdioma.DescricaoVideo.GenerateResume(85);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
