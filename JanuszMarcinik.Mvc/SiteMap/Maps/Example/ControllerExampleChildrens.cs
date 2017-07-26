namespace JanuszMarcinik.Mvc.SiteMap.Maps.Example
{
    public class ControllerExampleChildrens : ControllerMap
    {
        public ControllerExampleChildrens(string areaName, string controllerName) : base(areaName, controllerName)
        {
        }

        #region List()
        public ActionMap List(int parentId)
        {
            return ActionMapInit().Name(nameof(List)).Title("Lista childrenów").AddRouteValue(nameof(parentId), parentId);
        }
        #endregion

        #region Create()
        public ActionMap Create(int parentId)
        {
            return ActionMapInit().Name(nameof(Create)).Title("Utworzenie childa").AddRouteValue(nameof(parentId), parentId);
        }
        #endregion

        #region Edit()
        public ActionMap Edit(int id)
        {
            return ActionMapInit().Name(nameof(Edit)).Title("Edycja childa").AddRouteValue(nameof(id), id);
        }
        #endregion
    }
}