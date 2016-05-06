// <summary> CargarPersonaje.cs</summary>
// <remarks>
// Este código maneja la opción de cargar un personaje del jugador
// </remarks>


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CargarPersonaje : MonoBehaviour {

	public InputField personaje; //El input field donde el jugador pone el nombre de su personaje
	public Text nombre; //el texto donde se despliega el nombre de jugador
	public Text puntos; //el texto donde se despliega el puntaje del jugador
	public Text nivel; //el texto donde se despliega el numero de nivel donde se encuentra

	public string nom; //variable local para pasar de inputfield a string
	public float score; //variable para mostrar el score recuperado
	public int level; //variable para mostrar el nivel


	
	// Update is called once per frame
	void Update () {
		nom = personaje.text;
		
	
	}

	/* Func RetrieveData
	 * Cargamos los datos del jugador del niño, para poder mostrarle su personaje y luego le pique a cargar nivel
	 */

	public void RetrieveData(){

		//Cargo el nombre y los puntos del niño y se los muestro
		if (PlayerPrefs.HasKey (nom + "Nombre")) {
			nombre.text = "Nombre: " + PlayerPrefs.GetString (nom + "Nombre");
			score = PlayerPrefs.GetFloat (nom + "Puntos");
			puntos.text = "Puntuación: " + score.ToString();
			level = PlayerPrefs.GetInt (nom + "Nivel");
			level = level + 1;
			nivel.text = "Nivel : " + level.ToString ();
		} else {
			//Si no encuentro a tu personaje, te pido que lo escribas de nuevo.
			nombre.text = "No encontré a tu personaje. ¿Seguro que escribiste bien el nombre?";
			puntos.text = "";
			nivel.text = "";
		
		}
	}


	/* Func CargarNivel
	 * El niño pica el boton de cargar mi personaje, y se manda a la otra escena.
	 */
	public void CargarNivel(){

		PlayerPrefs.SetString ("nombre", nom);

		if(level == 2){
		Application.LoadLevel (9);
		}

		if(level == 3){
			Application.LoadLevel (10);
		}
	}
}
