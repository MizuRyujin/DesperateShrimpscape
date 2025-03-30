using UnityEngine;

public class PlantLight : MonoBehaviour
{
    [SerializeField] private float _lightTimer;
    [SerializeField] private Light _light;
    private void Update()
    {
        if (_lightTimer >= 0f)
        {
            _lightTimer -= 1f * Time.deltaTime;
        }
    }

    public void LightUp()
    {

    }
}
