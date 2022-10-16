using Hangfire.Dashboard;

namespace Catalog.WebAPIServer.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            //TODO implement authorization logic


            return true;
        }
    }
}