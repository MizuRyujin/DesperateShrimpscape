using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int _MAX_NOISE_LEVEL = 3;
    private const int _MIN_NOISE_LEVEL = 0;
    private const float _MAX_SILENCE_COOLDOWN = 7f;

    [SerializeField] private float _impulseForce = default;
    private PlayerSounds _sounds;

    private PlayerStates _currentState = default;
    private Rigidbody _rb = default;
    private Collider _selfCollider = default;
    private int _noiseLevel = default;
    private float _silenceCooldown = default;
    private Vector3 _cursorPos = default;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _noiseLevel = _MIN_NOISE_LEVEL;
        _currentState = PlayerStates.VISIBLE;

        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;

        _selfCollider = GetComponent<Collider>();

        _sounds = GetComponentInChildren<PlayerSounds>();
    }

    // Update is called once per frame
    private void Update()
    {
        PushForward();
        Hide();
        SoundCooldown();
        GetCursorPos();
        RotatePlayer();

        //ShootPebble();
    }

    private void ShootPebble()
    {
        if (Input.GetButtonDown("Mouse 0"))
        {
            Debug.Log("Should shoot");
        }
        // _sounds.GunSound();
    }

    private void GetCursorPos()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit result;
        if (Physics.Raycast(mouseRay, out result))
        {
            _cursorPos = result.point;
        }
    }

    private void PushForward()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _noiseLevel = ++_noiseLevel > 3 ? _MAX_NOISE_LEVEL : _noiseLevel;
            _rb.AddForce(transform.forward * _impulseForce * _noiseLevel);
            IncreaseCooldownTime(2f);
            Debug.Log("Player noise lvl: " + _noiseLevel);
            _sounds.MoveNoise(_noiseLevel);
        }
    }

    private void IncreaseCooldownTime(float value)
    {
        _silenceCooldown = _silenceCooldown > _MAX_SILENCE_COOLDOWN ?
                            _MAX_SILENCE_COOLDOWN : _silenceCooldown += value;
    }

    /// <summary>
    /// Change player state to hidden and disable collider so it wont be found
    /// </summary>
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
    /// <summary>
    /// Decrease noise level over time
    /// </summary>
    private void SoundCooldown()
    {
        if (_silenceCooldown > 0f)
        {
            _silenceCooldown -= 1f * Time.deltaTime;
            if (_silenceCooldown < 4f && _silenceCooldown > 2f)
            {
                _noiseLevel = 2;
            }
            else if (_silenceCooldown < 2f && _silenceCooldown > 0f)
            {
                _noiseLevel = 1;
            }
            else
            {
                _silenceCooldown = 0f;
                _noiseLevel = _MIN_NOISE_LEVEL;
            }
        }
    }

    private void RotatePlayer()
    {
        transform.LookAt(_cursorPos);
    }
}
