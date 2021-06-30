using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace wSoftware1.Data
{
    public sealed class Factory
    {

        private static readonly object _EntityLocker = new object();
        private static readonly object _TransactionLocker = new object();
        private static ApplicationDbContext _Current_DB_Context;
        private static IDbContextTransaction _Current_Transaction;

        private Factory()
        {

        }

        public static string CurrentCnx { get; set; }


        public static ApplicationDbContext GetCurrentDbContext
        {
            get
            {

                lock (_EntityLocker)
                {
                    if (_Current_DB_Context != null) return _Current_DB_Context;
                    else
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                        optionsBuilder.UseSqlServer(CurrentCnx);
                        _Current_DB_Context = new ApplicationDbContext(optionsBuilder.Options);
                        return _Current_DB_Context;
                    }
                }
            }
        }


        public static ApplicationDbContext GetDbContext
        {
            get
            {

                lock (_EntityLocker)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    optionsBuilder.UseSqlServer(CurrentCnx);
                    _Current_DB_Context = new ApplicationDbContext(optionsBuilder.Options);
                    return _Current_DB_Context;
                }
            }
        }

        public static IDbContextTransaction GetCurrentTransaction
        {
            get
            {
                lock (_TransactionLocker)
                {
                    if (_Current_Transaction != null) return _Current_Transaction;
                    else
                    {
                        _Current_Transaction = _Current_DB_Context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                        return _Current_Transaction;
                    }
                }
            }
        }


        public static TransactionScope createTransaction()
        {
            lock (_TransactionLocker)
            {
                TransactionScopeOption scopeOption = new TransactionScopeOption();
                scopeOption = TransactionScopeOption.Required;

                TransactionOptions transOptions = new TransactionOptions();
                transOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;

                return new TransactionScope(scopeOption, transOptions);
            }
        }


    }
}
