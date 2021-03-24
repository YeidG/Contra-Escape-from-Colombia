using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScControl(){

        SceneManager.LoadScene("Controles");

    }

    public void ScNivel1(){

        SceneManager.LoadScene("Nivel-1");

    }

    public void salir(){

        Application.Quit();
    }
}
