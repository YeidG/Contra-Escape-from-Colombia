using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    #region 



    [SerializeField] Text gameOVER;
    [SerializeField] TMPro.TMP_Text playerlives;

    [SerializeField] TMPro.TMP_Text coins;

    [SerializeField] TMPro.TMP_Text fin;

    [SerializeField] Button salir;
    [SerializeField] Button retry;


    #endregion


    void Awake()
    {
        if (UIManager.Instance == null)
        {
            UIManager.Instance = this.GetComponent<UIManager>();
        }
        else if (UIManager.Instance != null && UIManager.Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }



    // Start is called before the first frame update
    void Start()
    {
        fin.gameObject.SetActive(false);
        gameOVER.gameObject.SetActive(false);
        // salir.gameObject.SetActive(false);
        //retry.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowGameOver()
    {
        gameOVER.gameObject.SetActive(true);
        salir.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);

    }


    public void updateLives(int lives)
    {

        playerlives.text = " X " + lives;

    }

    public void updatecoins(int coin)
    {


        coins.text = " x " + coin;
    }
    public void NivelComplete(){

           fin.gameObject.SetActive(true);
            SceneManager.LoadScene("Main");

    }
}





