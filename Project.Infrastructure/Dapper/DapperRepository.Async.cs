using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace Project.Infrastructure.Dapper
{
    public partial class DapperRepository<T> : IDapperRepository<T> where T : class, new()
    {
        public async Task<IEnumerable<T>> SelectAllAsync(){
            return await this.Connection.GetAllAsync<T>();
        }

        public async Task<T> SelectAsync(long id){
            return await this.Connection.GetAsync<T>(id);
        }

        public async Task<long> InsertAsync(T entity)
        {
            return await this.Connection.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity){
            return await this.Connection.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(T entity){
            return await this.Connection.DeleteAsync(entity);
        }

    }

}