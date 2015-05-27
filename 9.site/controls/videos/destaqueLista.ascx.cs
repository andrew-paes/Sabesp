using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_videos_destaqueLista : SmartUserControl
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
			rptDestaques.DataSource = this.Videos;
			rptDestaques.DataBind();
			var li = (HtmlGenericControl)rptDestaques.Items[rptDestaques.Items.Count - 1].FindControl("li");
			if (li != null)
			{
				li.Attributes.Add("style", "display:none");
			}
		}
		else
		{
			this.Visible = false;
		}
	}

	protected void rptDestaques_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var ltrVideo = (Literal)e.Item.FindControl("ltrVideo");
			var hlTitulo = (HyperLink)e.Item.FindControl("hlTitulo");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

			Video video = (Video)e.Item.DataItem;
			VideoIdiomaService videoIdiomaService = new VideoIdiomaService();
			VideoIdioma videoIdioma = videoIdiomaService.Carregar(new VideoIdioma() { Video = video, Idioma = Util.CurrentIdioma });
			if (videoIdioma != null)
			{
				ltrVideo.Text = RedesSociais.YouTube.BuildYoutubeHtmlString(184, 122, video.UrlYoutube, video.Conteudo.ConteudoId);
				hlTitulo.NavigateUrl = String.Concat("~/fique-por-dentro/tv-sabesp-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", video.Conteudo.ConteudoId);
				ltrTitulo.Text = videoIdioma.TituloVideo.ReplaceHtml();
				lblChamada.Text = videoIdioma.DescricaoVideo.GenerateResume(300);
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
