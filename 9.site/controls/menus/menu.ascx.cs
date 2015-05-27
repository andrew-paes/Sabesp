using System;
using System.Web.UI.WebControls;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.Enumerators;

public partial class controls_menus_menu : SmartUserControl
{
	#region Events

	protected void Page_Load(object sender, EventArgs e)
	{
		this.MontaMenu();
	}

	#endregion

	#region Methods

	protected void MontaMenu()
	{
		Panel ctlPnlMenu = (Panel)Util.FindControlRecursive(this.Page, "pnlMenu");
		String estiloMenu = string.Empty;

		foreach (MenuPrincipal item in Enum.GetValues(typeof(MenuPrincipal)))
		{
			SecaoService secaoService = new SecaoService();
			ModeloService modeloService = new ModeloService();
			Secao secao = new Secao();
			Secao secaoPai = new Secao();
			Modelo modelo = new Modelo();

			try
			{
				CriaMenu(item, secaoService, modeloService, ref secao, ref secaoPai, ref modelo);
			}
			catch { }

			if ((secao != null && modelo != null) || (item == MenuPrincipal.AgenciaVirtual))
			{
				switch (item)
				{
					case MenuPrincipal.ASabesp:
						hlMenuSabesp.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", secao.SecaoId);
						estiloMenu = (secaoPai != null && secaoPai.SecaoId == secao.SecaoId) ? "menuSabesp" : estiloMenu;
						break;
					case MenuPrincipal.Saneamento:
						hlMenuSaneamento.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", secao.SecaoId);
						estiloMenu = (secaoPai != null && secaoPai.SecaoId == secao.SecaoId) ? "menuSaneamento" : estiloMenu;
						break;
					case MenuPrincipal.SociedadeEMeioAmbiente:
						hlMenuSociedade.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", secao.SecaoId);
						estiloMenu = (secaoPai != null && secaoPai.SecaoId == secao.SecaoId) ? "menuSociedade" : estiloMenu;
						break;
					case MenuPrincipal.ProdutosEServicos:
						hlMenuProdutos.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", secao.SecaoId);
						estiloMenu = (secaoPai != null && secaoPai.SecaoId == secao.SecaoId) ? "menuProdutos" : estiloMenu;
						break;
					case MenuPrincipal.FiquePorDentro:
						hlMenuFiquePorDentro.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", secao.SecaoId);
						estiloMenu = (secaoPai != null && secaoPai.SecaoId == secao.SecaoId) ? "menuFiquePorDentro" : estiloMenu;
						break;
					case MenuPrincipal.Imprensa:
						hlMenuAtendimento.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", secao.SecaoId);
						estiloMenu = (secaoPai != null && secaoPai.SecaoId == secao.SecaoId) ? "menuAtendimento" : estiloMenu;
						break;
					case MenuPrincipal.ClientesEServicos:
						hlMenuAgenciaVirtual.NavigateUrl = String.Concat(modelo.Arquivo, "?secaoId=", secao.SecaoId);
						estiloMenu = (secaoPai != null && secaoPai.SecaoId == secao.SecaoId) ? "menuAgenciaVirtual" : estiloMenu;
						break;
					default:
						break;
				}
			}
		}

		if (ctlPnlMenu != null)
		{
			ctlPnlMenu.CssClass = estiloMenu;
		}
	}

	private static void CriaMenu(MenuPrincipal item, SecaoService secaoService, ModeloService modeloService, ref Secao secao, ref Secao secaoPai, ref Modelo modelo)
	{
		secao = secaoService.Carregar(new Secao() { SecaoId = item.GetHashCode() });
		secaoPai = secaoService.GetRoot(SecaoId);
		if (secao != null)
		{
			modelo = modeloService.Carregar(new Modelo() { ModeloId = secao.Modelo.ModeloId });
		}
	}

	#endregion
}
