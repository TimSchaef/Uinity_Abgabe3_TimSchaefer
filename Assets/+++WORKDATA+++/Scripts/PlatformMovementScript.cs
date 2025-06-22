using UnityEngine;

public class MovingPlatformUpAndDownWithPause : MonoBehaviour
{
    public float moveDistance = 3f;     // Wie weit nach oben (Meter)
    public float moveSpeed = 2f;        // Bewegungsgeschwindigkeit
    public float waitTime = 2f;         // Wartezeit an der Startposition (Sekunden)

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingUp = false;
    private bool waiting = true;
    private float waitTimer;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.up * moveDistance;
        waitTimer = waitTime;
    }

    void Update()
    {
        if (waiting)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0f)
            {
                waiting = false;
                movingUp = true;
            }

            return;
        }

        float step = moveSpeed * Time.deltaTime;

        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);

            if (transform.position == startPosition)
            {
                waiting = true;
                waitTimer = waitTime;
            }
        }
    }
}