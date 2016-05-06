// <summary> DisparoController.cs</summary>
// <remarks>
// Este código maneja el control de mi disparo, su movimiento 
// </remarks>


using UnityEngine;
using System.Collections;

public class DisparoController : MonoBehaviour {


	public float fSpeed; //La velocidad de mi disparo
	private Rigidbody2D rb2d; //el componente rigidbody de mi bala


	public PlayerController player; //La referencia a mi jugador


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> (); //Ecnontramos al player
		rb2d = gameObject.GetComponent<Rigidbody2D> (); //incializamos el rigidbody
		if (player.transform.localScale.x < 0) { //Si está en un eje, lo volteamos para que esté correctamente en ese eje
			fSpeed = -fSpeed;
		}
	}

	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2 (fSpeed, rb2d.velocity.y); //la velocidad en x
	}

	/**
	 * Funcion OnTriggerEnter2D
	 * Acción que se ejecuta al que se active el trigger el objeto
	 **/
	void OnTriggerEnter2D(Collider2D other){

		//Si colisiona con un enemigo se destruye
		if (other.tag == "Enemy") { 
			Destroy (gameObject);
		}

		//Si colisiona con una pared se destruye
		if(other.tag == "Wall"){
			Destroy (gameObject);

		}

	}
}
