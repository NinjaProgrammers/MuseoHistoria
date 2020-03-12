using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Museo.Models
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Modificar rol", "Modificar rol"),
            new Claim("Añadir usuario", "Añadir usuario"),
            new Claim("Editar usuario", "Editar usuario"),
            new Claim("Eliminar usuario", "Eliminar usuario"),
            new Claim("Modificar visita", "Modificar visita"),
            new Claim("Modificar residente", "Modificar residente"),
            new Claim("Modificar actividad", "Modificar actividad"),
            new Claim("Modificar cargo", "Modificar cargo"),
            new Claim("Modificar área", "Modificar área"),
            new Claim("Modificar noticia", "Modificar noticia"),
            new Claim("Modificar plan anual", "Modificar plan anual")
        };
    }
}
