using CrudSimples.DAL;
using CrudSimples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudSimples.BLL
{
    public class BLLProduto
    {

        public void Adiciona(Produto produto)
        {
            //aqui ficaria alguma validação de regra de negócio
            ProdutoDAO dao = new ProdutoDAO();

            dao.Adiciona(produto);
        }

        public Produto BuscaPorId(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();

            Produto produto = dao.BuscaPorId(id);

            return produto;
        }

        public void Altera(Produto produto)
        {
            //aqui ficaria alguma validação de regra de negócio
            ProdutoDAO dao = new ProdutoDAO();

            dao.Altera(produto);
        }

        public List<Produto> Lista()
        {
            ProdutoDAO dao = new ProdutoDAO();

            List<Produto> lista = dao.Lista();

            return lista;
        }

        public void Exclui(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();

            dao.Exclui(id);
        }
    }
}