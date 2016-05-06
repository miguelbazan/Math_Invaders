
// <summary> Enemigo.cs</summary>
// <remarks>
// Este código maneja los movimientos y acciones del enemigo
// </remarks>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour {

	public float fSpeed = 5f; //La velocidad a la que se mueve mi enemigo
	private Rigidbody2D rb2d; //El rigidbody de nuestro enemigo
	public PlayerController player; //Una referencia a nuestro Jugador
	public UnityEngine.UI.Image life1, life2, life3; //Referencias a nuestras imagenes de UI
	public bool der = true; //La variable de nuestra dirección izquierda o derecha

	public bool canMove = true; //Para congelar al enemigo cuando esta frozen 
	public bool isHitted = false; //Variable para saber si esta golpeado
	public bool isBoss = false; //Si es jefe final o no
	public bool triggered = false; //Para nuestro trigger del jefe final
	public TextBoxManager theTextBox;  //El textbox manager de las preguntas

	public AudioSource sound1; //Sonido de hurt
	public AudioSource sound2; //Sonido de death



	// Inicializamos nuestras variables
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		theTextBox = FindObjectOfType<TextBoxManager> ();
		if (player.transform.localScale.x < 0) {
			fSpeed = -fSpeed; //Si la dirección es izquierda, lo volteamos.
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isBoss) {
		
		
		}
		if (!canMove) {
			return;
		}


		for (int i = 0; i < 10; i++) {
			rb2d.velocity = new Vector2 (fSpeed, rb2d.velocity.y);
			if (i == 10) {
				der = false;

			}
		}
		if (!der) {
			rb2d.velocity = new Vector2 (-fSpeed, rb2d.velocity.y);
		}

		if (triggered) {
		//Mostramos el dialogo
			GUI.Label(new Rect(300,300,500,200), "¡Has ganado el juego! Tu familia te espera en la tierra.");
		}
	
	}

	/**
	 *Func OnTriggerEnter2D
	 *Se activa mi colider y hago lo que está adentro.
	 **/

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Bullet") { //Si colisiona con un enemigo
			theTextBox.stopPlayerMovement = true;
			isHitted = true;
			theTextBox.EnableTextBox ();
			theTextBox.respuestaCorrecta = theTextBox.textLines [theTextBox.currentLine + 1];
			if (isBoss) {
				triggered = true;
			}
		}

		if (other.tag == "Enemy") {
		}

		if (other.tag == "Player") {
			player.fVida-=1;
			sound1.Play ();

		}

		if (other.tag != "Player") {
			fSpeed = fSpeed * -1;
		}
	}

	/**
	 *Func destroyEnemigo()
	 *Lo usamos para destruir el objeto de enemigo
	 **/

	public void destroyEnemigo(){
		Destroy (gameObject);
		isHitted = false;
		sound2.Play ();
	}
}
