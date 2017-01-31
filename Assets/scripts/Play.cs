using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

	void OnMouseDown(){

		SceneManager.LoadScene ("level01");

	}
    void OnMouseOver()
    {
        transform.localScale= new Vector3(1.2f, 1.2f, 1f);
    }
    void OnMouseExit()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
