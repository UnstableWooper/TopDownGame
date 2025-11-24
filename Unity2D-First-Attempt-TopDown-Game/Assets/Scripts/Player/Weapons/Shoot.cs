using System.Collections.Generic;
using System.Collections;
using Controllers;
using UnityEngine;

namespace Player.Weapons
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField]public GameObject bullet;
        [SerializeField] public float accuracySpread; //Vector2 to get the 2 numbers min and max
        [SerializeField, Range(0, 10f)] public int shots = 4;
        [SerializeField, Range(0, 4f)] public float shootCooldown;
        [SerializeField]private float offset = 90;
        
        private Controller _controller;
        
        private float _shotCooldownTimer;
        private float _shootRounds;
        private bool _desiredShoot;
        private void Awake()
        {
            _controller = GetComponent<Controller>();
        }
        private void Update()
        {
            _desiredShoot = _controller.input.RetrieveWeaponInput() == 1;
            _shotCooldownTimer -= Time.deltaTime;
            
            if (_desiredShoot && _shotCooldownTimer < 0)
            {
                for (int i = 0; i < shots; i++)
                { 
                    _shotCooldownTimer = shootCooldown;
                    Fire();
                }
            }
        }
        private void Fire()
        {
            Quaternion realOffset = Quaternion.Euler(0,0,offset);
            Quaternion randomAccuracy = Quaternion.Euler(0f, 0f, Random.Range(-accuracySpread, accuracySpread));
            Instantiate(bullet,transform.position, transform.rotation * randomAccuracy);
        }
    }
}
