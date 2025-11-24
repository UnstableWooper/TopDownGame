using System;
using Player;
using UnityEngine;


namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private GameObject _player;
        
        private Animator _animator;
        
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerHealth = _player.GetComponent<PlayerHealth>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetInteger("Health", _playerHealth.health);
        }
    }
}
