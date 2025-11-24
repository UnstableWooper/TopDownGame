using Unity;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript: MonoBehaviour
{ 
        private GameObject _player;

        void Start()
        {
                _player = GameObject.FindGameObjectWithTag("Player");
        }
        void Update()
        {
                transform.position = new Vector3(_player.transform.position.x, transform.position.y, -5);
        }
}