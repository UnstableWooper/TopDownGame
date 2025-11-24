using TreeEditor;
using UnityEngine;

namespace Enemy.ThiefChaser
{
    public class ThiefChaser : MonoBehaviour
    {
        [SerializeField, Range(1, 20)] public float speed;
        private Transform _playerPos;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private Vector2 _velocity;
        
        private GameObject _player;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerPos = _player.GetComponent<Transform>();
        }
        void Update()
        {
            Vector2 direction = _playerPos.position - transform.position;

            // Calculate angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply rotation (subtract 90 if your sprite faces "up" by default)
            transform.rotation = Quaternion.Euler(0, 0, angle + 270);
        }
        
        void FixedUpdate()
        {
            _velocity = _rigidbody.linearVelocity;
            
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
            
            _rigidbody.linearVelocity = _velocity;
        }
    }
}
