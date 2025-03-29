using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
