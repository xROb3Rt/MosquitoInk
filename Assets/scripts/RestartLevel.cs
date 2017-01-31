using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);		
	}
    void OnMouseOver()
    {
        transform.localScale = new Vector3(1.15f, 1.15f, 1f);
    }
    void OnMouseExit()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
