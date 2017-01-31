using UnityEngine;
using System.Collections;

public class coche : MonoBehaviour
{
    public Rigidbody2D car;
    // Use this for initialization
    void Start()
    {
        car.AddForce(new Vector2(-6000f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        car.AddForce(new Vector2(-6000f, 0f));

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pintura")
        {
            Destroy(other.gameObject);
        }
    }
}
