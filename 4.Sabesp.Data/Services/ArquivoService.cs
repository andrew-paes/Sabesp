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
    public class ArquivoService
    {
        private IArquivoDAL _arquivoDAL;

        public ArquivoService()
        {

        }

        public IArquivoDAL ArquivoDAL
        {

            get
            {
                if (_arquivoDAL == null)
                    _arquivoDAL = new ArquivoADO();

                return _arquivoDAL;
            }
            set
            {
                _arquivoDAL = value;
            }
        }

        public int TotalRegistros(ArquivoFH filtro)
        {
            return ArquivoDAL.TotalRegistros(filtro);
        }

        public IList<Arquivo> RetornaTodos()
        {
            return ArquivoDAL.CarregarTodos();
        }

        public IList<Arquivo> RetornaTodos(int registrosPorPagina, int numeroPagina, string ordem, string orientacao, ArquivoFH filtro)
        {
            return ArquivoDAL.CarregarTodos(registrosPorPagina, numeroPagina, ordem, orientacao, filtro);
        }

        //public IList<Arquivo> Carregar(Noticia entidade)
        //{
        //    return ArquivoDAL.Carregar(entidade);
        //}

        public Arquivo Carregar(Arquivo entidade)
        {
            return ArquivoDAL.Carregar(entidade);
        }

        public void Inserir(Arquivo entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ArquivoDAL.Inserir(entidade);

                tScope.Complete();
            }
        }

        public void Atualizar(Arquivo entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ArquivoDAL.Atualizar(entidade);

                tScope.Complete();
            }
        }

        public void Excluir(Arquivo entidade)
        {
            TimeSpan duracaoTransacao = new TimeSpan(0, 2, 0);
            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required, duracaoTransacao))
            {
                ArquivoDAL.Excluir(entidade);

                tScope.Complete();
            }
        }
    }
}