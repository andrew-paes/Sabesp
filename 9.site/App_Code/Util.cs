using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Sabesp.Enumerators;
using System.Web.UI;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Configuration;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{
	public Util() { }

	/// <summary>
	/// Returns the name of Site Map Provider
	/// </summary>
	public static String SiteMapProvider
	{
		get
		{
			Cookie cook = new Cookie();

			//convert cook.IdiomaId to enum Idiomas
			Idiomas enumIdioma = (Idiomas)Enum.Parse(typeof(Idiomas), cook.IdiomaId.ToString());

			//returns the name of SiteMap Provider
			switch (enumIdioma)
			{
				case Idiomas.Portugues:
					return "DefaultSiteMapProvider";
				case Idiomas.Ingles:
					return "DefaultSiteMapProviderEnUS";
				default:
					return "DefaultSiteMapProvider";
			}
		}
	}

	/// <summary>
	/// Build a virtual path of route with your parameters
	/// </summary>
	/// <param name="routeName"></param>
	/// <param name="routeParams"></param>
	/// <returns></returns>
	public static string GetVirtualPath(string routeName, RouteValueDictionary routeParams)
	{
		string vPath = string.Empty;
		//create a temo Route Value Dictionary to manipulate your values
		RouteValueDictionary routeParamsTmp = new RouteValueDictionary();
		foreach (var item in routeParams)
		{
			if (!String.IsNullOrEmpty(Convert.ToString(item.Value)))
			{
				//replace spaces with '+'
				routeParamsTmp.Add(item.Key, item.Value.ToString().Replace(" ", "+"));
			}
			else
			{
				routeParamsTmp.Add(item.Key, Convert.ToString(item.Value));
			}
		}

		//create a virtual path
		VirtualPathData pathData = RouteTable.Routes.GetVirtualPath(null, "Noticia", routeParamsTmp);

		if (pathData != null)
		{
			vPath = pathData.VirtualPath;
		}

		//returns a virual path
		return vPath;
	}

	public static Sabesp.BO.Idioma CurrentIdioma
	{
		get
		{
			Cookie cook = new Cookie();

			return new Sabesp.BO.Idioma(cook.IdiomaId);
		}
	}

	public static int CurrentIdiomaId
	{
		get
		{
			Cookie cook = new Cookie();

			return cook.IdiomaId;
		}
	}

	public static Control FindControlRecursive(Control root, string id)
	{
		if (root.ID == id)
		{
			return root;
		}

		foreach (Control c in root.Controls)
		{
			Control t = FindControlRecursive(c, id);
			if (t != null)
			{
				return t;
			}
		}

		return null;
	}

	public static String MaskDate
	{
		get
		{
			if (CurrentIdiomaId == Idiomas.Portugues.GetHashCode())
			{
				return "dd/MM/yyyy";
			}
			else
			{
				return "MM/dd/yyyy";
			}
		}
	}

	///<summary>Download de arquivo</summary>
	///
	///
	public static void DownloadFile(string ArquivoFisico, string ArquivoVirtual, bool forceDownload)
	{
		string path = ArquivoFisico;
		string name = Path.GetFileName(path);
		string ext = Path.GetExtension(path);
		HttpContext.Current.Response.Charset = "iso-8859-1";
		HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
		HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
		if (forceDownload)
		{
			HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + (ArquivoVirtual));
		}
		HttpContext.Current.Response.ContentType = "application/octet-stream";

		if (File.Exists(path))
		{
			HttpContext.Current.Response.WriteFile(path);
			HttpContext.Current.Response.End();
		}
	}

	public static string FullApplicationPath()
	{
		return HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, string.Empty) + HttpContext.Current.Request.ApplicationPath + "/";
	}

	#region ProdutoTipo

	/// <summary>
	/// Get the 'SecaoId' based on 'ProdutoTipo'
	/// </summary>
	/// <param name="produtoTipoId"></param>
	/// <returns></returns>
	public static int GetSecaoIdByProductType(int produtoTipoId)
	{
		Produtos tipoProduto = (Produtos)Enum.Parse(typeof(Produtos), produtoTipoId.ToString());

		return GetSecaoIdByProductType(tipoProduto);
	}

	public static int GetSecaoIdByProductType(Produtos produtoTipo)
	{
		FieldInfo fi = typeof(Produtos).GetField((produtoTipo.ToString()));
		DescriptionAttribute da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
		int secaoId = 0;

		if (!String.IsNullOrEmpty(da.Description))
		{
			try
			{
				secaoId = Convert.ToInt32(da.Description);
			}
			catch
			{
				secaoId = 0;
			}
		}

		return secaoId;
	}

	#endregion

	public static bool IsHomolog
	{
		get
		{
			if (ConfigurationManager.AppSettings["Homologacao"] != null)
			{
				try
				{
					return Convert.ToBoolean(ConfigurationManager.AppSettings["Homologacao"]);
				}
				catch
				{
					return false;
				}
			}
			return false;
		}
	}
}
