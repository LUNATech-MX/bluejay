using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Data
{
    class PeriodoDataObject:BaseDataObject
    {
        public DataTable GetPeriodoActualByNominaEmpresaTable(string ClaveNomina, string Empresa)
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
                            cmd.CommandText = string.Format(@"SELECT E.cve63 AS CLAVE_NOMINA, 
		 E.txt60 AS descripcion, 
		 D.cve64 AS CLAVE_PERIODO, 
		 D.fha64 AS fecha_inicial, 
		 D.fha65 AS fecha_final, 
		 D.num48 AS dias,
		(CASE WHEN UPPER(RTRIM(cve65))='SI' OR UPPER(RTRIM(cve65))='S' THEN 1 ELSE 0 END) AS mes_inicio,
		(CASE WHEN UPPER(RTRIM(cve66))='SI' OR UPPER(RTRIM(cve66))='S' THEN 1 ELSE 0 END) AS mes_fin,
		(CASE WHEN UPPER(RTRIM(cve69))='SI' OR UPPER(RTRIM(cve69))='S' THEN 1 ELSE 0 END) AS bimestre_inicio,
		(CASE WHEN UPPER(RTRIM(cve70))='SI' OR UPPER(RTRIM(cve70))='S' THEN 1 ELSE 0 END) AS bimestre_fin,
		(CASE WHEN UPPER(RTRIM(cve67))='SI' OR UPPER(RTRIM(cve67))='S' THEN 1 ELSE 0 END) AS anio_inicio,
		(CASE WHEN UPPER(RTRIM(cve68))='SI' OR UPPER(RTRIM(cve68))='S' THEN 1 ELSE 0 END) AS anio_fin,
		(CASE WHEN UPPER(RTRIM(cve71))='SI' OR UPPER(RTRIM(cve71))='S' THEN 1 ELSE 0 END) AS especial,
		D.fha538 AS fecha_corte_i, 
		D.fha539 AS fecha_corte_f, 
		P.cve73 AS mes_acumulacion 
	FROM dbo.dbENC46 E INNER JOIN 
		dbo.dbDET46 D ON E.NUM_DOC = D.NUM_DOC AND E.txt61 = D.cve64 INNER JOIN 
		dbo.dbENC45 P ON D.num49 = P.NUM_DOC 
	WHERE (E.NUM_DOC > 0) AND 
          (RTRIM(E.cve63)='{0}') and 
          (RTRIM(E.clave_empresa) = '{1}') ",ClaveNomina,Empresa);

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

        public PeriodoEntityObject GetPeriodoActualByNominaEmpresa(string ClaveNomina, string Empresa)
        {
            DataTable dt;
            PeriodoEntityObject _PeriodoInfo = null;

            try
            {
                dt = GetPeriodoActualByNominaEmpresaTable(ClaveNomina,Empresa);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    _PeriodoInfo = GetPeriodoObject(dt.Rows[0]);
                }

                return _PeriodoInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PeriodoEntityObject GetPeriodoObject(DataRow row)
        {
            PeriodoEntityObject _PeriodoInfo = new PeriodoEntityObject();

            if (row != null)
            {
                _PeriodoInfo.Id = 0;
                _PeriodoInfo.ClaveNomina = row["CLAVE_NOMINA"].ToString();
                _PeriodoInfo.Descripcion = row["descripcion"].ToString();
                _PeriodoInfo.ClavePeriodo = row["CLAVE_PERIODO"].ToString();
            }

            return _PeriodoInfo;
        }
    }
}
