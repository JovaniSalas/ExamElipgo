using ShoeShopWF.Api;
using ShoeShopWF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoeShopWF
{
    public partial class frmListado : Form
    {
        readonly Repository repository = new Repository();
        public frmListado()
        {
            InitializeComponent();
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            InitializeData();
        }

        private void InitializeData()
        {
            btnRemoveFilter.Visible = false;
            GetStoresData();
            GetArticlesData();
        }
        private void GetStoresData()
        {
            cbbStores.DisplayMember = "Text";
            cbbStores.ValueMember = "Value";
            cbbStores.DataSource = new BindingSource(repository.GetStores(), null);
            lblTotalStore.Text = (cbbStores.Items.Count == 2) ? cbbStores.Items.Count - 1 + " Store" : cbbStores.Items.Count - 1 + " Stores";
        }
        private void GetArticlesData()
        {
            var bindingListArticles = new BindingList<ArticleModel>(repository.GetArticles());
            AddArticlesDataSouce(bindingListArticles);
        }

        private void cbbStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dato = (ItemModel)cbbStores.SelectedItem;
            if (dato.Value != "0")
            {
                btnRemoveFilter.Visible = true;
                var bindingListArticles = new BindingList<ArticleModel>(repository.GetArticlesForStore(dato.Value));
                AddArticlesDataSouce(bindingListArticles);
                lblFilterAplicated.Text = "With filter";
            }
        }

        private void AddArticlesDataSouce(BindingList<ArticleModel> bindingListArticles)
        {
            var source = new BindingSource(bindingListArticles, null);
            dgvArticles.DataSource = source;
            lblTotalRecords.Text = (dgvArticles.Rows.Count == 1) ? dgvArticles.Rows.Count + " Record" : dgvArticles.Rows.Count + " Recors";
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            lblFilterAplicated.Text = "Unfiltered";
            InitializeData();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You sure want to close the system?", "¡Warning...!",
                MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
