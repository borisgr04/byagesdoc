using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using BLL.Security;



namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //gesMenuAdapter gm = new gesMenuAdapter();
            fcEntities ctx = new fcEntities();
            dataGridView1.DataSource = ctx.fc_menu.ToList();
            dataGridView1.Refresh();
            /*
            ProcesosCBLL p = new ProcesosCBLL();
            classFiltro f = new classFiltro();
            f.DEP_PSOL = "06";
            //f.COD_SOL = "2011-SGR-0001";
            
            f.ID_ABOG_ENC = "22667823";
            f.TIPO_FECHA = classFiltro.TipoFecha.REVISADO;
            f.FECHA_I = Convert.ToDateTime("01/04/2011");
            f.FECHA_F = Convert.ToDateTime("21/04/2011");

            dataGridView1.DataSource=  p.Consultar(f);
            dataGridView1.Refresh();*/

            //Entidades.Entities ctx = new Entidades.Entities();
            //string cod = ctx.Database.SqlQuery<string>("Select to_char(sysdate) from vtiposcont ").FirstOrDefault<string>();
            //ctx.Dispose();
            //MessageBox.Show(cod);
        }
    }
}
