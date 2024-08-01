using System.Text.RegularExpressions;

namespace MyFirstApp.CustomConstraints;

public class CustomContraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        // verifica se o valor existe
        if (!values.ContainsKey(routeKey))
        {
            return false;
        }

        Regex regex = new Regex("^(john|maria|ronaldo)$");
        string? name = values[routeKey]?.ToString();

        if (name is not null && regex.IsMatch(name)) return true;

        return false;
    }
}