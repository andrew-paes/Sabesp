using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_videos_maisVistos : SmartUserControl
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
        var ltrMaisVistos = (Literal)this.FindControl("ltrMaisVistos");
        ltrMaisVistos.Text = Resources.Resource.ltrMaisVistos.ToString();

    }
    /// <summary>
    /// Bind the repeater control
    /// </summary>
    public override void DataBind()
    {
        base.DataBind();

        if (this.Videos != null && this.Videos.Count > 0)
        {
            rptMaisVistos.DataSource = this.Videos;
            rptMaisVistos.DataBind();
            var li = (HtmlGenericControl)rptMaisVistos.Items[rptMaisVistos.Items.Count - 1].FindControl("li");
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

    protected void rptMaisVistos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            var ltrVideo = (Literal)e.Item.FindControl("ltrVideo");
            var hlVideo = (HyperLink)e.Item.FindControl("hlVideo");
            var lblTitulo = (Label)e.Item.FindControl("lblTitulo");
            var lblQtdVisualizacoes = (Label)e.Item.FindControl("lblQtdVisualizacoes");

            Video video = (Video)e.Item.DataItem;
            VideoIdiomaService videoIdiomaService = new VideoIdiomaService();
            VideoIdioma videoIdioma = videoIdiomaService.Carregar(new VideoIdioma() { Video = video, Idioma = Util.CurrentIdioma });
            if (videoIdioma != null)
            {
                ConteudoHits conteudoHits = new ConteudoHits();
                ConteudoHitsService conteudoHitsService = new ConteudoHitsService();
                conteudoHits = conteudoHitsService.CarregarToSite(video.Conteudo.ConteudoId);

                lblQtdVisualizacoes.Text = conteudoHits.Hits.ToString() + Resources.Resource.lblQtdVisualizacoes.ToString();

                //ltrVideo.Text = RedesSociais.YouTube.BuildYoutubeHtmlString(184, 122, video.UrlYoutube);
                hlVideo.NavigateUrl = String.Concat("~/fique-por-dentro/tv-sabesp-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", video.Conteudo.ConteudoId);
                lblTitulo.Text = videoIdioma.TituloVideo.ReplaceHtml();

            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }

    #endregion
}
