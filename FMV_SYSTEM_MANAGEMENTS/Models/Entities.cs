using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Models
{
    //[Serializable]
    public partial class Entities
    {
        private Entities(DbConnection connectionString, bool contextOwnsConnection = true)
            : base(connectionString, contextOwnsConnection)
        {
        }
        public static Entities CreateEntities(bool contextOwnsConnection = true)
        {
            //read connect file
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
            //connect cp = (connect)bf.Deserialize(fs);

            ////decrypt content
            //string servername = Encryptor.Decrypt(cp.servername, "asdfghjkl", true);
            //string username = Encryptor.Decrypt(cp.username, "asdfghjkl", true);
            //string pass = Encryptor.Decrypt(cp.passwd, "asdfghjkl", true);
            //string database = Encryptor.Decrypt(cp.database, "asdfghjkl", true);

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            SqlConnectionStringBuilder sqlConnectBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = "123.24.143.156";
            sqlBuilder.InitialCatalog = "MyStockDB";
            sqlBuilder.UserID = "sa";
            sqlBuilder.Password = "Tai@1234";

            string sqlConnectionString = sqlBuilder.ConnectionString + ";TrustServerCertificate=True";
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = sqlConnectionString;

            entityBuilder.Metadata = @"res://*/Models.SYSTEM_MANAGEMENT.csdl|res://*/Models.SYSTEM_MANAGEMENT.ssdl|res://*/Models.SYSTEM_MANAGEMENT.msl";

            //entityBuilder.Metadata = @"res://*/Models.SYSTEM_MANAGEMENT.csdl|res://*/Models.SYSTEM_MANAGEMENT.ssdl|res://*/Models.SYSTEM_MANAGEMENT.msl;";

            EntityConnection connection = new EntityConnection(entityBuilder.ConnectionString);

            return new Entities(connection);
        }
    }
}
