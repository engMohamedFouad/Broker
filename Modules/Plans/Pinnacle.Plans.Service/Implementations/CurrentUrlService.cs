using Microsoft.AspNetCore.Http;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class CurrentUrlService : ICurrentUrlService
    {
        #region Fileds
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructors
        public CurrentUrlService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetCurrentDomain()
        {
            var httpContext = _contextAccessor.HttpContext.Request;
            var domain = httpContext.Scheme+"://"+httpContext.Host;
            return domain;
        }
        #endregion

        #region Handle Functions
        public string GetCurrentHost()
        {
            var httpContext = _contextAccessor.HttpContext.Request;
            var host = httpContext.Host.ToString();
            return host;
        }
        #endregion

    }
}
