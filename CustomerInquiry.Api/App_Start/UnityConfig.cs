using System;
using Core.Infrastructure.Dal;
using CustomerInquiry.EntityFramework;
using CustomerInquiry.Services.Implementations;
using CustomerInquiry.Services.Interfaces;
using Unity;
using Unity.Lifetime;

namespace CustomerInquiry.Api
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion
        
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWorkAsync, EntityFrameworkUnitOfWorkAsync>();
            container.RegisterType<ICustomerInquiryService, CustomerInquiryService>();
        }
    }
}