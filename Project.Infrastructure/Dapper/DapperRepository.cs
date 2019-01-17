using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Project.Infrastructure.Dapper
{
    public partial class DapperRepository<T> : IDapperRepository<T> where T : class, new()
    {
        private readonly static Dictionary<DatabaseType, Type> DictionaryDatabaseType = new Dictionary<DatabaseType, Type>
        {
            [DatabaseType.SqlServer] = typeof(SqlConnection),
            [DatabaseType.MySQL] = typeof(MySqlConnection),
            [DatabaseType.SQLite] = typeof(SqliteConnection)
        };

        private readonly DapperOptions _options;
        internal IDbConnection Connection;

        public DapperRepository(IOptions<DapperOptions> optionsAccessor)
        {
            if (optionsAccessor == null)
            {
                throw new ArgumentNullException(nameof(optionsAccessor));
            }

            _options = optionsAccessor.Value;
            Type type = DictionaryDatabaseType[_options.DatabaseType];
            Connection = Activator.CreateInstance(type) as IDbConnection;
            Connection.ConnectionString = _options.ConnectionString;
        }

        public IEnumerable<T> SelectAll(){
            return this.Connection.GetAll<T>();
        }

        public T Select(long id){
            return this.Connection.Get<T>(id);
        }

        public long Insert(T entity)
        {
            return this.Connection.Insert(entity);
        }

        public bool Update(T entity){
            return this.Connection.Update(entity);
        }

        public bool Delete(T entity){
            return this.Connection.Delete(entity);
        }

    }

}