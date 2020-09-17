using AdventureWorksSales.Core.DAC;
using AdventureWorksSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class HomeController : Controller
    {
        private SalesOrderDAC _salesOrdersDAC;

        public HomeController()
        {
            _salesOrdersDAC = new SalesOrderDAC();
        }

        public ActionResult Index()
        {
            var model = new DashboardModel();

            model.TotalOrders = _salesOrdersDAC.CountSalesOrders();
            model.HighestLineTotal = _salesOrdersDAC.GetHighestLineTotal();
            model.FrontBrakesTotal = _salesOrdersDAC.FrontBrakesSalesTotal();

            return View(model);
        }

    }
}