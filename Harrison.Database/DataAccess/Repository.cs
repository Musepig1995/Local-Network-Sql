using System.Collections.Generic;
using System.Data.SqlClient;

namespace Harrison.Database.DataAccess
{
    /// <summary>
    /// Abstract access point for local network storage on home network
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T>
    {
        /// <summary>
        /// Connection string to access the local SQL Server
        /// </summary>
        private string connectionDetails = "Data Source=192.168.0.3,49172;Network Library=DBMSSOCN;Initial Catalog={0};User Id=BasicUser;Password=Pa$$w0rd1";

        /// <summary>
        /// Cached connection to the server
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// Connection to the SQL Server
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        /// <summary>
        /// A collection of all the entities in this storage point
        /// </summary>
        public abstract IEnumerable<T> List { get; }

        /// <summary>
        /// Initialises an instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="tableName">The name of the table to access in the SQL Server</param>
        public Repository(string tableName)
        {
            var connectionString = string.Format(connectionDetails, tableName);
            this.connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Delete the entity with a specfic ID
        /// </summary>
        /// <param name="id">ID of the entity to delete</param>
        public abstract void Delete(int id);

        /// <summary>
        /// Updates the specified entity
        /// </summary>
        /// <param name="entity">The entity with changes to be updated</param>
        public abstract void Update(T entity);

        /// <summary>
        /// Retrieves a specific entity with a specific ID
        /// </summary>
        /// <param name="id">The ID of the entity</param>
        /// <returns>The entity retrieved</returns>
        public abstract T FindById(int id);

        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="entity">The entity to create</param>
        /// <returns>The ID of the newly created Entity</returns>
        public abstract int Add(T entity);

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
