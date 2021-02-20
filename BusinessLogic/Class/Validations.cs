﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Validations
    {
        public bool isNumeric(string id)
        {
            return Regex.IsMatch(id, @"^\d+$");
        }
    }
}
