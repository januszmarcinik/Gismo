namespace JanuszMarcinik.Mvc
{
    public static class BootstrapHelpers
    {
        public static TwitterBootstrapMVC.Form Upload(this TwitterBootstrapMVC.Form form)
        {
            return form.HtmlAttributes(new { enctype = "multipart/form-data" });
        }
    }
}