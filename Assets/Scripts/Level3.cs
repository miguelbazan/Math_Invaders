// <summary> Level3.cs</summary>
// <remarks>
// Este código maneja el setteo del nivel 3 de mi jugador
// </remarks>


using UnityEngine;
using System.Collections;

public class Level3 : MonoBehaviour {


	public PlayerController jugador; //La referencia a mi jugador
	// Use this for initialization
	void Start () {

		jugador = FindObjectOfType<PlayerController> (); //Inicializamos mi variable de jugador
	}

	/**
	 *Func OnTriggerEnter2D 
	 * si colisiona con mi jugador, su nivel actual se settea como 3.
	 **/

	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player") { 

			jugador.currentLevel = 3;
			PlayerPrefs.SetInt (jugador.nombre + "Nivel", 3);
		}
	}
}
