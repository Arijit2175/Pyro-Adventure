using UnityEngine;

public class DayNightRotation : MonoBehaviour
{
    public float dayLengthInSeconds = 60f;
    private float rotationSpeed;

    void Start()
    {
        rotationSpeed = 360f / dayLengthInSeconds;
    }

    void Update()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}