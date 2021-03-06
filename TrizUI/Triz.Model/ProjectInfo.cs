﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class ProjectInfo
    {

        private int? id;
        public int? ID
        {
            get { return id; }
            set { id = value; }
        }
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string owner;
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        private string department;
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        private DateTime? createDateTime;

        public DateTime? CreateDateTime
        {
            get { return createDateTime; }
            set { createDateTime = value; }
        }

    }
}

