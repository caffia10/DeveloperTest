using Microsoft.Extensions.DependencyInjection;
using WebApiTest.Interface;
using WebApiTest.Logic;

namespace WebApiTest.Configs
{
    public static class DependencyInjections
    {
        public static void InitializeInjections(this IServiceCollection services)
        {
            services.AddSingleton<IContactsLogic, ContactsLogic>();
        }
    }
}
