using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sabesp.DAL;
using Sabesp.DAL.ADO;
using System.Transactions;
using Sabesp.FilterHelper;
using Sabesp.BO;

namespace Sabesp.Data.Services
{
	public class HorarioPreferenciaService
	{
		private IHorarioPreferenciaDAL _horarioPreferenciaDAL;

		public HorarioPreferenciaService()
		{

		}

		public IHorarioPreferenciaDAL HorarioPreferenciaDAL
		{
			get
			{
				if (_horarioPreferenciaDAL == null)
					_horarioPreferenciaDAL = new HorarioPreferenciaADO();

				return _horarioPreferenciaDAL;
			}
			set
			{
				_horarioPreferenciaDAL = value;
			}
		}

		public int TotalRegistros(HorarioPreferenciaFH filtro)
		{
			return HorarioPreferenciaDAL.TotalRegistros(filtro);
		}

		public IList<HorarioPreferencia> RetornaTodos()
		{
			return HorarioPreferenciaDAL.CarregarTodos();
		}

		public IList<HorarioPreferencia> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			return HorarioPreferenciaDAL.CarregarTodos(registrosPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
		}

		public HorarioPreferencia Carregar(HorarioPreferencia entidade)
		{
			return HorarioPreferenciaDAL.Carregar(entidade);
		}

		public void Inserir(HorarioPreferencia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				HorarioPreferenciaDAL.Inserir(entidade);

				tScope.Complete();
			}
		}

		public void Atualizar(HorarioPreferencia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				HorarioPreferenciaDAL.Atualizar(entidade);

				tScope.Complete();
			}
		}

		public void Excluir(HorarioPreferencia entidade)
		{
			TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
			using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
			{
				HorarioPreferenciaDAL.Excluir(entidade);

				tScope.Complete();
			}
		}
	}
}