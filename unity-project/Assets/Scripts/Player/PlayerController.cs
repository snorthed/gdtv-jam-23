using UnityEngine;
using UnityEngine.InputSystem;
using Helpers;
using UnityEngine.Serialization;

namespace Player
{
	public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
	{
		private PlayerInput _controls;
		private Vector2 _currentMoveInputVector = Vector2.zero;
		private InputAction _moveAction;
        private CharacterController _characterController;

		[SerializeField] private float moveSpeed;
		private float _playerGrav;
		[SerializeField] private float gravityValue;

		// Start is called before the first frame update
		void Awake()
		{
			GetComponent<Collider>();
			GetComponent<Rigidbody>();
			_characterController = GetComponent<CharacterController>();

			_controls = new PlayerInput();
			_moveAction = _controls.Player.Move;

			_moveAction.performed += OnMove;
		}

		private void OnEnable()
		{
			EnableControls();
		}

		private void EnableControls()
		{
			_controls.Enable();
			_controls.Player.Enable();
		}


        private void Update()
		{
			var temp = _currentMoveInputVector.ToVector3TopDown() * (Time.deltaTime * moveSpeed);

			_playerGrav = _characterController.isGrounded ? 0f : gravityValue * Time.deltaTime;

			temp.y = _playerGrav;

            _characterController.Move(temp);

        }

        public void OnMove(InputAction.CallbackContext context)
		{
			_currentMoveInputVector = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;

        }

        public void OnLook(InputAction.CallbackContext context) { throw new System.NotImplementedException(); }

		public void OnFire(InputAction.CallbackContext context) { throw new System.NotImplementedException(); }
		public void OnDodge(InputAction.CallbackContext context) { throw new System.NotImplementedException(); }
	}
}
