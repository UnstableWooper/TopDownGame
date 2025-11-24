using System;
using System.Collections;
using Player.Weapons.bullet;
using UI;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Score = UI.Score;


namespace Enemy
{
    public class HitReader : MonoBehaviour
    {
        [SerializeField] public int health;
        [SerializeField] public int damage;
        [SerializeField] public int pointValue;
        
        private Score _score;
        private SpriteRenderer _spriteRenderer;
        private Projectile _projectile;
        private GameObject _gameManager;
        private Color _color;
        
        private float _damage;

        void Start()
        {
            _gameManager = GameObject.FindGameObjectWithTag("GameManager");
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _score = _gameManager.GetComponent<Score>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Projectile"))
            {
                _projectile = other.GetComponent<Projectile>();
                SpriteRenderer color = other.GetComponent<SpriteRenderer>();
                _color = color.color;
                Projectile projectile = other.GetComponent<Projectile>();
                _damage = projectile.damage;
                health -= Mathf.RoundToInt(_damage);
                StartCoroutine(Visuals());
                if (health <= 0)
                {
                    _score.AddPoints(pointValue);
                    Destroy(gameObject);
                }
                
                if (_projectile.destroyOnContact)
                {
                    Destroy(other.gameObject);
                }
            }
        }

        IEnumerator Visuals()
        {
            for (int i = 0; i <= 1; i++)
            {
                if(_color ==  Color.white) _color = Color.black;
                _spriteRenderer.color = _color;
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.color = Color.white;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
