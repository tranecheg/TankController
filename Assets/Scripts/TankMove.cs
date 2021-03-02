using UnityEngine;

public class TankMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speedMove = 20f, speedRot = 50f, xRot;
    public static float verPos, horPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verPos = Input.GetAxis("Vertical");
        horPos = Input.GetAxis("Horizontal");
        xRot = transform.eulerAngles.x;

        if (xRot >= 270)
            xRot -= 360;

            if (verPos != 0 && rb.velocity.magnitude < 10)
            {
                rb.AddForce(transform.forward * verPos * speedMove);
                if(xRot > -10)
                   transform.Rotate(Vector3.left * Time.deltaTime * 15f, Space.Self);
            }
           
            if (horPos != 0)
                transform.Rotate(Vector3.up * horPos * Time.deltaTime * speedRot, Space.World);
            
               
            if(verPos == 0 && xRot !=0)
            {
                rb.velocity = Vector3.zero;
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.Euler(0, transform.eulerAngles.y, 0), Time.deltaTime * 2);
                transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            }
        
    }
}
