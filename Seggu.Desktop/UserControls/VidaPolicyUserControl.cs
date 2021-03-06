﻿using Seggu.Desktop.Forms;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Seggu.Desktop.UserControls
{
    public partial class VidaPolicyUserControl : UserControl
    {
        private readonly ICoverageService coverageService;
        private IEmployeeService employeeService;
        private PolicyFullDto currentPolicy;
        private EndorseFullDto currentEndorse;
        private readonly ICoveragesPackService coveragePackService;
        public Layout MainForm => (Layout)FindForm();

        public VidaPolicyUserControl( ICoverageService covergeService, IEmployeeService _employeeService,
            ICoveragesPackService _coveragePackService)
        {
            InitializeComponent();
            coverageService = covergeService;
            employeeService = _employeeService;
            coveragePackService = _coveragePackService;
        }

        public void PopulatePolicyVida(int riskId)
        {
            LoadCmbCoverages(riskId);

            currentPolicy = MainForm.currentPolicy;
            //if (MainForm.currentPolicy.Employees == null || !MainForm.currentPolicy.Employees.Any()) return;

            LoadEmployeeGrid();
        }
        public void PopulateEndorseVida(int riskId)
        {
            LoadCmbCoverages(riskId);

            currentEndorse = MainForm.currentEndorse;
            currentPolicy = MainForm.currentPolicy;
            //if (MainForm.currentEndorse.Employees == null || !MainForm.currentEndorse.Employees.Any()) return;

            LoadEmployeeGrid();
        }
        private void LoadCmbCoverages(int riskTypeId)
        {
            var coberturas = coveragePackService.GetAllByRiskId(riskTypeId).ToList();
            cmbCoberturas.DataSource = coberturas;
            cmbCoberturas.DisplayMember = "Name";
            cmbCoberturas.ValueMember = "Id";
            if (currentPolicy?.Employees != null && currentPolicy.Employees.Any())
            {
                var coverages = currentPolicy.Employees.SelectMany(x => x.Coverages ?? new List<CoverageDto>());
                if (coverages.Any())
                    cmbCoberturas.SelectedValue = coveragePackService.GetPackIdByCoverageId(coverages.First().Id, riskTypeId);
            }
            else
            {
                currentEndorse = MainForm.currentEndorse;
                if (currentEndorse?.Employees != null && currentEndorse.Employees.Any())
                {
                    var coverages = currentEndorse.Employees.SelectMany(x => x.Coverages ?? new List<CoverageDto>());
                    if (coverages.Any())
                        cmbCoberturas.SelectedValue = coveragePackService.GetPackIdByCoverageId(coverages.First().Id, riskTypeId);
                }
            }
        }
        private void LoadEmployeeGrid()
        {
            var employeeTable = BuildEmployeeTable();
            grdEmployees.DataSource = employeeTable;
            grdEmployees.Columns["Id"].Visible = false;
        }
        private DataTable BuildEmployeeTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Apellido", typeof(string));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("DNI", typeof(string));
            table.Columns.Add("CUIT", typeof(string));
            table.Columns.Add("Nacimiento", typeof(DateTime));
            table.Columns.Add("Suma Asegurada", typeof(decimal));

            if (currentEndorse == null || !currentEndorse.Employees.Any())
            {
                foreach (var employee in currentPolicy.Employees ?? new List<EmployeeDto>())
                {
                    var row = table.NewRow();
                    row["Id"] = employee.Id;
                    row["Apellido"] = employee.Apellido;
                    row["Nombre"] = employee.Nombre;
                    row["DNI"] = employee.DNI;
                    row["CUIT"] = employee.CUIT;
                    row["Nacimiento"] = employee.Fecha_Nacimiento;
                    row["Suma Asegurada"] = employee.Suma;
                    table.Rows.Add(row);
                }
            }
            else
            {
                foreach (var employee in currentEndorse.Employees ?? new List<EmployeeDto>())
                {
                    var row = table.NewRow();
                    row["Id"] = employee.Id;
                    row["Apellido"] = employee.Apellido;
                    row["Nombre"] = employee.Nombre;
                    row["DNI"] = employee.DNI;
                    row["CUIT"] = employee.CUIT;
                    row["Nacimiento"] = employee.Fecha_Nacimiento;
                    row["Suma Asegurada"] = employee.Suma;
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var employees = new List<EmployeeDto>();
            var table = (DataTable)grdEmployees.DataSource;
            var coverages = coverageService.GetByPackId(((int)cmbCoberturas.SelectedValue));
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                var employee = new EmployeeDto
                {
                    Id = row["Id"] is DBNull ? default(int) : (int)row["Id"],
                    Apellido = row["Apellido"] is DBNull ? string.Empty : (string)row["Apellido"],
                    Nombre = row["Nombre"] is DBNull ? string.Empty : (string)row["Nombre"],
                    DNI = row["DNI"] is DBNull ? "Sin DNI" : (string)row["DNI"],
                    CUIT = row["CUIT"] is DBNull ? "Sin CUIT" : (string)row["CUIT"],
                    Fecha_Nacimiento = row["Nacimiento"] is DBNull ? DateTime.MinValue : (DateTime)row["Nacimiento"],
                    Suma = row["Suma Asegurada"] is DBNull ? 0M : (decimal)row["Suma Asegurada"],
                    Coverages = coverages
                };
                employees.Add(employee);
            }
            return employees;
        }
        #region validaciones
        private void grdEmployees_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var ctrl = (DataGridView)sender;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !ctrl.Rows[e.RowIndex].IsNewRow)
            {
                ResetCell(ctrl, e.RowIndex, e.ColumnIndex);
                if (e.ColumnIndex == 3)
                {
                    var i = 0L;
                    if (!long.TryParse(e.FormattedValue.ToString(), out i))
                    {
                        //e.Cancel = true;
                        SetError(ctrl, e.RowIndex, e.ColumnIndex, "El valor debe ser un DNI valido.", e);
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    var i = 0L;
                    if (!long.TryParse(e.FormattedValue.ToString(), out i))
                    {
                        //e.Cancel = true;
                        SetError(ctrl, e.RowIndex, e.ColumnIndex, "El valor debe ser un CUIT valido.", e);
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    var i = DateTime.Now;
                    if (!DateTime.TryParse(e.FormattedValue.ToString(), out i))
                    {
                        //e.Cancel = true;
                        SetError(ctrl, e.RowIndex, e.ColumnIndex, "El valor debe ser una fecha valida.", e);
                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    var i = 0M;
                    if (!decimal.TryParse(e.FormattedValue.ToString(), out i))
                    {
                        //e.Cancel = true;
                        SetError(ctrl, e.RowIndex, e.ColumnIndex, "El valor debe ser un monto valido.", e);
                    }
                }
            }
        }
        private void ResetCell(DataGridView sender, int rowIndex, int columnIndex)
        {
            //var cell = sender.Rows[rowIndex].Cells[columnIndex];
            //cell.Style.ForeColor = Color.Black;
            //cell.ToolTipText = string.Empty;
        }
        private void SetError(DataGridView sender, int rowIndex, int columnIndex, string errorMsg, DataGridViewCellValidatingEventArgs e)
        {
            //var cell = sender.Rows[rowIndex].Cells[columnIndex];
            //cell.Style.ForeColor = Color.Red;
            //cell.ToolTipText = errorMsg;
            //cell.ErrorText = errorMsg;
            MessageBox.Show(errorMsg);
            e.Cancel = true;
        }
        private void grdEmployees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.Clear();
            int a = grdEmployees.RowCount;
            int i = 0;
            int j = 0;

            if(a<=1)
            {
                e.Cancel = true;
                errorProvider1.SetError(grdEmployees, "Al menos un empleado debe ser ingresado");

            }
            for (i=0; i<=a-2; i++)
                {
                    for(j = 1; j<=6; j++)
                    {
                        if(grdEmployees[j, i].Value.ToString() == string.Empty)
                        {
                            e.Cancel = true;
                            errorProvider1.SetError(grdEmployees, "Todos los campos son obligatorios");
                        }

                    }
                }
            }  
        #endregion
    }
}
