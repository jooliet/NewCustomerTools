using System;

namespace GoSwitch.CustomerTools.DAL
{
    public class DataRepositoryStore
    {
        public static readonly string KEY_DATACONTEXT = "DataRepository";
        public static IDataRepositoryStore CurrentDataStore;
    }
}
