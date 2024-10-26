using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _Scripts.Gameplay.Items.Spawner
{
    public interface IItemsSpawner
    {
        UniTask SpawnItems(List<Transform> spawnPoint);
    }
}