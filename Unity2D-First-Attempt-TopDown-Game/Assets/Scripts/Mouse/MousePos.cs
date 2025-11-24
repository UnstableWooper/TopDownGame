using UnityEngine;
using UnityEngine.InputSystem;

namespace Mouse
{
    public class MousePos : MonoBehaviour
    {
        [SerializeField] private GameObject cursor;
        private Camera _mainCamera;

        void Awake()
        {
            _mainCamera = Camera.main;
        }

        void Update()
        {
            // Read mouse position in screen coordinates (pixels)
            Vector2 screenPosition = UnityEngine.InputSystem.Mouse.current.position.ReadValue();

            // Convert it to world coordinates
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, _mainCamera.nearClipPlane));

            // Set the cursor's position (z=0 to keep it in 2D)
            cursor.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);
        }
    }
}