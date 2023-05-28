using CommonComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HackingPlayerController :  Damagable, PlayerInput.IPlayerActions
{

	private CharacterController _characterController;


	private Vector2 _currentLookPosition;
	private Vector2 _currentMoveInputVector = Vector2.zero;
	private float _playerGrav;

	#region Serialisation
	[SerializeField] private float moveSpeed;
	[SerializeField] private float gravityValue;
	private Camera _camera;
	private Vector3 _lookDir;
	private InputAction _primaryAction;
	[SerializeField] private float _dodgePower;
	[SerializeField] private float _dodgeCooldown;
	[SerializeField] private bool _canDodge;
	[SerializeField] private bool dodging;
	[SerializeField] private float dodgingDuration;
	[SerializeField] private float dodgeDuration;
	[SerializeField] GameObject playerAimTarget;
	[SerializeField] GameObject playerMoveTarget;

	#endregion

	// Start is called before the first frame update
	public  void Awake()
	{
		
		
		_camera = Camera.main;
		_characterController = GetComponent<CharacterController>();


		CacheControls();

		
		var hpSlider = PlayerUIManager.Instance.PlayerHPSlider;
		hpSlider.MaxValue = MaxHP;
		hpSlider.SetToMax();
		HPChangedEvent += hpSlider.SetValues;
		
	}


	#region InputSetup
	private PlayerInput _controls;
	private InputAction _moveAction;
	private InputAction _lookAction;
	private InputAction _dodgeAction;
	private InputAction _swapWeaponsAction;
	private InputAction _secondaryAction;
	private InputAction _activateAction;
    #endregion
    private void CacheControls()
	{

		_controls = new PlayerInput();
		_moveAction = _controls.Player.Move;
		_lookAction = _controls.Player.Look;
		_primaryAction = _controls.Player.Primary;
		_dodgeAction = _controls.Player.Dodge;
		_secondaryAction = _controls.Player.Secondary;
		_swapWeaponsAction = _controls.Player.SwapWeapon;
		_activateAction = _controls.Player.Action;

		
		_dodgeAction.performed += OnDodge;
		_moveAction.performed += OnMove;
		_lookAction.performed += OnLook;
		_primaryAction.started += OnPrimary;
		_primaryAction.canceled += OnPrimaryCancel;
		_secondaryAction.started += OnSecondary;
		_secondaryAction.canceled += OnSecondaryCancel;
		_swapWeaponsAction.started += OnSwapWeapon;
		_activateAction.performed += OnAction;
	}

    private void OnPrimaryCancel(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void OnSecondaryCancel(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void OnEnable()
	{
		EnableControls();
		_characterController.enabled = true;
	}

	private void OnDisable()
	{
		EnableControls();
		_characterController.enabled = false;
	}
	private void EnableControls()
	{
		_controls.Enable();
		_controls.Player.Enable();
		_canDodge = true;
	}

	private void DisableControls()
	{
		_controls.Disable();
		_controls.Player.Disable();
		_canDodge = false;
	}
	void Start()
    {
        inputActions = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayerMove()
    {
        var temp = _currentMoveInputVector.normalized.ToVector3TopDown() * (Time.deltaTime * moveSpeed);

        _playerGrav = _characterController.isGrounded ? 0f : gravityValue * Time.deltaTime;

        temp.y = _playerGrav;
        //playerMoveTarget.transform.position = this.transform.position+_currentMoveInputVector.ToVector3TopDown()*(Time.deltaTime*moveSpeed);
        _characterController.Move(temp);
    }
    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrimary(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSecondary(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnDodge(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSwapWeapon(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnAction(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
