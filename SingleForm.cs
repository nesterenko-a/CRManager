using CrmManager.CrmApi;

namespace CrmManager
{
    class SingleForm
    {
        public static LoginForm uniqueLoginForm;
        public static ConfigForm uniqueConfigForm;

        public static LoginForm LoginFormInstance(CrmApiManager crm_api)
        {
            if (uniqueLoginForm == null)
                uniqueLoginForm = new LoginForm(crm_api);
            return uniqueLoginForm;
        }

        public static ConfigForm ConfigFormInstance()
        {
            if (uniqueConfigForm == null)
                uniqueConfigForm = new ConfigForm();
            return uniqueConfigForm;
        }
    }
}
