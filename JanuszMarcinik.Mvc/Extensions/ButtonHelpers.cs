using TwitterBootstrap3;
using TwitterBootstrapMVC.BootstrapMethods;
using TwitterBootstrapMVC.Controls;

namespace JanuszMarcinik.Mvc
{
    public static class ButtonHelpers
    {
        #region ActionLinkButton() - Basic
        public static BootstrapActionLinkButton ActionLinkButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionMap siteMapAction) where TModel : class
        {
            return bootstrap.ActionLinkButton(siteMapAction.Title, siteMapAction.ActionName, siteMapAction.ControllerName).RouteValues(siteMapAction.RouteValues);
        }
        #endregion

        #region ActionLink()
        public static BootstrapActionLink ActionLink<TModel>(this BootstrapBase<TModel> bootstrap, string text, ActionMap siteMapAction) where TModel : class
        {
            return bootstrap.ActionLink(text, siteMapAction.ActionName, siteMapAction.ControllerName).RouteValues(siteMapAction.RouteValues);
        }
        #endregion

        #region AddButton()
        public static BootstrapActionLinkButton AddButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionMap result) where TModel : class
        {
            return bootstrap.ActionLinkButton(result).Style(ButtonStyle.Success).PrependIcon(FontAwesome.plus);
        }
        #endregion

        #region ListButton()
        public static BootstrapActionLinkButton ListButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionMap result) where TModel : class
        {
            return bootstrap.ActionLinkButton(result).PrependIcon(FontAwesome.list).Style(ButtonStyle.Info).Text(result.Title);
        }
        #endregion

        #region EditButton()
        public static BootstrapActionLinkButton EditButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionMap result) where TModel : class
        {
            return bootstrap.ActionLinkButton(result).Style(ButtonStyle.Warning).PrependIcon(FontAwesome.pencil);
        }
        #endregion

        #region DeleteButton
        public static BootstrapActionLinkButton DeleteButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionMap result) where TModel : class
        {
            return bootstrap.ActionLinkButton(result).Style(ButtonStyle.Danger).PrependIcon(FontAwesome.remove);
        }
        #endregion

        #region ConfirmDeleteButton()
        public static BootstrapButton<TModel> ConfirmDeleteButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.Button().Style(ButtonStyle.Danger).PrependIcon(FontAwesome.remove).Text("Usuń").TriggerModal("deleteConfirm");
        }
        #endregion

        #region BackButton()
        public static BootstrapActionLinkButton BackButton<TModel>(this BootstrapBase<TModel> bootstrap, ActionMap result) where TModel : class
        {
            return bootstrap.ActionLinkButton(result).Title("Wstecz").PrependIcon(FontAwesome.arrow_left);
        }
        #endregion

        #region SubmitSaveButton()
        public static BootstrapButton<TModel> SubmitSaveButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.SubmitButton().Text("Zapisz").PrependIcon(FontAwesome.save).Style(ButtonStyle.Primary);
        }
        #endregion

        #region SubmitDeleteButton()
        public static BootstrapButton<TModel> SubmitDeleteButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.SubmitButton().Text("Usuń").PrependIcon(FontAwesome.remove).Style(ButtonStyle.Danger);
        }
        #endregion

        #region SubmitFilterButton()
        public static BootstrapButton<TModel> SubmitFilterButton<TModel>(this BootstrapBase<TModel> bootstrap) where TModel : class
        {
            return bootstrap.SubmitButton().Text("Filtruj").PrependIcon(FontAwesome.filter).Style(ButtonStyle.Warning);
        }
        #endregion
    }
}