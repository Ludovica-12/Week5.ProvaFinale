using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.ProvaFinale.Entites;
using Week5.ProvaFinale.Interfaces;

namespace Week5.ProvaFinale.LisAdoRepositories
{
    class ImpegnoAdoRepository : IDbRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = Calendar;" +
                                          "Integrated Security = true;";

        public void Delete(Impegno imp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Impegno where Id = @id";
                command.Parameters.AddWithValue("@id", imp.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Impegno> Fetch()
        {
            List<Impegno> impegni = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = " select * from Impegno ";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var scadenza = (DateTime)reader["Scadenza"];
                    var importanza = (_Importanza)reader["Importanza"];
                    var flag = (bool)reader["Flag"];
                    var id = (int)reader["Id"];

                    Impegno imp = new Impegno(titolo, descrizione, scadenza, importanza, flag, id);

                    impegni.Add(imp);

                }


            }
            return impegni;
        }

        public void Insert(Impegno imp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Impegno values (@titolo, @descrizione, @scadenza, @importanza, @flag)";
                command.Parameters.AddWithValue("@titolo", imp.Titolo);
                command.Parameters.AddWithValue("@descrizione", imp.Descrizione);
                command.Parameters.AddWithValue("@scadenza", imp.Scadenza);
                command.Parameters.AddWithValue("@importanza", (int)imp.Importanza);
                command.Parameters.AddWithValue("@flag", imp.Flag);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Impegno imp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Impegno set Titolo = @titolo, Descrizione = @descrizione, Scadenza = @scadenza, Importanza = @importanza, Flag = @flag where Id = @id";
                command.Parameters.AddWithValue("@titolo", imp.Titolo);
                command.Parameters.AddWithValue("@descrizione", imp.Descrizione);
                command.Parameters.AddWithValue("@scadenza", imp.Scadenza);
                command.Parameters.AddWithValue("@importanza", (int)imp.Importanza);
                command.Parameters.AddWithValue("@flag", imp.Flag);
                command.Parameters.AddWithValue("@id", imp.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Impegno> GetByFinish()
        {
            List<Impegno> impegni = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where Flag = 1";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var scadenza = (DateTime)reader["Scadenza"];
                    var importanza = (_Importanza)reader["Importanza"];
                    var id = (int)reader["Id"];

                    Impegno imp = new Impegno(titolo, descrizione, scadenza, importanza, true, id);

                    impegni.Add(imp);
                }
            }
            return impegni;
        }

        public List<Impegno> GetByImportanza(_Importanza imp)
        {
            List<Impegno> important = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where Importanza = @imp";
                command.Parameters.AddWithValue("@imp", (int)imp);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var scadenza = (DateTime)reader["Scadenza"];
                    var flag = (bool)reader["Flag"];
                    var id = (int)reader["Id"];

                    Impegno i = new Impegno(titolo, descrizione, scadenza, imp, flag, id);

                    important.Add(i);
                }
            }
            return important;
        }

        public List<Impegno> GetByScadenza(DateTime dt)
        {

            List<Impegno> scad = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where Scadenza = @dt";
                command.Parameters.AddWithValue("@dt", (DateTime)dt);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var importanza = (_Importanza)reader["Importanza"];
                    var flag = (bool)reader["Flag"];
                    var id = (int)reader["Id"];

                    Impegno d = new Impegno(titolo, descrizione, dt, importanza, flag, id);

                    scad.Add(d);
                }
            }
            return scad;
        }
    }
}
