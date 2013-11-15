
namespace OpenCBS.Interface
{
    public interface ISettingsProvider
    {
        string GetDatabaseServerName();
        void SetDatabaseServerName(string name);

        string GetDatabaseName();
        void SetDatabaseName(string name);

        string GetDatabaseUsername();
        void SetDatabaseUsername(string username);

        string GetDatabasePassword();
        void SetDatabasePassword(string password);
    }
}
