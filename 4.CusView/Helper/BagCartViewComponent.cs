using _1.DATA.Model;
using _4.ClientView.StrConnection;
using _4.CusView.IServices;
using _4.CusView.ModelRequest;
using CustomerViews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CustomerViews.Helpers
{
    public class BagCartViewComponent : ViewComponent
    {
        private readonly IAllServices _services;
        public BagCartViewComponent(IAllServices services)
        {
            _services = services;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lstGHCT = await _services.GetAllViewCart<CartRequest>(StrConnection.api + "GioHangChiTiets/Get-All");
            string idgh = HttpContext.Session.GetString("idgh");
            BagCartViewModel bagCartView;
            if (idgh != null)
            {
                if (lstGHCT == null || lstGHCT.data.Count == 0)
                {
                    lstGHCT = null;
                    return View(lstGHCT);
                }
                else
                {
                    bagCartView = new BagCartViewModel()
                    {
                        numberOfItems = lstGHCT.data.Where(x => x.idGiohang.ToString() == idgh).Sum(x => x.SoLuong)
                    };
                    return View(bagCartView);
                }
            }
            else
            {
                lstGHCT = null;
                return View(lstGHCT);
            }


        }
    }
}
