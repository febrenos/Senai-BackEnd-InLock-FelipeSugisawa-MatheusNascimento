using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DEV1401\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=sa@132";

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos (NomeJogos, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@Nome, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.NomeJogos);

                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);

                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);

                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.Estudio.IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE Jogos WHERE IdJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("ID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> ListaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT Jogos.IdJogo, Jogos.NomeJogos, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudio.IdEstudio, Estudio.NomeEstudio FROM Jogos INNER JOIN Estudio ON Estudio.IdEstudio = Jogos.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        JogosDomain Jogo = new JogosDomain
                        {
                            IdJogos = Convert.ToInt32(rdr["IdJogo"]),

                            NomeJogos = rdr["NomeJogos"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = rdr["Valor"].ToString(),

                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                NomeEstudio = rdr["NomeEstudio"].ToString(),

                            }
                        };

                        ListaJogos.Add(Jogo);
                    }
                }
            }
            return ListaJogos;
        }
    }
}
