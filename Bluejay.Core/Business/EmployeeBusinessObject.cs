using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Bluejay.Core.Data;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Business
{
    public class EmployeeBusinessObject:BaseBusinessObject
    {
        private EmployeeDataObject _EmployeeDAO;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set 
            { 
                _ConnectionString = value;
                if (_EmployeeDAO != null)
                    _EmployeeDAO.ConnectionString = this.ConnectionString;
            }
        }

        public EmployeeBusinessObject()
        { 
            _EmployeeDAO = new EmployeeDataObject();

            if (this.ConnectionString != null && this._ConnectionString != string.Empty)
                _EmployeeDAO.ConnectionString = this.ConnectionString;
        }

        public DataTable GetEmployeesTable()
        {
            return _EmployeeDAO.GetEmployeesTable();
        }
        public List<EmployeeEntityOnject> GetEmployees() 
        {
            return _EmployeeDAO.GetEmployees();
        }
        public List<EmployeeEntityOnject> GetEmployees(string ClaveEmpresa)
        {
            List<EmployeeEntityOnject> _EmployeesList = _EmployeeDAO.GetEmployees();
            return _EmployeesList.FindAll(x => x.Empresa.Clave == ClaveEmpresa);
        }
        public List<EmployeeEntityOnject> GetEmployeesActive()
        {
            return _EmployeeDAO.GetEmployeesActive();
        }
        public List<EmployeeEntityOnject> GetEmployeesActive(string ClaveEmpresa)
        {
            List<EmployeeEntityOnject> _EmployeesList = _EmployeeDAO.GetEmployeesActive();
            return _EmployeesList.FindAll(x => x.Empresa.Clave == ClaveEmpresa);
        }
        public EmployeeEntityOnject GetEmployee(string ClaveTrabajador)
        {
            return _EmployeeDAO.GetEmployee(ClaveTrabajador);
        }
        public EmployeeEntityOnject GetEployeeFullKardex(string ClaveTrabajador)
        {
            return null;
        }

    }
}
