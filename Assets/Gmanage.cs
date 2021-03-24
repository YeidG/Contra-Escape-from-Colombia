using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gmanage : MonoBehaviour
{
    public GameObject managertext;
    public static GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        Gmanage.gameManager = managertext;
        Gmanage.gameManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public static void show(){

        Gmanage.gameManager.SetActive(true);

    }
}
