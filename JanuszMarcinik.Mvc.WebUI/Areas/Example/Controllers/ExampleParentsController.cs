using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Repositories.Examples.Abstract;
using JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Controllers
{
    public class ExampleParentsController : Controller
    {
        private IExampleParentsRepository _exampleParentsRepository;

        public ExampleParentsController(IExampleParentsRepository exampleParentsRepository)
        {
            this._exampleParentsRepository = exampleParentsRepository;
        }

        public ActionResult List()
        {
            var model = new ExampleParentDataSource();
            model.ExampleParents = Mapper.Map<List<ExampleParentViewModel>>(_exampleParentsRepository.ExampleParents);
            model.SetActions();

            return View(MVC.Shared.Views._Grid, model.GetGridModel());
        }

        #region Create()
        public ActionResult Create()
        {
            var model = new ExampleParentViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ExampleParentViewModel model)
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

            return View(model);
        }
        #endregion

        #region Edit
        public async Task<ActionResult> Edit(int id)
        {
            var parent = await _exampleParentsRepository.GetAsync(id);
            var model = Mapper.Map<ExampleParentViewModel>(parent);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ExampleParentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parent = await _exampleParentsRepository.GetAsync(model.Id);
                parent.Text = model.Text;
                parent.LongText = model.LongText;

                await _exampleParentsRepository.UpdateAsync(parent);

                return RedirectToAction("List");
            }
            return View(model);
        }
        #endregion

        #region Delete()
        public async Task<ActionResult> Delete(int id)
        {
            var parent = await _exampleParentsRepository.GetAsync(id);
            var model = Mapper.Map<ExampleParentViewModel>(parent);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _exampleParentsRepository.DeleteAsync(id);

            return RedirectToAction("List");
        }
        #endregion
    }
}