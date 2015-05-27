using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class ctl_ag2UploadList : System.Web.UI.UserControl
{
	#region objeto Arquivo
	[Serializable]
	public class Arquivo
	{
		private string _arquivo = string.Empty;
		private string _titulo = string.Empty;

		public string arquivo { get { return _arquivo; } set { _arquivo = value; } }
		public string titulo { get { return _titulo; } set { _titulo = value; } }

	}

	private List<Arquivo> _arquivos = new List<Arquivo>();

	#endregion

	#region variaveis e propriedades

	private string _targetFolder = string.Empty;
	public string targetFolder { get { return _targetFolder; } set { _targetFolder = value; } }

	#endregion

	#region eventos de Start

	protected override void OnInit(EventArgs e)
	{
		uplField.TargetFolder = ConfigurationManager.AppSettings["FolderUploadNoticia"];
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		// Seta pasta alvo para colocar os arquivos
		if (!string.IsNullOrEmpty(_targetFolder)) { uplField.TargetFolder = _targetFolder; }
	}

	#endregion

	#region eventos gerais

	protected void cvArquivo_ServerValidate(object source, ServerValidateEventArgs args)
	{
		if (string.IsNullOrEmpty(uplField.FileName))
		{
			args.IsValid = false;
		}
		else
			args.IsValid = true;

	}

	protected void btnAdiciona_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			if (!string.IsNullOrEmpty(uplField.FileName))
			{
				Arquivo objArq = new Arquivo();
				objArq.arquivo = uplField.FileName;
				objArq.titulo = txtTitulo.Text;
				_arquivos.Add(objArq);

				grdLista.DataSource = _arquivos;
				grdLista.DataBind();

				CleanForm();
			}
			else
				cvArquivo.IsValid = false;
		}
	}

	protected void grdLista_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			string strArquivo = grdLista.DataKeys[e.RowIndex].Value.ToString();

			Arquivo objArquivo = new Arquivo();
			objArquivo.arquivo = strArquivo;

			List<Arquivo> listTemp = new List<Arquivo>(_arquivos);
			foreach (Arquivo item in listTemp)
				if (item.arquivo.Equals(objArquivo.arquivo))
					_arquivos.Remove(item);

			grdLista.DataSource = _arquivos;
			grdLista.DataBind();
		}
	}

	#endregion

	#region metodos privados

	/// <summary>
	/// Metodo carregar lista de arquivos no grid e atualizar.
	/// </summary>
	/// <param name="item"></param>
	private void atualizaLista(List<Arquivo> item)
	{
		if (item.Count >= 0)
		{
			grdLista.DataSource = item;
			grdLista.DataBind();
		}
	}

	#endregion

	#region metodos publicos

	/// <summary>
	/// Metodo para preencher a listagem com dados.
	/// </summary>
	/// <param name="item"></param>
	public void LoadList(List<Arquivo> item)
	{
		if (item.Count >= 1)
		{
			_arquivos = item;
			atualizaLista(_arquivos);
		}
	}

	/// <summary>
	/// Metodo para preencher a listagem com 1 item
	/// </summary>
	/// <param name="item"></param>
	public void LoadList(Arquivo item)
	{
		if (!string.IsNullOrEmpty(item.arquivo) && !string.IsNullOrEmpty(item.titulo))
		{
			_arquivos.Add(item);
			atualizaLista(_arquivos);
		}
	}

	/// <summary>
	/// Metodo que retorna a lista de arquivos inseridos.
	/// </summary>
	public List<Arquivo> GetFiles()
	{
		return _arquivos;
	}

	/// <summary>
	/// Metodo para limpar formulário
	/// </summary>
	public void CleanForm()
	{
		uplField.FileName = string.Empty;
		txtTitulo.Text = "";
	}

	/// <summary>
	/// Metodo para limpar listagem
	/// </summary>
	public void CleanGrid()
	{
		_arquivos.Clear();
		atualizaLista(_arquivos);
	}

	#endregion

	#region "ViewState"

	protected override void LoadViewState(object savedState)
	{
		//throw new System.NotImplementedException();
		List<object> totalState = null;
		if (savedState != null)
		{
			totalState = (List<object>)savedState;
			// Load base state.
			base.LoadViewState(totalState[0]);
			// Load extra information specific to this control.
			_arquivos = (List<Arquivo>)totalState[1];
		}
	}

	protected override object SaveViewState()
	{
		List<object> totalState = new List<object>();

		totalState.Clear();
		totalState.Add(base.SaveViewState());
		totalState.Add(_arquivos);
		return totalState;
	}

	#endregion

}

