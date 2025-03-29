using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStates _currentState;
    private Rigidbody _rb;
    private Collider _selfCollider;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _currentState = PlayerStates.VISIBLE;

        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;

        _selfCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    private void Update()
    {
        PushForward();
        Hide();
    }
    private void FixedUpdate()
    {
        RotatePlayer();
    }

    private void Hide()
    {
        if (Input.GetKey(KeyCode.C))
        {
            _currentState = PlayerStates.HIDDEN;
            _selfCollider.enabled = false;
        }
        else
        {
            _currentState = PlayerStates.VISIBLE;
            _selfCollider.enabled = true;
        }
    }

    private void RotatePlayer()
    {
        throw new NotImplementedException();
    }

    private void PushForward()
    {
        throw new NotImplementedException();
    }
}
