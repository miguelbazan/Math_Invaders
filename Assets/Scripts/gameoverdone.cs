// <summary> PlayerController.cs</summary>
// <remarks>
// Este código maneja el movimiento de nuestro personaje tanto caminar como saltar y caer.
// </remarks>


using UnityEngine;
using System.Collections;

public class gameoverdone : MonoBehaviour {
	public int level;
	public string nombre;



	double timer = 0.0;
	// Use this for initialization
	void Start () {
		nombre = PlayerPrefs.GetString ("nombre");
		Debug.Log ("El nombre que tome fue: " + nombre);
		level = PlayerPrefs.GetInt (nombre + "Nivel");
	}
	
	// Update is called once per frame
	void Update () {
	
		timer *= Time.deltaTime;
		Debug.Log ("El nombre que tome fue: " + nombre);
		Debug.Log ("el nivel que tome fue  " + level);

	}


	public void onClick(){
		if (level == 1) {
			Application.LoadLevel (5);
		}

		if(level == 2){
			Application.LoadLevel (9);
		}

		if(level == 3){
			Application.LoadLevel (10);
		}
	}
}
