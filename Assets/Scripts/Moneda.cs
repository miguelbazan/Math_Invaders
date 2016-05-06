// <summary> Moneda.cs</summary>
// <remarks>
// Este código maneja el comportamiento de la moneda
// </remarks>


using UnityEngine;
using System.Collections;

public class Moneda : MonoBehaviour {
	public PlayerController jugador; //Jalamos al jugador
	public Puntuacion puntuacion; //Hacemos una union con la clase de puntuacion
	public AudioSource sound;  //La variable de sound

	// Use this for initialization
	void Start () {
		//Inicializamos las variables a otras clases
		jugador = FindObjectOfType<PlayerController> ();
		puntuacion = FindObjectOfType<Puntuacion> ();
	}

	/**
	 *Fun OnTriggerEnter2D
	 *Cuando se ejecuta el trigger destruimos a la moneda y le damos puntuación al jugador
	 **/

	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player") {
			sound.Play ();
			Destroy (gameObject);
			jugador.fPuntuacion = jugador.fPuntuacion + 10;
			Debug.Log (jugador.fPuntuacion);
			puntuacion.puntos.text = jugador.fPuntuacion.ToString ();
		}
	}
		
}
