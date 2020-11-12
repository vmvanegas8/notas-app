using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CalculoNotas
{
    public partial class Trash : Form
    {


        public Trash()
        {
            InitializeComponent();
        }

        public void deleteAlumno(Alumno alumno)
        {
            frmcalculonotas.listaAlumnosBorrados.Add(alumno);
            dgvAlumnosBorrados.DataSource = null;
            dgvAlumnosBorrados.DataSource = frmcalculonotas.listaAlumnosBorrados;
            // saveAlumnosBorrados();
        }



        public void loadAlumnosBorrados()
        {
            Console.WriteLine("loadAlumnosBorrados");


            dgvAlumnosBorrados.DataSource = null;
            dgvAlumnosBorrados.DataSource = frmcalculonotas.listaAlumnosBorrados;
        }

        private void Trash_Load(object sender, EventArgs e)
        {
            loadAlumnosBorrados();
        }

        private Alumno obtenerAlumnoBorrado(int code)
        {
            foreach (Alumno alumno in frmcalculonotas.listaAlumnosBorrados)
            {
                if (alumno.Codigo == code)
                {
                    return alumno;
                }
            }
            return null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Alumno alumno = obtenerAlumnoBorrado(int.Parse(txtCode.Text));
            frmcalculonotas.listaAlumnosBorrados.Remove(alumno);
            frmcalculonotas.listaAlumnos.Add(alumno);

            frmcalculonotas frmcalculonotas1 = new frmcalculonotas();

            frmcalculonotas1.recuperarAlumno();

            dgvAlumnosBorrados.DataSource = null;
            dgvAlumnosBorrados.DataSource = frmcalculonotas.listaAlumnosBorrados;
            // saveAlumnosBorrados();
            txtCode.Clear();
        }

    }
}
