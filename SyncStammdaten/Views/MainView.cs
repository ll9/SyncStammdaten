using SyncStammdaten.Controllers;
using SyncStammdaten.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncStammdaten
{
    public partial class MainView : Form
    {
        private MainController _controller;

        public MainView()
        {
            InitializeComponent();
            Initialize();
            _controller = new MainController(this);
        }

        public DataTable DataSource { get => dataGridView1.DataSource as DataTable; set => dataGridView1.DataSource = value; }

        private void Initialize()
        {
            dataGridView1.DefaultValuesNeeded += DataGridView1_DefaultValuesNeeded;
        }

        private void DataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.DataGridView.Columns.Contains(nameof(BaseEntity.Id))) {
                e.Row.Cells[nameof(BaseEntity.Id)].Value = Guid.NewGuid().ToString();
            }
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.SaveChanges(DataSource);
        }
    }
}
