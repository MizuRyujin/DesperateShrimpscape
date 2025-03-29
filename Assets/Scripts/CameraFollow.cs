using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;
    [SerializeField] private float _followSpeed = 5f;

    private void LateUpdate()
    {
        Vector3 moveDir = _playerPos.position - transform.position;
        moveDir.y = 0;
        // Debug.Log("MoveDir" + moveDir);
        // Debug.Log("MoveDir" + transform.position);
        transform.Translate(moveDir * _followSpeed * Time.deltaTime);
    }
}
