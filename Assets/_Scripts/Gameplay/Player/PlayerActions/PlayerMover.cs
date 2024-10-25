using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input;
using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.Player.PlayerActions
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;
        
        private IInputService _inputService;
        private IDataProvider _dataProvider;
        private CharacterController _characterController;
        
        private float _speed;
        
        [Inject]
        public void Inject(IInputService inputService,
            IDataProvider dataProvider)
        {
            _inputService = inputService;
            _dataProvider = dataProvider;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _speed = _dataProvider.PlayerSettings.Speed;
        }

        private void Update()
        {
            Vector3 move = _inputService.MoveAxis;
            Vector3 moveDirection = _camera.transform.forward
                * move.z + _camera.transform.right * move.x;
            
            moveDirection.y = 0f;
            moveDirection.Normalize();

            Vector3 velocity = moveDirection * _speed;
            velocity.y += Physics.gravity.y * Time.deltaTime;

            _characterController.Move(velocity * Time.deltaTime);
        }
    }
}