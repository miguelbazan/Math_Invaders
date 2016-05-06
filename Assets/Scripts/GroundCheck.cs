// <summary> GroundCheck.cs</summary>
// <remarks>
// Este código maneja el control de checar si el jugador esta en el piso
// </remarks>

using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerController player; //Una referencia al jugador

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<PlayerController> (); //Inicializamos la referencia.
	}

	/**
	 * OnTriggerEnter2D
	 * La acción que se ejecuta al activarse un trigger
	 **/

	void OnTriggerEnter2D(Collider2D col){
		player.bGrounded = true; //Si hay una colision con un trigger, estamos grounded
	
	}

	/**
	 * OnTriggerStay2D
	 * La acción que se ejecuta al activarse un trigger
	 **/
	void OnTriggerStay2D(Collider2D col){
	
		player.bGrounded = true; //Checando que si estamos en el piso
	
	}
	void OnTriggerExit2D(Collider2D col){
		player.bGrounded = false; //Cuando no estas en el piso, no estas grounded
	}
		
}
