using Core.Abratractions;
using Core.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Infrastructure;

public sealed class DBSession : IDBSession
{
    public IDbConnection Connection { get; }

    public IDbTransaction Transaction { get; }

    public DBSession()
    {
        Connection = new SqlConnection(AppSettings.ConnectionStrings?.DBConnection);
    }
    public void Close() => Connection.Close();

    public void Dispose() => Connection.Dispose();
}

public sealed class UnitOfWork : IUnitOfWork
{
    public readonly IDBSession _session;
    public UnitOfWork(IDBSession session)
    {
        _session = session;
    }
    public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        if (_session.Transaction == null)
        {
            // _session.Transaction = _session.Connection.BeginTransaction(isolationLevel);
        }
    }

    public void Commit()
    {
        if (_session.Transaction != null)
        {
            _session.Transaction.Commit();
        }

        Dispose();
    }

    public void Rollback()
    {
        if (_session.Transaction != null)
        {
            _session.Transaction.Rollback();
        }

        Dispose();
    }

    public void Dispose() => _session.Transaction?.Dispose();
}
