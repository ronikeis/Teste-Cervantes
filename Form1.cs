using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Npgsql;

namespace Aplicação_DEMO
{
    public partial class FrmCadFunc : Form
    {
        
        public FrmCadFunc()
        {
            InitializeComponent();

            // String de conexão para conectar ao PostgreSQL sem especificar o banco de dados
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=roni99";
            // Nome do banco de dados que será criado
            string databaseName = "bd_teste1";

            // Verifica se o banco de dados existe e cria caso não exista
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Verifica se o banco de dados já existe
                using (var cmd = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname = '{databaseName}'", conn))
                {
                    var exists = cmd.ExecuteScalar();
                    if (exists == null)
                    {
                        // Cria o banco de dados se não existir
                        cmd.CommandText = $"CREATE DATABASE {databaseName}";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            string connStringWithDB = $"Host=localhost;Port=5432;Username=postgres;Password=roni99;Database={databaseName}";
            using (var conn = new NpgsqlConnection(connStringWithDB))
            {
                conn.Open();

                // Verifica se a tabela tb_funcionarios já existe
                using (var cmd = new NpgsqlCommand($"SELECT 1 FROM information_schema.tables WHERE table_name = 'tb_funcionarios'", conn))
                {
                    var exists = cmd.ExecuteScalar();
                    if (exists == null)
                    {
                        // Cria a tabela tb_funcionarios
                        cmd.CommandText = @"
                        CREATE TABLE tb_funcionarios (
                            cod_funcionario INT PRIMARY KEY,
                            nome_funcionario VARCHAR(30),
                            dep_funcionario VARCHAR(20)
                        )";
                        cmd.ExecuteNonQuery();
                    }
                }
                // Verifica se a tabela tb_logfuncionarios já existe
                using (var cmd = new NpgsqlCommand($"SELECT 1 FROM information_schema.tables WHERE table_name = 'tb_logfuncionarios'", conn))
                {
                    var exists = cmd.ExecuteScalar();
                 
                    if (exists == null)
                    {
                        // Cria a tabela tb_logfuncionarios
                        cmd.CommandText = @"
                        CREATE TABLE tb_logfuncionarios (
                            tb_logdata DATE,
                            tb_loghora TIME,
                            tb_logtipo VARCHAR(10),
                            tb_logcodfuncionario INTEGER
                        )";
                        cmd.ExecuteNonQuery();
                    }
                }

                // Criação da Função da Trigger
                string createFunction = @"
                CREATE OR REPLACE FUNCTION log_funcionarios() 
                RETURNS TRIGGER AS $$
                BEGIN
                    IF (TG_OP = 'INSERT') THEN
                        INSERT INTO tb_logfuncionarios (tb_logdata, tb_loghora, tb_logtipo, tb_logcodfuncionario)
                        VALUES (CURRENT_DATE, CURRENT_TIME(0), 'INSERIR', NEW.cod_funcionario);
                    ELSIF (TG_OP = 'UPDATE') THEN
                        INSERT INTO tb_logfuncionarios (tb_logdata, tb_loghora, tb_logtipo, tb_logcodfuncionario)
                        VALUES (CURRENT_DATE, CURRENT_TIME(0),'ATUALIZAR', NEW.cod_funcionario);
                    ELSIF (TG_OP = 'DELETE') THEN
                        INSERT INTO tb_logfuncionarios (tb_logdata, tb_loghora, tb_logtipo, tb_logcodfuncionario)
                        VALUES (CURRENT_DATE, CURRENT_TIME(0), 'DELETAR', OLD.cod_funcionario);
                    END IF;
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;";

                using (var cmd = new NpgsqlCommand(createFunction, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Criação da Trigger, se não existir
                string createTrigger = @"
                DO $$
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM pg_trigger WHERE tgname = 'trg_log_funcionarios') THEN
                         CREATE TRIGGER trg_log_funcionarios
                         AFTER INSERT OR UPDATE OR DELETE
                         ON tb_funcionarios
                         FOR EACH ROW
                         EXECUTE FUNCTION log_funcionarios();
                    END IF;
                END
                $$;";

                using (var cmd = new NpgsqlCommand(createTrigger, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
        }
        public static class DbConnection
        {
            // String de conexão definida apenas uma vez
            private static readonly string connString ="Host =localhost;Port=5432;Username=postgres;Password=roni99;Database=bd_teste1";

            // Método para obter a string de conexão
            public static string GetConnectionString()
            {
                return connString;
            }
        }
        private void LoadData()

        {
            using (NpgsqlConnection conn = new NpgsqlConnection(DbConnection.GetConnectionString()))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM tb_funcionarios ORDER BY cod_funcionario";
                    using (var da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.ReadOnly = true;
                        dataGridView1.Columns[0].HeaderText = "Código";
                        dataGridView1.Columns[1].HeaderText = "Nome ";
                        dataGridView1.Columns[2].HeaderText = "Departamento";
                        if (dataGridView1.Rows.Count > 0)
                        {
                            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar os dados: {ex.Message}");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void FrmCadFunc_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                    e.SuppressKeyPress = true;
                    TextBox textBox = sender as TextBox;

                }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string codigoText = textcodigo.Text;
            string nomeText = textnomefunc.Text;
            string departamentoText = textdepartamento.Text;
            string nomeFuncionario = textnomefunc.Text;
            string depFuncionario = textdepartamento.Text;

            if (!int.TryParse(textcodigo.Text, out int codFuncionario) || codFuncionario == 0)
            {
                MessageBox.Show("O código do funcionário deve ser um número válido.");
                textcodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nomeFuncionario) || string.IsNullOrWhiteSpace(depFuncionario))
            {
                MessageBox.Show("Nome e departamento não podem estar vazios.");
                textnomefunc.Focus();
                return;
            }

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM tb_funcionarios WHERE cod_funcionario = @cod";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@cod", int.Parse(textcodigo.Text));
                        object result = checkCmd.ExecuteScalar();
                        int count = 0;
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                        if (count > 0)
                        {
                            MessageBox.Show("Código do funcionário já cadastrado.","Cadastro de Funcionarios");
                            textcodigo.Focus();
                            return;
                        }
                    }

                    // Inserir o novo registro
                    string insertQuery = "INSERT INTO tb_funcionarios (cod_funcionario, nome_funcionario, dep_funcionario) VALUES (@cod, @nome, @dep)";
                    using (NpgsqlCommand insertCmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@cod", codFuncionario);
                        insertCmd.Parameters.AddWithValue("@nome", nomeFuncionario);
                        insertCmd.Parameters.AddWithValue("@dep", depFuncionario);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Funcionário cadastrado com sucesso.","Cadastro de Funcionarios");
                            //Função substituida pela trigger trg_log_funcionarios()
                            //RegistrarLog("Inclusão", codFuncionario); 
                            LimparTela();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar funcionário.");
                        }
                    }
                    LoadData();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Erro de banco de dados: {ex.Message}\n\nDetalhes: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}\n\nDetalhes: {ex.StackTrace}");
            }
        }
          
        private void FrmCadFunc_Click(object sender, EventArgs e)
        {

        }

        private void textcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textnomefunc_TextChanged(object sender, EventArgs e)
        {
            // Salva a posição atual do cursor
            int selectionStart = textnomefunc.SelectionStart;
            int selectionLength = textnomefunc.SelectionLength;

            // Converte a primeira letra de cada palavra para maiúscula

            textnomefunc.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textnomefunc.Text.ToLower());
            

            // Restaura a posição do cursor
            textnomefunc.SelectionStart = selectionStart;
            textnomefunc.SelectionLength = selectionLength;
        }

        private void bt_Alterar_Click(object sender, EventArgs e)
        {

            string nomeFuncionario = textnomefunc.Text;
            string depFuncionario = textdepartamento.Text;

            if (!int.TryParse(textcodigo.Text, out int codFuncionario))
            {
                MessageBox.Show("Por favor, insira um número inteiro válido.");
                textcodigo.Focus(); 
                return;
            }
            if (string.IsNullOrWhiteSpace(nomeFuncionario) || string.IsNullOrWhiteSpace(depFuncionario))
            {
                MessageBox.Show("Nome e departamento não podem estar vazios.");
                textnomefunc.Focus();
                return;
            }

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(DbConnection.GetConnectionString()))
                {
                    conn.Open();
                    string query = "UPDATE tb_funcionarios SET nome_funcionario = @nome, dep_funcionario = @dep WHERE cod_funcionario = @cod";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("cod", codFuncionario);
                        cmd.Parameters.AddWithValue("nome", nomeFuncionario);
                        cmd.Parameters.AddWithValue("dep", depFuncionario);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Funcionário alterado com sucesso!");
                            //Função substituida pela trigger trg_log_funcionarios()
                            //RegistrarLog("Alteração", codFuncionario);
                            LimparTela();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro encontrado para alterar.");
                        }

                    }
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao alterar o funcionário: {ex.Message}\n\nDetalhes: {ex.StackTrace}");
            }

        }

        private void bt_Excluir_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(textcodigo.Text, out int codFuncionario))
            {
                MessageBox.Show("O código do funcionário deve ser um número válido.");
                textcodigo.Focus();
                return;
            }

            // Pedir confirmação ao usuário
            DialogResult result = MessageBox.Show(
                "Tem certeza de que deseja Excluir este funcionário?",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try 
                {
                     using (NpgsqlConnection conn = new NpgsqlConnection(DbConnection.GetConnectionString()))
                     {
                         conn.Open();
                         string query = "DELETE FROM tb_funcionarios WHERE cod_funcionario = @cod";

                         using (var cmd = new NpgsqlCommand(query, conn))
                         {
                             cmd.Parameters.AddWithValue("cod", codFuncionario);

                             int rowsAffected = cmd.ExecuteNonQuery();

                             if (rowsAffected > 0)
                             {
                                 MessageBox.Show("Funcionário excluído com sucesso!","Cadastro de Funcionarios.");
                                //Função substituida pela trigger trg_log_funcionarios()
                                //RegistrarLog("Exclusão", codFuncionario);
                                 LimparTela();
                            }
                             else
                             {
                                 MessageBox.Show("Nenhum registro encontrado para excluir.","Cadastro de Funcionarios.");
                             }

                         }
                         LoadData();
                     }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao deletar o funcionário: {ex.Message}\n\nDetalhes: {ex.StackTrace}");
                }

            }
            else
            {
                MessageBox.Show("Operação de exclusão cancelada.","Cadastro de Funcionarios.");
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bt_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarLog(string tipo, int codFuncionario)
        {

            /* Função substituida pela tregger
            DateTime dataAtual = DateTime.Now;
            TimeSpan horaAtualSemMilissegundos = new TimeSpan(dataAtual.Hour, dataAtual.Minute, dataAtual.Second);

            using (NpgsqlConnection conn = new NpgsqlConnection(DbConnection.GetConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO tb_logfuncionarios (tb_logdata, tb_loghora, tb_logtipo, tb_logcodfuncionario) " +
                               "VALUES (@data, @hora, @tipo, @cod)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@data", dataAtual.Date);
                    cmd.Parameters.AddWithValue("@hora", horaAtualSemMilissegundos);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@cod", codFuncionario);

                    cmd.ExecuteNonQuery();
                }
            }*/
        }

        private void textdepartamento_TextChanged(object sender, EventArgs e)
        {
            // Salva a posição atual do cursor
            int selectionStart = textdepartamento.SelectionStart;
            int selectionLength = textdepartamento.SelectionLength;
            // Converte a primeira letra de cada palavra para maiúscula
            textdepartamento.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(textdepartamento.Text.ToLower());
            // Restaura a posição do cursor
            textdepartamento.SelectionStart = selectionStart;
            textdepartamento.SelectionLength = selectionLength;

        }

        private void textcodigo_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void LimparTela()
        {
            textcodigo.Text = "";
            textnomefunc.Text = "";
            textdepartamento.Text = "";
            textcodigo.Focus();

        }
    }
}
