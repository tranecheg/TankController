using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bulletPref, bulletTarget, startShot;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPref, bulletTarget.transform.position, Quaternion.identity);

            GameObject exp = Instantiate(startShot, bulletTarget.transform.position, Quaternion.identity);
            exp.transform.SetParent(bulletTarget.transform);
            rb.AddForce(-transform.forward * 5f, ForceMode.Impulse);
        }

        
    }
}
