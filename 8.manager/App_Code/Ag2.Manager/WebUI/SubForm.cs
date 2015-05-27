using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Text;

namespace Ag2.Manager.WebUI
{
	/// <summary>
	/// 
	/// </summary>
	public class SubFormEventArgs
	{
		/// <summary>
		/// 
		/// </summary>
		public string[] listIDs;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="plistIDs"></param>
		public SubFormEventArgs(string[] plistIDs) { listIDs = plistIDs; }
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void SubFormEventHandler(object sender, SubFormEventArgs e);

	/// <summary>
	/// 
	/// </summary>
	public enum SubFormTipoConsistencia { Sincrona, Assincrona };

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class clsItemSubForm
	{
		/// <summary>
		/// 
		/// </summary>
		public int ID = 0;

		/// <summary>
		/// 
		/// </summary>
		public clsObjectTable ObjTable;

		/// <summary>
		/// 
		/// </summary>
		public clsItemSubForm()
		{
			ObjTable = new clsObjectTable();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class clsObjectParameter
	{
		/// <summary>
		/// 
		/// </summary>
		private object _ObjValue;

		/// <summary>
		/// 
		/// </summary>
		public object ObjValue
		{
			get { return _ObjValue; }
			set { _ObjValue = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		private string _ObjColumn;

		/// <summary>
		/// 
		/// </summary>
		public string ObjColumn
		{
			get { return _ObjColumn; }
			set { _ObjColumn = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		private string _ObjDataSource;

		/// <summary>
		/// 
		/// </summary>
		public string ObjDataSource
		{
			get { return _ObjDataSource; }
			set { _ObjDataSource = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		private ctrType _ObjType;

		/// <summary>
		/// 
		/// </summary>
		public ctrType ObjType
		{
			get { return _ObjType; }
			set { _ObjType = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public clsObjectParameter() { }
	}

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class clsObjectRow
	{
		/// <summary>
		/// 
		/// </summary>
		private List<clsObjectParameter> _ObjParameters;

		/// <summary>
		/// 
		/// </summary>
		public List<clsObjectParameter> ObjParameters
		{
			get { return _ObjParameters; }
			set { _ObjParameters = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public clsObjectRow()
		{
			_ObjParameters = new List<clsObjectParameter>();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class clsObjectTable
	{
		/// <summary>
		/// 
		/// </summary>
		private string _ObjDataSource;

		/// <summary>
		/// 
		/// </summary>
		public string ObjDataSource
		{
			get { return _ObjDataSource; }
			set { _ObjDataSource = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		private List<clsObjectRow> _ObjRows;

		/// <summary>
		/// 
		/// </summary>
		public List<clsObjectRow> ObjRows
		{
			get { return _ObjRows; }
			set { _ObjRows = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public clsObjectTable()
		{
			_ObjRows = new List<clsObjectRow>();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public enum ctrType
	{
		PK = 0,
		Text = 1,
		OrderColumn = 2
	}

	/// <summary>
	/// 
	/// </summary>
	[ValidationProperty("FileName")]
	[DefaultProperty("Value"), ToolboxData("<{0}:SubForm runat=server></{0}:SubForm>")]
	public class SubForm : System.Web.UI.WebControls.WebControl, INamingContainer
	{
		#region [ PUBLIC VARIABLE ]

		/// <summary>
		/// 
		/// </summary>
		public event SubFormEventHandler Adicionar;

		/// <summary>
		/// 
		/// </summary>
		public event SubFormEventHandler Excluir;

		#endregion

		#region [ PRIVATE VARIABLE ] Componentes da Interface

		/// <summary>
		/// 
		/// </summary>
		private Panel _ListLabel;

		/// <summary>
		/// 
		/// </summary>
		private ImageButton _btnAdicionar;

		/// <summary>
		/// 
		/// </summary>
		private HiddenField _hddAdicionarRetorno;

		/// <summary>
		/// 
		/// </summary>
		private ImageButton _btnExcluir;

		/// <summary>
		/// 
		/// </summary>
		private object _DataSource;

		/// <summary>
		/// 
		/// </summary>
		private string _SqlStringCommand = "";

		/// <summary>
		/// 
		/// </summary>
		private string _DataTextField = "";

		/// <summary>
		/// 
		/// </summary>
		private string _DataValueField = "";

		/// <summary>
		/// 
		/// </summary>
		private string _DataTableIdentifier = "";

		/// <summary>
		/// 
		/// </summary>
		private bool _IsTableOrder = false;

		/// <summary>
		/// 
		/// </summary>
		private string _DataOrderField = "";

		/// <summary>
		/// 
		/// </summary>
		private int _QtdMaxItens = -1;

		/// <summary>
		/// 
		/// </summary>
		private clsObjectTable _tableItens = new clsObjectTable();

		/// <summary>
		/// 
		/// </summary>
		private string[] NomeColunas;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strTable"></param>
		/// <returns></returns>
		public clsObjectTable GetListObjType(string strTable)
		{
			if (HttpContext.Current.Session["_objListItens_" + strTable] == null)
				HttpContext.Current.Session["_objListItens_" + strTable] = new clsObjectTable();

			return (clsObjectTable)HttpContext.Current.Session["_objListItens_" + strTable];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="listData"></param>
		/// <param name="strTable"></param>
		public void SetListObjType(clsObjectTable listData, string strTable)
		{
			HttpContext.Current.Session["_objListItens_" + strTable] = listData;
		}

		#endregion

		#region [ PROPERTIES ]

		/// <summary>
		/// 
		/// </summary>
		public bool IsTableOrder
		{
			get { return _IsTableOrder; }
			set { _IsTableOrder = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string DataOrderField
		{
			get { return _DataOrderField; }
			set { _DataOrderField = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public int QtdMaxItens
		{
			get { return _QtdMaxItens; }
			set { _QtdMaxItens = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string DataTableIdentifier
		{
			get
			{ return _DataTableIdentifier; }
			set
			{ _DataTableIdentifier = GetCurrentID(value); }
		}

		/// <summary>
		/// 
		/// </summary>
		public object DataSource { get { return _DataSource; } set { _DataSource = value; } }

		/// <summary>
		/// 
		/// </summary>
		public string SqlStringCommand { get { return _SqlStringCommand; } set { _SqlStringCommand = value; } }

		/// <summary>
		/// 
		/// </summary>
		public string DataTextField
		{
			get { return _DataTextField; }
			set
			{
				_DataTextField = value;
				string[] strColunas = value.Split(',');
				NomeColunas = new string[strColunas.Length];
				for (int i = 0; i < strColunas.Length; i++)
				{
					string[] strColDef = strColunas[i].Split(':');
					NomeColunas[i] = (strColDef.Length > 1) ? strColDef[1] : "";
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string DataValueField { get { return _DataValueField; } set { _DataValueField = value; } }

		/// <summary>
		/// 
		/// </summary>
		private string _dataKeyValue = "";

		/// <summary>
		/// 
		/// </summary>
		public string DataKeyValue { get { return _dataKeyValue; } set { _dataKeyValue = value; } }

		/// <summary>
		/// 
		/// </summary>
		private string _urlPagina = "~/content/list.aspx";

		/// <summary>
		/// 
		/// </summary>
		public string UrlPagina { get { return _urlPagina; } set { _urlPagina = value; } }

		/// <summary>
		/// 
		/// </summary>
		public clsObjectTable TableItens { get { return _tableItens; } set { _tableItens = value; } }

		/// <summary>
		/// 
		/// </summary>
		private string _ModuloSubForm = "biblioArquivo";

		/// <summary>
		/// 
		/// </summary>
		public string ModuloSubForm
		{
			get { return _ModuloSubForm; }
			set { _ModuloSubForm = (value != "") ? value : _ModuloSubForm; }
		}

		/// <summary>
		/// 
		/// </summary>
		private SubFormTipoConsistencia _TipoConsistencia = SubFormTipoConsistencia.Assincrona;

		/// <summary>
		/// 
		/// </summary>
		public SubFormTipoConsistencia TipoConsistenciaEnum { get { return _TipoConsistencia; } set { _TipoConsistencia = value; } }

		/// <summary>
		/// 
		/// </summary>
		public string TipoConsistencia
		{
			get { return (_TipoConsistencia == SubFormTipoConsistencia.Assincrona) ? "Assincrona" : "Sincrona"; }
			set { _TipoConsistencia = (value.ToUpper() == "ASSINCRONA") ? SubFormTipoConsistencia.Assincrona : (value.ToUpper() == "SINCRONA") ? SubFormTipoConsistencia.Sincrona : SubFormTipoConsistencia.Assincrona; }
		}

		#endregion

		#region [ METHODS ]

		/// <summary>
		/// Constructor
		/// </summary>
		public SubForm()
		{
			_ListLabel = new Panel();
			_btnAdicionar = new ImageButton();
			_hddAdicionarRetorno = new HiddenField();
			_btnExcluir = new ImageButton();

			_ListLabel.ID = "pnlListLabel";
			_btnAdicionar.ID = "btnAdicionar";
			_hddAdicionarRetorno.ID = "btnAdicionarRetorno";
			_btnExcluir.ID = "btnExcluir";

			_btnExcluir.Click += new ImageClickEventHandler(btnExcluir_Click);
			_btnAdicionar.Click += new ImageClickEventHandler(btnAdicionar_Click);

			_btnExcluir.ImageUrl = "~/img/delete.png";
			_btnAdicionar.ImageUrl = "~/img/add.png";
		}

		/// <summary>
		/// Component Initialization
		/// </summary>
		/// <param name="e">Event</param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnAdicionar_Click(object sender, ImageClickEventArgs e)
		{
			SubFormAdicionarAssicrono(new SubFormEventArgs(_hddAdicionarRetorno.Value.Split(',')), this);

			this.CreateChildControls();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
		{
			clsObjectTable objItens = new clsObjectTable();
			List<string> strIdRemoveidos = new List<string>();
			foreach (clsObjectRow objRow in _tableItens.ObjRows)
			{
				foreach (clsObjectParameter objItem in objRow.ObjParameters)
				{
					if (objItem.ObjType == ctrType.PK)
					{
						CheckBox chkLabel = (CheckBox)_ListLabel.FindControl(string.Format("chkItem_{0}", objItem.ObjValue));
						if (chkLabel != null && !chkLabel.Checked)
						{
							objItens.ObjRows.Add(objRow);
						}
						else
						{
							strIdRemoveidos.Add(objItem.ObjValue.ToString());
						}
					}
				}
			}

			_tableItens.ObjRows.Clear();
			_tableItens = objItens;
			SetListObjType(_tableItens, DataTableIdentifier);

			if (Excluir != null) Excluir(this, new SubFormEventArgs(strIdRemoveidos.ToArray()));

			this.CreateChildControls();
		}

		/// <summary>
		/// 
		/// </summary>
		public override void DataBind()
		{
			base.DataBind();

			DataTable datTable = (DataTable)DataSource;

			// INI Ordena Dados
			if (IsTableOrder)
			{
				datTable.DefaultView.Sort = DataOrderField;
				datTable = datTable.DefaultView.ToTable();
			}
			// END Ordena Dados

			_tableItens.ObjRows.Clear();
			string[] strColunas = DataTextField.Split(',');
			clsObjectTable lista = new clsObjectTable();
			int intItensAdicionados = 0;

			// Varre o datatable controlando a quantidade máxima de itens
			for (int i = 0; (i < datTable.Rows.Count); i++)
			{
				clsObjectRow objRow = new clsObjectRow();

				for (int ind = 0; ind < strColunas.Length; ind++)
				{
					for (int j = 0; j < datTable.Columns.Count; j++)
					{
						if (strColunas[ind].Trim().Equals(datTable.Columns[j].ColumnName, StringComparison.InvariantCultureIgnoreCase))
						{
							clsObjectParameter param = new clsObjectParameter();
							param.ObjColumn = datTable.Columns[j].ColumnName;
							param.ObjDataSource = DataTableIdentifier;
							param.ObjType = ctrType.Text;

							if (datTable.Columns[j].DataType.Name.ToLower().Equals("boolean"))
							{
								param.ObjValue = ((bool)datTable.Rows[i][datTable.Columns[j].ColumnName]) ? "Sim" : "Não";
							}
							else
							{
								param.ObjValue = datTable.Rows[i][datTable.Columns[j].ColumnName];
							}

							objRow.ObjParameters.Add(param);
						}
						else if (strColunas[ind].Trim().ToLower().Contains(string.Concat(datTable.Columns[j].ColumnName.ToLower(), ":")))
						{
							clsObjectParameter param = new clsObjectParameter();
							param.ObjColumn = strColunas[ind].Substring(strColunas[ind].IndexOf(":") + 1);
							param.ObjDataSource = DataTableIdentifier;
							param.ObjType = ctrType.Text;

							if (datTable.Columns[j].DataType.Name.ToLower().Equals("boolean"))
							{
								param.ObjValue = ((bool)datTable.Rows[i][datTable.Columns[j].ColumnName]) ? "Sim" : "Não";
							}
							else
							{
								param.ObjValue = datTable.Rows[i][datTable.Columns[j].ColumnName];
							}

							objRow.ObjParameters.Add(param);
						}
					}
				}

				if (IsTableOrder)
				{
					clsObjectParameter paramOrder = new clsObjectParameter();
					paramOrder.ObjColumn = "order_customOrder";
					paramOrder.ObjDataSource = DataTableIdentifier;
					paramOrder.ObjType = ctrType.OrderColumn;
					paramOrder.ObjValue = "";
					objRow.ObjParameters.Add(paramOrder);
				}

				clsObjectParameter paramPK = new clsObjectParameter();
				paramPK.ObjColumn = "order_PK";
				paramPK.ObjDataSource = DataTableIdentifier;
				paramPK.ObjType = ctrType.PK;
				paramPK.ObjValue = datTable.Rows[i][DataValueField].ToString();

				objRow.ObjParameters.Add(paramPK);

				lista.ObjRows.Add(objRow);
				intItensAdicionados++;
			}

			_tableItens = lista;

			SetListObjType(_tableItens, DataTableIdentifier);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strId"></param>
		/// <returns></returns>
		private string GetCurrentID(string strId)
		{
			string chave = strId.Substring(strId.LastIndexOf("_") + 1);
			int valor = 0;
			Int32.TryParse(chave, out valor);

			if (valor > 0)
			{
				return strId;
			}
			else
			{
				if (HttpContext.Current.Request["id"] != null)
				{
					return string.Concat(strId, "_", HttpContext.Current.Request["id"].ToString());
				}
				else
				{
					return strId;
				}
			}
		}

		/// <summary>
		/// Create Child Controls 
		/// </summary>        
		protected override void CreateChildControls()
		{
			this.Controls.Clear();
			this.Controls.Add(MontaInterface());

			base.CreateChildControls();
			this.ChildControlsCreated = true;
		}

		/// <summary>
		/// Render Method
		/// </summary>
		/// <param name="writer"></param>
		protected override void Render(HtmlTextWriter writer)
		{
			base.RenderChildren(writer);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected Control MontaInterface()
		{
			string strParamBotaoAdicionar = "";
			string strParamLinhaGrid = "";
			string strUrlPagina = "";
			string ParamFuncaoRetorno = "";

			if (TipoConsistenciaEnum == SubFormTipoConsistencia.Assincrona)
			{
				strUrlPagina = "~/content/list.aspx";
				ParamFuncaoRetorno = "FuncaoRetorno";
			}

			if (TipoConsistenciaEnum == SubFormTipoConsistencia.Sincrona)
			{
				strUrlPagina = "~/content/edit.aspx?ExibiBotaoList=0";
				ParamFuncaoRetorno = "FuncaoRetornoEdit";
			}

			strParamBotaoAdicionar += "'" + ParamFuncaoRetorno + "', ";
			strParamBotaoAdicionar += "'" + ResolveUrl(strUrlPagina) + "', ";
			strParamBotaoAdicionar += "'" + ModuloSubForm + "', ";
			strParamBotaoAdicionar += "'" + DataKeyValue + "'";

			strParamLinhaGrid += "'FuncaoRetornoEdit', ";
			strParamLinhaGrid += "'" + ResolveUrl("~/content/edit.aspx?ExibiBotaoList=0") + "', ";
			strParamLinhaGrid += "'" + ModuloSubForm + "', ";
			strParamLinhaGrid += "'" + DataKeyValue + "'";

			_ListLabel.Controls.Clear();

			Table tbTable = new Table();
			tbTable.Attributes.Add("ID", "ctl00_holderPrincipal_managerContent");
			tbTable.CssClass = "";
			tbTable.Width = 580;

			if (NomeColunas != null)
			{
				tbTable.Rows.Add(CriaLinhaNomeColunas());
			}

			bool bolAlternateCss = false;

			foreach (clsObjectRow objItem in _tableItens.ObjRows)
			{
				TableRow trLinha = new TableRow();

				TableCell tdColuna1 = new TableCell();

				clsObjectParameter newObj = objItem.ObjParameters.Find(delegate(clsObjectParameter op) { return op.ObjType == ctrType.PK; });

				if (newObj != null)
				{
					if (bolAlternateCss)
					{
						trLinha.CssClass = "cinza";
					}

					bolAlternateCss = !bolAlternateCss;

					trLinha.ID = newObj.ObjValue.ToString();

					CheckBox chkLabel = new CheckBox();
					chkLabel.ID = "chkItem_" + newObj.ObjValue.ToString();

					string strParam2 = "";
					strParam2 += string.Format("'{0}', {1}, {2}", this.ClientID + "_" + _btnAdicionar.ID, strParamLinhaGrid, newObj.ObjValue.ToString());

					tdColuna1.Controls.Add(chkLabel);

					trLinha.Cells.Add(tdColuna1); // 1° Coluna 

					// INI n Colunas
					foreach (clsObjectParameter itemNew in objItem.ObjParameters)
					{
						TableCell tdColunaN = new TableCell();

						LinkButton lnkButton = new LinkButton();

						if (itemNew.ObjType == ctrType.OrderColumn)
						{
							tbTable.CssClass = "TableOrder_" + newObj.ObjDataSource;

							Image imgUp = new Image();
							imgUp.ImageUrl = "~/img/img_seta_ordem_cresc.gif";
							imgUp.ToolTip = "Subir";
							HyperLink lnkUp = new HyperLink();

							lnkUp.NavigateUrl = string.Format("javascript:invokeRowUp(this,{0},'{1}');", newObj.ObjValue, GetCurrentID(newObj.ObjDataSource));
							lnkUp.Controls.Add(imgUp);

							Image imgDown = new Image();
							imgDown.ImageUrl = "~/img/img_seta_ordem_decresc.gif";
							imgDown.ToolTip = "Descer";
							HyperLink lnkDown = new HyperLink();
							lnkDown.NavigateUrl = string.Format("javascript:invokeRowDown(this,{0},'{1}');", newObj.ObjValue, GetCurrentID(newObj.ObjDataSource));
							lnkDown.Controls.Add(imgDown);

							HtmlGenericControl pnlOrder = new HtmlGenericControl("div");
							pnlOrder.Controls.Add(lnkUp);
							Literal ltlSpace = new Literal();
							ltlSpace.Text = "&nbsp;&nbsp;";
							pnlOrder.Controls.Add(ltlSpace);
							pnlOrder.Controls.Add(lnkDown);

							tdColunaN.Controls.Add(pnlOrder);
							tdColunaN.Width = 60;
							trLinha.Cells.Add(tdColunaN);
						}
						else
						{
							if (itemNew.ObjType == ctrType.Text)
							{
								lnkButton.Text = Convert.ToString(itemNew.ObjValue);
								lnkButton.OnClientClick = "return AG2ManagerWebUI_OpenModalUpload(" + strParam2 + ");";
								tdColunaN.Controls.Add(lnkButton);
								trLinha.Cells.Add(tdColunaN);
							}
						}
					}
					// END n Colunas

					tbTable.Rows.Add(trLinha);
				}
			}

			_ListLabel.Controls.Add(tbTable);

			_btnAdicionar.OnClientClick = "return AG2ManagerWebUI_OpenModalUpload(this.id, " + strParamBotaoAdicionar + ", '');";

			_ListLabel.Controls.Add(_btnExcluir);
			_ListLabel.Controls.Add(_btnAdicionar);
			_ListLabel.Controls.Add(_hddAdicionarRetorno);

			return _ListLabel;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private TableRow CriaLinhaNomeColunas()
		{
			TableRow trCabecalho = new TableRow();
			trCabecalho.CssClass = "cabecalho";

			for (int c = 0; c < NomeColunas.Length; c++)
			{
				if (c == 0)
				{
					trCabecalho.Cells.Add(new TableHeaderCell());
					trCabecalho.Cells[0].CssClass = "cabecalhoitem";
					trCabecalho.Cells[0].Text = "&nbsp;";
					trCabecalho.Cells[0].Width = 20;
				}

				TableHeaderCell tdColCab = new TableHeaderCell();
				tdColCab.CssClass = "cabecalhoitem";
				tdColCab.Text = (NomeColunas[c].Trim().Equals("")) ? "&nbsp;" : NomeColunas[c];
				trCabecalho.Cells.Add(tdColCab);
			}

			return trCabecalho;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		/// <param name="objSubForm"></param>
		private void SubFormAdicionarAssicrono(SubFormEventArgs e, SubForm objSubForm)
		{
			int intItensAdicionados = objSubForm.TableItens.ObjRows.Count;
			foreach (string strID in e.listIDs)
			{
				try
				{
					// Controla a quantidade máxima de itens
					if (QtdMaxItens > -1 && intItensAdicionados >= QtdMaxItens)
					{
						return;
					}

					// Verifica se o ID já não está cadastrado
					if (!objSubForm.TableItens.ObjRows.Exists(delegate(clsObjectRow objItem)
																	{
																		return objItem.ObjParameters.Exists(delegate(clsObjectParameter op)
																												{
																													return op.ObjType == ctrType.PK && op.ObjValue.ToString() == strID;
																												}
																											);
																	}
																)
						)
					{
						Database _db = DatabaseFactory.CreateDatabase();
						// Se não encontrou o item, inclui ele na coleção
						DbCommand cmdObj = _db.GetSqlStringCommand((string)objSubForm.SqlStringCommand);
						_db.AddInParameter(cmdObj, objSubForm.DataValueField, DbType.Int32, Convert.ToInt32(strID));

						DataTable datTable = _db.ExecuteDataSet(cmdObj).Tables[0];

						clsItemSubForm objItem = new clsItemSubForm();
						objItem.ID = Convert.ToInt32(strID);

						clsObjectTable listaObjeto = new clsObjectTable();

						clsObjectRow newItem = new clsObjectRow();

						foreach (DataRow dr in datTable.Rows)
						{
							clsObjectParameter objParam = new clsObjectParameter();

							objParam.ObjType = ctrType.Text;
							objParam.ObjValue = dr[objSubForm.DataTextField].ToString();
							objParam.ObjColumn = objSubForm.DataTextField;

							newItem.ObjParameters.Add(objParam);
						}

						clsObjectParameter paramPK = new clsObjectParameter();
						paramPK.ObjColumn = "order_PK";
						paramPK.ObjType = ctrType.PK;
						paramPK.ObjValue = strID;
						newItem.ObjParameters.Add(paramPK);

						objSubForm.TableItens.ObjRows.Add(newItem);
						intItensAdicionados++;
					}
				}
				catch (System.Exception exc) { }
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void ClearItens()
		{
			_tableItens.ObjRows.Clear();
			this.CreateChildControls();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<Int32> BuscaPKs()
		{
			List<Int32> lstInt = new List<int>();
			foreach (clsObjectRow objRow in TableItens.ObjRows)
			{
				// Busca a Chave Primária do registro
				clsObjectParameter objParam = objRow.ObjParameters.Find(delegate(clsObjectParameter oP)
				{
					return oP.ObjType == ctrType.PK;
				});
				if (objParam != null) lstInt.Add(Convert.ToInt32(objParam.ObjValue));
			}
			return lstInt;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="savedState"></param>
		protected override void LoadViewState(object savedState)
		{
			List<object> totalState = null;
			if (savedState != null)
			{
				totalState = (List<object>)savedState;
				// Load base state.
				base.LoadViewState(totalState[0]);
				// Load extra information specific to this control.

				_tableItens = (clsObjectTable)totalState[1];
				DataKeyValue = (string)totalState[2];
				DataTextField = (string)totalState[3];
				DataValueField = (string)totalState[4];
				NomeColunas = (string[])totalState[5];
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override object SaveViewState()
		{
			List<object> totalState = new List<object>();

			totalState.Clear();
			totalState.Add(base.SaveViewState());
			totalState.Add(_tableItens);
			totalState.Add(DataKeyValue);
			totalState.Add(DataTextField);
			totalState.Add(DataValueField);
			totalState.Add(NomeColunas);

			return totalState;
		}

		#endregion
	}
}