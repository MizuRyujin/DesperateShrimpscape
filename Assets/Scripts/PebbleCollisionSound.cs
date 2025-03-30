using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PebbleCollisionSound : MonoBehaviour
{
    [SerializeField] EventReference _pebbleSound;
    EventInstance _event;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Debug.Log("pebble hit wall");
            _event = RuntimeManager.CreateInstance(_pebbleSound);
            RuntimeManager.AttachInstanceToGameObject(_event, gameObject);
            _event.start();
        }
    }
}
