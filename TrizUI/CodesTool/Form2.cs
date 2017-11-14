using System;
using System.Collections.Generic;
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
            objectList = new BusObjManager().Get(txtSource.Lines);

            txtModel.Text = new ModelCodes().Generate(objectList);
            txtDAL.Text = new DALCodes().Generate(objectList);
            txtBLL.Text = new BLLCodes().Generate(objectList);
            txtAPIControler.Text = new WebAPIControlerCodes().Generate(objectList);
            txtListHtml.Text = new ListHtmlPageCodes().Generate(objectList);
            txtListCtrl.Text = new ListCtrlCodes().Generate(objectList);
            txtOperateHtml.Text = new OperateHtmlPageCodes().Generate(objectList);
            txtOpeCtrl.Text = new OpeCtrlCodes().Generate(objectList);
            txtSQL.Text = new SqlCodes().Generate(objectList);
        }
        string dirname = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OutPutManager OutPutManager = new CodesTool.OutPutManager(objectList[0].ObjName);
            OutPutManager.CreateCodeFile(txtModel.Text, objectList[0].ObjName + "Info.cs");
            OutPutManager.CreateCodeFile(txtDAL.Text, objectList[0].ObjName + "DAL.cs");
            OutPutManager.CreateCodeFile(txtBLL.Text, objectList[0].ObjName + "Logic.cs");
            OutPutManager.CreateCodeFile(txtAPIControler.Text, objectList[0].ObjName + "sController.cs");
            OutPutManager.CreateCodeFile(txtListHtml.Text, objectList[0].ObjName, objectList[0].ObjName + "List.html");
            OutPutManager.CreateCodeFile(txtListCtrl.Text, "Controllers", objectList[0].ObjName + ".js");
            OutPutManager.CreateCodeFile(txtOperateHtml.Text, objectList[0].ObjName, objectList[0].ObjName + "Operate.html");
            OutPutManager.CreateCodeFile(txtOpeCtrl.Text, "Controllers", objectList[0].ObjName + "OpeCtrl.js");
            dirname = OutPutManager.DicName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(dirname);

        }
    }
}
