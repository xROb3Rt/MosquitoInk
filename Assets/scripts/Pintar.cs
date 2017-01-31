using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pintar : MonoBehaviour {
    public GameObject[] obj;
    public int tinta = 150;
    public int fuerza = 100;
    public Rigidbody2D puntero = new Rigidbody2D();
    public bool pressed = false;
    public bool pressedDerecho = false;
    public int colorPos = 0;
    public GameObject[] golpe;
    public GameObject[] golpes;
    public GameObject[] pinturas;
    public GameObject[] pinturitas;
    public Image barTinta;
    public Image barfuerza;
    public MovimientoPersonaje personaje;
    public bool atacar = false;
    Vector2 posAnterior = new Vector2(0,0);



    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame

	void Update () {
        Pressed();
        PressedDerecho();
        //SeguirPuntero();
        golpes = GameObject.FindGameObjectsWithTag("golpe");
        pinturitas = GameObject.FindGameObjectsWithTag("pinturas");
        DestruirGolpe();
        variacion_barra();
        movertinta();
        Destruirpinturitas();
        puntero.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Generar();


    }
    void Generar()
    {
        if (pressed && tinta>=1)
        {
            
            Instantiate(obj[colorPos], puntero.position, Quaternion.identity);
            Instantiate(obj[colorPos], (puntero.position + posAnterior) / 2, Quaternion.identity);
            Instantiate(obj[colorPos], (puntero.position+(puntero.position + posAnterior) / 2) / 2, Quaternion.identity);
            Instantiate(obj[colorPos], (posAnterior + (puntero.position + posAnterior) / 2) / 2, Quaternion.identity);
            if (Mathf.Sqrt(Mathf.Pow((puntero.position.x - posAnterior.x), 2) + Mathf.Pow((puntero.position.y - posAnterior.y), 2)) >= 1)
            {
                Instantiate(obj[colorPos], (posAnterior + (posAnterior + (puntero.position + posAnterior) / 2) / 2) / 2, Quaternion.identity);
                Instantiate(obj[colorPos], (puntero.position + (puntero.position + (puntero.position + posAnterior) / 2) / 2) /2, Quaternion.identity);
                Instantiate(obj[colorPos], (((puntero.position + posAnterior) / 2) + (posAnterior + (puntero.position + posAnterior) / 2) / 2) / 2, Quaternion.identity);
                Instantiate(obj[colorPos], (((puntero.position + posAnterior) / 2) + (puntero.position + (puntero.position + (puntero.position + posAnterior) / 2) / 2) / 2) / 2, Quaternion.identity);

                Instantiate(obj[colorPos], (((puntero.position + posAnterior) / 2) + (((puntero.position + posAnterior) / 2) + (posAnterior + (puntero.position + posAnterior) / 2) / 2) / 2) / 2, Quaternion.identity);
                Instantiate(obj[colorPos], (posAnterior + (posAnterior + (posAnterior + (puntero.position + posAnterior) / 2) / 2) / 2) / 2, Quaternion.identity);
                Instantiate(obj[colorPos], (puntero.position + (puntero.position + (puntero.position + (puntero.position + posAnterior) / 2) / 2) / 2) /2, Quaternion.identity);
                Instantiate(obj[colorPos], ((puntero.position + posAnterior) / 2 + (((puntero.position + posAnterior) / 2) + (posAnterior + (puntero.position + posAnterior) / 2) / 2) / 2) / 2, Quaternion.identity);
                Instantiate(obj[colorPos], ((puntero.position + posAnterior) / 2 + (((puntero.position + posAnterior) / 2) + (puntero.position + (puntero.position + (puntero.position + posAnterior) / 2) / 2) / 2) / 2) / 2, Quaternion.identity);
            }
            Instantiate(golpe[colorPos], transform.position, Quaternion.identity);
            Instantiate(pinturas[colorPos], personaje.rb.position + new Vector2(0f,Random.Range(0,0.8f)), Quaternion.identity);
            tinta-=4;
            posAnterior = puntero.position;
        }
        else
        {
            if(pressed && tinta < 1 && fuerza>0)
            {
                Instantiate(golpe[0], transform.position, Quaternion.identity);
                fuerza--;
            }
        }
        if (pressedDerecho && fuerza>0)
        {
            //Instantiate(golpe[0], personaje.transform.position+new Vector3(0f,1f,0f), Quaternion.identity);
            fuerza--;
            atacar = true;
        }
        if(!pressedDerecho && !pressed && fuerza < 100)
        {
            fuerza++;
            atacar = false;
        }
        if (fuerza < 1) { atacar = false; }
    }

    void SeguirPuntero() {
        puntero.position= Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }
    void Pressed()
    {
        if (Input.GetMouseButton(0))
        {
            pressed = true;
            posAnterior = puntero.position; 
        }
        else { pressed = false;
             colorPos = Random.Range(0, obj.Length);
        }

    }

    void PressedDerecho()
    {
        if (Input.GetMouseButton(1))
        {
            pressedDerecho = true;
        }
        else
        {
            pressedDerecho = false;
        }

    }

    void DestruirGolpe()
    {   
        for(int i = 0; i < golpes.Length; i++)
        {
            Destroy(golpes[i],0.5f);
        }
    }

    void Destruirpinturitas()
    {
        for (int i = 0; i < pinturitas.Length; i++)
        {
            Destroy(pinturitas[i], 0.17f);
        }
    }

    void movertinta()
    {
        for(int i= 0; i<pinturitas.Length; i++)
        {
            float rand = Random.Range(0.07f, 0.4f);
            pinturitas[i].transform.localScale = new Vector3(rand, rand, 1f);
            pinturitas[i].transform.position = pinturitas[i].transform.position + new Vector3((puntero.position.x - personaje.transform.position.x)*5, (puntero.position.y - personaje.transform.position.y) * 5, 0f) * Time.deltaTime;
        }

    }
    void variacion_barra()
    {
        barTinta.fillAmount = (float)tinta / 150;
        barfuerza.fillAmount = (float)fuerza / 100;
    }


}

