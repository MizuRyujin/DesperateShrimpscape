using UnityEngine;

public class ShrimpShoot : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private float _force = 200f;

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
        numberOfHits = Physics.OverlapSphereNonAlloc(transform.position, 4f, hits, 6);
        if (numberOfHits > 1)
        {
            Debug.Log("Near pebble");
            _arrow?.SetActive(true);
            if (Input.GetButtonDown("Mouse0"))
            {
                hits[0].attachedRigidbody.MovePosition(transform.position);
                hits[0].attachedRigidbody.AddForce((Input.mousePosition.normalized - transform.position) * _force);
                _arrow?.SetActive(false);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
