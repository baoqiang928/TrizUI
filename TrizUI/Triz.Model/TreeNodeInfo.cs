using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class TreeNodeInfo
    {
        private string _id = "";

        public string id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        private string _name = "";
        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public bool isParent
        {
            get
            {
                return _isParent;
            }

            set
            {
                _isParent = value;
            }
        }

        private bool _isParent = false;
    }
}
