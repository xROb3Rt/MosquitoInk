using UnityEngine;
using System.Collections;

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
	

    // Use this for initialization
    void Start () {
	    rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
	}

    void FixedUpdate()
    {

		isGrounded = Physics2D.OverlapCircle(comprobadorSuelo.position, radioComprobar, layerSuelo);

		
    }
	
	// Update is called once per frame
	void Update () {

        //if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        if (isJumping==false && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
			isJumping = true;
        }

        if (isGrounded)
        {
            isJumping = false;
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
    }

    void girar()
    {
        if(rb.velocity.x > 0.01){
            transform.localScale = new Vector2(1, 1);
           animador.SetFloat("velocidad_X", 1f);
        }
        if (rb.velocity.x < -0.01)
        {
            transform.localScale = new Vector2(-1, 1);
            animador.SetFloat("velocidad_X", 1f);
        }
        if(rb.velocity.x == 0f)
        {
           animador.SetFloat("velocidad_X", 0f);
       }
    }
}
