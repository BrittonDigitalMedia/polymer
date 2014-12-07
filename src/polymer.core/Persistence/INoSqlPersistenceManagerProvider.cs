using polymer.core.Modularisation;

namespace polymer.core.Persistence
{
    public interface INoSqlPersistenceManagerProvider
    {
        INoSqlPersistenceManager GetPersistenceManager(IModuleContext moduleContext);
    }
}