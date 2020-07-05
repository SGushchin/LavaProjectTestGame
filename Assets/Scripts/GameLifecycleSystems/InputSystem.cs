using UnityEngine;

namespace LavaGame
{
    public class InputSystem : MonoBehaviour
    {
        private const int LEFT_MOUSE_BUTTON = 0;

        private void Update()
        {
            if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
            {
                Debug.Log("InputSystem: LMB button down");
                EventBus.LeftMouseButtonClick.Publish(Input.mousePosition);
            }
        }
    }
}