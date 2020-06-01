using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class PressentacionCondominios : Form
    {
        public PressentacionCondominios()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Search = tbxSearch.Text;
            DataTable dt = NCondominios.Buscar(Search);
            dataGridView1.DataSource = dt;
        }

        public NegocioCondominios NCondominios = new NegocioCondominios();

        void listarPersonas()
        {
            DataTable dt = NCondominios.NegocioListado();
            dataGridView1.DataSource = dt;
        }

        private void PressentacionCondominios_Load(object sender, EventArgs e)
        {
            listarPersonas();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = NCondominios.fillComboBox();
            da.Fill(dataTable);
            cbxApartamento.DataSource = dataTable;
            cbxApartamento.DisplayMember = "Nombre";
            cbxApartamento.ValueMember = "Apto_id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txbName.Text;
            string cedula = txbIdCard.Text;
            int apto = int.Parse(cbxApartamento.SelectedValue.ToString());
            EntidadCondominios entidadCondominios = new EntidadCondominios(name, cedula, apto);
            NCondominios.insert(entidadCondominios);
            listarPersonas();
            txbName.Clear();
            txbIdCard.Clear();
        }

        int indexRow;


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                string idCard = row.Cells[1].Value.ToString();
                NCondominios.deleteFromDatabase(idCard);
                listarPersonas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            txbName.Text = row.Cells[0].Value.ToString();
            txbIdCard.Text = row.Cells[1].Value.ToString();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            string name = txbName.Text;
            string cedula = txbIdCard.Text;
            int apto = int.Parse(cbxApartamento.SelectedValue.ToString());
            string idCard = row.Cells[1].Value.ToString();
            EntidadCondominios entidadCondominios = new EntidadCondominios(name, cedula, apto);
            NCondominios.UpdateFromDatabase(idCard,entidadCondominios);
            listarPersonas();
            txbName.Clear();
            txbIdCard.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = NCondominios.PersonasPorManzana();
            dataGridView1.DataSource = dt;
        }

        private void btnLisEdificio_Click(object sender, EventArgs e)
        {
            DataTable dt = NCondominios.PersonasPorEdificio();
            dataGridView1.DataSource = dt;
        }

        private void btnLisDefault_Click(object sender, EventArgs e)
        {
            listarPersonas();
        }
    }
}
