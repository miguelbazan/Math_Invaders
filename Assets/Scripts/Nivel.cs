// <summary> Nivel.cs</summary>
// <remarks>
// Este código se encarga de guardar la partida cada vez que el jugador termina un nivel
// </remarks>


using UnityEngine;
using System.Collections;

public class Nivel : MonoBehaviour {

	public int level; //El nivel del jugador que guardaremos
	public PlayerController player; //Referencia a mi clase de jugador
	public string nombreJugador; //El string de nombre de mi jugador

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> (); //Inicializamos la referencia a jugador
		nombreJugador = player.nombre; //Sacamos el nombre de mi jugador
	
	}



	/**
	 * Func OnTriggerEnter2D
	 * Si colisiona con mi jugador, guardamos su nivel actual, su nombre, y puntuación en playerprefs, para que pueda ser accedido por mi
	 * jugador al cargar el nivel.
	 **/
	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			//Guardo el nombre de mi jugador. Por ejemplo, si me llamo Axel, se guarda como AxelNombre.
			PlayerPrefs.SetString (player.nombre + "Nombre", player.nombre);
			Debug.Log("Nombre como " + player.nombre + "Nombre");
			//Guardo el puntaje de mi jugador. Si soy Axel se accede como AxelPuntos.
			PlayerPrefs.SetFloat(player.nombre + "Puntos", player.fPuntuacion);
			Debug.Log("Puntos guardados como " + player.nombre + "Puntos");
			//Guardo el nivel donde se encuentra mi personaje
			PlayerPrefs.SetInt(player.nombre + "Nivel", player.currentLevel);
			//Variable temporal de nivel para mi gameover
			PlayerPrefs.SetInt("nivel", player.currentLevel);
			Debug.Log ("Nivel guardado como " + player.nombre + "Nivel");

			//Comprobamos.
			Debug.Log(PlayerPrefs.GetString ("Estoy imprimiendo tu nombre: " + player.nombre + "Nombre"));
			Debug.Log(PlayerPrefs.GetFloat ("Estoy imprimiendo tu puntaje: " + player.nombre + "Puntos"));
			Debug.Log(PlayerPrefs.GetInt ("Estoy imprimiendo tu nivel: " + player.nombre + "Nivel"));


			Application.LoadLevel (level);

		}
	}




	

}
