using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWave : MonoBehaviour
{
    [SerializeField] private float velocity;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            SceneManager.LoadScene(0);
        }
    }
}
