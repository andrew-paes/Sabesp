using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;

public partial class CtlTituloTextoCaixaEsquerda : SmartUserControl, IDinamicControl
{
	#region Properties
	
	public int ControleId { get; set; } 
	
	#endregion

	#region Constructors
	
	public CtlTituloTextoCaixaEsquerda() { }

	public CtlTituloTextoCaixaEsquerda(int controleId)
	{
		this.ControleId = controleId;
	}

	#endregion

	#region Events
	
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public override void DataBind()
	{
		base.DataBind();

		this.BindConteudo();
	}

	protected void BindConteudo()
	{
		ControleIdiomaService controleIdiomaService = new ControleIdiomaService();
		ControleIdioma controleIdioma = controleIdiomaService.CarregarToSite(this.ControleId, Util.CurrentIdiomaId);
		if (controleIdioma != null)
		{
			ltrTitulo.Text = controleIdioma.Titulo;

			IList<ControleIdiomaDado> controleIdiomaDadoList = new List<ControleIdiomaDado>();
			ControleIdiomaDadoFH controleIdiomaDadoFH = new ControleIdiomaDadoFH();
			controleIdiomaDadoFH.ControleIdiomaId = controleIdioma.ControleIdiomaId.ToString();

			ControleIdiomaDadoService controleIdiomaDadoService = new ControleIdiomaDadoService();
			controleIdiomaDadoList = controleIdiomaDadoService.RetornaTodos(0, 0, "", "", controleIdiomaDadoFH);

			if (controleIdiomaDadoList != null && controleIdiomaDadoList.Count > 0)
			{
				hlDescricao.Text = controleIdiomaDadoList[0].TextoChamada;
				hlDescricao.NavigateUrl = controleIdiomaDadoList[0].Link;
				hlDescricao.Target = controleIdiomaDadoList[0].Target;
			}
		}
		else
		{
			this.Visible = false;
		}
	}
	
	#endregion
}
