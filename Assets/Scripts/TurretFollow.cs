using UnityEngine;

public class TurretFollow : MonoBehaviour
{
   
    private float mouseX, mouseY;
    public Transform turretTarget;
    
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        turretTarget.localPosition = new Vector3(Mathf.Clamp(mouseX, -10, 10), Mathf.Clamp(mouseY * 2, -7, 7), 20);
        transform.LookAt(turretTarget);
    }
    
}
