using UnityEngine;
using System.Collections;

public class GenerarCoche : MonoBehaviour {
    public GameObject[] coches;
    public int time;
    public int limite;
	// Use this for initialization
	void Start () {
        limite = Random.Range(200, 1200);
	}
	
	// Update is called once per frame
	void Update () {
        if (time > limite)
        {
            time = 0;
            Instantiate(coches[0], transform.position, Quaternion.identity);
            limite = Random.Range(200, 1200);
        }
        time++;
	}
}
