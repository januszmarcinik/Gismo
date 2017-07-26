using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleChildrens;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Controllers
{
    public class ExampleChildrensController : ApplicationController
    {
        private IExampleChildrensRepository _exampleChildrensRepository;

        public ExampleChildrensController(IExampleChildrensRepository exampleChildrensRepository)
        {
            this._exampleChildrensRepository = exampleChildrensRepository;
        }

        #region List()
        public ViewResult List(int parentId)
        {
            var datasource = new ExampleChildDataSource()
            {
                Data = Mapper.Map<List<ExampleChildViewModel>>(_exampleChildrensRepository.GetByParentId(parentId))
            };
            datasource.Initialize();

            return View(datasource);
        }
        #endregion

        #region Create()
        public ViewResult Create(int parentId)
        {
            var model = new ExampleChildViewModel();
            model.ParentId = parentId;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExampleChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                var child = new ExampleChild()
                {
                    Name = model.Name,
                    ParentId = model.ParentId
                };

                _exampleChildrensRepository.Create(child);

                return List(model.ParentId);
            }

            return View(model);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var child = _exampleChildrensRepository.Get(id);
            var model = Mapper.Map<ExampleChildViewModel>(child);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExampleChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                var child = _exampleChildrensRepository.Get(model.Id);
                child.Name = model.Name;

                _exampleChildrensRepository.Update(child);

                return List(model.ParentId);
            }

            return View(model);
        }
        #endregion

        #region Delete()
        public PartialViewResult Delete(int id, int exampleParentId)
        {
            var model = new DeleteConfirmViewModel()
            {
                Id = id,
                ActionOnDelete = JMap.Example.ExampleChildrens.List(exampleParentId),
                ConfirmationText = "Czy na pewno usunąć childa?"
            };

            return PartialView("_DeleteConfirm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteConfirmViewModel model)
        {
            _exampleChildrensRepository.Delete(model.Id);
            return RedirectToAction(model.ActionOnDelete);
        }
        #endregion
    }
}