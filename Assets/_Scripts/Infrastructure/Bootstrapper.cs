using _Scripts.Data.DataProvider;
using UnityEngine;
using VContainer.Unity;

namespace _Scripts.Infrastructure
{
    public class Bootstrapper : IStartable
    {
        private const int FRAMERATE = 240;
        
        private readonly IDataProvider _dataProvider;
        private readonly ISceneLoader _sceneLoader;

        public Bootstrapper(IDataProvider dataProvider,
            ISceneLoader sceneLoader)
        {
            _dataProvider = dataProvider;
            _sceneLoader = sceneLoader;
        }

        public async void Start()
        {
            Application.targetFrameRate = FRAMERATE;
            await _sceneLoader.Load(_dataProvider.ObjectsReferences.MainScene);
        }
    }
}
