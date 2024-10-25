using System.Collections.Generic;
using _Scripts.Gameplay.Input;
using _Scripts.Gameplay.Items.Spawner;
using _Scripts.Infrastructure.Factories;
using UnityEngine;
using VContainer;

namespace _Scripts.Infrastructure
{
    public class GameBoostraper : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints = new ();
        
        private IInputService _inputService;
        private IPlayerFactory _playerFactory;
        private IItemsSpawner _itemSpawner;

        [Inject]
        public void Inject(IPlayerFactory playerFactory,
            IInputService inputService,
            IItemsSpawner itemsSpawner)
        {
            _playerFactory = playerFactory;
            _inputService = inputService;
            _itemSpawner = itemsSpawner;
        }

        public async void Start()
        {
            await _itemSpawner.SpawnItems(_spawnPoints);
            await _playerFactory.CreatePlayer(Vector3.zero, Vector3.zero);
            
            _inputService.Initialize();
        }
    }
}