using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using Sabesp.FilterHelper;

public partial class releases_Lista : BasePage
{

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.BindReleases();
		}
	}

	protected void lstReleases_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
	{
		DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

		if (IsPostBack)
		{
			BindReleases();
		}
	}

	/// <summary>
	/// Bind list view
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void lstReleases_ItemDataBound(object sender, ListViewItemEventArgs e)
	{
		bool visible = false;
		using (var item = ((ListViewDataItem)e.Item))
		{
			if (item != null)
			{
				var release = (Release)item.DataItem;
				if (release != null)
				{
					var hlRelease = (HyperLink)item.FindControl("hlRelease");
					var lblData = (Label)item.FindControl("lblData");
					var lblTitulo = (Label)item.FindControl("lblTitulo");
					var lblTexto = (Label)item.FindControl("lblTexto");

					ReleaseIdiomaService releaseIdiomaService = new ReleaseIdiomaService();
					//load the language
					ReleaseIdioma releaseIdioma = releaseIdiomaService.Carregar(new ReleaseIdioma() { Release = release, Idioma = Util.CurrentIdioma });
					//bind the controls
					if (releaseIdioma != null)
					{
						hlRelease.NavigateUrl = String.Concat("Releases-Detalhes.aspx?secaoId=", MenuPrincipal.Imprensa.GetHashCode(), "&id=", release.Conteudo.ConteudoId);
						lblTitulo.Text = releaseIdioma.TituloRelease;
						lblTexto.Text = releaseIdioma.ChamadaRelease.GenerateResume(250);
						lblData.Text = release.DataHoraPublicacao.ToString(Util.MaskDate);
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
	protected void BindReleases()
	{
		ReleaseService releaseService = new ReleaseService();

		string[] dataExibicaoInicio = { "dataHoraPublicacao" };
		string[] orderBy = { "DESC" };
		List<Release> releases = new List<Release>();
		if (TagId > 0)
		{
			releases = (List<Release>)releaseService.CarregarTagged(TagId);
		}
		else
		{
			releases = (List<Release>)releaseService.CarregarTodosSite(0, dataExibicaoInicio, orderBy, null);
		}
		lstReleases.DataSource = releases;
		lstReleases.DataBind();

	}
	#endregion

}