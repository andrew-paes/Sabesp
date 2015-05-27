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

namespace Sabesp.BO
{
    public class ConteudoTagService
    {
        private IConteudoTagDAL _conteudoTagDAL;

        public ConteudoTagService() { }

        public IConteudoTagDAL ConteudoTagDAL
        {
            get
            {
                if (_conteudoTagDAL == null)
                    _conteudoTagDAL = new ConteudoTagADO();

                return _conteudoTagDAL;
            }
            set
            {
                _conteudoTagDAL = value;
            }
        }

        public int TotalRegistros(ConteudoTagFH filtro)
        {
            return ConteudoTagDAL.TotalRegistros(filtro);
        }

        public IList<ConteudoTag> RetornaTodos()
        {
            return ConteudoTagDAL.CarregarTodos();
        }

        public IList<ConteudoTag> RetornaTodos(int registrosPorPagina, int numeroPagina, string ordemColunas, string ordemSentidos, ConteudoTagFH filtro)
        {
            return ConteudoTagDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordemColunas, ordemSentidos, filtro);
        }

        public ConteudoTag Carregar(ConteudoTag entidade)
        {
            return ConteudoTagDAL.Carregar(entidade);
        }

        public void Inserir(ConteudoTag entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ConteudoTagDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(ConteudoTag entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ConteudoTagDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(ConteudoTag entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ConteudoTagDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}
