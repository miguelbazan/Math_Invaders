// <summary> NaveDaño.cs</summary>
// <remarks>
// Este código maneja las funciones de mi nave estrellada del primer nivel
// </remarks>


using UnityEngine;
using System.Collections;

public class NaveDaño : MonoBehaviour {
	public PlayerController player; //Referencia al jugador

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> (); //inicializamos la referencia a mi jugador
	}
		
	/**
	 *Func OnTriggerEnter2D
	 *Maneja las colisiones de mi nave (de tipo trigger, si es colisión el evento se maneja onCollisionEnter2D)
	 **/
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") { //Si colisiono con el jugador, le restamos un punto de vida.
			player.fVida--;
		
		}
	
	}
}
