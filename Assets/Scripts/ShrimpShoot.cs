using UnityEngine;

public class ShrimpShoot : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private float _force = 200f;
    [SerializeField] private PlayerSounds _sounds;

    private void Awake()
    {
        _arrow?.SetActive(false);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        int numberOfHits = 0;
        Collider[] hits = new Collider[10];
        numberOfHits = Physics.OverlapSphereNonAlloc(transform.position, 4f, hits, LayerMask.GetMask("Pebble"));
        if (numberOfHits >= 1)
        {
            _arrow?.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                hits[0].attachedRigidbody.AddForce(transform.parent.forward * _force);
                _arrow?.SetActive(false);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
