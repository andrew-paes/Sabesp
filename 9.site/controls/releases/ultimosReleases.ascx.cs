using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_releases_ultimosReleases : SmartUserControl
{
    #region Properties

    /// <summary>
    /// DataSource of this control
    /// </summary>
    public List<Release> Releases { get; set; }

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

        if (this.Releases != null && this.Releases.Count > 0)
        {
            rptReleases.DataSource = this.Releases;
            rptReleases.DataBind();
            var li = (HtmlGenericControl)rptReleases.Items[rptReleases.Items.Count - 1].FindControl("li");
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

    protected void rptReleases_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            var hlRelease = (HyperLink)e.Item.FindControl("hlRelease");
			//var ltlData = (Label)e.Item.FindControl("ltlData");
            var lblChamada = (Label)e.Item.FindControl("lblChamada");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

            Release release = (Release)e.Item.DataItem;
            ReleaseIdiomaService releaseIdiomaService = new ReleaseIdiomaService();
            ReleaseIdioma releaseIdioma = releaseIdiomaService.Carregar(new ReleaseIdioma() { Release = release, Idioma = Util.CurrentIdioma });
            if (releaseIdioma != null)
            {
                hlRelease.NavigateUrl = String.Concat("~/imprensa/Releases-Detalhes.aspx?secaoId=", MenuPrincipal.Releases.GetHashCode(), "&id=", release.Conteudo.ConteudoId);
				ltrTitulo.Text = String.Concat("<b style=\"font-size: 11px;\">", release.DataHoraPublicacao.ToString(Util.MaskDate), "</b> ", releaseIdioma.TituloRelease);
                lblChamada.Text = releaseIdioma.ChamadaRelease.GenerateResume(250);
				//ltlData.Text = release.DataHoraPublicacao.ToString(Util.MaskDate);
            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }

    #endregion
}
