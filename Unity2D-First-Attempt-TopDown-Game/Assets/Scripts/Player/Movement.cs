using Controllers;
using Player.Weapons;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace  Player
{
    
public class Movement : MonoBehaviour
{
    [SerializeField] public Vector2 maxSpeed = new Vector2(7, 7);
    [SerializeField, Range(0f, 100f)] public float acceleration = 35f;
    [SerializeField] private WeaponDirection weaponDirection;

    
    private Controller _controller;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private GameObject _cursor;
    
    private Vector2 _velocity;
    private Vector2 _direction;
    private Vector2 _desiredVelocity;
    private float _maxSpeedChange;
    void Awake()
    {
        _controller = GetComponent<Controller>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
        
    // Update is called once per frame
    void Update()
    {
        _direction = new Vector2(_controller.input.RetrieveMoveInput().x, _controller.input.RetrieveMoveInput().y);
        _desiredVelocity = new Vector2(maxSpeed.x * _direction.x , maxSpeed.y * _direction.y);
    }

    void FixedUpdate()
    {
        //transform.rotation = Quaternion.LookRotation(_cursor.transform.position); Doesn't work
        
        _velocity = _rigidbody.linearVelocity;
        _maxSpeedChange = acceleration * Time.deltaTime;
        _velocity = new Vector2(Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange)
            ,Mathf.MoveTowards(_velocity.y, _desiredVelocity.y, _maxSpeedChange)); 
        
        _rigidbody.linearVelocity = _velocity;
    }
}

}
