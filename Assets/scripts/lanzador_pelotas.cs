using UnityEngine;
using System.Collections;

public class lanzador_pelotas : MonoBehaviour {
    public GameObject pelota;
    public int contador = 0;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
        if (contador > 90)
        {
            Instantiate(pelota, transform.position, Quaternion.identity);
            contador=0;
        }
        contador++;
	
	}
}
