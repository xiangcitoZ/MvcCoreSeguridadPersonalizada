using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcCoreSeguridadPersonalizada.Filters
{
    public class AuthorizeUsersAttribute : AuthorizeAttribute
        , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //AQUI ES DONDE ENTRAREMOS EN JUEGO ENTRE LAS 
            //PETICIONES DE VIEWS Y CONTROLLERS
            //EL METODO IMPEDIRA ENTRAR EN CIERTOS LUGARES
            //CON MIS PREGUNTAS, DEBO CAMBIAR LA DIRECCION 
            //DE ACCESO (Login)
            //EL USUARIO SE ALMACENA DENTRO DE HttpContext
            //Y LA PROPIEDAD User
            //UN USUARIO ESTA COMPUESTO POR IDENTITY Y UN PRINCIPAL
            //MEDIANTE LA IDENTIDAD PODEMOS SABER EL NAME DEL USUARIO
            //MEDIANTE EL PRINCIPAL PODEMOS PREGUNTAR POR EL ROLE


            var user = context.HttpContext.User;
            if(user.Identity.IsAuthenticated == false ) 
            {
                //AQUI DENTRO, NO NOS GUSTA QUE NO SE HAYA
                //AUTENTIFICADO Y NOS LO LLEVAMOS A Login
                RouteValueDictionary rutaLogin =
                new RouteValueDictionary
                (
                    new { controller = "Managed", action = "Login" }
                );
            //REDIRECCIONAMOS
            context.Result =
                new RedirectToRouteResult(rutaLogin);

                 

            }
        }
    }
}
