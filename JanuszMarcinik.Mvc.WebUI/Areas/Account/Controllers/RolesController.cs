//using AutoMapper;
//using JanuszMarcinik.Mvc.Domain.Data;
//using JanuszMarcinik.Mvc.Domain.Models.Identity;
//using JanuszMarcinik.Mvc.Domain.Repositories.Identity;
//using JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Controllers
//{
//    public partial class RolesController : Controller
//    {
//        #region RolesController()
//        private ApplicationRoleManager _roleManager;

//        public RolesController(ApplicationDbContext context)
//        {
//            _roleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));
//        }
//        #endregion

//        #region List()
//        public virtual ActionResult List()
//        {
//            var datasource = new RoleDataSource()
//            {
//                Model = Mapper.Map<List<RoleViewModel>>(_roleManager.Roles)
//            };

//            return View(MVC.Shared.Views._Grid, datasource.GetGridModel());
//        }
//        #endregion

//        #region Create()
//        public virtual ActionResult Create()
//        {
//            var model = new RoleViewModel();
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public virtual ActionResult Create(RoleViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                _roleManager.Create(new Role() { Name = model.Name });
//                return RedirectToAction(MVC.Account.Roles.List());
//            }

//            return View(model);
//        }
//        #endregion

//        #region Edit
//        public virtual async Task<ActionResult> Edit(int id)
//        {
//            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
//            var model = Mapper.Map<RoleViewModel>(role);

//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public virtual ActionResult Edit(RoleViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var role = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
//                role.Name = model.Name;
//                _roleManager.Update(role);

//                return RedirectToAction(MVC.Account.Roles.List());
//            }
//            return View(model);
//        }
//        #endregion

//        #region Delete()
//        public virtual ActionResult Delete(int id)
//        {
//            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
//            var model = Mapper.Map<RoleViewModel>(role);

//            return View(model);
//        }

//        [ValidateAntiForgeryToken]
//        [HttpPost, ActionName("Delete")]
//        public virtual ActionResult DeleteConfirmed(RoleViewModel model)
//        {
//            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
//            _roleManager.Delete(role);

//            return RedirectToAction(MVC.Account.Roles.List());
//        }
//        #endregion
//    }
//}