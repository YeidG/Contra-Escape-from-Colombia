using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{

    public int coinCount =0;

    public static Manager Instance;
    public int livescount = 2;
    
    bool ispaused = false;
    public bool gameSTEP;
    public bool GameOver = false;

    //public UIManager UIManager;




    //[SerializeField]Text GameOvertext;
    // Start is called before the first frame update
    

    void Awake()
    {
        if(Manager.Instance == null){
            Manager.Instance = this.GetComponent<Manager>();
        }
        else if (Manager.Instance != null && Manager.Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }
   

    void Start()
    {
    UIManager.Instance.updatecoins(coinCount);
    UIManager.Instance.updateLives(livescount);

    }

    // Update is called once per frame
    void Update()
    {

     UIManager.Instance.updatecoins(coinCount);
    }


    public void addcoin(int a)
    {

        coinCount+=a;

    }
    public void updateLives(int lives)
    {
        livescount+=lives;
        coinCount=0;
        

        if (livescount  < 0)
        {
            
            GameOver = true;
           
            UIManager.Instance.ShowGameOver(); 
           


           // Time.timeScale=0;
        }
        else
        {

            SceneManager.LoadScene("Nivel-1");
            UIManager.Instance.updateLives(livescount);
        }

    }
       public void ScNivel1(){

            coinCount =0;
            livescount=2;
        SceneManager.LoadScene("Nivel-1");

    }

    public void Scmenuprincipal(){

        SceneManager.LoadScene("Main");

    }  

    
}
    

