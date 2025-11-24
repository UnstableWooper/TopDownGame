using UnityEngine;
using Controllers;

namespace Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        private Controller _controller;
        private WeaponType _currentWeapon;

        [SerializeField]private GameObject sword;
        [SerializeField]private GameObject gun;
        
        void Start()
        {
            _controller = GetComponent<Controller>();
            _currentWeapon = WeaponType.Gun;
        }
        void Update()
        {
            _currentWeapon = _controller.input.RetrieveWeaponSwitchInput();

            switch (_currentWeapon)
            {
                case WeaponType.Gun:
                    gun.SetActive(true);
                    sword.SetActive(false);
                    break;

                case WeaponType.Sword:
                    sword.SetActive(true);
                    gun.SetActive(false);
                    break;
            }
        }
    }

}
