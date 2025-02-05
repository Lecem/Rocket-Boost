using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
      if (Keyboard.current.escapeKey.isPressed)
      {
        Debug.Log("Esc key is was pressed");
        Application.Quit();
      } 
    }
}
