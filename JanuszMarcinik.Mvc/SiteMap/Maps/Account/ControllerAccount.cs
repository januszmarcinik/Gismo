namespace JanuszMarcinik.Mvc.SiteMap.Maps.Account
{
    public class ControllerAccount : ControllerMap
    {
        public ControllerAccount(string areaName, string controllerName) : base(areaName, controllerName)
        {
        }

        #region Login()
        public ActionMap Login()
        {
            return ActionMapInit()
                .Name(nameof(Login))
                .Title("Logowanie");
        }
        #endregion

        #region LogOff()
        public ActionMap LogOff()
        {
            return ActionMapInit()
                .Name(nameof(LogOff))
                .Title("Wyloguj");
        }
        #endregion

        #region Register()
        public ActionMap Register()
        {
            return ActionMapInit()
                .Name(nameof(Register))
                .Title("Rejestracja");
        }
        #endregion
    }
}