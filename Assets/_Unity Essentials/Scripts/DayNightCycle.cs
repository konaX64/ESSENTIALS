using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day Length Settings")]
    [Tooltip("Length of a full in-game day in real-world seconds.")]
    public float dayDurationInSeconds = 120f;

    [Header("Rotation Settings")]
    [Tooltip("Axis to rotate around. Usually X for a sun-like effect.")]
    public Vector3 rotationAxis = Vector3.right;

    private float degreesPerSecond;

    void Start()
    {
        if (dayDurationInSeconds <= 0f)
        {
            Debug.LogWarning("Day duration must be greater than 0. Setting to default (120 seconds).");
            dayDurationInSeconds = 120f;
        }

        // 360 degrees divided by the number of seconds in a full day
        degreesPerSecond = 360f / dayDurationInSeconds;
    }

    void Update()
    {
        float rotationThisFrame = degreesPerSecond * Time.deltaTime;
        transform.Rotate(rotationAxis, rotationThisFrame, Space.World);
    }

    // If you change the value in the Inspector during play mode
    void OnValidate()
    {
        if (dayDurationInSeconds > 0f)
        {
            degreesPerSecond = 360f / dayDurationInSeconds;
        }
    }
}
