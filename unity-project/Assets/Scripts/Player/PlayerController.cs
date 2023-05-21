using UnityEngine;
using UnityEngine.InputSystem;
using Helpers;
using UnityEngine.Serialization;

namespace Player
{
	public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
	{
		#region Input
		private PlayerInput _controls;
		private InputAction _moveAction;
		private InputAction _lookAction;

        #endregion

        private CharacterController _characterController;


        private Vector2 _currentLookPosition;
		private Vector2 _currentMoveInputVector = Vector2.zero;
		private float _playerGrav;


        #region Serialisation

		[SerializeField] private float moveSpeed;
		[SerializeField] private float gravityValue;
		private Camera _camera;

		#endregion

        // Start is called before the first frame update
        void Awake()
		{
			_camera = Camera.main;
			GetComponent<Collider>();
			GetComponent<Rigidbody>();
			_characterController = GetComponent<CharacterController>();

			_controls = new PlayerInput();
			_moveAction = _controls.Player.Move;
			_lookAction = _controls.Player.Look;

            _moveAction.performed += OnMove;
			_lookAction.performed += OnLook;

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
			PlayerMove();
			UpdateLookDir();
		}


		private void PlayerMove()
		{
			var temp = _currentMoveInputVector.ToVector3TopDown() * (Time.deltaTime * moveSpeed);

			_playerGrav = _characterController.isGrounded ? 0f : gravityValue * Time.deltaTime;

			temp.y = _playerGrav;

			_characterController.Move(temp);
		}

		private void UpdateLookDir()
		{
            //transform.forward = transform.position - worldMousePos;
			float lookAngle = Mathf.Atan2(_currentLookPosition.y, _currentLookPosition.x) * Mathf.Rad2Deg - 90f;
			Debug.Log(lookAngle);

            transform.rotation = Quaternion.AngleAxis(lookAngle, Vector3.up);

        }


        public void OnMove(InputAction.CallbackContext context)
		{
			_currentMoveInputVector = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;

        }

		public void OnLook(InputAction.CallbackContext context)
		{

            _currentLookPosition = !context.canceled ? context.ReadValue<Vector2>() : Vector2.zero;
			Debug.Log($"Look Vector From Object {_currentLookPosition}");

        }



        public void OnFire(InputAction.CallbackContext context) { throw new System.NotImplementedException(); }
		public void OnDodge(InputAction.CallbackContext context) { throw new System.NotImplementedException(); }
	}
}
