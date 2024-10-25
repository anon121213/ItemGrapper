using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure
{
    public class MainInstaller : LifetimeScope
    {
        [SerializeField] private AllData _allData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<ILoadAssetService, LoadAssetService>(Lifetime.Singleton);
            builder.Register<IDataProvider, DataProvider>(Lifetime.Singleton).WithParameter(_allData);
           
            builder.RegisterEntryPoint<Bootstrapper>();
        }
    }
}