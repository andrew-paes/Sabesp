using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;
using Sabesp.FilterHelper;
using System.Web.UI.HtmlControls;

public partial class comunicados_Default : BasePage
{

	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		/************************************************
		Remover a linha abaixo quando habilitar a nova página
		/************************************************/
		//Response.Redirect("http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=2&proj=AgenciaNoticias&pub=T&nome=ListaMaterias&db=&nivel=COMUNICADOS&pagina=1");

		if (!IsPostBack)
		{
			this.BindComunicados();
			boxZebrado.DataBind(Assuntos.Comunicado);
			segundaColunaDinamica1.DataBind();
		}

	}

	protected void lstComunicados_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
	{
		DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

		if (IsPostBack)
		{
			BindComunicados();
		}
	}

	/// <summary>
	/// Bind list view
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void lstComunicados_ItemDataBound(object sender, ListViewItemEventArgs e)
	{
		bool visible = false;
		using (var item = ((ListViewDataItem)e.Item))
		{
			if (item != null)
			{
				var comunicado = (Comunicado)item.DataItem;
				if (comunicado != null)
				{
					var hlComunicado = (HyperLink)item.FindControl("hlComunicado");
					var lblData = (Label)item.FindControl("lblData");
					var lblTitulo = (Label)item.FindControl("lblTitulo");
					var lblTexto = (Label)item.FindControl("lblTexto");

					ComunicadoIdiomaService comunicadoIdiomaService = new ComunicadoIdiomaService();
					//load the language
					ComunicadoIdioma comunicadoIdioma = comunicadoIdiomaService.Carregar(new ComunicadoIdioma() { Comunicado = comunicado, Idioma = Util.CurrentIdioma });
					//bind the controls
					if (comunicadoIdioma != null)
					{
						hlComunicado.NavigateUrl = String.Concat("comunicados-Detalhes.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode(), "&id=", comunicado.Conteudo.ConteudoId);
						lblTitulo.Text = comunicadoIdioma.TituloComunicado;
						lblTexto.Text = comunicadoIdioma.TextoComunicado.GenerateResume(200);
						lblData.Text = comunicado.DataExibicaoInicio.Value.ToString(Util.MaskDate);
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
	protected void BindComunicados()
	{
		ComunicadoService comunicadoService = new ComunicadoService();

		string[] dataExibicaoInicio = { "dataExibicaoInicio" };
		string[] orderBy = { "DESC" };

		List<Comunicado> comunicados = new List<Comunicado>();

		if (TagId > 0)
		{
			comunicados = (List<Comunicado>)comunicadoService.CarregarTagged(TagId);
		}
		else
		{
			comunicados = (List<Comunicado>)comunicadoService.RetornaTodosSite(0, 0, dataExibicaoInicio, orderBy, null);
		}
		lstComunicados.DataSource = comunicados;
		lstComunicados.DataBind();
	}

	#endregion

}