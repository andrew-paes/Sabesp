using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Enumerators;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;

public partial class noticias_Default : BasePage
{
	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadResources();
		this.BindDestaques();
        this.BindMaisVistos();
        this.BindUltimasNoticias();
        boxZebrado.DataBind(Assuntos.Noticia);
		segundaColunaDinamica1.DataBind();
	}

	#endregion

	#region Methods

	/// <summary>
	/// Load the resources based in current language
	/// </summary>
	protected void LoadResources()
	{
		hlTodasNoticias.NavigateUrl = String.Concat("Noticias-Lista.aspx?secaoId=", MenuPrincipal.FiquePorDentro.GetHashCode());
		hlTodasNoticias.Text = GetLocalResourceObject(hlTodasNoticias.ID).ToString();
	}

	protected void BindDestaques()
	{
		NoticiaService noticiaService = new NoticiaService();
		string[] dataHoraPublicacao = { "dataHoraPublicacao" };
		string[] orderBy = { "DESC" };

		List<Noticia> noticias = (List<Noticia>)noticiaService.RetornaTodosSite(5, dataHoraPublicacao, orderBy, new NoticiaFH() { DestaqueNoticias = "1" });

		if (noticias != null && noticias.Count > 0)
		{
			noticiaDestaqueGrande1.Noticia = noticias[0];
			noticiaDestaqueGrande1.DataBind();

			noticias.RemoveAt(0);
			noticiaDestaqueLista1.Noticias = noticias;
			noticiaDestaqueLista1.DataBind();
		}
		else
		{
			noticiaDestaqueGrande1.Visible = false;
			noticiaDestaqueLista1.Visible = false;
		}
	}
    protected void BindMaisVistos()
    {
        NoticiaService noticiaService = new NoticiaService();
        List<Noticia> noticias = new List<Noticia>();
        noticias = (List<Noticia>)noticiaService.CarregarMaisVistos(3);
        noticiaMaisVistos.Noticias = noticias;
        noticiaMaisVistos.DataBind();
    }
    protected void BindUltimasNoticias()
    {
        NoticiaService noticiaService = new NoticiaService();
        List<Noticia> noticias = new List<Noticia>();
        noticias = (List<Noticia>)noticiaService.CarregarUltimasNoticias(6, new NoticiaFH() { DestaqueNoticias = "0" });

        noticiaUltimasNoticias.Noticias = noticias;
        noticiaUltimasNoticias.DataBind();
    }
	#endregion
}