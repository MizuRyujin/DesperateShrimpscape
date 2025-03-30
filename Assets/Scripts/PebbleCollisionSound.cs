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
            int nHits;
            Collider[] result = new Collider[10];
            nHits = Physics.OverlapSphereNonAlloc(transform.position, 10f, result, LayerMask.GetMask("Plant"));
            if (nHits > 0)
            {
                foreach (Collider col in result)
                {
                    col.gameObject.GetComponent<PlantLight>();
                }
            }
        }
    }
}
