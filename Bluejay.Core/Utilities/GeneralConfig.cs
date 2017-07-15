using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bluejay.Core.Utilities
{
    public class GeneralConfig
    {
        /// <summary>
        /// Construye la ruta del servidor web. (Sirve para referenciar los archivos img, css y js desde la ruta raiz)
        /// </summary>
        /// <param name="strFolderAndFile">Representa el nombre de la carpeta y el archivo separados por una diagonal entre los dos.</param>
        /// <returns>Devuelve la ruta completa del servidor junto con la carpeta y el archivo.</returns>
        public static String ServerPath(String strFolderAndFile)
        {
            // Ruta del servidor web.
            String baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
            // Devuelve la ruta web para la carpeta y el archivo.
            return baseUrl + strFolderAndFile;
        }

    }
}
