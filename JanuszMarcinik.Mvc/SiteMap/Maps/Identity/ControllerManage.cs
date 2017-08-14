namespace JanuszMarcinik.Mvc.SiteMap.Maps.Identity
{
    public class ControllerManage : ControllerMap
    {
        public ControllerManage(string areaName, string controllerName) : base(areaName, controllerName)
        {
        }

        #region Index()
        public ActionMap Index()
        {
            return ActionMapInit()
                .Name(nameof(Index))
                .Title("Index");
        }
        #endregion
    }
}