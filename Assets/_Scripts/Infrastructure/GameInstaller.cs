using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input;
using _Scripts.Gameplay.Items;
using _Scripts.Gameplay.Items.Spawner;
using _Scripts.Infrastructure.Factories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private AllData _allData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IInputService, InputService>(Lifetime.Singleton);
            builder.Register<ILoadAssetService, LoadAssetService>(Lifetime.Singleton);
            builder.Register<IPlayerFactory, PlayerFactory>(Lifetime.Singleton);
            builder.Register<IItemsContainer, ItemsContainer>(Lifetime.Singleton);
            builder.Register<IItemsSpawner, ItemsSpawner>(Lifetime.Singleton);
            builder.Register<IDataProvider, DataProvider>(Lifetime.Singleton).WithParameter(_allData);
        }
    }
}