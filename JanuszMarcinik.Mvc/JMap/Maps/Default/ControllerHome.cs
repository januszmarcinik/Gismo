namespace JanuszMarcinik.Mvc.JMap.Maps.Default
{
    public class ControllerHome : ControllerMap
    {
        public ControllerHome(string areaName, string controllerName) : base(areaName, controllerName)
        {
        }

        #region Index()
        public ActionMap Index()
        {
            return ActionMapInit().Name("Index").Title("Strona główna");
        }
        #endregion
    }
}