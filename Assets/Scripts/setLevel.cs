// <summary> setLevel.cs</summary>
// <remarks>
// Este código maneja el setteo del nivel 1 para mi jugador
// </remarks>


using UnityEngine;
using System.Collections;

public class setLevel : MonoBehaviour {
	public PlayerController jugador; //Referencia a mi jugador
	// Use this for initialization
	void Start () {
		jugador = FindObjectOfType<PlayerController> (); //Inicializamos la referencia de jugador
	} 
		
	/**
	 *Func OnTrigger2D
	 *Si hay un trigger, se pone el nivel como 1
	 **/
	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player") {
			jugador.currentLevel = 1;
			PlayerPrefs.SetInt (jugador.nombre + "Nivel", 1);
		}

	}
}
