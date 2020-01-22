using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseCRUD_EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DatabaseCRUD_EF
{
    class DataAccessor
    {
        private static DataAccessor _instance;

        private static AdventureWorks2012Context context;

        public static DataAccessor getInstance()
        {
            if (_instance == null)
                _instance = new DataAccessor();

            return _instance;
        }

        private DataAccessor()
        {
            if(context == null)
                context = new AdventureWorks2012Context();
        }

        public List<Person> GetPersonsByOrderDate(DateTime date)
        {
            return context.Persons
                    .FromSqlInterpolated($"EXECUTE dbo.uspGetPersonsByOrderDate {date}")
                    .ToList<Person>();
        }
    }
}
