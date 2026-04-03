using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - Camera.main.transform.position;
        direction.y = 0;

        float angle = Vector3.SignedAngle(Camera.main.transform.forward, direction, Vector3.up);

        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}