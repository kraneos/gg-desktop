using Seggu.Desktop.Forms;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Seggu.Desktop.UserControls
{
    public partial class SiniestrosUserControl : UserControl
    {
        private ICasualtyService casualtyService;
        private ICasualtyTypeService casualtyTypeService;
        private int policyId;
        public Layout MainForm
        {
            get
            {
                return (Layout)this.FindForm();
            }
        }


        public SiniestrosUserControl(ICasualtyService casualtyService, ICasualtyTypeService casualtyTypeService
            , int policyId)
        {
            InitializeComponent();
            this.casualtyService = casualtyService;
            this.casualtyTypeService = casualtyTypeService;
            this.policyId = policyId;
            TabPage page2 = tctrlSiniestrosDatos.TabPages[1];
            page2.Enabled = false;
        }



        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                try
                {
                    CasualtyDto casualty = GetFormInfo();
                    //var injuries = (List<FeeDto>)this.grdInjuries.DataSource;
                    //CasualtyDto submitCasualtyFormDto = this.ConvertToSubmitForm(casualty, injuries);
                    casualtyService.Save(casualty);
                    MessageBox.Show("Guardó OK, refresque los datos apretando el botón de Pólizas");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Una excepcion ha llegado a la aplicacion. Por favor copiar el siguiente mensaje y consultar al equipo tecnico.\n" +
                        ex.Message +
                        "\n" +
                        ex.StackTrace +
                        (ex.InnerException == null ? string.Empty : "\nInner Exception: " +
                        ex.InnerException.Message +
                        "\nStackTrace: " +
                        ex.InnerException.StackTrace),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Datos obligatorios sin completar", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private CasualtyDto GetFormInfo()
        {
            throw new NotImplementedException();
        }

        private bool ValidateControls()
        {
            bool ok = true;
            errorProvider1.Clear();
            foreach (TabPage tabPage in this.tctrlSiniestrosDatos.TabPages)
            {
                foreach (Control c in tabPage.Controls)
                {
                    if (c is TextBox)
                    {
                        if (c == txtDescripcionSiniestro || c == txtIndemnizacionEst || c == txtIndemnizacionDef)
                            if (c.Text == string.Empty)
                            {
                                errorProvider1.SetError(c, "Campo vacio");
                                ok = false;
                            }
                    }
                    else if (c is ComboBox)
                    {
                        if (c == cmbType || c == cmbNumber)
                            if ((c as ComboBox).SelectedIndex == -1)
                            {
                                errorProvider1.SetError(c, "Debe seleccionar un elemento");
                                ok = false;
                            }
                    }
                }
            }
            return ok;
        }

        private void EmptyControlsDetalleTab()
        {
            foreach (TabPage tabPage in this.tctrlSiniestrosDatos.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is TextBox)
                        control.Text = string.Empty;
                    //else if (control is ComboBox)
                    //    (control as ComboBox).SelectedIndex = -1;
                    else if (control is CheckBox)
                        (control as CheckBox).Checked = false;
                    else if (control == lblId)
                        control.Text = string.Empty;
                    else if (control is DateTimePicker)
                    {
                        (control as DateTimePicker).Value = DateTime.Today;
                        (control as DateTimePicker).Checked = false;
                    }
                    else if (control is GroupBox)
                    {
                        foreach (Control groupBoxControl in control.Controls)
                        {
                            if (groupBoxControl is TextBox)
                                groupBoxControl.Text = string.Empty;
                            else if (groupBoxControl is ComboBox)
                                (groupBoxControl as ComboBox).SelectedIndex = -1;
                            else if (groupBoxControl is CheckBox)
                                (groupBoxControl as CheckBox).Checked = false;
                            else if (groupBoxControl is DateTimePicker)
                            {
                                (groupBoxControl as DateTimePicker).Value = DateTime.Today;
                                (groupBoxControl as DateTimePicker).Checked = false;
                            }
                        }
                    }
                }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ////resultado es una variable que captura la decion del usuario en el messagebox.
            //DialogResult resultado = MessageBox.Show("¿Seguro decea eliminar este registro?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (resultado == DialogResult.Yes)
            //{
            //    casualty sini = new casualty();
            //    AssignInternoYFecha(sini);
            //    sini = this.casualtysRepository.GetByIntPolizaYFechaOcurrido((int)sini.cod_poliza, (DateTime)sini.fecha_ocurrido);
            //    this.casualtysRepository.Delete(sini);
            //    this.casualtysRepository.Save();
            //    MessageBox.Show("El registro se ah eliminado con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    IQueryable<casualty> casualtys = casualtysRepository.GetAll().AsQueryable();
            //    this.grdCasualties.DataSource = this.GetSiniestrosGridView(casualtys);
            //    this.bloquearControles();
            //    this.tctrlSiniestrosControl.SelectedIndex = 0;
            //}
        }
        private void bloquearControles()
        {
            this.tctrlSiniestrosDatos.Enabled = false;
            this.btnGrabar.Enabled = false;
        }


        private void txtTitular_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexto(e);
        }
        private void txtConductor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexto(e);
        }
        public void ValidarTexto(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true)
            {
            }
            //Codigo Ascii para el Backspace
            else if (e.KeyChar == '\b')
            {
            }
            //Codigo Ascii para el Space
            else if (e.KeyChar == 32)
            {
            }
            else
            {
                e.Handled = true;
            }
        }


        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros(e);
        }
        public void ValidarNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true)
            {
            }
            //codigo Ascii para el guion 
            else if (e.KeyChar == 45)
            {
            }
            //Codigo Ascii para el Backspace
            else if (e.KeyChar == '\b')
            {
            }
            //Codigo Ascii para el Space
            else if (e.KeyChar == 32)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string policeReportDirectoryPath = ValidateDirectory();
            string fileName = "P-" + MainForm.currentPolicy.Número + " D-";// + currentCasualty.Number;
            string policeReportFilePath = Path.Combine(policeReportDirectoryPath, fileName);

            string tempPath = System.IO.Path.GetTempFileName();
            FileInfo tempFile = new FileInfo(tempPath);
            System.IO.File.WriteAllBytes(tempPath, Properties.Resources.PlantillaDenunciaSiniestro);

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(tempPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //PopulateExcelPoliceReport(xlWorkSheet);

            tempFile.Delete();
            xlWorkBook.SaveAs(policeReportFilePath);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            Process.Start(policeReportFilePath + ".xlsx");
        }
        private string ValidateDirectory()
        {
            string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SeGGu Denuncias";
            if (!(Directory.Exists(pathFolder))) Directory.CreateDirectory(pathFolder);
            return pathFolder;
        }
        //private void PopulateExcelPoliceReport(Excel.Worksheet xlWorkSheet)
        //{
        //    VehicleDto vehicle = currentCasualty.Vehicles.First();
        //    var client = currentCasualty.Client;
        //    xlWorkSheet.Cells[5, 3] = currentCasualty.Producer;
        //    xlWorkSheet.Cells[6, 3] = MainForm.currentPolicy.Compañía;
        //    xlWorkSheet.Cells[6, 13] = MainForm.currentPolicy.Número;
        //    xlWorkSheet.Cells[6, 18] = currentCasualty.Number;
        //    xlWorkSheet.Cells[8, 2] = currentCasualty.OccurredDate;
        //    xlWorkSheet.Cells[27, 5] = client.Apellido + ", " + client.Nombre;

        //    xlWorkSheet.Cells[28, 3] = client.DNI;
        //    xlWorkSheet.Cells[28, 13] = client.Tel_Móvil;
        //    xlWorkSheet.Cells[29, 3] = client.HomeStreet + " " + client.HomeNumber;
        //    xlWorkSheet.Cells[32, 2] = vehicle.Brand;
        //    xlWorkSheet.Cells[32, 9] = vehicle.Model;
        //    xlWorkSheet.Cells[32, 17] = vehicle.VehicleType;
        //    xlWorkSheet.Cells[33, 2] = vehicle.Plate;
        //    xlWorkSheet.Cells[33, 17] = vehicle.Year;
        //    xlWorkSheet.Cells[34, 2] = vehicle.Engine;
        //    xlWorkSheet.Cells[34, 13] = vehicle.Chassis;
        //}
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
