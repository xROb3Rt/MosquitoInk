using UnityEngine;
using System.Collections;

public class Pelota : MonoBehaviour {
    public Rigidbody2D bola;
	// Use this for initialization
	void Start () {
        bola.AddForce(new Vector2(Random.Range(-500,500), 2000));
        Destroy(this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "pintura")
        {
            Destroy(col.gameObject);
        }

    }
}
