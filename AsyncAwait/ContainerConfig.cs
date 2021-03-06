﻿using Autofac;

namespace AsyncAwait
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterType<FilePolling>().As<IFilePolling>();

            return builder.Build();
        }
    }
}
