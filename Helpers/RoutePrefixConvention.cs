using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;

namespace WSArtemisaApi.Helpers
{
    public class RoutePrefixConvention : IControllerModelConvention
    {
        private readonly string _prefix;

        public RoutePrefixConvention(string prefix)
        {
            _prefix = prefix;
        }

        public void Apply(ControllerModel controller)
        {
            var selector = controller.Selectors.FirstOrDefault();
            if (selector != null)
            {
                selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"{_prefix}/{controller.ControllerName}"));
            }
        }
    }
}
