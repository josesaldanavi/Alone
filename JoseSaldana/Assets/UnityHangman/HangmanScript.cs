using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangmanScript : MonoBehaviour {
    public string palabra;

    string palabraEscondida;
    //se tiene que agregar la libreria UnityEngine.UI
    public Text outputText;
    public InputField inputText;

    public AudioClip introSound;
    public AudioClip winSound;
    public AudioClip successSound;
    public AudioClip failSound;
    public AudioSource camSource;

    bool endHangman;
    // Use this for initialization
    void Start()
    {
        inputText.Select();
        foreach (char c in palabra)
        {
            palabraEscondida += "*";
            camSource.PlayOneShot(introSound);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!endHangman)
        {
            runHangman();
        }

    }

    void runHangman()
    {
        if (outputText.text != palabraEscondida)
        {
            outputText.text = palabraEscondida;
        }
        //...metodo imput apretaste(enter)
        if (Input.GetKeyDown(KeyCode.Return) && !string.IsNullOrEmpty(inputText.text))
        {
            string letra = inputText.text.Substring(0, 1);
            if (palabra.Contains(letra))
            {
                string palabraTemporal = "";
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i] == letra[0])
                    {
                        palabraTemporal += letra;
                    }
                    else
                    {
                        palabraTemporal += palabraEscondida[i];
                    }
                }
                palabraEscondida = palabraTemporal;
                camSource.PlayOneShot(successSound);
            }
            else
            {
                camSource.PlayOneShot(failSound);
            }
            inputText.text = "";
            inputText.Select();
            inputText.ActivateInputField();

        }
        if (palabraEscondida == palabra)
        {
            camSource.PlayOneShot(winSound);
            outputText.text = "Felicidades Ganaste";
            inputText.gameObject.SetActive(false);
            endHangman = true;
        }
    }


}
