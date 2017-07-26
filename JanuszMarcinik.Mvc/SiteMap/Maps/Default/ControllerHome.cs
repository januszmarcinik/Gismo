namespace JanuszMarcinik.Mvc.SiteMap.Maps.Default
{
    public class ControllerHome : ControllerMap
    {
        public ControllerHome(string areaName, string controllerName) : base(areaName, controllerName)
        {
        }

        #region Index()
        public ActionMap Index()
        {
            return ActionMapInit().Name(nameof(Index)).Title("Strona główna");
        }
        #endregion
    }
}