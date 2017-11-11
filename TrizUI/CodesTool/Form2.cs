using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodesTool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        List<BusinessObjectInfo> objectList = new List<BusinessObjectInfo>();
        private void button1_Click(object sender, EventArgs e)
        {
            objectList = new BusObjManager().Get(txtName.Text, txtSource.Lines);

            txtModel.Text = new ModelCodes().Generate(objectList);
            txtDAL.Text = new DALCodes().Generate(objectList);
            txtBLL.Text = new BLLCodes().Generate(objectList);
            txtAPIControler.Text = new WebAPIControlerCodes().Generate(objectList);
            txtListHtml.Text = new ListHtmlPageCodes().Generate(objectList);
            txtListCtrl.Text = new ListCtrlCodes().Generate(objectList);
            txtOperateHtml.Text = new OperateHtmlPageCodes().Generate(objectList);

        }

        
    }
}
