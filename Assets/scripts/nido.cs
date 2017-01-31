using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class nido : MonoBehaviour {

    public float posX;
    public float posY;
    public GameObject nid;
    public int time;
    public float velocidad;
    public int vidaNido = 1000;
    public Pintar pincel;
    public GameObject camaraGO;
    public PolygonCollider2D colisionador;
    public MovimientoPersonaje personaje;
    public Image barVida;

	void Start () {
        posX = transform.position.x;
        posY= transform.position.y;
	}

	void Update () {
       if (time >= 500) 
        {
            time = 0;
            posX = Random.Range(124f, 133f);
            posY = Random.Range(-3f, 4f);
        }
        time++;

        moverNido();
        if (vidaNido < 1) {
            Destroy(nid);
            personaje.puntos += 20;
            personaje.puntos_totales += 20;
            camaraGO.SetActive(true);//temporalmente(en un futuro poner fin de nivel)
        }
        modificarBarra();
    }

    void moverNido()
    {
        if (transform.position.x > posX)
        {
            if (transform.position.y > posY)
            {
                transform.position = transform.position + new Vector3(-velocidad, -velocidad, 0f) * Time.deltaTime;
            }
            if (transform.position.y < posY)
            {
                transform.position = transform.position + new Vector3(-velocidad, velocidad, 0f) * Time.deltaTime;
            }
        }
        if (transform.position.x < posX)
        {
            if (transform.position.y > posY)
            {
                transform.position = transform.position + new Vector3(velocidad, -velocidad, 0f) * Time.deltaTime;
            }
            if (transform.position.y < posY)
            {
                transform.position = transform.position + new Vector3(velocidad, velocidad, 0f) * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.tag == "arma" && pincel.atacar)
        {
            vidaNido--;
        }
    }
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.tag == "arma" && pincel.atacar)
        {
            vidaNido--;
        }
    }
    void modificarBarra()
    {
        barVida.fillAmount = (float)vidaNido / 1000;
    }
}
