using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mosquito : MonoBehaviour {
    public float velocidad;
    public GameObject mosquito;
    public MovimientoPersonaje personaje;
    public Rigidbody2D mosq;
    public CircleCollider2D enemyColid;
    public GameObject[] pint;
    public int vidaMosq;
    public Image barSalud;
    public Image bartintaMosq;
    public Pintar pincel;
    public int tintaMosq = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
     
        pint = GameObject.FindGameObjectsWithTag("pintura");
        comportaMosquito();
        CompruebaVida();
        modificarBarra();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pintura")
        {
            Destroy(other.gameObject);
            if (tintaMosq < 30)
            {
                tintaMosq++;
            }
        }
        if (other.tag == "golpe")
        {
            vidaMosq--;
        } 
    }

    void comportaMosquito(){
        if (pint.Length >= 1 && tintaMosq<30)
        {
            float vel = velocidad / pint.Length;
            for (int i = 0; i < pint.Length; i++)
            {
                if (pint[0].transform.position.x < mosquito.transform.position.x)
                {
                    transform.localScale = new Vector2(-1, 1);

                    if (mosquito.transform.position.y > pint[0].transform.position.y)
                    {
                        transform.position = transform.position + new Vector3(-vel, -vel) * Time.deltaTime;
                    }
                    if (mosquito.transform.position.y < pint[0].transform.position.y)
                    {
                        transform.position = transform.position + new Vector3(-vel, vel, 0f) * Time.deltaTime;
                    }
                }
                if (pint[0].transform.position.x > mosquito.transform.position.x)
                {
                    transform.localScale = new Vector2(1, 1);

                    if (mosquito.transform.position.y > pint[0].transform.position.y)
                    {
                        transform.position = transform.position + new Vector3(vel, -vel, 0f) * Time.deltaTime;
                    }
                    if (mosquito.transform.position.y < pint[0].transform.position.y)
                    {
                        transform.position = transform.position + new Vector3(vel, vel, 0f) * Time.deltaTime;
                    }
                }
            }
        }
        else
        {

            if (mosq.position.x > personaje.rb.position.x)
            {
                transform.localScale = new Vector2(-1,1);

                if (mosq.position.y > personaje.rb.position.y+0.5f)
                {
                    transform.position = transform.position + new Vector3(-velocidad, -velocidad, 0f) * Time.deltaTime;
                }
                if (mosq.position.y < personaje.rb.position.y+0.5f)
                {
                    transform.position = transform.position + new Vector3(-velocidad, velocidad, 0f) * Time.deltaTime;
                }
            }
            if (mosq.position.x < personaje.rb.position.x)
            {
                transform.localScale = new Vector2(1, 1);

                if (mosq.position.y > personaje.rb.position.y+0.5f)
                {
                    transform.position = transform.position + new Vector3(velocidad, -velocidad, 0f) * Time.deltaTime;
                }
                if (mosq.position.y < personaje.rb.position.y+0.5f)
                {
                    transform.position = transform.position + new Vector3(velocidad, velocidad, 0f) * Time.deltaTime;
                }
            }
        }

    }

    void CompruebaVida()
    {
        if (vidaMosq < 1)
        {   
            Destroy(mosquito);
            pincel.tinta += tintaMosq;
        }
    }
    void modificarBarra()
    {
        barSalud.fillAmount = (float)vidaMosq/300 ;
        bartintaMosq.fillAmount = (float)tintaMosq / 30;
    }   
}