using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input;
using _Scripts.Gameplay.Items;
using _Scripts.Gameplay.Items.Spawner;
using _Scripts.Infrastructure.Factories;
using _Scripts.Infrastructure.Loader;
using _Scripts.Infrastructure.SpawnContainer;
using _Scripts.Infrastructure.Win;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Installers
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private AllData _allData;
        [SerializeField] private SpawnPointsContainer _spawnPointContainer;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IInputService, InputService>(Lifetime.Singleton);
            builder.Register<ILoadAssetService, LoadAssetService>(Lifetime.Singleton);
            builder.Register<IPlayerFactory, PlayerFactory>(Lifetime.Singleton);
            builder.Register<IItemsContainer, ItemsContainer>(Lifetime.Singleton);
            builder.Register<IItemsSpawner, ItemsSpawner>(Lifetime.Singleton);
            builder.Register<IWinnerChecker, WinnerChecker>(Lifetime.Singleton);
            builder.Register<IDataProvider, DataProvider>(Lifetime.Singleton).WithParameter(_allData);
            builder.RegisterInstance((ISpawnPointContainer)_spawnPointContainer);
        }
    }
}