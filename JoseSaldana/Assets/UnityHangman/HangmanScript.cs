﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangmanScript : MonoBehaviour {
	public string palabra;
	string palabraEscondida;
	//se tiene que agregar la libreria UnityEngine.UI
	public Text outputText;
	public InputField imputText;
	// Use this for initialization
	void Start () {
		foreach (char c in palabra) {
			palabraEscondida += "*";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (outputText.text != palabraEscondida) {
			outputText.text = palabraEscondida;
		}
		//...metodo imput apretaste(enter)
		if(Input.GetKeyDown(KeyCode.Return)){
			string  letra = imputText.text.Substring(0,1);
			if(palabra.Contains(letra)){
				string palabraTemporal="";
				for(int i=0; i<palabra.Length; i++){
					if (palabra [i] == letra[0]) {
						palabraTemporal += letra;
					} else {
						palabraTemporal += palabraEscondida [i];
					}
				}
				palabraEscondida = palabraTemporal;
			}
			imputText.text = "";
		}
		if(palabraEscondida == palabra){
			Debug.Log ("Felicidades");
		}
	}
}
