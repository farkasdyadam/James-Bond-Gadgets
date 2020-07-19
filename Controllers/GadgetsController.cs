using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basic_CRUD_App_James_Bond_Gadgets_.Models;
using Basic_CRUD_App_James_Bond_Gadgets_.Data;
using Microsoft.AspNetCore.Mvc;

namespace Basic_CRUD_App_James_Bond_Gadgets_.Controllers
{
    public class GadgetsController : Controller
    {
        List<GadgetModel> gadgets = new List<GadgetModel>();
        public IActionResult Index()
        {
            GadgetDAO gadgetDAO = new GadgetDAO();

            gadgets=gadgetDAO.FetchAll();

            return View("Index",gadgets);
        }

        public IActionResult Details(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FetchOne(id);

            return View("Details",gadget);
        }

        public IActionResult Create()
        {
            return View("GadgetForm");
        }

        public IActionResult Edit(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FetchOne(id);

            return View("GadgetForm",gadget);
        }

        public IActionResult Delete(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.Delete(id);

            List<GadgetModel> gadgets = gadgetDAO.FetchAll();
            return View("Index", gadgets);
        }

        [HttpPost]
        public IActionResult ProcessCreate(GadgetModel gadgetModel)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();

             gadgetDAO.CreateOrUpdate(gadgetModel);

            return View("Details", gadgetModel);
        }

        public IActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public IActionResult SearchForName(string searchPhrase)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            List<GadgetModel> searchResoults = gadgetDAO.SearchForName(searchPhrase);

            return View("Index", searchResoults);
        }
    }
}
