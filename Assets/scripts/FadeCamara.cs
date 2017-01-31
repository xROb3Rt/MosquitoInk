using UnityEngine;
using System.Collections;

public class FadeCamara : MonoBehaviour {

    public Texture2D fadeTexture;
    public float velocidad = 1.0f;
    public int depth = 1000;
    public float alpha = 1.0f;
    public int direccion = -1;

    
    void OnGUI()
    {
        //Debug.Log("AD");
        alpha += direccion * velocidad * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color() { a = alpha };
        GUI.depth = depth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

    }

    void fadeIn()
    {
        Debug.Log("fadeIn");
        direccion = -1;
    }

    void fadeOut()
    {
        Debug.Log("fadeOut");
        direccion = 1;
    }

}
