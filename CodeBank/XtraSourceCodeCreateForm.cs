﻿using BLL.Service;
using DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DAL.Entities;

namespace CodeBank
{
    public partial class XtraSourceCodeCreateForm : DevExpress.XtraEditors.XtraForm
    {
        private AppDbContext context = new AppDbContext();
        private CategoryService categoryService = new CategoryService();
        private SourceCodeService SourceCodeService = new SourceCodeService();
        private SourceCode sourceCode;

        public XtraSourceCodeCreateForm(SourceCode sourceCode)
        {
            InitializeComponent();
            this.sourceCode = sourceCode;
        }

        public XtraSourceCodeCreateForm()
        {
            InitializeComponent();
            KategoriListele();
        }

        public void KategoriListele()
        {
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            DAL.AppDbContext dbContext = new DAL.AppDbContext();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.Categories.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                categoriesBindingSource.DataSource = dbContext.Categories.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            sourceCode = new SourceCode();
            if (sourceCode.CategoryId == null)
            {
                MessageBox.Show("Lütfen kategori seçiniz.");
            }
            else
            {
                sourceCode.CategoryId = (int)listBoxControl1.SelectedValue;
            }
            sourceCode.Title = txtTitle.Text;
            sourceCode.Content = txtContent.Text;
            if (ToggleIsArchived.IsOn == true)
            {
                sourceCode.isArchived = true;
            }
            else
            {
                sourceCode.isArchived = false;
            }
            if (SourceCodeService.AddOrUpdate(context, sourceCode))
            {
                SourceCodeService.Save(context);
                MessageBox.Show("Kaynak kod kaydı başarılı.");
                XtraSourceCodesForm form = (XtraSourceCodesForm)Application.OpenForms["XtraSourceCodesForm"];
                foreach (Form FORM in Application.OpenForms)
                {
                    if (FORM.GetType() == typeof(XtraSourceCodesForm))
                    {
                        form.KaynakKodListele();
                    }
                }
            }

        }
    }
}