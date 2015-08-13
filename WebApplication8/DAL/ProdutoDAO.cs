using CrudSimples.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudSimples.DAL
{
    public class ProdutoDAO
    {
        private string connectionstring = ConfigurationManager.ConnectionStrings["banco"].ConnectionString;

        public void Adiciona(Produto produto)
        {
            using (IDbConnection conexao = new SqlConnection(connectionstring))
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "insert into produto (nome, descricao) values (@nome, @descricao)";

                IDbDataParameter paramNome = comando.CreateParameter();
                paramNome.ParameterName = "nome";
                paramNome.Value = produto.Nome;

                IDbDataParameter paramDescricao = comando.CreateParameter();
                paramDescricao.ParameterName = "descricao";
                paramDescricao.Value = produto.Descricao;

                comando.Parameters.Add(paramNome);
                comando.Parameters.Add(paramDescricao);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (IDbConnection conexao = new SqlConnection(connectionstring))
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "select * from produto where id = @id";

                IDbDataParameter paramId = comando.CreateParameter();
                paramId.ParameterName = "id";
                paramId.Value = id;

                comando.Parameters.Add(paramId);

                conexao.Open();
                IDataReader dr = comando.ExecuteReader();

                Produto produto = null;
                if (dr.Read())
                {
                    produto = new Produto();
                    produto.Id = Convert.ToInt32(dr["id"]);
                    produto.Nome = dr["nome"].ToString();
                    produto.Descricao = dr["descricao"].ToString();
                }

                return produto;
            }
        }

        public void Altera(Produto produto)
        {
            using (IDbConnection conexao = new SqlConnection(connectionstring))
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "update produto set nome = @nome, descricao = @descricao where id = @id";

                IDbDataParameter paramId = comando.CreateParameter();
                paramId.ParameterName = "id";
                paramId.Value = produto.Id;

                IDbDataParameter paramNome = comando.CreateParameter();
                paramNome.ParameterName = "nome";
                paramNome.Value = produto.Nome;

                IDbDataParameter paramDescricao = comando.CreateParameter();
                paramDescricao.ParameterName = "descricao";
                paramDescricao.Value = produto.Descricao;

                comando.Parameters.Add(paramId);
                comando.Parameters.Add(paramNome);
                comando.Parameters.Add(paramDescricao);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
        }

        public List<Produto> Lista()
        {
            using (IDbConnection conexao = new SqlConnection(connectionstring))
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "select * from produto";

                conexao.Open();
                IDataReader dr = comando.ExecuteReader();

                List<Produto> lista = new List<Produto>();
                while (dr.Read())
                {
                    Produto produto = new Produto();
                    produto = new Produto();
                    produto.Id = Convert.ToInt32(dr["id"]);
                    produto.Nome = dr["nome"].ToString();
                    produto.Descricao = dr["descricao"].ToString();

                    lista.Add(produto);
                }

                return lista;
            }
        }

        public void Exclui(int id)
        {
            using (IDbConnection conexao = new SqlConnection(connectionstring))
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "delete from produto where id = @id";

                IDbDataParameter paramId = comando.CreateParameter();
                paramId.ParameterName = "id";
                paramId.Value = id;

                comando.Parameters.Add(paramId);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
        }
    }
}