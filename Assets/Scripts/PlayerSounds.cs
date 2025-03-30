using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] EventReference _moveSound;
    [SerializeField] EventReference _gunSound;
    [SerializeField] private GameObject _trail;
    [SerializeField] private GameObject _burst;
    [SerializeField] private GameObject _soundVFX;
    EventInstance _event;


    public void MoveNoise(int noiseLevel)
    {
        _event = RuntimeManager.CreateInstance(_moveSound);
        RuntimeManager.AttachInstanceToGameObject(_event, gameObject);
        _event.setParameterByName("Noise_Level", noiseLevel);
        _event.start();
        CreateAndPlayVFX();

    }
    public void GunSound()
    {
        _event = RuntimeManager.CreateInstance(_gunSound);
        RuntimeManager.AttachInstanceToGameObject(_event, gameObject);
        _event.start();
    }

    private void CreateAndPlayVFX()
    {
        GameObject soundVFX = Instantiate(_soundVFX, transform.position, Quaternion.Euler(90, 0, 0));
        // GameObject trail = Instantiate(_trail, transform.position, Quaternion.Inverse(transform.rotation));
        // GameObject burst = Instantiate(_burst, transform.position, Quaternion.Inverse(transform.localRotation));

        _burst.GetComponent<ParticleSystem>().Play();
        _trail.GetComponent<ParticleSystem>().Play();
        Animator anim = soundVFX.GetComponent<Animator>();
        anim.Play("SoundWave");
    }
}
