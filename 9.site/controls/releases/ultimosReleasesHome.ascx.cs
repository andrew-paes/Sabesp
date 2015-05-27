using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using System.Web.UI.HtmlControls;

public partial class controls_releases_ultimosReleasesHome : SmartUserControl
{
	#region Properties

	/// <summary>
	/// DataSource of this control
	/// </summary>
	public List<Release> Releases { get; set; }

	#endregion

	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
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

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void rptReleases_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.DataItem != null)
		{
			var hlRelease = (HyperLink)e.Item.FindControl("hlRelease");
			var lblChamada = (Label)e.Item.FindControl("lblChamada");

			Release releaseBO = (Release)e.Item.DataItem;
			ReleaseIdiomaService releaseIdiomaService = new ReleaseIdiomaService();
			ReleaseIdioma releaseIdiomaBO = releaseIdiomaService.Carregar(new ReleaseIdioma() { Release = releaseBO, Idioma = Util.CurrentIdioma });

			if (releaseIdiomaBO != null)
			{
				hlRelease.NavigateUrl = String.Concat("~/imprensa/Releases-Detalhes.aspx?secaoId=", MenuPrincipal.Releases.GetHashCode(), "&id=", releaseBO.Conteudo.ConteudoId);
				lblChamada.Text = releaseIdiomaBO.TituloRelease;
			}
			else
			{
				e.Item.Visible = false;
			}
		}
	}

	#endregion
}
