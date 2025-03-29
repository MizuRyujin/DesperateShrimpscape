using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStates _currentState;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _currentState = PlayerStates.PAUSED;
        Debug.Log(_currentState);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
