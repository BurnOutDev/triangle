using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReserveProject.Application.CommandHandlers;
using ReserveProject.Application.EventHandlers;
using ReserveProject.Application.Execution;
using ReserveProject.Application.ProcessManagers;
using ReserveProject.Application.Services;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.EventDispatching;
using ReserveProject.Infrastructure.Repositories;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System.Linq;
using ReserveProject.DI;
using Microsoft.EntityFrameworkCore;
using ReserveProject.Infrastructure.Repositories.Implementations;
using ReserveProject.Application.QueryHandlers;
using Microsoft.Extensions.Logging.Debug;

namespace ReserveProject.DI
{
    public class PrimeDependencyResolver
    {
        private IServiceCollection _serviceCollection;

        public PrimeDependencyResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public PrimeDependencyResolver Resolve(IServiceCollection services = null)
        {
            if (services == null)
            {
                services = new ServiceCollection();
            }

            _serviceCollection = services;

            string connectionString = Configuration.GetConnectionString("PrimeDbContext");
            services.AddSingleton(Configuration);
            services.AddScoped<IMediator, Mediator>();
            services.AddDbContext<PrimeDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString)
                                                                    .UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider() })));
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ServiceFactory>(p => p.GetService);
            services.AddScoped(ApplicationContextFactory.Create);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoggerRepository, LoggerRepository>();

            services.AddScoped<TransactionalDomainEventDispatcher>();
            services.AddScoped<AsynchronousEventProcessor>();
            services.AddScoped<ICommandExecutor, CommandExecutor>();
            services.AddScoped<IQueryExecutor, QueryExecutor>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();

            services.AddScoped<IBankRepository, BankRepositroy>();
            services.AddScoped<IBankAccountRepository, BankAccountRepositroy>();

            services.AddScoped<IPaymentTermRepository, PaymentTermRepositroy>();

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ISalesPersonRepository, SalesPersonRepository>();

            services.AddScoped<IPartyRepository, PartyRepository>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();

            return this;
        }

        public IServiceCollection SynchronousEventDispatching()
        {
            _serviceCollection.Scan(scan =>
                scan.FromAssembliesOf(typeof(CustomerEventHandler))
                    .AddClasses(x => x.InNamespaces(typeof(CustomerEventHandler).Namespace,
                        typeof(CommandHandlerAssembly).Namespace,
                        typeof(CustomerListQueryHandler).Namespace))
                    .AsImplementedInterfaces());
            return _serviceCollection;
        }

        public IServiceCollection AsynchronousEventDispatching()
        {
            _serviceCollection.Scan(scan =>
                scan.FromAssembliesOf(typeof(CustomerProcessManager))
                    .AddClasses(x => x.InNamespaces(typeof(CustomerProcessManager).Namespace))
                    .AsImplementedInterfaces());
            return _serviceCollection;
        }



        public IServiceCollection TestEventDispatching()
        {
            _serviceCollection.Scan(scan =>
                scan.FromAssembliesOf(typeof(CommandHandlerAssembly))
                    .AddClasses(x => x.InNamespaces(typeof(CommandHandlerAssembly).Namespace,
                        typeof(CustomerListQueryHandler).Namespace))
                    .AsImplementedInterfaces());

            return _serviceCollection;
        }

    }

}