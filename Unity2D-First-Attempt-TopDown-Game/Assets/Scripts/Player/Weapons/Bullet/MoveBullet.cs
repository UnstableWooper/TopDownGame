using UnityEngine;

namespace Player.Weapons.bullet
{
    public class MoveBullet : MonoBehaviour
    {
        [SerializeField,Range(1,400)] public float speed;
        private Rigidbody2D _rigidbody;
        private Vector2 _velocity;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        { 
            _rigidbody.MovePosition(_rigidbody.position + (Vector2)(transform.right * speed * Time.fixedDeltaTime));
        }
    }
}
