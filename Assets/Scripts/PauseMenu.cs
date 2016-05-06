// <summary> PauseMenu.cs</summary>
// <remarks>
// Este código maneja la pausa del juego
// </remarks>

using UnityEngine;
using System.Collections;


public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI; //Referencia a mi clase de pausa
	private bool bIsPaused = false; //Variable para saber si está pausado el juego

	void Start(){
		PauseUI.SetActive(false); //Cuando empieza el juego no esta pausado el juego
	}

	void Update(){
		//Si picamos la pausa, se pausa
		if(Input.GetButtonDown("Pause")){
			bIsPaused = !bIsPaused;
		}

		//Manejamos la pausa
		if(bIsPaused){
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}
		if(!bIsPaused){
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}

}
	/**
	 *Func Resume()
	 *Para resumir el juego
	 **/
	public void Resume(){
		bIsPaused = false;
	}

	/**
	 *Func Restart()
	 *Para reiniciar el nivel
	 **/
	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);
	}

	/**
	 *Func MainMenu()
	 *Para cargar el menu principal
	 **/
	public void MainMenu(){
		Application.LoadLevel (0);
	}


	/**
	 *Func Quit()
	 *Para salir del juego
	 **/
	public void Quit(){
		Application.Quit();
	}
}
