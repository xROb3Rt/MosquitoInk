using UnityEngine;
using System.Collections;

public class pauseTutorial : MonoBehaviour {

	public bool isPaused;
	public GameObject camaraTutorial;
	public float timeLeft = 0.4f;
	public bool firstTime;

	// Use this for initialization
	void Start () {
	
		isPaused = false;
		firstTime = true;
		
	}

	
	// Update is called once per frame
	void Update () {
	
		timeLeft -= Time.deltaTime;
		
		if (timeLeft < 0 && firstTime)
        {
            isPaused = true;
        }

		if(isPaused){
			
			Time.timeScale = 0;
			camaraTutorial.SetActive(true);
			firstTime = false;
		}
		if (Input.GetKeyDown(KeyCode.Space)){
		
			isPaused = false;
			firstTime = false;
			Time.timeScale = 1;
			camaraTutorial.SetActive(false);
			
		}
	
	}
}
