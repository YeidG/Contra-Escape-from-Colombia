using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
public class stompHelp : MonoBehaviour
{

    #region 

        bool _isStomp =false;

    public bool IsStomp  {get=> _isStomp;}

    #endregion
    // Start is called before the first frame update
   



   void OnCollisionEnter2D(Collision2D collision){

        if(collision.transform.tag == "Player"){

            _isStomp=true;
        }
   }

   
}
