using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player.Weapons.bullet
{
    public class Projectile : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        
        [SerializeField, Range(1,100)]public float damage;
        [SerializeField, Range(1,100)]public float critChance;
        [SerializeField, Range(1,100)]public float bloodyCritChance;
        [SerializeField]public float critMultiplier;
        [SerializeField]public float bloodyCritMultiplier;
        [SerializeField]public float life;
        [SerializeField]public bool destroyOnContact;
        
        private GameObject _camera;
        void Start()
        {
            StartCoroutine(MilliTimer());
            _camera = GameObject.FindGameObjectWithTag("MainCamera");
            _spriteRenderer = GetComponent<SpriteRenderer>();
            float pickRandomCrit = Random.Range(1, 100);
            if(pickRandomCrit <= critChance)
            {
                float pickRandomBloodyCrit = Random.Range(1, 100);
                if (pickRandomBloodyCrit <= bloodyCritChance)
                {
                    damage = damage * bloodyCritMultiplier;
                    _spriteRenderer.color = Color.teal;
                    damage = Mathf.RoundToInt(damage);
                }
                else
                {
                    damage = damage * critMultiplier;
                    _spriteRenderer.color = Color.red;
                    damage = Mathf.RoundToInt(damage);
                }
            }
        }

        private void Update()
        {
            if (transform.position.x > 12 + _camera.transform.position.x ||
                transform.position.x < -12 + _camera.transform.position.x ||
                transform.position.y > 5.5f + _camera.transform.position.y ||
                transform.position.y < -5.5f + _camera.transform.position.y||
                life < 0)
            {
                Destroy(gameObject);
            }
        }

        IEnumerator MilliTimer()
        {
            life -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(MilliTimer());
        }
    }
}
