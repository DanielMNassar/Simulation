using UnityEngine;

public class RaycastInspector : MonoBehaviour
{
    public float rayDistance = 100f;
    public Color rayColor = Color.red;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate left/right with A and D
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        // Create a ray pointing forward
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, rayColor);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            Debug.Log($"Hit Object: {hit.collider.name}, Tag: {hit.collider.tag}");

            if (hit.collider.CompareTag("Target"))
            {
                Renderer rend = hit.collider.GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material.color = Color.green;
                }
            }
        }
    }
void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
}

}

