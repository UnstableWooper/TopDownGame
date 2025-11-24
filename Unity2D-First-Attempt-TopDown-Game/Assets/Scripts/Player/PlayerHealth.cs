using System;
using System.Collections;
using Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField, Range(1, 100)] public int health;
        [SerializeField, Range(0, 10)] private float maxImmortality;

        [SerializeField, Range(1, 100)] public float timeTillDead;
        
        private SpriteRenderer _spriteRenderer;
        private HitReader _enemyHit;
        
        private float _immortalityTimer;
        private float _offset;
        private int _damage;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        void Update()
        {
            _immortalityTimer -= Time.deltaTime;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy") && _immortalityTimer < 0f)
            {
                _enemyHit = other.GetComponent<HitReader>();
                _damage = _enemyHit.damage;
                if (_damage > 0)
                {
                    health -= _damage;
                    _immortalityTimer = maxImmortality;
                    StartCoroutine(Visuals());
                    if (health <= 0) StartCoroutine(Dead());
                }
            }
        }
        
        IEnumerator Visuals()
        {
            while (_immortalityTimer > 0f)
            {
                _spriteRenderer.color = Color.black;
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.color = Color.white;
                yield return new WaitForSeconds(0.1f);
            }
        }

        IEnumerator Dead()
        {
            yield return new WaitForSeconds(timeTillDead);
            SceneManager.LoadScene(0);
        }
    }
}
