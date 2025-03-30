using UnityEngine;

public class DestroyPrefabAfterTime : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void DestroyInstance() => Destroy(gameObject);
}
