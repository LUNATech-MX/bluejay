using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluejay.Core.Entities
{
    public abstract class CatalogoEntity
    {
        int _ID;
        string _clave;
        string _descripcion;

        public int Id
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Clave
        {
            get{ return _clave; }
            set{ _clave = value; }
        }
        public string Descripcion
        {
            get{ return _descripcion; }
            set{ _descripcion = value; }
        }
        public CatalogoEntity()
        {
            _ID = 0;
            _clave = string.Empty;
            _descripcion = string.Empty;
        }
    }

    public class EmpresaEntity : CatalogoEntity
    {
    }
    public class SucursalEntity : CatalogoEntity
    {
    }
    public class CentroCostoEntity : CatalogoEntity
    {
    }
    public class DepartamentoEntity : CatalogoEntity
    {
    }
    public class PuestoEntity : CatalogoEntity
    {
    }
}
