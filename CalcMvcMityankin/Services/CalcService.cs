using CalcMvcMityankin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalcMvcMityankin.Services
{
    public class CalcService
    {

        public static double? Calc(CalcStateViewModel calcState)
        {
            double? result = 0;
            switch (calcState.PreviousAction)
            {
                case "/":
                    if(calcState.CurrentValue == 0)
                    {
                        result = null;
                        break;
                    }
                    result = calcState.PreviousValue / calcState.CurrentValue;
                    break;
                case "*":
                    result = calcState.PreviousValue * calcState.CurrentValue;
                    break;
                case "-":
                    result = calcState.PreviousValue - calcState.CurrentValue;
                    break;
                case "+":
                    result = calcState.PreviousValue + calcState.CurrentValue;
                    break;            
            }
            return result;
        }

    }
}