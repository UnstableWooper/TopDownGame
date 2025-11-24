using Mouse;
using UnityEngine;


namespace Player.Weapons  
{
    public class WeaponDirection : MonoBehaviour
    {
        [SerializeField, Range(0,360)] private float offset;

        public float Direction{private set; get;}
        
        private GameObject _cursor;
        
        
        void Start()
        {
            _cursor = GameObject.FindGameObjectWithTag("Cursor");
        }
        void Update()
        {
            float xDiff = _cursor.transform.position.x - transform.position.x;
            float yDiff = _cursor.transform.position.y - transform.position.y;
            
            float radians = Mathf.Atan2(yDiff, xDiff);
            float degrees = Mathf.Rad2Deg * radians;
            
            Direction = degrees + offset;
            
            transform.rotation = Quaternion.Euler(0, 0, Direction);
        }
    }
}

