using polymer.core.Modularisation;

namespace polymer.core.Persistence
{
    public interface IPersistenceManagerProvider
    {
        IPersistenceManager GetPersistenceManager(IModuleContext moduleContext);
    }
}