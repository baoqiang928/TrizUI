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
    public partial class FrmSimpleObjectCtrlCodes : Form
    {
        public FrmSimpleObjectCtrlCodes()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            List<BusinessObjectInfo> BusinessObjectInfoList = new List<BusinessObjectInfo>();
            for (int i = 0; i < txtSource.Lines.Length; i++)
            {
                BusinessObjectInfo BusinessObjectInfo = new BusinessObjectInfo();
                BusinessObjectInfo.ObjName = txtSource.Lines[0];
                BusinessObjectInfo.Name = txtSource.Lines[i];
                BusinessObjectInfoList.Add(BusinessObjectInfo);
            }
            txtCtrl.Text = new SimpleCtrlCodes().Generate(BusinessObjectInfoList);
            txtHTML.Text = new SimpleHtmlCodes().Generate(BusinessObjectInfoList);

        }
    }


}
