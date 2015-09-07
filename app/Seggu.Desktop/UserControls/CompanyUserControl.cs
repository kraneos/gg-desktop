using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Seggu.Services.Interfaces;
using Seggu.Dtos;

namespace Seggu.Desktop.UserControls
{
    public partial class CompanyUserControl : UserControl
    {
        private ICompanyService companyService;
        private IProducerService producerService;
        
        public CompanyUserControl(ICompanyService companyService, IProducerService producerService)
        {
            InitializeComponent();
            this.companyService = companyService;
            this.producerService = producerService;
            this.InitializeIndex();
        }

        private void InitializeIndex()
        {
            // Init Producers
            var producers = this.producerService.GetProducers();
            this.producerCombobox.DataSource = producers.ToList();
            this.producerCombobox.ValueMember = "Id";
            this.producerCombobox.DisplayMember = "Name";

            var companies = this.companyService.GetAllFull().ToList();
            var companyList = new BindingList<CompanyFormDto>(companies);
            this.companyGrid.DataSource = companyList;
            foreach (DataGridViewColumn column in this.companyGrid.Columns)
            {
                if (column.Name != "Name")
                {
                    column.Visible = false;
                }
                else
                {
                    column.Visible = true;
                }
            }
        }
    }
}
