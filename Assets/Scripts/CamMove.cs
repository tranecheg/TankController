using UnityEngine;

public class CamMove : MonoBehaviour
{
    private float xMin = -5f, xMax = 4f, yMin = -35f, yMax = 35f;
    private Quaternion camRot;
    private void Start()
    {
        camRot = transform.localRotation;
    }
    private void Update()
    {
       
        camRot.x -= Input.GetAxis("Mouse Y");
        camRot.y += Input.GetAxis("Mouse X");

        camRot.x = Mathf.Clamp(camRot.x, xMin, xMax);
        camRot.y = Mathf.Clamp(camRot.y, yMin, yMax);


        transform.localRotation = Quaternion.Slerp(transform.localRotation, 
            Quaternion.Euler(camRot.x * 0.75f, camRot.y * 0.75f, camRot.z), Time.deltaTime * 2f);

    }

}
