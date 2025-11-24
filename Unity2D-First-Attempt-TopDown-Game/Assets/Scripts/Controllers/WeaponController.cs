using Controllers;
using Player;
using UnityEngine;

namespace Controllers
{
    [CreateAssetMenu(fileName = "WeaponController", menuName = "inputController/WeaponController")]
    public class WeaponController : InputController
    {
        private PlayerInputAction _playerInput;
        private int _shootPressed;
        private void OnEnable()
        {
            _playerInput = new PlayerInputAction();
            _playerInput.WeaponAttack.Enable();
            _playerInput.WeaponAttack.Attack.started += Attack;
        }
        
        private void Attack(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            _shootPressed = 1;
        }
        
        private void OnDisable()
        {
            _playerInput.WeaponAttack.Disable();
            _playerInput = null;
        }

        public override int RetrieveWeaponInput()
        {
            int attackThisFrame = _shootPressed;
            _shootPressed = 0;
            return attackThisFrame;
        }
        
        public override Vector2 RetrieveMoveInput()
        {
            return Vector2.zero;
        }
        
        public override WeaponType RetrieveWeaponSwitchInput()
        {
            return 0;
        }
    }
}
