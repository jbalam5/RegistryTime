using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;


namespace BussinesLayer.Connection
{   
    

    public class ConnectionBLL
    {
        public String core = "BusinessJDLRegistryTime.Conexion";
        public String name = ConfigurationManager.AppSettings.Get("nameSystem");

       public void CreateDirectory(String directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public void saveConexion(String instancia, String username, String password, String database)
        {
            try
            {
                String directory = String.Format("C:\\{0}", name);
                CreateDirectory(directory);
                String path = String.Format(@"{0}\ConnectionString.config", directory);
                File.Delete(path);
                if (!File.Exists(path))
                {
                    XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", null));
                    XElement nodoRaiz = new XElement("configuration");
                    document.Add(nodoRaiz);
                    XElement appSettings = new XElement("appSettings");
                    XElement addInstancia = new XElement("add");
                    addInstancia.SetAttributeValue("key", "instancia");
                    addInstancia.SetAttributeValue("value", Encriptar(instancia));
                    appSettings.Add(addInstancia);

                    XElement addUsername = new XElement("add");
                    addUsername.SetAttributeValue("key", "username");
                    addUsername.SetAttributeValue("value", Encriptar(username));
                    appSettings.Add(addUsername);

                    XElement addPassword = new XElement("add");
                    addPassword.SetAttributeValue("key", "password");
                    addPassword.SetAttributeValue("value", Encriptar(password));
                    appSettings.Add(addPassword);

                    XElement addDatabase = new XElement("add");
                    addDatabase.SetAttributeValue("key", "database");
                    addDatabase.SetAttributeValue("value", Encriptar(database));
                    appSettings.Add(addDatabase);

                    nodoRaiz.Add(appSettings);
                    document.Save(path);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.saveConexion: {1}", core, ex));
            }
        }
        public String ConnectionStrings()
        {
            try
            {
                CollectionConneccionString Values = openConexionFile();
                String ConnectionString = String.Format("server={0} ; database={1}; User Id={2};Password = {3}; ", Values.Instancia, Values.database, Values.username, Values.password);
                return ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.ConnectionStrings: {1}", core, ex));
            }
        }

        public CollectionConneccionString openConexionFile()
        {
            try
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                String path = String.Format(@"C:\{0}\ConnectionString.config", name);
                fileMap.ExeConfigFilename = path; // @"c:\\jdlSystem\\ConnectionStrings.config";
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);


                String instancia = DesEncriptar(config.AppSettings.Settings["instancia"].Value);
                String username = DesEncriptar(config.AppSettings.Settings["username"].Value);
                String password = DesEncriptar(config.AppSettings.Settings["password"].Value);
                String database = DesEncriptar(config.AppSettings.Settings["database"].Value);
                CollectionConneccionString Datos = new CollectionConneccionString();
                Datos.Instancia = instancia;
                Datos.username = username;
                Datos.password = password;
                Datos.database = database;

                return Datos;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.openConexionFile: {1}", core, ex));
            }
        }

        public string Encriptar(string _cadenaAencriptar)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Encriptar: {1}", core, ex));
            }
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string _cadenaAdesencriptar)
        {
            try
            {

                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.DesEncriptar: {1}", core, ex));
            }
        }

        public void CreateConnection()
        {
            try
            {
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionStrings()
                };
                Conexion.Open();
            }
            catch(Exception ex)
            {
                throw new Exception("Datos de Conexion incorrectos!!");
                //throw new Exception(String.Format("{0}.CreateConnection", core, ex));
            }
        }
        public void DeleteConnection()
        {
            try
            {
                String directory = String.Format("C:\\{0}", name);
                CreateDirectory(directory);
                String path = String.Format(@"{0}\ConnectionString.config", directory);
                File.Delete(path);
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.DeleteConnection: {1}", core, ex));
            }
        }

    }

    public class CollectionConneccionString
    {
        public String Instancia;
        public String username;
        public String password;
        public String database;
    }
}
