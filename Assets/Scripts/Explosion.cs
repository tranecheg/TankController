using UnityEngine;


public class Explosion : MonoBehaviour
{

    private Rigidbody rb;
    private GameObject bulletPos;
    private float force = 50f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletPos = GameObject.Find("bulletPos");
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
       rb.AddForce(bulletPos.transform.forward * force);
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Box"))
        {
            if(col.GetComponent<Rigidbody>()!=null)
                col.GetComponent<Rigidbody>().AddExplosionForce(100f, transform.position, 50f, 10f);

            rb.isKinematic = true;
            GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 4f);
        }
        
    }

}
