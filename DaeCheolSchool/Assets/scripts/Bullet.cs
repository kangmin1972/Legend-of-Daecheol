using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 hitPoint;

    public GameObject dirt;

    public GameObject blood;

    public int speed;

    //public AudioSource myShot;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce((hitPoint - transform.position).normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemyy")
        {
            Destroy(gameObject);
        }
    }
}
