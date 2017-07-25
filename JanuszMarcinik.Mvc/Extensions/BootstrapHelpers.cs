using JanuszMarcinik.Mvc.JMap;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrap3;
using TwitterBootstrapMVC.BootstrapMethods;
using TwitterBootstrapMVC.Controls;

namespace JanuszMarcinik.Mvc
{
    public static class BootstrapHelpers
    {
        public static BootstrapActionLinkButton AddButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("Dodaj", result).Style(ButtonStyle.Success).PrependIcon(FontAwesome.plus);
        }

        public static BootstrapActionLinkButton ListButton<TModel>(this BootstrapBase<TModel> bootstrap, string linkText, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("", result).Text(linkText).PrependIcon(FontAwesome.list).Style(ButtonStyle.Info);
        }

        #region EditButton()
        public static BootstrapActionLinkButton EditButton<TModel>(this BootstrapBase<TModel> bootstrap, Task<ActionResult> result) where TModel : class
        {
            return bootstrap.ActionLinkButton("", result).Title("Edytuj").Style(ButtonStyle.Warning).PrependIcon(FontAwesome.pencil);
        }

        public static BootstrapActionLinkButton EditButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("", result).Title("Edytuj").Style(ButtonStyle.Warning).PrependIcon(FontAwesome.pencil);
        }
        #endregion

        #region DeleteButton
        public static BootstrapActionLinkButton DeleteButton<TModel>(this BootstrapBase<TModel> bootstrap, Task<ActionResult> result) where TModel : class
        {
            return bootstrap.ActionLinkButton("", result).Title("Usuń").Style(ButtonStyle.Danger).PrependIcon(FontAwesome.remove);
        }

        public static BootstrapActionLinkButton DeleteButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("", result).Title("Usuń").Style(ButtonStyle.Danger).PrependIcon(FontAwesome.remove);
        }
        #endregion

        public static BootstrapButton<TModel> ConfirmDeleteButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.Button().Style(ButtonStyle.Danger).PrependIcon(FontAwesome.remove).Text("Usuń").TriggerModal("deleteConfirm");
        }

        public static BootstrapActionLinkButton BackButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLinkButton("Powrót", result).PrependIcon(FontAwesome.arrow_left);
        }

        public static BootstrapButton<TModel> SubmitSaveButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.SubmitButton().Text("Zapisz").PrependIcon(FontAwesome.save).Style(ButtonStyle.Primary);
        }

        public static BootstrapButton<TModel> SubmitDeleteButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.SubmitButton().Text("Usuń").PrependIcon(FontAwesome.remove).Style(ButtonStyle.Danger);
        }

        public static BootstrapActionLink ListGroupItem<TModel>(this BootstrapBase<TModel> bootstrap, string text, ActionResult result) where TModel : class
        {
            return bootstrap.ActionLink(text, result).Class("list-group-item");
        }

        public static BootstrapActionLinkButton ActionLinkButton<TModel>(this BootstrapBase<TModel> bootstrap, string text, ActionMap siteMapAction) where TModel : class
        {
            return bootstrap.ActionLinkButton(text, siteMapAction.ActionName, siteMapAction.ControllerName).RouteValues(siteMapAction.RouteValues).PrependIcon(FontAwesome.android);
        }
    }
}