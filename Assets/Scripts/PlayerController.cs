// <summary> PlayerController.cs</summary>
// <remarks>
// Este código maneja el movimiento de nuestro personaje tanto caminar como saltar y caer.
// </remarks>



using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

	private Animator anim;

	//Declaramos nuestras variables
	public float fMaxSpeed = 5f; //La velocidad maxima
	public float fSpeed = 50f; //Si velocidad actual
	public float fJumpPower = 150f; //La potencia de salto
	public bool bGrounded; //Checa si mi jugador esta en el piso
	public bool bActivo = true; //Si mi personaje se encuentra activo
	public float fPuntuacion; //La puntuacion actual de mi personaje
	public int fVida = 3; //La vida que tiene mi personaje
	public int fVidaMax = 5; //La vida maxima de mi personaje
	public string nombre = "Jugador"; //El nombre de mi personaje
	public int level; //El nivel que usamos para la funcion die
	public int nivel = 1; //el nivel en el que nos encontramos
	public int currentLevel = 0; //Variable clon que utilizamos para playerprefs
	public bool canDisparar = true; //Para congelarlo si esta contestando una pregunta
	public AudioSource shoot; //El audio de disparo
	public Text tNombre; //El textfield de nombre
	public Transform firePoint; //El punto de donde salen mis disparos
	public GameObject disparo; //El disparo que se instancia

	//Necesitamos un rigidbody2D en el codigo para usarlo.
	private Rigidbody2D rb2d;

	public bool canMove = true;

	// Use this for initialization
	void Start () {

		nombre = PlayerPrefs.GetString("nombre");
		tNombre.text = PlayerPrefs.GetString("nombre");
		if (PlayerPrefs.HasKey (nombre + "Puntos")) {
			fPuntuacion = PlayerPrefs.GetFloat (nombre + "Puntos");
		} else {
			fPuntuacion = 0;
		}


		//Inicializamos el rigidbody2d
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		fVida = fVidaMax;
	}
	
	// Update is called once per frame
	void Update () {
		//Imprimimos el nivel actual
		Debug.Log ("El nivel Actual es: " + currentLevel);
		//si el personaje se puede mover
		if (!canMove) {
			return;
		}
		//hacemos un link de las animaciones con las variables del animator
		anim.SetBool ("Grounded", bGrounded);
		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		//el movimiento y acciones de nuestro personaje
		if (bActivo == true) {
			if (Input.GetAxis ("Horizontal") < -0.1f) {
				transform.localScale = new Vector3 (-1, 1, 1);
			}

			if (Input.GetAxis ("Horizontal") > 0.1f) {
				transform.localScale = new Vector3 (1, 1, 1);
			}

			if (Input.GetKeyDown(KeyCode.UpArrow)&& bGrounded) {
				rb2d.AddForce (Vector2.up * fJumpPower);
			}
			if (canDisparar) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					shoot.Play ();
					Instantiate (disparo, firePoint.position, firePoint.rotation);
				}
			}
		}

		//que la vida actual de mi jugador no se pase del máximo 
		if (fVida > fVidaMax) {
			fVida = fVidaMax;
		}
		//si muere lo mandamos a la pantalla de gameover
		if (fVida <= 0) {
			Die (7);
		}
	}

	/**Cuando usamos un rigidbody es necesario que utilizemos FixedUpdate en lugar de Update.
	 * This function is called every fixed framerate frame
	 * 
	**/
	void FixedUpdate () {

		if (!canMove) {
			return;
		}

		if (bActivo == true) {
			//Variable que obtiene la direccion(?) horizontal
			//Si el jugador aprieta la tecla de izq. el valor es -1, y si es a la der. es (+)1
			float fHorizontal = Input.GetAxis ("Horizontal");

			//Movemos a nuestro personaje a través de su RB2D
			rb2d.AddForce ((Vector2.right * fSpeed) * fHorizontal);


			//Si me paso de la vel máxima, lo igualamos para que no super acelere.
			//A LA DERECHA
			if (rb2d.velocity.x > fMaxSpeed) {
				rb2d.velocity = new Vector2 (fMaxSpeed, rb2d.velocity.y);
			}

			//Si me paso de la vel máxima, lo igualamos para que no super acelere.
			//A LA IZQUIERDA
			if (rb2d.velocity.x < -fMaxSpeed) {
				rb2d.velocity = new Vector2 (-fMaxSpeed, rb2d.velocity.y);
			}
			
		}

	}
		
	//la funcion de morir, recibe el nivel que es la pantalla de gameover
	void Die (int level)
	{
		//Restart
		Application.LoadLevel (level);
	}
}
