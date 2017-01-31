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
    private Animator animador;
    public int estado;
    public nido nido;

    // Use this for initialization
    void Start () {
        animador = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
     
        pint = GameObject.FindGameObjectsWithTag("pintura");
        comportaMosquito();
        CompruebaVida();
        modificarBarra();
        if (nido.vidaNido < 900) {
            estado = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pintura")
        {
            Destroy(other.gameObject);
            if (tintaMosq < 90)
            {
                tintaMosq++;
            }
        }
        if (other.tag == "golpe")
        {
            vidaMosq--;
        }

        if (other.tag == "Player")
        {
            personaje.vitalidad--;
        }
        if (other.tag == "arma"&& pincel.atacar)
        {
            vidaMosq--;
            animador.SetBool("golpeado", true);
        }
        //else { animador.SetBool("golpeado", false); }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "arma" && pincel.atacar)
        {
            vidaMosq--;
            animador.SetBool("golpeado", true);
            if (personaje.transform.localPosition.x > transform.localPosition.x)
            {
                transform.localPosition = transform.position + new Vector3(-1, 0, 0) * Time.maximumDeltaTime;
            }
            if (personaje.transform.localPosition.x < transform.localPosition.x)
            {
                transform.localPosition = transform.position + new Vector3(1, 0, 0) * Time.maximumDeltaTime;
            }
        }
        //else { animador.SetBool("golpeado", false); }
        if (other.tag == "Player")
        {
            personaje.vitalidad--;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "arma")
        {
            animador.SetBool("golpeado", false);
            
        }
    }

    void comportaMosquito(){
        if (estado == 0)
        {
            if (pint.Length >= 1 && tintaMosq < 90)
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
                    transform.localScale = new Vector2(-1, 1);

                    if (mosq.position.y > personaje.rb.position.y + 0.5f)
                    {
                        transform.position = transform.position + new Vector3(-velocidad, -velocidad, 0f) * Time.deltaTime;
                    }
                    if (mosq.position.y < personaje.rb.position.y + 0.5f)
                    {
                        transform.position = transform.position + new Vector3(-velocidad, velocidad, 0f) * Time.deltaTime;
                    }
                }
                if (mosq.position.x < personaje.rb.position.x)
                {
                    transform.localScale = new Vector2(1, 1);

                    if (mosq.position.y > personaje.rb.position.y + 0.5f)
                    {
                        transform.position = transform.position + new Vector3(velocidad, -velocidad, 0f) * Time.deltaTime;
                    }
                    if (mosq.position.y < personaje.rb.position.y + 0.5f)
                    {
                        transform.position = transform.position + new Vector3(velocidad, velocidad, 0f) * Time.deltaTime;
                    }
                }
            }
        }

    }

    void CompruebaVida()
    {
        if (vidaMosq < 1)
        {   
            Destroy(mosquito);
            personaje.puntos+=10;
            personaje.puntos_totales += 10;
            pincel.tinta += tintaMosq;
            if (pincel.tinta>150)
            {
                pincel.tinta = 150;
            }
        }
    }
    void modificarBarra()
    {
        barSalud.fillAmount = (float)vidaMosq/50 ;
        bartintaMosq.fillAmount = (float)tintaMosq / 90;
    }   
}