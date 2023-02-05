using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtDescricao.Text, txtQuantidade.Text, txtValorUnitario.Text);
            txtVenda.Clear(); txtDescricao.Clear(); txtQuantidade.Clear(); txtValorUnitario.Clear();
            txtRowCount.Text = dataGridView1.RowCount.ToString();
            int total = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                total += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            txtTotal.Text = total.ToString("C");
            MessageBox.Show("Venda inserida com sucesso!", "Inserir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
            txtRowCount.Text = dataGridView1.RowCount.ToString();
            int total = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                total += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            txtTotal.Text = total.ToString("C");
            MessageBox.Show("Venda removida com sucesso!", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Cells[1].Value = txtQuantidade.Text;
            dataGridView1.CurrentRow.Cells[1].Value = txtQuantidadeBox.Text;
            int total = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                total += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            txtTotal.Text = total.ToString("C");
            MessageBox.Show("Quantidade alterada com sucesso!", "Alteracao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                txtQuantidade.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtQuantidadeBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MessageBox.Show("Pronto para a nova venda!", "Nova Venda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtVenda.Clear(); txtDescricao.Clear(); txtQuantidade.Clear(); txtValorUnitario.Clear();
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MessageBox.Show("Venda cancelada!", "Venda Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtVenda.Clear(); txtDescricao.Clear(); txtQuantidade.Clear(); txtValorUnitario.Clear();
        }
    }
}
