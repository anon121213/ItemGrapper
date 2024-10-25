using System.Collections.Generic;
using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Grapper;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Items.Spawner
{
    public class ItemsSpawner : IItemsSpawner
    {
        private List<Transform> _spawnPoints = new();
        private readonly IDataProvider _dataProvider;
        private readonly ILoadAssetService _loadAssetService;
        private readonly IItemsContainer _itemsContainer;

        public ItemsSpawner(IDataProvider dataProvider,
            ILoadAssetService loadAssetService,
            IItemsContainer itemsContainer)
        {
            _dataProvider = dataProvider;
            _loadAssetService = loadAssetService;
            _itemsContainer = itemsContainer;
        }

        public async UniTask SpawnItems(List<Transform> points)
        {
            _spawnPoints = points;
            
            foreach (var spawnPoint in _spawnPoints)
            {
                Item item = await GetItem(spawnPoint.position);
                
                _itemsContainer.AddItem(item.GetComponent<Item>());
                
                Object.Instantiate(item, spawnPoint.position, spawnPoint.rotation);
            }
        }

        private async UniTask<Item> GetItem(Vector3 spawnPoint)
        {
            int assetIndex = Random.Range(0, _dataProvider.ItemsReferences.Items.Count);
            
            GameObject item =
                await _loadAssetService.GetAsset<GameObject>
                    (_dataProvider.ItemsReferences.Items[assetIndex]);

            BoxCollider prefabCollider = item.GetComponent<BoxCollider>();
            Vector3 size = prefabCollider.size;
            Collider[] colliders = Physics.OverlapBox(spawnPoint, size / 2);
            
            if (colliders.Length > 0)
                return await GetItem(spawnPoint);

            return item.GetComponent<Item>();
        }
    }

    public interface IItemsSpawner
    {
        UniTask SpawnItems(List<Transform> points);
    }
}
