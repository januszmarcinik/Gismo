using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleChildrens;
using JanuszMarcinik.Mvc.WebUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Controllers
{
    public partial class ExampleChildrensController : Controller
    {
        private IExampleChildrensRepository _exampleChildrensRepository;

        public ExampleChildrensController(IExampleChildrensRepository exampleChildrensRepository)
        {
            this._exampleChildrensRepository = exampleChildrensRepository;
        }

        public virtual ActionResult List(int parentId)
        {
            var datasource = new ExampleChildDataSource(parentId)
            {
                Model = Mapper.Map<List<ExampleChildViewModel>>(_exampleChildrensRepository.GetByParentId(parentId))
            };
            datasource.Initialize();

            return View(MVC.Shared.Views._Grid, datasource.GetGridModel());
        }

        #region Create()
        public virtual ActionResult Create(int parentId)
        {
            var model = new ExampleChildViewModel();
            model.ParentId = parentId;

            return View(MVC.Example.ExampleChildrens.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(ExampleChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                var child = new ExampleChild()
                {
                    Name = model.Name,
                    ParentId = model.ParentId
                };

                await _exampleChildrensRepository.CreateAsync(child);

                return RedirectToAction(MVC.Example.ExampleChildrens.List(model.ParentId));
            }

            return View(MVC.Example.ExampleChildrens.Views.Edit, model);
        }
        #endregion

        #region Edit
        public virtual async Task<ActionResult> Edit(int id)
        {
            var child = await _exampleChildrensRepository.GetAsync(id);
            var model = Mapper.Map<ExampleChildViewModel>(child);

            return View(MVC.Example.ExampleChildrens.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(ExampleChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                var child = await _exampleChildrensRepository.GetAsync(model.Id);
                child.Name = model.Name;

                await _exampleChildrensRepository.UpdateAsync(child);

                return RedirectToAction(MVC.Example.ExampleChildrens.List(model.ParentId));
            }

            return View(MVC.Example.ExampleChildrens.Views.Edit, model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(int id, int exampleParentId)
        {
            var model = new DeleteConfirmViewModel()
            {
                Id = id,
                ActionOnDelete = MVC.Example.ExampleChildrens.List(exampleParentId),
                ConfirmationText = "Czy na pewno usunąć childa?"
            };

            return PartialView(MVC.Shared.Views._DeleteConfirm, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Delete(DeleteConfirmViewModel model)
        {
            await _exampleChildrensRepository.DeleteAsync(model.Id);
            return RedirectToAction(model.ActionOnDelete);
        }
        #endregion
    }
}