using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpHeight = 2f;
    public float jumpTime = 0.65f;

    private bool isJumping = false;
    private float timeElapsed = 0f;
    private Vector3 startPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            timeElapsed = 0f;
            startPosition = transform.position;
        }

        if (isJumping)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / jumpTime;

            // Clamp t between 0 and 1
            t = Mathf.Clamp01(t);

            // Parabola: goes from 0 to jumpHeight and back to 0
            float height = 2 * jumpHeight * t * (1 - t);
            transform.position = new Vector3(startPosition.x, startPosition.y + height, startPosition.z);

            if (t >= 1f)
                isJumping = false;
        }
    }
}
