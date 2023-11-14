using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject botonPause;
    [SerializeField] private GameObject menuPause;
    private bool juegoPausado = false;
    private void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Escape))
        { 
            if(juegoPausado)
            { 
                Reanudar();
            }
            else
            { 
                Pausa();
            }    
        }  
    }     
    
    public void Pausa(){
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPause.SetActive(false);
        menuPause.SetActive(true);
    }

    public void Reanudar(){
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Reiniciar(){
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar(){
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

}
