using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly IObjectResolver _resolver;
        private readonly ILoadAssetService _loadAssetService;

        public PlayerFactory(ILoadAssetService loadAssetService,
            IDataProvider dataProvider,
            IObjectResolver resolver)
        {
            _loadAssetService = loadAssetService;
            _dataProvider = dataProvider;
            _resolver = resolver;
        }

        public async UniTask CreatePlayer(Transform spawnPoint)
        {
            var player = await _loadAssetService
                .GetAsset<GameObject>(_dataProvider.ObjectsReferences.Player);
            
            _resolver.Instantiate(player, spawnPoint);
        }
    }

    public interface IPlayerFactory
    {
        UniTask CreatePlayer(Transform spawnPoint);
    }
}