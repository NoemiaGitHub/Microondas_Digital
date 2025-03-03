using MicroondasDigital;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

public class ConexaoDB
{
    private string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MicroondasDB.mdf");
    private string connectionString;

    public ConexaoDB()
    {
        connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
        CriarBancoSeNecessario();  // Chama o método para criar o banco de dados se necessário
        CriarTabelaSeNecessario(); // Chama o método para criar a tabela se necessário
    }

    // Método para criar o banco de dados, se necessário
    private void CriarBancoSeNecessario()
    {
        // Verifica se o arquivo de banco de dados já existe
        if (!File.Exists(dbPath))
        {
            try
            {
                // Conectar ao SQL Server sem especificar um banco de dados para verificar a existência do banco
                using (var connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True;"))
                {
                    connection.Open();

                    // Verificar se o banco de dados já existe
                    var verificaBancoQuery = "SELECT database_id FROM sys.databases WHERE name = 'MicroondasDB'";
                    using (var command = new SqlCommand(verificaBancoQuery, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            // O banco de dados já existe, então não tentaremos criá-lo novamente
                            MessageBox.Show("O banco de dados já existe.");
                            return;
                        }
                    }

                    // Caso o banco não exista, criá-lo
                    using (var command = new SqlCommand($"CREATE DATABASE [MicroondasDB] ON (NAME = MicroondasDB, FILENAME = '{dbPath}')", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Banco de dados criado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar banco de dados: {ex.Message}");
            }
        }
        else
        {
            // Se o banco já existir, apenas informa ao usuário
            MessageBox.Show("O banco de dados já existe.");
        }
    }

    // Método para criar a tabela 'Programas', se necessário
    private void CriarTabelaSeNecessario()
    {
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Programas' AND xtype='U')
                                CREATE TABLE Programas (
                                    Id INT IDENTITY(1,1) PRIMARY KEY,
                                    Nome NVARCHAR(100) NOT NULL,
                                    Alimento NVARCHAR(100) NOT NULL,
                                    CadPotencia INT NOT NULL,
                                    Caractere NVARCHAR(10) NOT NULL,
                                    CadTempo INT NOT NULL,
                                    InstrucoesII NVARCHAR(MAX) NULL
                                );";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao criar tabela: {ex.Message}");
        }
    }

    // Método para obter todos os programas armazenados no banco de dados
    public List<CadastrarProgramaAquecimento> ObterTodosProgramas()
    {
        var programas = new List<CadastrarProgramaAquecimento>();
        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM Programas";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var programa = new CadastrarProgramaAquecimento
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Alimento = reader.GetString(2),
                            CadPotencia = reader.GetInt32(3),
                            Caractere = reader.GetString(4),
                            CadTempo = reader.GetInt32(5),
                            InstrucoesII = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        };
                        programas.Add(programa);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar programas: {ex.Message}");
            }
        }
        return programas;
    }

    // Método para salvar programas customizados no banco de dados
    public void SalvarProgramaCustomizado(string nome, string alimento, int potencia, string caractere, int tempo, string instrucoes, ComboBox cmbProgramas)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Verifica se o programa já existe no banco
                string verificarQuery = "SELECT COUNT(*) FROM Programas WHERE Nome = @Nome";
                using (SqlCommand verificarCmd = new SqlCommand(verificarQuery, connection))
                {
                    verificarCmd.Parameters.AddWithValue("@Nome", nome);
                    int count = (int)verificarCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Já existe um programa com esse nome. Escolha outro.");
                        return;
                    }
                }

                // Insere o novo programa customizado
                string query = "INSERT INTO Programas (Nome, Alimento, CadPotencia, Caractere, CadTempo, InstrucoesII) " +
                               "VALUES (@Nome, @Alimento, @Potencia, @Caractere, @Tempo, @Instrucoes)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Alimento", alimento);
                    command.Parameters.AddWithValue("@Potencia", potencia);
                    command.Parameters.AddWithValue("@Caractere", caractere);
                    command.Parameters.AddWithValue("@Tempo", tempo);
                    command.Parameters.AddWithValue("@Instrucoes", string.IsNullOrEmpty(instrucoes) ? DBNull.Value : (object)instrucoes);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Programa salvo com sucesso!");

                // Adiciona o nome do programa no ComboBox
                cmbProgramas.Items.Add(nome);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar programa: {ex.Message}");
            }
        }
    }
}