using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Extensions;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;

public partial class controls_dinamicos_segundaColuna : SmartUserControl
{
	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	#endregion

	#region Methods

	public override void DataBind()
	{
		base.DataBind();

		this.GetControls();
	}

	protected void GetControls()
	{
		ControleSessaoService controleSessaoService = new ControleSessaoService();
		string[] orderColumn = { "posicao" };
		string[] orderDirection = { "ASC" };

		List<ControleSessao> listaControleSessao = (List<ControleSessao>)controleSessaoService.RetornaTodosSite(0, orderColumn, orderDirection, new ControleSessaoFH() { SecaoId = SecaoId.ToString(), Coluna = "2" });

		if (listaControleSessao != null && listaControleSessao.Count > 0)
		{
			this.Controls.Clear();
			foreach (var ctl in listaControleSessao)
			{
				this.AddControl(ctl.Controle.ControleId);
			}
		}
	}

	/// <summary>
	/// Add a control to page
	/// </summary>
	/// <param name="controleId"></param>
	protected void AddControl(int controleId)
	{
		ControleService controleService = new ControleService();
		Controle ctl = controleService.Carregar(new Controle() { ControleId = controleId, Ativo = true });

		if (ctl != null)
		{
			ControleTipoService controleTipoService = new ControleTipoService();
			ctl.ControleTipo = controleTipoService.Carregar(ctl.ControleTipo);

			if (ctl.ControleTipo != null)
			{
				Control ctlDinamic = null;
				try
				{
					//Load the controle dinamically
					ctlDinamic = this.LoadControl(ctl.ControleTipo.ArquivoControle, ctl.ControleId);
				}
				catch { }

				if (ctlDinamic != null)
				{
					ctlDinamic.DataBind();
					this.Controls.Add(ctlDinamic);
				}
			}
		}
	}

	#endregion

  
}
