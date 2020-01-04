using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlador : MonoBehaviour
{
    public void CambiarEscena(string nombre)
    {
        print("Cambiando a la escena " + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        print("salir de juego");
        Application.Quit();
    }
}
