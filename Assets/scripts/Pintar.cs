using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pintar : MonoBehaviour {
    public GameObject[] obj;
    public float tiempoMin = 1f;
    public float tiempoMax = 2f;
    public int tinta = 150;
    public int fuerza = 100;
    public Rigidbody2D puntero = new Rigidbody2D();
    public bool pressed = false;
    public bool pressedDerecho = false;
    public int colorPos = 0;
    public GameObject[] golpe;
    public GameObject[] golpes;
    public Image barTinta;
    public Image barfuerza;




    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
              
        Generar();    
        Pressed();
        PressedDerecho();
        SeguirPuntero();
        golpes = GameObject.FindGameObjectsWithTag("golpe");
        DestruirGolpe();
        variacion_barra();



    }
    void Generar()
    {
        if (pressed && tinta>=1)
        {
            Instantiate(obj[colorPos], transform.position, Quaternion.identity);
            Instantiate(golpe[colorPos], transform.position, Quaternion.identity);
            tinta--;     
        }
        if (pressedDerecho && fuerza>=1)
        {
            Instantiate(golpe[0], transform.position, Quaternion.identity);
            fuerza--;
        }
        if(!pressedDerecho && fuerza < 100)
        {
            fuerza++;
        }
    }

    void SeguirPuntero() {
        puntero.position= Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }
    void Pressed()
    {
        if (Input.GetMouseButton(0))
        {
            pressed = true;
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
    void variacion_barra()
    {
        barTinta.fillAmount = (float)tinta / 150;
        barfuerza.fillAmount = (float)fuerza / 100;
    }


}

