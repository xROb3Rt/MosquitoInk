using UnityEngine;
using System.Collections;

public class fondos : MonoBehaviour {
    public Camera cam;
    public Vector3 posAnterior;
	// Use this for initialization
	void Start() {
        posAnterior = cam.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //if (cam.transform.position.x > posAnterior.x || cam.transform.position.x < posAnterior.x)
        //{
            //transform.position = transform.position + new Vector3(cam.transform.position.x-posAnterior.x, 0, 0);
            transform.Translate(new Vector3(cam.transform.position.x - posAnterior.x, 0, 0)*Time.maximumDeltaTime);
        //}
        posAnterior = cam.transform.position;
	
	}
}
