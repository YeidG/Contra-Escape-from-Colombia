using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroll : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public GameObject PlayerController;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController==null)
        return;
        Vector3 position =transform.position;
        position.x=PlayerController.transform.position.x;
        transform.position=position;
    }
}
