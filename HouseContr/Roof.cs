﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseContr
{
    class Roof : Item, IPart
    {
        public Roof() { Status = false; }
        public bool Status
        {
            get => status;
            set { status = value; }
        }
        public string ShowPart() => "крыша";
    }
}