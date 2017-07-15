using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Data
{
    class EmployeeDataObject:BaseDataObject 
    {
        public int Insert(EmployeeEntityOnject EmployeeInfo)
        {
            throw new NotImplementedException();
        }
        public int Update(EmployeeEntityOnject EmployeeInfo)
        {
            throw new NotImplementedException();
        }
        public int Delete(EmployeeEntityOnject EmployeeInfo)
        {
            throw new NotImplementedException();
        }
        public DataTable GetEmployeesTable()
        {
            DataTable dt;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = conn;
                            cmd.CommandTimeout = 30000;
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.CommandText = "sp_GRL_GetTrabajadoresTodos_";
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @"SELECT CONVERT(nvarchar(10), E.cve107) as CLAVE_TRABAJADOR, 
                                                      E.txt93 as nombre, 
                                                      E.txt91 as paterno, 
                                                      E.txt92 as materno, 
                                                      E.fha569 as fecha_alta,
                                                      E.fha90 as fecha_ingreso,
                                                      E.fha578 as fecha_baja, 
                                                      E.cve340 as CLAVE_COMPANIA,
                                                      E.cve111 as CLAVE_SUCURSAL,
                                                      E.cve109 as CLAVE_DEPTO, 
                                                      E.cve342 as CLAVE_CENTRO,
                                                      E.cve110 as CLAVE_PUESTO, 
                                                      E.cve329 as TIPO_FACTOR,
                                                      E.num316 as factor_integracion,
                                                      E.num65 as sueldo_diario, 
                                                      E.num66 as sueldo_variable,
                                                      E.num67 as sueldo_integrado,
                                                      E.num273 as sueldo_infonavit,
                                                      E.cve343 as vigente,
                                                      (CASE WHEN txt91 IS NOT NULL THEN RTRIM(txt91) ELSE '' END) + ' ' +
                                                      (CASE WHEN txt92 IS NOT NULL THEN RTRIM(txt92) ELSE '' END) + ' ' +
                                                      (CASE WHEN txt93 IS NOT NULL THEN RTRIM(txt93) ELSE '' END) as nombre_completo,
                                                      Nom.txt123 as rfc,
                                                      Nom.cve116 as tipo_nomina
                                               FROM dbENC77 E INNER JOIN dbENC73 Nom ON E.num75 = Nom.NUM_DOC
                                               WHERE (E.NUM_DOC > 0)
                                               ORDER BY E.cve107";

                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                }
                
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EmployeeEntityOnject> GetEmployees()
        {
            DataTable dt;
            EmployeeEntityOnject _EmployeeInfo;
            List<EmployeeEntityOnject> _EmployeesList = new List<EmployeeEntityOnject>(); 

            try {

                dt = GetEmployeesTable(); 

                if (dt != null)
                    foreach (DataRow row in dt.Rows) {
                        _EmployeeInfo = GetEmployeeObject(row);
                        _EmployeesList.Add(_EmployeeInfo);
                    }

                return _EmployeesList;
            }
            catch (Exception ex) { 
                throw ex; 
            }
        }
        public List<EmployeeEntityOnject> GetEmployeesActive()
        {
            return ((List<EmployeeEntityOnject>)GetEmployees()).FindAll(x => x.Activo == true);
        }

        public EmployeeEntityOnject GetEmployee(string ClaveTrabajador)
        {
            DataTable dt;
            DataRow[] rows; 
            EmployeeEntityOnject _EmployeeInfo = null;
            
            try
            {
                dt = GetEmployeesTable();
                rows = dt.Select(string.Format(@"CLAVE_TRABAJADOR='{0}'", ClaveTrabajador));

                if (rows != null && rows.Length > 0)
                {
                    _EmployeeInfo = GetEmployeeObject(rows[0]);

                    //Se obtienen los datos de Nomina del Kardex
                    GetEmployeeNominaData(ref _EmployeeInfo);
                }

                return _EmployeeInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private EmployeeEntityOnject GetEmployeeObject(DataRow row)
        {
            EmployeeEntityOnject _EmployeeInfo = null;

            if (row != null)
            {
                _EmployeeInfo = new EmployeeEntityOnject();                
                _EmployeeInfo.Clave = row["CLAVE_TRABAJADOR"].ToString();
                _EmployeeInfo.Nombre = row["nombre"].ToString();
                _EmployeeInfo.ApellidoPaterno = row["paterno"].ToString();
                _EmployeeInfo.ApellidoMaterno = row["materno"].ToString();

                if (row["fecha_alta"] != DBNull.Value) { _EmployeeInfo.FechaAlta = Convert.ToDateTime(row["fecha_alta"]); }
                if (row["fecha_ingreso"] != DBNull.Value) { _EmployeeInfo.FechaIngreso = Convert.ToDateTime(row["fecha_ingreso"]); }
                if (row["fecha_baja"] != DBNull.Value) { _EmployeeInfo.FechaBaja = Convert.ToDateTime(row["fecha_baja"]); }

                _EmployeeInfo.Empresa.Clave = row["CLAVE_COMPANIA"].ToString().Trim();
                _EmployeeInfo.CentroCosto.Clave = row["CLAVE_CENTRO"].ToString().Trim();
                _EmployeeInfo.Sucursal.Clave = row["CLAVE_SUCURSAL"].ToString().Trim();
                _EmployeeInfo.Departamento.Clave = row["CLAVE_DEPTO"].ToString().Trim();
                _EmployeeInfo.Puesto.Clave = row["CLAVE_PUESTO"].ToString().Trim();
                _EmployeeInfo.TipoFactor = row["TIPO_FACTOR"].ToString().Trim();
                if (row["factor_integracion"] != DBNull.Value) { _EmployeeInfo.FactorIntegracion = Convert.ToDecimal(row["factor_integracion"]); }
                if (row["sueldo_diario"] != DBNull.Value) { _EmployeeInfo.SueldoDiario = Convert.ToDecimal(row["sueldo_diario"]); }
                if (row["sueldo_variable"] != DBNull.Value) { _EmployeeInfo.SueldoVariable = Convert.ToDecimal(row["sueldo_variable"]); }
                if (row["sueldo_integrado"] != DBNull.Value) { _EmployeeInfo.SueldoVariable = Convert.ToDecimal(row["sueldo_integrado"]); }
                if (row["sueldo_infonavit"] != DBNull.Value) { _EmployeeInfo.SueldoInfonavit = Convert.ToDecimal(row["sueldo_infonavit"]); }
                _EmployeeInfo.Activo = (row["vigente"] != DBNull.Value && row["vigente"].ToString().ToUpper().Trim() == "SI") ? true : false;
            }

            return _EmployeeInfo;
        }
        private void GetEmployeeRhData(ref EmployeeEntityOnject EmployeeInfo)
        {
            DataTable dt = new DataTable();
            DataRow row = null;

            try
            {
                if (EmployeeInfo != null)
                {
                    using(SqlConnection conn = new SqlConnection() { ConnectionString = _ConnectionString })                    
                        using(SqlCommand cmd = new SqlCommand() { Connection = conn})
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_GRL_GetTrabajadorDatosRH_";
                            cmd.Parameters.AddWithValue("@CLAVE_TRABAJADOR", EmployeeInfo.Clave);

                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                da.Fill(dt);
                        }

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        row = dt.Rows[0];
                        EmployeeInfo.Calle = (row["calle"] != System.DBNull.Value) ? row["calle"].ToString() : "";
                        EmployeeInfo.Colonia = (row["colonia"] != System.DBNull.Value) ? row["colonia"].ToString() : "";
                        EmployeeInfo.Numero = (row["numero"] != System.DBNull.Value) ? row["numero"].ToString() : "";
                        EmployeeInfo.Calle = (row["estado"] != System.DBNull.Value) ? row["estado"].ToString() : "";
                        EmployeeInfo.Calle = (row["poblacion"] != System.DBNull.Value) ? row["poblacion"].ToString() : "";
                        EmployeeInfo.Calle = (row["telefono"] != System.DBNull.Value) ? row["telefono"].ToString() : "";
                        EmployeeInfo.Calle = (row["telefono2"] != System.DBNull.Value) ? row["telefono2"].ToString() : "";
                        EmployeeInfo.Calle = (row["telefono3"] != System.DBNull.Value) ? row["telefono3"].ToString() : "";
                        EmployeeInfo.Calle = (row["cp"] != System.DBNull.Value) ? row["cp"].ToString() : "";
                        EmployeeInfo.Calle = (row["escolaridad"] != System.DBNull.Value) ? row["escolaridad"].ToString() : "";
                        EmployeeInfo.Calle = (row["carrera"] != System.DBNull.Value) ? row["carrera"].ToString() : "";
                        EmployeeInfo.Calle = (row["sexo"] != System.DBNull.Value) ? row["sexo"].ToString() : "";
                        if (row["fecha_nacimiento"] != DBNull.Value) { EmployeeInfo.FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]); }                        
                        EmployeeInfo.Calle = (row["lugar_nacimiento"] != System.DBNull.Value) ? row["lugar_nacimiento"].ToString() : "";
                        EmployeeInfo.Calle = (row["estado_civil"] != System.DBNull.Value) ? row["estado_civil"].ToString() : "";
                        EmployeeInfo.Calle = (row["padre"] != System.DBNull.Value) ? row["padre"].ToString() : "";
                        EmployeeInfo.Calle = (row["madre"] != System.DBNull.Value) ? row["madre"].ToString() : "";
                        EmployeeInfo.Calle = (row["localidad"] != System.DBNull.Value) ? row["localidad"].ToString() : "";
                        EmployeeInfo.Calle = (row["cve_instituto"] != System.DBNull.Value) ? row["cve_instituto"].ToString() : "";
                        EmployeeInfo.Calle = (row["estadonivel"] != System.DBNull.Value) ? row["estadonivel"].ToString() : "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetEmployeeNominaData(ref EmployeeEntityOnject EmployeeInfo)
        {
            string sql;
            DataTable dt;

            try
            {
                if (EmployeeInfo != null)
                {
                    sql = string.Format(@"SELECT T.cve107 as CLAVE_TRABAJADOR
          ,txt123 as rfc
          ,txt124 as comisiones
          ,txt125 as cuenta
          ,cve119 as ptu
          ,cve120 as cuota_sindical
          ,txt130 as descanso1
          ,cve116 as CLAVE_NOMINA
          ,cve117 as CLAVE_TURNO 
          ,cve118 as tipo_pago
          ,txt126 as control_interno
          ,txt131 as descanso2
          ,banco
          ,numero_tarjeta
          ,Tn.txt60 as DescNomina
          ,CLABE
          ,REGIMEN_CONT as REGIMEN
          ,TURNO_ACTUAL
   FROM dbENC77 T INNER JOIN dbENC73 ON T.num75 = dbENC73.NUM_DOC
                  INNER JOIN dbENC46 Tn ON dbENC73.cve116 = Tn.cve63 and Tn.clave_empresa = T.cve340
   WHERE (dbENC73.NUM_DOC > 0) AND (T.cve107 = '{0}')", EmployeeInfo.Clave);

                    dt = ExecuteDataTable(sql,null,null);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        EmployeeInfo.ClaveNomina = dt.Rows[0]["CLAVE_NOMINA"].ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GetEmployeeImssData(ref EmployeeEntityOnject EmployeeInfo)
        {
            try
            {
                if (EmployeeInfo != null)
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
