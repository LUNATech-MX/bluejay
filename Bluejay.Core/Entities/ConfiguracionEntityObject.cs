using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bluejay.Core.Entities
{
    public class ConfiguracionEntityObject
    {
        #region Properties
        string _ServerDatabase;
        public string ServerDatabase
        {
            get
            {
                return _ServerDatabase;
            }
            set
            {
                _ServerDatabase = value;
                ReplaceDatabaseToSystemConnectionString();
            }
        }

        string _UserDatabase;
        public string UserDatabase
        {
            get
            {
                return _UserDatabase;
            }
            set
            {
                _UserDatabase = value;
                ReplaceDatabaseToSystemConnectionString();
            }
        }

        string _PasswordDatabase;
        public string PasswordDatabase
        {
            get
            {
                return _PasswordDatabase;
            }
            set
            {
                _PasswordDatabase = value;
                ReplaceDatabaseToSystemConnectionString();
            }
        }

        string _SystemDatabase;
        public string SystemDatabase
        {
            get
            {
                return _SystemDatabase;
            }
            set
            {
                _SystemDatabase = value;
                ReplaceDatabaseToSystemConnectionString();
            }
        }

        string _EstuderDatabase;
        public string EstuderDatabase
        {
            get
            {
                return _EstuderDatabase;
            }
            set
            {
                _EstuderDatabase = value;
                ReplaceDatabaseToEstuderConnectionString();
            }
        }

        string _SystemConnectionString;
        public string SystemConnectionString
        {
            get
            {
                return _SystemConnectionString;
            }
            set
            {
                _SystemConnectionString = value;
            }
        }

        string _EstuderConnectionString;
        public string EstuderConnectionString
        {
            get
            {
                return _EstuderConnectionString;
            }
            set
            {
                _EstuderConnectionString = value;
            }
        }
        #endregion

        #region Constructor
        public ConfiguracionEntityObject()
        {
            _ServerDatabase = string.Empty;
            _UserDatabase = string.Empty;
            _PasswordDatabase = string.Empty;
            _SystemDatabase = string.Empty;
            _EstuderDatabase = string.Empty; 
            _SystemConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataSystemConnection"].ConnectionString;
            _EstuderConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataSystemConnection"].ConnectionString;
        }
        #endregion

        #region Functions
        private void ReplaceDatabaseToSystemConnectionString()
        {
            string[] connFields;
            string[] param;
            Hashtable hashTable = new Hashtable();
            string key;
            string value;
            int idx;

            //int matchV1;
            //int matchV2;

            connFields = _SystemConnectionString.Split(';');

            foreach (string s in connFields)
            {
                if (s != string.Empty)
                {
                    idx = s.IndexOf('=');
                    key = s.Substring(0, idx);
                    value = s.Substring(idx + 1);
                        
                    hashTable.Add(key, value); 
                }
            }

            //Se inicializan los valores del la configuracion
            this._ServerDatabase = ((_ServerDatabase != string.Empty) && (_ServerDatabase != (string)hashTable["Server"])) ? _ServerDatabase : (string)hashTable["Server"];
            this._UserDatabase = ((_UserDatabase != string.Empty) && (_UserDatabase != (string)hashTable["User Id"]))? _UserDatabase : (string)hashTable["User Id"];
            this._PasswordDatabase = ((_PasswordDatabase != string.Empty) && (_PasswordDatabase != (string)hashTable["Password"]))? _PasswordDatabase : (string)hashTable["Password"];

            param = new string[] { _ServerDatabase, _SystemDatabase, _UserDatabase, _PasswordDatabase };
            this._SystemConnectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};", param);
        }
        private void ReplaceDatabaseToEstuderConnectionString()
        {
            string[] connFields;
            string[] param;
            Hashtable hashTable = new Hashtable();
            string key;
            string value;
            int idx;

            //int matchV1;
            //int matchV2;

            connFields = _SystemConnectionString.Split(';');

            foreach (string s in connFields)
            {
                if (s != string.Empty)
                {
                    idx = s.IndexOf('=');
                    key = s.Substring(0, idx);
                    value = s.Substring(idx + 1);

                    hashTable.Add(key, value);
                }
            }

            //Se inicializan los valores del la configuracion
            this._ServerDatabase = (string)hashTable["Server"];
            this._UserDatabase = (string)hashTable["User Id"];
            this._PasswordDatabase = (string)hashTable["Password"];

            param = new string[] { _ServerDatabase, _EstuderDatabase, _UserDatabase, _PasswordDatabase };
            this._EstuderConnectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};", param);
        }
        #endregion
    }
}
