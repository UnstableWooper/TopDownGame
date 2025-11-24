using Player;
using UnityEngine;

namespace Controllers
{
    [CreateAssetMenu(fileName = "PlayerController", menuName = "inputController/PlayerController")]
    
    public class PlayerController : InputController
    {
        private PlayerInputAction _playerInput;
        private WeaponType _currentWeapon;
        
        private bool _weaponSwitchTriggered;
        // Update is called once per frame
        private void OnEnable()
        {
            _playerInput = new PlayerInputAction();
            _playerInput.PlayerMovement.Enable();
            _playerInput.PlayerMovement.WeaponSwitch.started += WeaponSwitch;

            _currentWeapon = WeaponType.Gun;    
        }
        private void OnDisable()
        {
            _playerInput.PlayerMovement.Disable();
            _playerInput.PlayerMovement.WeaponSwitch.started -= WeaponSwitch;
            _playerInput = null;
        }
        
        private void WeaponSwitch(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            
            _currentWeapon = _currentWeapon == WeaponType.Gun ? WeaponType.Sword : WeaponType.Gun;
            _weaponSwitchTriggered = true;
        }
        

        
        public override Vector2 RetrieveMoveInput()
        {
            return _playerInput.PlayerMovement.Move.ReadValue<Vector2>();
        }

        public override int RetrieveWeaponInput()
        {
            throw new System.NotImplementedException();
        }

        public override WeaponType RetrieveWeaponSwitchInput()
        {
            if (_weaponSwitchTriggered)
            {
                _weaponSwitchTriggered = false;
                return _currentWeapon;
            }
            return _currentWeapon;
        }
    }
}

