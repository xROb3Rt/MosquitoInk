using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovimientoPersonaje : MonoBehaviour {


    public float jumpSpeed = 1000f;
	public float moveForce = 155f;			// Amount of force added to move the player left and right.
	public float speed = 2.5f;				// The fastest the player can travel in the x axis.
	public float maxSpeed = 2.5f;
	public bool isJumping = false;
    public Rigidbody2D rb;
    public bool isGrounded = false;
    public Transform comprobadorSuelo;
    public float radioComprobar = 0.05f;
    public LayerMask layerSuelo;
    private Animator animador;
	public GameObject camaraGO;
	public bool isFinal = false;
	public GameObject camaraNextLevel;
    public Pintar pincel;
    public int vida = 3;
    public int vitalidad = 500;
    private Vector3 posicionRestart;
    public GameObject fondo_negro;
    public Image barVitalidad;
    public Image barcorazones;
    public int puntos = 0;
    public int puntos_totales = 0;
    public TextMesh marcador;
    public TextMesh marcadorfinal;

    //public bool activarTimer = false;
    // public float timeLeft = 1.0f;

    // Use this for initialization
    void Start () {
	    rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        posicionRestart = transform.position;
        barcorazones.fillAmount = (float)vida * 0.2f;
    }

    void FixedUpdate()
    {

		isGrounded = Physics2D.OverlapCircle(comprobadorSuelo.position, radioComprobar, layerSuelo);

		
    }
	
	// Update is called once per frame
	void Update () {

        //if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        if (isJumping==false && (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)))
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
			isJumping = true;
            animador.SetBool("Saltando", true);
        }

        if (isGrounded)
        {
            isJumping = false;
            animador.SetBool("Saltando", false);
        }
		
		if(isFinal){
		Debug.Log("AAA");
		}

		float h = Input.GetAxis("Horizontal");

		if(h * rb.velocity.x < maxSpeed)
            // ... add a force to the player.
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        girar();
		
		if (rb.position.y < -6 || vitalidad < 1) {
            vida--;
            barcorazones.fillAmount = (float) vida * 0.2f;
            
            if (vida < 1)
            {
                persoanajeMuerto();
                transform.position += new Vector3(0f,-10f,0f);
            }
            else
            {
                Instantiate(fondo_negro, posicionRestart, Quaternion.identity);
                DestroyObject(GameObject.FindGameObjectWithTag("fondo_negro"), 1f);


                //Camera.main.SendMessage("fadeOut");
                //activarTimer = true;
                transform.position = posicionRestart;
                pincel.fuerza = 100;
                vitalidad = 500;
                if (pincel.tinta < 50)
                {
                    pincel.tinta = 50;
                }
            }
		}

        if (Input.GetMouseButton(1) && pincel.atacar)
        {
            animador.SetBool("golpear", true);
        }
        else { animador.SetBool("golpear", false); }

        modificarBarra();

        actualizarMarcador();

        SubirVida();
        /* if (activarTimer)
         {
             timeLeft -= Time.deltaTime;
             if (timeLeft <= 0) { Camera.main.SendMessage("fadeIn"); activarTimer = false; timeLeft = 1.0f;  }
         }*/
         if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void girar()
    {
        if(rb.velocity.x > 0.01){
            transform.localScale = new Vector3(1, 1, 1);
           animador.SetFloat("velocidad_X", 1f);
        }
        if (rb.velocity.x < -0.01)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animador.SetFloat("velocidad_X", 1f);
        }
        if(rb.velocity.x == 0f)
        {
           animador.SetFloat("velocidad_X", 0f);
       }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bote" && pincel.tinta < 150)
        {
            Destroy(other.gameObject); 
            pincel.tinta = 150;
            
        }
        if(other.tag == "punto_guardado")
        {
            posicionRestart = transform.position;
            other.transform.position= other.transform.position + new Vector3(0f,15f,0f)*Time.deltaTime;
            Destroy(other, 1f);
        }
    }

    void persoanajeMuerto(){
		camaraGO.SetActive(true);
	}
	
	void OnCollisionEnter2D(Collision2D col){
	
		if(col.gameObject.tag == "finTutorial"){
			Time.timeScale = 0;
			camaraNextLevel.SetActive(true);
		}
	
	}
    void modificarBarra()
    {
        barVitalidad.fillAmount = (float)vitalidad / 500;
    }

    void actualizarMarcador()
    {
        marcador.text = puntos.ToString();
        marcadorfinal.text = puntos_totales.ToString();
    }

    void SubirVida()
    {
        if (puntos >= 50)
        {
            puntos = puntos - 50;
            if (vida < 5)
            {
                vida++;
                barcorazones.fillAmount = (float)vida * 0.2f;
            }
        }
    }

}
