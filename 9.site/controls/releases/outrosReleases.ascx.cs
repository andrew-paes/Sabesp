using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class controls_releases_outrosReleases : SmartUserControl
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
		var ltrOutrosReleases = (Literal)this.FindControl("ltrOutrosReleases");
		ltrOutrosReleases.Text = Resources.Resource.ltrOutrosReleases.ToString();

	}
	/// <summary>
	/// Bind the repeater control
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		if (this.Releases != null && this.Releases.Count > 0)
		{
			rptOutrosReleases.DataSource = this.Releases;
			rptOutrosReleases.DataBind();
			var li = (HtmlGenericControl)rptOutrosReleases.Items[rptOutrosReleases.Items.Count - 1].FindControl("li");
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

	protected void rptOutrosReleases_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var lblDataPublicacao = (Label)e.Item.FindControl("lblDataPublicacao");
			var hlRelease = (HyperLink)e.Item.FindControl("hlRelease");
			var ltrTitulo = (Literal)e.Item.FindControl("ltrTitulo");

			Release release = (Release)e.Item.DataItem;
			ReleaseIdiomaService releaseIdiomaService = new ReleaseIdiomaService();
			ReleaseIdioma releaseIdioma = releaseIdiomaService.Carregar(new ReleaseIdioma() { Release = release, Idioma = Util.CurrentIdioma });
			if (releaseIdioma != null)
			{
				ltrTitulo.Text = releaseIdioma.TituloRelease;
				lblDataPublicacao.Text = release.DataHoraPublicacao.ToString(Util.MaskDate);
				hlRelease.NavigateUrl = String.Concat("~/imprensa/Releases-Detalhes.aspx?secaoId=", MenuPrincipal.Releases.GetHashCode(), "&id=", release.Conteudo.ConteudoId);
				hlRelease.Text = releaseIdioma.ChamadaRelease.GenerateResume(250);

			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}