using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjetoPimBlockChain {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        SqlConnection sqlConnection = null;
        private string strConnection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Mikhael Melhem;Data Source=MIKA\SQLEXPRESS";
        private string strSql = string.Empty;


        private void tsbtnSalvar_Click(object sender, EventArgs e) {
            strSql = "insert into dbo.userRegister (nome, cep, endereco, bairro, numero, complemento, telefone, email, estado, cidade, carteiraBTC) values (@nome, @cep, @endereco, @bairro, @numero, @complemento, @telefone, @email, @estado, @cidade, @carteiraBTC)";
            sqlConnection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(strSql, sqlConnection);

            /*command.Parameters.Add("@id", SqlDbType.Int).Value = txtId.Text;*/
            command.Parameters.Add("@nome", SqlDbType.VarChar).Value = txtNome.Text;
            command.Parameters.Add("@cep", SqlDbType.VarChar).Value = mtxtCep.Text;
            command.Parameters.Add("@endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            command.Parameters.Add("@bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            command.Parameters.Add("@numero", SqlDbType.VarChar).Value = txtNumero.Text;
            command.Parameters.Add("@complemento", SqlDbType.VarChar).Value = txtComplemento.Text;
            command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = mtxtTelefone.Text;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
            command.Parameters.Add("@estado", SqlDbType.VarChar).Value = txtEstado.Text;
            command.Parameters.Add("@cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            command.Parameters.Add("@carteiraBTC", SqlDbType.VarChar).Value = txtCarteira.Text;

            try {
                sqlConnection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Cadastro Concluído!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlConnection.Close();
            }

            //txt bool
            txtId.Enabled = true;
            txtNome.Enabled = true;
            mtxtCep.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            mtxtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtEstado.Enabled = true;
            txtCidade.Enabled = true;
            txtCarteira.Enabled = true;
            //valor da caixa de texto
            tstxtBuscar.Text = "";
            txtId.Text = "";
            txtNome.Text = "";
            mtxtCep.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            mtxtTelefone.Text = "";
            txtEmail.Text = "";
            txtEstado.Text = "";
            txtCidade.Text = "";
            txtCarteira.Text = "";



        }

        private void tsbtnPesquisar_Click(object sender, EventArgs e) {
            strSql = "select * from dbo.userRegister where id=@id";
            sqlConnection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(strSql, sqlConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = tstxtBuscar.Text;

            try {
                if (tstxtBuscar.Text == string.Empty) {
                    throw new Exception("É necessário um ID válido para a pesquisa!");
                }
                sqlConnection.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == false) {
                    throw new Exception("Este ID não esta cadastrado no sistema!");
                }

                txtId.Text = Convert.ToString(dataReader["id"]);
                txtNome.Text = Convert.ToString(dataReader["nome"]);
                mtxtCep.Text = Convert.ToString(dataReader["cep"]);
                txtEndereco.Text = Convert.ToString(dataReader["endereco"]);
                txtBairro.Text = Convert.ToString(dataReader["bairro"]);
                txtNumero.Text = Convert.ToString(dataReader["numero"]);
                txtComplemento.Text = Convert.ToString(dataReader["complemento"]);
                mtxtTelefone.Text = Convert.ToString(dataReader["telefone"]);
                txtEmail.Text = Convert.ToString(dataReader["email"]);
                txtEstado.Text = Convert.ToString(dataReader["estado"]);
                txtCidade.Text = Convert.ToString(dataReader["cidade"]);
                txtCarteira.Text = Convert.ToString(dataReader["carteiraBTC"]);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlConnection.Close();
            }
            txtId.Enabled = false;
            txtId.Text = "";

        }

        private void tsbtnEditar_Click(object sender, EventArgs e) {
            strSql = "update dbo.userRegister set nome=@nome, cep=@cep, endereco=@endereco, bairro=@bairro, numero=@numero, complemento=@complemento, telefone=@telefone, email=@email, estado=@estado, cidade=@cidade, carteiraBTC=@carteiraBTC where id=@txtBuscar";
            sqlConnection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(strSql, sqlConnection);

            command.Parameters.Add("@txtBuscar", SqlDbType.Int).Value = tstxtBuscar.Text;

            //command.Parameters.Add("@id", SqlDbType.Int).Value = txtId.Text;
            command.Parameters.Add("@nome", SqlDbType.VarChar).Value = txtNome.Text;
            command.Parameters.Add("@cep", SqlDbType.VarChar).Value = mtxtCep.Text;
            command.Parameters.Add("@endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            command.Parameters.Add("@bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            command.Parameters.Add("@numero", SqlDbType.VarChar).Value = txtNumero.Text;
            command.Parameters.Add("@complemento", SqlDbType.VarChar).Value = txtComplemento.Text;
            command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = mtxtTelefone.Text;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
            command.Parameters.Add("@estado", SqlDbType.VarChar).Value = txtEstado.Text;
            command.Parameters.Add("@cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            command.Parameters.Add("@carteiraBTC", SqlDbType.VarChar).Value = txtCarteira.Text;

            try {
                sqlConnection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Cadastro Atualizado!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlConnection.Close();
            }

            //valor da caixa de texto
            tstxtBuscar.Text = "";
            txtId.Text = "";
            txtNome.Text = "";
            mtxtCep.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            mtxtTelefone.Text = "";
            txtEmail.Text = "";
            txtEstado.Text = "";
            txtCidade.Text = "";
            txtCarteira.Text = "";

        }

        private void tsbtnDeletar_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Deseja excluir definitivamente este cadastro?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                MessageBox.Show("Operação Cancelada!");
            else {
                strSql = "delete from dbo.userRegister where id=@id";
                sqlConnection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(strSql, sqlConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = tstxtBuscar.Text;

                try {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Excluido Com Sucesso!");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    sqlConnection.Close();
                }

                //txt bool
                txtId.Enabled = true;
                txtNome.Enabled = true;
                mtxtCep.Enabled = true;
                txtEndereco.Enabled = true;
                txtBairro.Enabled = true;
                txtNumero.Enabled = true;
                txtComplemento.Enabled = true;
                mtxtTelefone.Enabled = true;
                txtEmail.Enabled = true;
                txtEstado.Enabled = true;
                txtCidade.Enabled = true;
                txtCarteira.Enabled = true;
                //valor da caixa de texto
                tstxtBuscar.Text = "";
                txtId.Text = "";
                txtNome.Text = "";
                mtxtCep.Text = "";
                txtEndereco.Text = "";
                txtBairro.Text = "";
                txtNumero.Text = "";
                txtComplemento.Text = "";
                mtxtTelefone.Text = "";
                txtEmail.Text = "";
                txtEstado.Text = "";
                txtCidade.Text = "";
                txtCarteira.Text = "";

            }
        }

        private void tsbtnNovo_Click(object sender, EventArgs e) {

            //
            txtId.Enabled = false;
            txtNome.Enabled = true;
            mtxtCep.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            mtxtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtEstado.Enabled = true;
            txtCidade.Enabled = true;
            txtCarteira.Enabled = true;
            //
            tstxtBuscar.Text = "";
            txtId.Text = "";
            txtNome.Text = "";
            mtxtCep.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            mtxtTelefone.Text = "";
            txtEmail.Text = "";
            txtEstado.Text = "";
            txtCidade.Text = "";
            txtCarteira.Text = "";
        }

        private void tsbtnCancelar_Click(object sender, EventArgs e) {

            txtId.Enabled = false;
            txtId.Text = "";
            //valor da caixa de texto
            tstxtBuscar.Text = "";
            txtId.Text = "";
            txtNome.Text = "";
            mtxtCep.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            mtxtTelefone.Text = "";
            txtEmail.Text = "";
            txtEstado.Text = "";
            txtCidade.Text = "";
            txtCarteira.Text = "";
        }
    }
}
