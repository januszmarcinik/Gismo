namespace JanuszMarcinik.Mvc.SiteMap.Maps.Example
{
    public class ControllerExampleParents : ControllerMap
    {
        public ControllerExampleParents(string areaName, string controllerName) : base(areaName, controllerName)
        {
        }

        #region List()
        public ActionMap List()
        {
            return ActionMapInit().Name(nameof(List)).Title("Lista parentów");
        }
        #endregion

        #region Create()
        public ActionMap Create()
        {
            return ActionMapInit().Name(nameof(Create)).Title("Utworzenie parenta");
        }
        #endregion

        #region Edit()
        public ActionMap Edit(int id)
        {
            return ActionMapInit().Name(nameof(Edit)).Title("Edycja parenta").AddRouteValue(nameof(id), id);
        }
        #endregion

        #region Delete()
        public ActionMap Delete(int id)
        {
            return ActionMapInit().Name(nameof(Delete)).Title("Usuń parenta").AddRouteValue(nameof(id), id);
        }
        #endregion
    }
}