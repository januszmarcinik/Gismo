namespace JanuszMarcinik.Mvc.JMap.Maps.Example
{
    public class ControllerExampleParents : ControllerMap
    {
        public ControllerExampleParents(string areaName, string controllerName) : base(areaName, controllerName)
        {
        }

        #region List()
        public ActionMap List()
        {
            return ActionMapInit().Name("List").Title("Lista parentów");
        }
        #endregion

        #region Edit()
        public ActionMap Edit(int id)
        {
            return ActionMapInit().Name("Edit").Title("Edycja parenta").AddRouteValue("id", id);
        }
        #endregion
    }
}