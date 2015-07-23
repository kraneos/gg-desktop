using Seggu.Data;
using Seggu.Desktop.Forms;
using Seggu.Dtos;
using Seggu.Infrastructure;
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
        private ICoverageService coverageService;
        private IEmployeeService employeeService;
        private PolicyFullDto currentPolicy;
        private EndorseFullDto currentEndorse;
        private ICoveragesPackService coveragePackService;
        public Layout MainForm
        {
            get
            {
                return (Layout)FindForm();
            }
        }

        public VidaPolicyUserControl(ICoverageService _covergeService, IEmployeeService _employeeService,
            ICoveragesPackService _coveragePackService)
        {
            InitializeComponent();
            coverageService = _covergeService;
            employeeService = _employeeService;
            coveragePackService = _coveragePackService;
        }

        public void InitializeIndex(string riskId)
        {
            currentPolicy = MainForm.currentPolicy;
            var riskGuid = new Guid(riskId);
            
            var table = BuildEmployeeTable();
            grdEmployees.DataSource = table;
            grdEmployees.Columns["Id"].Visible = false;
            var coberturas = SegguContainer.Instance.Risks.First(x => x.Id == riskGuid)
                .CoveragesPacks
                .OrderBy(r => r.Name)
                .ToList();
            cmbCoberturas.DataSource = coberturas;
            cmbCoberturas.DisplayMember = "Name";
            cmbCoberturas.ValueMember = "Id";
                if (currentPolicy != null && currentPolicy.Employees != null && currentPolicy.Employees.Any())
                {
                    var coverages = currentPolicy.Employees.SelectMany(x => x.Coverages ?? new List<CoverageDto>());
                    if (coverages.Any())
                        cmbCoberturas.SelectedValue = new Guid(coveragePackService.GetPackIdByCoverageId(coverages.First().Id, riskId));
                }
                else
                {
                    currentEndorse = MainForm.currentEndorse;
                    if (currentEndorse != null && currentEndorse.Employees != null && currentEndorse.Employees.Any())
                    {
                        var coverages = currentEndorse.Employees.SelectMany(x => x.Coverages ?? new List<CoverageDto>());
                        if (coverages.Any())
                            cmbCoberturas.SelectedValue = new Guid(coveragePackService.GetPackIdByCoverageId(coverages.First().Id, riskId));
                    }

                }
        }
            private DataTable BuildEmployeeTable()
            {
                var table = new DataTable();
                table.Columns.Add("Id", typeof(string));
                table.Columns.Add("Apellido", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("DNI", typeof(string));
                table.Columns.Add("CUIT", typeof(string));
                table.Columns.Add("Nacimiento", typeof(DateTime));
                table.Columns.Add("Suma Asegurada", typeof(decimal));

                if (currentEndorse == null || currentEndorse.Employees.Count() == 0)
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
            var coverages = coverageService.GetByPackId(((Guid)cmbCoberturas.SelectedValue).ToString());
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                var employee = new EmployeeDto();
                employee.Id = row["Id"] is DBNull ? string.Empty : (string)row["Id"];
                employee.Apellido = row["Apellido"] is DBNull ? string.Empty : (string)row["Apellido"];
                employee.Nombre = row["Nombre"] is DBNull ? string.Empty : (string)row["Nombre"];
                employee.DNI = row["DNI"] is DBNull ? "Sin DNI" : (string)row["DNI"];
                employee.CUIT = row["CUIT"] is DBNull ? "Sin CUIT" : (string)row["CUIT"];
                employee.Fecha_Nacimiento = row["Nacimiento"] is DBNull ? DateTime.MinValue : (DateTime)row["Nacimiento"];
                employee.Suma = row["Suma Asegurada"] is DBNull ? 0M : (decimal)row["Suma Asegurada"];
                employee.Coverages = coverages;
                employees.Add(employee);
            }
            return employees;
        }
    }
}
