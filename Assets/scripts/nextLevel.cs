using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	
	void OnMouseDown(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("level02");
	}
}
