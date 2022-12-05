using System;
using static BaseShop.SharedKernel.Models.ObjectContainer;

namespace BaseShop.SharedKernel.Models
{
  public enum LifeStyle
  {
    /// <summary>Represents a component is a transient component.
    /// </summary>
    Transient,
    /// <summary>Represents a component is a singleton component.
    /// </summary>
    Singleton
  }
  /// <summary>Represents an object container interface.
  /// </summary>
  public interface IObjectContainer
  {
    /// <summary>Build the container.
    /// </summary>
    void Build();
    /// <summary>Register a implementation type.
    /// </summary>
    /// <param name="implementationType">The implementation type.</param>
    /// <param name="serviceName">The service name.</param>
    /// <param name="life">The life cycle of the implementer type.</param>
    void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton);
    /// <summary>Register a implementer type as a service implementation.
    /// </summary>
    /// <param name="serviceType">The service type.</param>
    /// <param name="implementationType">The implementation type.</param>
    /// <param name="serviceName">The service name.</param>
    /// <param name="life">The life cycle of the implementer type.</param>
    void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton);
    /// <summary>Register a implementer type as a service implementation.
    /// </summary>
    /// <typeparam name="TService">The service type.</typeparam>
    /// <typeparam name="TImplementer">The implementer type.</typeparam>
    /// <param name="serviceName">The service name.</param>
    /// <param name="life">The life cycle of the implementer type.</param>
    void Register<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        where TService : class
        where TImplementer : class, TService;
    /// <summary>Register a implementer type instance as a service implementation.
    /// </summary>
    /// <typeparam name="TService">The service type.</typeparam>
    /// <typeparam name="TImplementer">The implementer type.</typeparam>
    /// <param name="instance">The implementer type instance.</param>
    /// <param name="serviceName">The service name.</param>
    void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null)
        where TService : class
        where TImplementer : class, TService;
    /// <summary>Resolve a service.
    /// </summary>
    /// <typeparam name="TService">The service type.</typeparam>
    /// <returns>The component instance that provides the service.</returns>
    TService Resolve<TService>() where TService : class;
    /// <summary>Resolve a service.
    /// </summary>
    /// <param name="serviceType">The service type.</param>
    /// <returns>The component instance that provides the service.</returns>
    object Resolve(Type serviceType);
    /// <summary>Try to retrieve a service from the container.
    /// </summary>
    /// <typeparam name="TService">The service type to resolve.</typeparam>
    /// <param name="instance">The resulting component instance providing the service, or default(TService).</param>
    /// <returns>True if a component providing the service is available.</returns>
    bool TryResolve<TService>(out TService instance) where TService : class;
    /// <summary>Try to retrieve a service from the container.
    /// </summary>
    /// <param name="serviceType">The service type to resolve.</param>
    /// <param name="instance">The resulting component instance providing the service, or null.</param>
    /// <returns>True if a component providing the service is available.</returns>
    bool TryResolve(Type serviceType, out object instance);
    /// <summary>Resolve a service.
    /// </summary>
    /// <typeparam name="TService">The service type.</typeparam>
    /// <param name="serviceName">The service name.</param>
    /// <returns>The component instance that provides the service.</returns>
    TService ResolveNamed<TService>(string serviceName) where TService : class;
    /// <summary>Resolve a service.
    /// </summary>
    /// <param name="serviceName">The service name.</param>
    /// <param name="serviceType">The service type.</param>
    /// <returns>The component instance that provides the service.</returns>
    object ResolveNamed(string serviceName, Type serviceType);
    /// <summary>Try to retrieve a service from the container.
    /// </summary>
    /// <param name="serviceName">The name of the service to resolve.</param>
    /// <param name="serviceType">The type of the service to resolve.</param>
    /// <param name="instance">The resulting component instance providing the service, or null.</param>
    /// <returns>True if a component providing the service is available.</returns>
    bool TryResolveNamed(string serviceName, Type serviceType, out object instance);
  }
    /// <summary>Represents an object container.
    /// </summary>
    public class ObjectContainer
    {
      /// <summary>Represents the current object container.
      /// </summary>
      public static IObjectContainer Current { get; private set; }

      /// <summary>Set the object container.
      /// </summary>
      /// <param name="container"></param>
      public static void SetContainer(IObjectContainer container)
      {
        Current = container;
      }

      /// <summary>Build the container.
      /// </summary>
      public static void Build()
      {
        Current.Build();
      }
      /// <summary>Register a implementation type.
      /// </summary>
      /// <param name="implementationType">The implementation type.</param>
      /// <param name="serviceName">The service name.</param>
      /// <param name="life">The life cycle of the implementer type.</param>
      public static void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
      {
        Current.RegisterType(implementationType, serviceName, life);
      }
      /// <summary>Register a implementer type as a service implementation.
      /// </summary>
      /// <param name="serviceType">The implementation type.</param>
      /// <param name="implementationType">The implementation type.</param>
      /// <param name="serviceName">The service name.</param>
      /// <param name="life">The life cycle of the implementer type.</param>
      public static void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
      {
        Current.RegisterType(serviceType, implementationType, serviceName, life);
      }
      /// <summary>Register a implementer type as a service implementation.
      /// </summary>
      /// <typeparam name="TService">The service type.</typeparam>
      /// <typeparam name="TImplementer">The implementer type.</typeparam>
      /// <param name="serviceName">The service name.</param>
      /// <param name="life">The life cycle of the implementer type.</param>
      public static void Register<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
          where TService : class
          where TImplementer : class, TService
      {
        Current.Register<TService, TImplementer>(serviceName, life);
      }
      /// <summary>Register a implementer type instance as a service implementation.
      /// </summary>
      /// <typeparam name="TService">The service type.</typeparam>
      /// <typeparam name="TImplementer">The implementer type.</typeparam>
      /// <param name="instance">The implementer type instance.</param>
      /// <param name="serviceName">The service name.</param>
      public static void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null)
          where TService : class
          where TImplementer : class, TService
      {
        Current.RegisterInstance<TService, TImplementer>(instance, serviceName);
      }
      /// <summary>Resolve a service.
      /// </summary>
      /// <typeparam name="TService">The service type.</typeparam>
      /// <returns>The component instance that provides the service.</returns>
      public static TService Resolve<TService>() where TService : class
      {
        return Current.Resolve<TService>();
      }
      /// <summary>Resolve a service.
      /// </summary>
      /// <param name="serviceType">The service type.</param>
      /// <returns>The component instance that provides the service.</returns>
      public static object Resolve(Type serviceType)
      {
        return Current.Resolve(serviceType);
      }
      /// <summary>Try to retrieve a service from the container.
      /// </summary>
      /// <typeparam name="TService">The service type to resolve.</typeparam>
      /// <param name="instance">The resulting component instance providing the service, or default(TService).</param>
      /// <returns>True if a component providing the service is available.</returns>
      public static bool TryResolve<TService>(out TService instance) where TService : class
      {
        return Current.TryResolve<TService>(out instance);
      }
      /// <summary>Try to retrieve a service from the container.
      /// </summary>
      /// <param name="serviceType">The service type to resolve.</param>
      /// <param name="instance">The resulting component instance providing the service, or null.</param>
      /// <returns>True if a component providing the service is available.</returns>
      public static bool TryResolve(Type serviceType, out object instance)
      {
        return Current.TryResolve(serviceType, out instance);
      }
      /// <summary>Resolve a service.
      /// </summary>
      /// <typeparam name="TService">The service type.</typeparam>
      /// <param name="serviceName">The service name.</param>
      /// <returns>The component instance that provides the service.</returns>
      public static TService ResolveNamed<TService>(string serviceName) where TService : class
      {
        return Current.ResolveNamed<TService>(serviceName);
      }
      /// <summary>Resolve a service.
      /// </summary>
      /// <param name="serviceName">The service name.</param>
      /// <param name="serviceType">The service type.</param>
      /// <returns>The component instance that provides the service.</returns>
      public static object ResolveNamed(string serviceName, Type serviceType)
      {
        return Current.ResolveNamed(serviceName, serviceType);
      }
      /// <summary>Try to retrieve a service from the container.
      /// </summary>
      /// <param name="serviceName">The name of the service to resolve.</param>
      /// <param name="serviceType">The type of the service to resolve.</param>
      /// <param name="instance">The resulting component instance providing the service, or null.</param>
      /// <returns>True if a component providing the service is available.</returns>
      public static bool TryResolveNamed(string serviceName, Type serviceType, out object instance)
      {
        return Current.TryResolveNamed(serviceName, serviceType, out instance);
      }
    }
}

