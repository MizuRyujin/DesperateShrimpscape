using UnityEngine;

public class ShrimpMoveVFX
{
    private GameObject _trailVFX;
    private GameObject _bubbleBurstVFX;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="trailVFX"></param>
    /// <param name="burstVFX"></param>
    public ShrimpMoveVFX(GameObject trailVFX, GameObject burstVFX)
    {
        _trailVFX = trailVFX;
        _bubbleBurstVFX = burstVFX;
    }

    public void PlayTrailVFX(Vector3 pos)
    {
        GameObject trail = GameObject.Instantiate(_trailVFX, pos, Quaternion.identity);
        trail.GetComponent<ParticleSystem>().Play();
    }
    public void PlayBurstVFX(Vector3 pos)
    {
        GameObject burst = GameObject.Instantiate(_bubbleBurstVFX, pos, Quaternion.identity);
        burst.GetComponent<ParticleSystem>().Play();
    }
}
