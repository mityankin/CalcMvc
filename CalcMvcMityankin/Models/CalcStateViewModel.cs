using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalcMvcMityankin.Models
{
    public class CalcStateViewModel
    {


        public string History { get; set; }

        public double? PreviousValue { get; set; }
        public double? CurrentValue { get; set; }
        
        public string CurrentData { get; set; }

        public string PreviousAction { get; set; }
        public string CurrentAction { get; set; }

        public double? Result { get; set; }
    }
}