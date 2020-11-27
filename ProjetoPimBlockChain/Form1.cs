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
            strSql = "insert into CadastroCliente (Id, Nome, CEP, Endereco, Bairro, Numero, Complemento, Telefone, Email, Estado, Cidade, CarteiraBTC) values (@Id, @Nome, @CEP, @Endereco, @Bairro, @Numero, @Complemento, @Telefone, @Email, @Estado, @Cidade, @CarteiraBTC)";
            sqlConnection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(strSql, sqlConnection);

            command.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            command.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mtxtCep.Text;
            command.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            command.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            command.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
            command.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = txtComplemento.Text;
            command.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mtxtTelefone.Text;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
            command.Parameters.Add("@Estado", SqlDbType.VarChar).Value = txtEstado.Text;
            command.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            command.Parameters.Add("@CarteiraBTC", SqlDbType.VarChar).Value = txtCarteira.Text;

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
            strSql = "select * from CadastroCliente where Id=@Id";
            sqlConnection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(strSql, sqlConnection);

            command.Parameters.Add("@Id", SqlDbType.Int).Value = tstxtBuscar.Text;

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

                txtId.Text = Convert.ToString(dataReader["Id"]);
                txtNome.Text = Convert.ToString(dataReader["Nome"]);
                mtxtCep.Text = Convert.ToString(dataReader["CEP"]);
                txtEndereco.Text = Convert.ToString(dataReader["Endereco"]);
                txtBairro.Text = Convert.ToString(dataReader["Bairro"]);
                txtNumero.Text = Convert.ToString(dataReader["Numero"]);
                txtComplemento.Text = Convert.ToString(dataReader["Complemento"]);
                mtxtTelefone.Text = Convert.ToString(dataReader["Telefone"]);
                txtEmail.Text = Convert.ToString(dataReader["Email"]);
                txtEstado.Text = Convert.ToString(dataReader["Estado"]);
                txtCidade.Text = Convert.ToString(dataReader["Cidade"]);
                txtCarteira.Text = Convert.ToString(dataReader["CarteiraBTC"]);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                sqlConnection.Close();
            }



        }

        private void tsbtnEditar_Click(object sender, EventArgs e) {
            strSql = "update CadastroCliente set Id=@Id, Nome=@Nome, CEP=@CEP, Endereco=@Endereco, Bairro=@Bairro, Numero=@Numero, Complemento=@Complemento, Telefone=@Telefone, Email=@Email, Estado=@Estado, Cidade=@Cidade, CarteiraBTC=@CarteiraBTC where Id=@txtBuscar";
            sqlConnection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(strSql, sqlConnection);

            command.Parameters.Add("@txtBuscar", SqlDbType.Int).Value = tstxtBuscar.Text;

            command.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            command.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            command.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mtxtCep.Text;
            command.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            command.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            command.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txtNumero.Text;
            command.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = txtComplemento.Text;
            command.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mtxtTelefone.Text;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
            command.Parameters.Add("@Estado", SqlDbType.VarChar).Value = txtEstado.Text;
            command.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            command.Parameters.Add("@CarteiraBTC", SqlDbType.VarChar).Value = txtCarteira.Text;

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
                strSql = "delete from CadastroCliente where Id=@Id";
                sqlConnection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(strSql, sqlConnection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = tstxtBuscar.Text;

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
