using System.Collections;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy.TheifDasher
{
    public class ThiefChaser : MonoBehaviour
    {
        [SerializeField, Range(1, 100)] public float dashForce;
        [SerializeField, Range(0, 20)] public float attackCooldown;
        private Transform _playerPos;
        private Rigidbody2D _rigidbody;
        private Vector2 _velocity;
        
        private GameObject _player;

        void Start()
        {
            StartCoroutine(Dash());
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerPos = _player.GetComponent<Transform>();
        }
        void Update()
        {
              _rigidbody.AddForce(Vector2.right * 0.01f , ForceMode2D.Impulse);
            Vector2 direction = _playerPos.position - transform.position;

            // Calculate angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply rotation (subtract 90 if your sprite faces "up" by default)
            transform.rotation = Quaternion.Euler(0, 0, angle + 270);
        }
        
        IEnumerator Dash()
        {
            
            _velocity = _rigidbody.linearVelocity;
            
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, dashForce * Time.deltaTime);
            
            _rigidbody.linearVelocity = _velocity;
            
            yield return new WaitForSeconds(attackCooldown);
            StartCoroutine(Dash());
        }
    }
}
