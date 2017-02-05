using CalcMvcMityankin.Models;
using CalcMvcMityankin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalcMvcMityankin.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index(CalcStateViewModel calcState)
        {      
               
            return View("Index", calcState);
        }

        private void ClearCache()
        {
            ModelState.Remove(nameof(CalcStateViewModel.History));
            ModelState.Remove(nameof(CalcStateViewModel.Result));

            ModelState.Remove(nameof(CalcStateViewModel.PreviousValue));
            ModelState.Remove(nameof(CalcStateViewModel.CurrentValue));

            ModelState.Remove(nameof(CalcStateViewModel.PreviousAction));
            ModelState.Remove(nameof(CalcStateViewModel.CurrentAction));
        }


        [HttpPost]
        public ActionResult Index(CalcStateViewModel calcStateViewModel, string btnAction)
        {
            ClearCache();

            if (btnAction.Equals("clear")|| (calcStateViewModel.CurrentAction!=null && calcStateViewModel.CurrentAction.Equals("=")))
            {
                return View(new CalcStateViewModel());
            }

            calcStateViewModel.PreviousAction =  calcStateViewModel.CurrentAction ;
            calcStateViewModel.CurrentAction = btnAction;

            if (calcStateViewModel.PreviousValue != null && calcStateViewModel.CurrentValue != null)
            {
                         
                double? result = CalcService.Calc(calcStateViewModel);
                if (result == null)
                {
                    return View(new CalcStateViewModel() {History="Error",CurrentAction="=" });
                }
                calcStateViewModel.Result = result;
                calcStateViewModel.PreviousValue = result;
            }

            if (calcStateViewModel.PreviousValue == null && calcStateViewModel.CurrentValue != null)
            {
                calcStateViewModel.PreviousValue = calcStateViewModel.CurrentValue;
            }

            if(calcStateViewModel.CurrentValue != null && !btnAction.Equals("="))
            {
                calcStateViewModel.History += btnAction;
            }
            calcStateViewModel.CurrentValue = null;
           
            return View(calcStateViewModel);
        }


    }
}