using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Objects;
using System.Data.EntityClient;
using GoSwitch.CustomerTools.Common;

namespace GoSwitch.CustomerTools.DAL
{
    public static class DataRepositoryFactory
    {
        public static IRepository CurrentRepository
        {
            get
            {
                var repository = DataRepositoryStore.CurrentDataStore[DataRepositoryStore.KEY_DATACONTEXT] as IRepository;
                if (repository == null)
                {   
                 
                    repository = new EFGenericRepository(new ObjectContext(new EntityConnection(SiteSettings.ConnectionString)));
                    DataRepositoryStore.CurrentDataStore[DataRepositoryStore.KEY_DATACONTEXT] = repository;
                }

                return repository;

            }
        }

        public static void CloseCurrentRepository()
        {
            var repository = DataRepositoryStore.CurrentDataStore[DataRepositoryStore.KEY_DATACONTEXT] as IRepository;
            if (repository != null)
            {
                repository.Dispose();
                DataRepositoryStore.CurrentDataStore[DataRepositoryStore.KEY_DATACONTEXT] = null;
            }
        }

        public static IRepository DefaultRepository
        {
            get
            {
                return DataRepositoryFactory.CurrentRepository;
            }
        }
    }
}
