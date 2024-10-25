using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input;
using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.Player.Camera
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;
        
        private IInputService _inputService;
        private IDataProvider _dataProvider;
        private float _mouseSpeed;
        private float xRotation;

        [Inject]
        private void Inject(IDataProvider dataProvider, 
            IInputService inputService)
        {
            _dataProvider = dataProvider;
            _inputService = inputService;
        }

        private void Awake()
        {
            _mouseSpeed = _dataProvider.PlayerSettings.MouseSpeed;
        }

        private void Update()
        {
            float mouseX = _inputService.LookXAxis * _mouseSpeed * Time.deltaTime;
            float mouseY = _inputService.LookYAxis * _mouseSpeed * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}