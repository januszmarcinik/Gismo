using AutoMapper;
using JanuszMarcinik.Mvc.DataSource;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Default.Models;
using JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Controllers
{
    public partial class ExampleParentsController : Controller
    {
        private IExampleParentsRepository _exampleParentsRepository;

        public ExampleParentsController(IExampleParentsRepository exampleParentsRepository)
        {
            this._exampleParentsRepository = exampleParentsRepository;
        }

        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Example.ExampleParents.List());
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var datasource = new ExampleParentDataSource()
            {
                Model = Mapper.Map<List<ExampleParentViewModel>>(_exampleParentsRepository.ExampleParents),
                OrderBy = null,
                SortOrder = GridSortOrder.ASC
            };
            datasource.Initialize();

            return View(MVC.Shared.Views._Grid, datasource.GetGridModel());
        }
        #endregion

        #region Create()
        public virtual ActionResult Create()
        {
            var model = new ExampleParentViewModel();

            return View(MVC.Example.ExampleParents.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(ExampleParentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parent = new ExampleParent()
                {
                    Text = model.Text,
                    LongText = model.LongText
                };

                await _exampleParentsRepository.CreateAsync(parent);

                return RedirectToAction("List");
            }

            return View(MVC.Example.ExampleParents.Views.Edit, model);
        }
        #endregion

        #region Edit
        public virtual async Task<ActionResult> Edit(int id)
        {
            var parent = await _exampleParentsRepository.GetAsync(id);
            var model = Mapper.Map<ExampleParentViewModel>(parent);

            return View(MVC.Example.ExampleParents.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(ExampleParentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parent = await _exampleParentsRepository.GetAsync(model.Id);
                parent.Text = model.Text;
                parent.LongText = model.LongText;

                await _exampleParentsRepository.UpdateAsync(parent);

                return RedirectToAction("List");
            }

            return View(MVC.Example.ExampleParents.Views.Edit, model);
        }
        #endregion

        #region Delete()
        public virtual PartialViewResult Delete(int id)
        {
            var model = new DeleteConfirmViewModel()
            {
                Id = id,
                ConfirmationText = "Czy na pewno usunąć parenta?"
            };

            return PartialView(MVC.Default.Shared.Views._DeleteConfirm, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Delete(DeleteConfirmViewModel model)
        {
            await _exampleParentsRepository.DeleteAsync(model.Id);
            return RedirectToAction(MVC.Example.ExampleParents.List());
        }
        #endregion
    }
}