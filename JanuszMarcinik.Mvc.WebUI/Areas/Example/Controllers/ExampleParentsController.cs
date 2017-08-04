using AutoMapper;
using JanuszMarcinik.Mvc.DataSource;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Controllers
{
    public class ExampleParentsController : ApplicationController
    {
        private IExampleParentsRepository _exampleParentsRepository;

        public ExampleParentsController(IExampleParentsRepository exampleParentsRepository)
        {
            this._exampleParentsRepository = exampleParentsRepository;
        }

        #region Index()
        public ActionResult Index()
        {
            return List();
        }
        #endregion

        #region List()
        public ActionResult List(ExampleParentDataSource datasource = null)
        {
            datasource.Data = Mapper.Map<List<ExampleParentViewModel>>(_exampleParentsRepository.ExampleParents);
            datasource.Initialize();

            return View(datasource);
        }

        [HttpPost]
        [ActionName("List")]
        [ValidateAntiForgeryToken]
        public ActionResult DataSource(ExampleParentDataSource datasource)
        {
            return List(datasource);
        }
        #endregion

        #region Create()
        public ActionResult Create()
        {
            var model = new ExampleParentViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExampleParentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parent = new ExampleParent()
                {
                    Text = model.Text,
                    LongText = model.LongText
                };

                _exampleParentsRepository.Create(parent);

                return List();
            }

            return View(model);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var parent = _exampleParentsRepository.Get(id);
            var model = Mapper.Map<ExampleParentViewModel>(parent);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExampleParentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parent = _exampleParentsRepository.Get(model.Id);
                parent.Text = model.Text;
                parent.LongText = model.LongText;

                _exampleParentsRepository.Update(parent);

                return List();
            }

            return View(model);
        }
        #endregion

        #region Delete()
        public PartialViewResult Delete(int id)
        {
            var model = new DeleteConfirmViewModel()
            {
                Id = id,
                ConfirmationText = "Czy na pewno usunąć parenta?"
            };

            return PartialView("_DeleteConfirm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteConfirmViewModel model)
        {
            _exampleParentsRepository.Delete(model.Id);
            return List();
        }
        #endregion
    }
}