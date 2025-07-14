using UnityEngine;
 
public class Sim1 : MonoBehaviour
{
    public float speed = 5f;
    //public float jump = 5f;
    //private Rigidbody rb;
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
     float horizontalInput =Input.GetAxis("Horizontal");
     float verticalInput = Input.GetAxis("Vertical");
     if (horizontalInput !=0)
     {
     SidewayMovement(horizontalInput);  
     }
     if (verticalInput !=0)
     {
     AxialMovement(verticalInput);
     }
    //  if (Input.GetKeyDown(KeyCode.Space))
    //  {
    //  transform.Translate(Vector3.up * jump);
    //  }
    }

public void SidewayMovement(float direction)
{
    transform.Translate(Vector3.right *direction *speed *Time.deltaTime);
}
public void AxialMovement(float direction)
{
    transform.Translate(Vector3.forward *direction *speed *Time.deltaTime);
}
}

