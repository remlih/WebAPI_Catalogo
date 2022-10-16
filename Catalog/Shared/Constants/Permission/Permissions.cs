using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Catalog.Shared.Constants.Permission
{
    public static class Permissions
    {

        #region seguridad app

        /// <summary>
        /// Users
        /// </summary>
        public static class Users
        {
            public const string View = "Permisos.SeguridadUsuarios.Ver";
            public const string Create = "Permisos.SeguridadUsuarios.Crear";
            public const string Edit = "Permisos.SeguridadUsuarios.Editar";
            public const string Delete = "Permisos.SeguridadUsuarios.Eliminar";
            public const string Export = "Permisos.SeguridadUsuarios.Exportar";
            public const string Search = "Permisos.SeguridadUsuarios.Buscar";
        }

        public static class Roles
        {
            public const string View = "Permisos.SeguridadRoles.Ver";
            public const string Create = "Permisos.SeguridadRoles.Crear";
            public const string Edit = "Permisos.SeguridadRoles.Editar";
            public const string Delete = "Permisos.SeguridadRoles.Eliminar";
            public const string Search = "Permisos.SeguridadRoles.Buscar";
        }

        public static class RoleClaims
        {
            public const string View = "Permisos.RoleClaims.Ver";
            public const string Create = "Permisos.RoleClaims.Crear";
            public const string Edit = "Permisos.RoleClaims.Editar";
            public const string Delete = "Permisos.RoleClaims.Eliminar";
            public const string Search = "Permisos.RoleClaims.Buscar";
        }
        #endregion

        
        /// <summary>
        /// AuditTrails
        /// </summary>
        public static class AuditTrails
        {
            public const string View = "Permisos.Auditoria.Ver";
            public const string Export = "Permisos.Auditoria.Exportar";
            public const string Search = "Permisos.Auditoria.Buscar";
        }

        #region Catalogo
        /// <summary>
        /// Products
        /// </summary>
        public static class Products
        {
            public const string View = "Permisos.Productos.Ver";
            public const string Create = "Permisos.Productos.Crear";
            public const string Edit = "Permisos.Productos.Editar";
            public const string Delete = "Permisos.Productos.Eliminar";
            public const string Export = "Permisos.Productos.Exportar";
            public const string Search = "Permisos.Productos.Buscar";
        }

        /// <summary>
        /// Categories
        /// </summary>
        public static class Categories
        {
            public const string View = "Permisos.Categorias.Ver";
            public const string Create = "Permisos.Categorias.Crear";
            public const string Edit = "Permisos.Categorias.Editar";
            public const string Delete = "Permisos.Categorias.Eliminar";
            public const string Export = "Permisos.Categorias.Exportar";
            public const string Search = "Permisos.Categorias.Buscar";
        }

        /// <summary>
        /// Brands
        /// </summary>
        public static class Brands
        {
            public const string View = "Permisos.Marcas.Ver";
            public const string Create = "Permisos.Marcas.Crear";
            public const string Edit = "Permisos.Marcas.Editar";
            public const string Delete = "Permisos.Marcas.Eliminar";
            public const string Export = "Permisos.Marcas.Exportar";
            public const string Search = "Permisos.Marcas.Buscar";
        }
        #endregion

        public static class Preferences
        {
            public const string ChangeLanguage = "Permisos.Preferencias.CambiarIdioma";

            //TODO - add permissions
        }

        /// <summary>
        /// Returns a list of Permissions.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetRegisteredPermissions()
        {
            var permssions = new List<string>();
            foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
            {
                var propertyValue = prop.GetValue(null);
                if (propertyValue is not null)
                    permssions.Add(propertyValue.ToString());
            }
            return permssions;
        }
    }
}