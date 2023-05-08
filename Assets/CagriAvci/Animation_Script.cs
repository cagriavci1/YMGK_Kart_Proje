using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Animation_Script : MonoBehaviour
{
    public static Animation_Script Instance;
    private void Awake()
    {
        Instance= this;
    }

    public TextMeshProUGUI start_text;
    public GameObject gameStartImageObject;
    public GameObject gameCardObject;
    public float timer=0;
    public float filledTime = 2f;
    private float timeElapsed = 0f;
    private Image card_image;

    public GameObject Game_Manager;
    public GameObject GameButtons;
    void Start()
    {
        card_image = gameCardObject.GetComponent<Image>();
        gameStartImageObject.SetActive(true);
        gameCardObject.SetActive(false);
        GameButtons.SetActive(false);
        start_text.text = "GAME STARTS";
        Invoke("TextChange1",.3f);

    }
    private void Update()
    {
        if (timer ==10)
        {
            CancelInvoke();
            GameStart();
        }
    }
    #region TextChangeAnim
    void TextChange1()
    {
        timer += 1;
        start_text.text = "GAME STARTS.";
        Invoke("TextChange2", .3f);
    }
    void TextChange2()
    {
        start_text.text = "GAME STARTS..";
        Invoke("TextChange3", .3f);
    }
    void TextChange3()
    {
        timer += 1;
        start_text.text = "GAME STARTS...";
        Invoke("TextChange1", .3f);
    }
    #endregion

    void GameStart()
    {
        gameStartImageObject.SetActive(false);
        gameCardObject.SetActive(true);

        timeElapsed += Time.deltaTime;
        float waitingTime = timeElapsed / filledTime;
        card_image.fillAmount=waitingTime;

        if (waitingTime>=1)
        {
            Game_Manager.SetActive(true);
            GameButtons.SetActive(true);
            enabled = false;
        }
    }
}
