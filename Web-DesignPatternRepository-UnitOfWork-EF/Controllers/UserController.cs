using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_UnitOfWork_EF.Model;
using Web_UnitOfWork_EF.Repository;

namespace Web_DesignPatternRepository_UnitOfWork_EF.Controllers
{
    public class UserController : Controller
    {

        //IMPLEMENTANDO O UNITOFWORK 
        private IUnitOfWork<UserModel> _unitOfWorkUser;

        public UserController(IUnitOfWork<UserModel> unitOfWorkUser)
        {
            _unitOfWorkUser = unitOfWorkUser;
        }


        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _unitOfWorkUser.GetById(id);
            return View();

        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel collection)
        {
            try
            {
                _unitOfWorkUser.Add(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _unitOfWorkUser.GetById(id);
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserModel collection)
        {
            try
            {
                collection.Id = id;
                _unitOfWorkUser.Update(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _unitOfWorkUser.GetById(id);
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var model = _unitOfWorkUser.Where(x => x.Id == id).FirstOrDefault();
                _unitOfWorkUser.Delete(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
