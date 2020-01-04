using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    bool active;
    Canvas canvas;
    public GameObject flecha, lista;

    int indice = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        Dibujar();
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKeyDown("up");
        bool down = Input.GetKeyDown("down");
          
        if (Input.GetKeyDown("space")){
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }

        if (up) indice--;
        if (down) indice++;

        if (indice > lista.transform.childCount-1) indice = 0;
        else if (indice < 0) indice = lista.transform.childCount-1;

        if ( up || down) Dibujar();

        if (Input.GetKeyDown("return")) accion();

    }

    void Dibujar()
    {
        Transform opcion = lista.transform.GetChild(indice);
        flecha.transform.position = opcion.position;
    }

    void accion()
    {
        Transform opcion = lista.transform.GetChild(indice);

        if (opcion.gameObject.name == "Salir_padre") {
            print("cerrar juego");
            Application.Quit();
        }

        SceneManager.LoadScene(opcion.gameObject.name);
    }
}
