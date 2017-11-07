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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<BusinessObjectInfo> objectList = new List<BusinessObjectInfo>();
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void INI()
        { 
        //ini object
            InIObject();
            InIObjectNameList();
        
        }

        private void InIObjectNameList()
        {
           foreach(BusinessObjectInfo BusinessObjectInfo in objectList)
            {

                listBox1.Items.Add(BusinessObjectInfo.Name + "" + BusinessObjectInfo.Description);

            
            }

        }
        
        private void InIObject()
        {
            objectList = new List<BusinessObjectInfo>();
            for (int i = 1; i < textBox1.Lines.Length; i++)
            {
                string src = textBox1.Lines[i];
                string[] s = src.Split('	');
                if (s.Length < 7) continue;
                BusinessObjectInfo BusinessObjectInfo = new BusinessObjectInfo();
                BusinessObjectInfo.Name = s[0];
                BusinessObjectInfo.Description = s[1];
                BusinessObjectInfo.Type = s[2];
                BusinessObjectInfo.Length = s[3];
                BusinessObjectInfo.Query = s[4];
                BusinessObjectInfo.List = s[5];
                BusinessObjectInfo.Operate = s[6];
                BusinessObjectInfo.Mondantory = s[7];
                objectList.Add(BusinessObjectInfo);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            INI();
        }
    }
}
