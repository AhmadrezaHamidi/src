using Autofac;
using BaseShop.Core.Interfaces;
using BaseShop.Core.Services;

namespace BaseShop.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
