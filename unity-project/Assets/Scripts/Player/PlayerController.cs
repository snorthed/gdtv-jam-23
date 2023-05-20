using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
	{
		// Start is called before the first frame update
		void Start()
		{
        
		}

		// Update is called once per frame
		void Update()
		{
        
		}

		public void OnMove(InputAction.CallbackContext context) { throw new System.NotImplementedException(); }

		public void OnLook(InputAction.CallbackContext context) { throw new System.NotImplementedException(); }

		public void OnFire(InputAction.CallbackContext context) { throw new System.NotImplementedException(); }
	}
}
