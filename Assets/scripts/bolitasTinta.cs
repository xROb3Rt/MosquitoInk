using UnityEngine;
using System.Collections;

public class bolitasTinta : MonoBehaviour {
    public MovimientoPersonaje persona;
    private bool toca=false;
    public Pintar pincel;
    public TextMesh marcador;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (toca == true)
        {
            transform.Translate(new Vector3(persona.transform.position.x - transform.position.x, (persona.transform.position.y+0.5f) - transform.position.y, 0) * Time.maximumDeltaTime);
        }

    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            toca = true;
            DestroyObject(this.gameObject, 0.2f);
            if (pincel.tinta < 150)
            {
                pincel.tinta++;
            }
            persona.puntos++;
            persona.puntos_totales++;
        }
        else
        {
            toca = false;
        }
    }
}
