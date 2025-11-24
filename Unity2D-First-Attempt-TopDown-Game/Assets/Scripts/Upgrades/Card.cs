using System;
using Player;
using Player.Weapons;
using Player.Weapons.bullet;
using UnityEngine;

namespace Upgrades
{
    public class Card:MonoBehaviour
    {
        #region Stats

        private GameObject _player;
        private GameObject _pistol;
        private GameObject _shotgun;
        [SerializeField] private GameObject pistolBullet;
        [SerializeField] private GameObject shotgunShell;
        
        private Vector2 _maxPlayerSpeed;
        private float _playerAcceleration;
        private float _pistolAccuracy; 
        private float _shotgunAccuracy;
        private float _pistolShootCooldown;
        private float _shotgunShootCooldown;
        private float _pistolBulletSpeed;
        private float _shotgunShellSpeed; 
        private float _shotgunShellDamage;
        private float _pistolBulletDamage;
        private float _shotgunShellCritChance;
        private float _pistolBulletCritChance;
        private float _shotgunShellBloodyCritChance;
        private float _pistolBulletBloodyCritChance;
        private float _shotgunShellCritMultiplier;
        private float _pistolBulletCritMultiplier;
        private float _shotgunShellBloodyCritMultiplier;
        private float _pistolBulletBloodyCritMultiplier;
        private float _shotgunShellLife;//How Long It stays on the screen aka when it gets destroyed for being in the map for too long.
        private float _pistolBulletLife;//How Long It stays on the screen aka when it gets destroyed for being in the map for too long.
        
        private int _shotgunShots;
        private int _pistolShots;
                
        private Movement _movement;
        private Shoot _pistolShoot;
        private Shoot _shotgunShoot;
        private MoveBullet _pistolBulletMove;
        private MoveBullet _shotgunShellMove;
        private Projectile _pistolBulletProjectile;
        private Projectile _shotgunShellProjectile;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            
            Shoot[] shooters = GameObject.FindObjectsByType<Shoot>(FindObjectsSortMode.None);

            _pistol = null;
            _shotgun = null;

            foreach (var shooter in shooters)
            {
                if (shooter.bullet == pistolBullet)
                    _pistol = shooter.gameObject;

                if (shooter.bullet == shotgunShell)
                    _shotgun = shooter.gameObject;
            }
            Debug.Log(_pistol + " , " + _shotgun);

        }

        private void Start()
        { 
            _movement = _player.GetComponent<Movement>();
            _pistolShoot = _pistol.GetComponent<Shoot>();
            _shotgunShoot = _shotgun.GetComponent<Shoot>();
            _pistolBulletProjectile = _pistol.GetComponent<Projectile>();
            _shotgunShellProjectile = _shotgun.GetComponent<Projectile>();
            _pistolBulletMove = _pistol.GetComponent<MoveBullet>();
            _shotgunShellMove = _shotgun.GetComponent<MoveBullet>();
            _pistolBulletSpeed = _pistolBulletMove.speed;
            _shotgunShellSpeed = _shotgunShellMove.speed;
            _maxPlayerSpeed = _movement.maxSpeed;
            _playerAcceleration = _movement.acceleration;
            _pistolAccuracy = _pistolShoot.accuracySpread;
            _shotgunAccuracy = _shotgunShoot.accuracySpread;
            _pistolShootCooldown = _pistolShoot.shootCooldown;
            _shotgunShootCooldown = _shotgunShoot.shootCooldown;
            _shotgunShellDamage = _pistolBulletProjectile.damage;
            _pistolBulletDamage = _shotgunShellProjectile.damage;
            _shotgunShellCritChance = _pistolBulletProjectile.critChance;
            _pistolBulletCritChance = _shotgunShellProjectile.critChance;
            _shotgunShellBloodyCritChance = _pistolBulletProjectile.bloodyCritChance;
            _pistolBulletBloodyCritChance = _shotgunShellProjectile.bloodyCritChance;
            _shotgunShellCritMultiplier = _pistolBulletProjectile.critMultiplier;
            _pistolBulletCritMultiplier = _shotgunShellProjectile.critMultiplier;
            _shotgunShellBloodyCritMultiplier = _pistolBulletProjectile.bloodyCritMultiplier;
            _pistolBulletBloodyCritMultiplier = _shotgunShellProjectile.bloodyCritMultiplier;
            _shotgunShellLife = _pistolBulletProjectile.life;
            _pistolBulletLife = _shotgunShellProjectile.life;
        }

        #endregion
    }
}