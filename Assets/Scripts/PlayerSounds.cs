using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] EventReference _moveSound;
    EventInstance _event;

    public void MoveNoise(int noiseLevel)
    {
        _event = RuntimeManager.CreateInstance(_moveSound);
        RuntimeManager.AttachInstanceToGameObject(_event, gameObject);
        Debug.Log("Noise Lvl:" + noiseLevel);
        _event.setParameterByName("Noise_Level", noiseLevel);
        _event.start();
    }
}
