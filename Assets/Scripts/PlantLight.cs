using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlantLight : MonoBehaviour
{
    [SerializeField] EventReference _plantSound;
    [SerializeField] private float _lightTimer;
    [SerializeField] private Light _light;
    EventInstance _event;
    float _timer;
    bool lightUp;

    private void Awake()
    {
        _timer = _lightTimer;
        lightUp = false;
    }
    private void Update()
    {
        if (lightUp)
        {
            _lightTimer -= 1f * Time.deltaTime;

            if (_timer <= 0f)
            {
                Debug.Log("Time's up");
                lightUp = false;
                _light.enabled = false;
            }
        }
    }

    public void LightUp()
    {
        if (lightUp == false)
        {
            lightUp = true;
            _light.enabled = true;
            _timer = _lightTimer;
            _event = RuntimeManager.CreateInstance(_plantSound);
            RuntimeManager.AttachInstanceToGameObject(_event, gameObject);
            _event.start();
        }
    }
}
