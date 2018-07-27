using Autofac;
using NTCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.Domain.Extensions
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var infrastructureAssembly = typeof(AggregateRoot).GetTypeInfo().Assembly;
            var domainAssembly = typeof(AutofacModule).Assembly;
            var dataAccessAssembly = typeof(AppDbContext).Assembly;

            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(ICommandHandler<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(ICommandHandlerAsync<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(IValidator<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(IRules<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(IEventHandler<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(IEventHandlerAsync<>));

            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IRepository<>));
            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IEventHandler<>));
            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IEventHandlerAsync<>));
            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IQueryHandler<,>));
            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IQueryHandlerAsync<,>));

            //builder.RegisterAssemblyTypes(reportingAssembly).AsClosedTypesOf(typeof(IEventHandler<>));
            //builder.RegisterAssemblyTypes(reportingAssembly).AsClosedTypesOf(typeof(IEventHandlerAsync<>));

            //builder.RegisterAssemblyTypes(infrastructureAssembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(domainAssembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(dataAccessAssembly).AsImplementedInterfaces();
        }
    }


}
