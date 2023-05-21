using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Question_Manager : MonoBehaviour
{
    public string[] sorular;
    public int[] cevaplar;

    // soru havuzu listesi olacak
    // cevap havuzu listesi olacak
    // soru süre havuzu listesi olacak
    // doðru ve yanlýþ cevap puaný etkileyecek
    // puan sistemi olacak
    // puan harcama ile joker satýn alacak
    // joker iþlevi soruda 2 þýk eleyecek
    // 
    public TextMeshProUGUI Question_Number;
    public TextMeshProUGUI Question_Text;

    public int questionNumber = 0;

    public TextMeshProUGUI A_button;
    public TextMeshProUGUI B_button;
    public TextMeshProUGUI C_button;
    public TextMeshProUGUI D_button;

    public int indexCount;

    void Start()
    {
        sorular = new string[5];
        sorular[0] = "Görselde yer alan YEÞÝL KURBAÐALAR'ýn sayýsý kaçtýr?";
        sorular[1] = "Görselde yer alan KIRMIZI KURBAÐALAR'ýn sayýsý kaçtýr?";
        sorular[2] = "Görselde yer alan KIRMIZI ÇÝÇEKLER'in sayýsý kaçtýr?";
        sorular[3] = "Görselde yer alan TURUNCU ÇÝÇEKLER'in sayýsý kaçtýr?";
        sorular[4] = "Görselde yer alan BEYAZ ÇÝÇEKLER'in sayýsý kaçtýr?";

        cevaplar = new int[5];
        cevaplar[0] = 5;
        cevaplar[1] = 7;
        cevaplar[2] = 11;
        cevaplar[3] = 12;
        cevaplar[4] = 9;


        SoruGetir(questionNumber);
    }

    void Update()
    {
        if (questionNumber==5)
        {
            SceneManager.LoadScene(2);
        }
    }
    
    public void IndexGonder(int index)
    {
        if (indexCount == index)
            DogruCevap();
        else
            YanlýsCevap();
    }

    private void YanlýsCevap()
    {
        Debug.Log("Yanlýþ");
        SoruGetir(questionNumber);
    }

    private void DogruCevap()
    {
        Debug.Log("Dogru");
        indexCount = 0;
        if (questionNumber < 5)
            questionNumber++;
        else
            Debug.Log("Oyun Bitti");//Game Finish

        SoruGetir(questionNumber);
    }

    public void SoruGetir(int questionNo)
    {
        Question_Text.text = sorular[questionNo];
        Question_Number.text = (questionNo + 1).ToString();

        int dogruIndex = Random.RandomRange(0, 4);

        switch (dogruIndex)
        {
            case 0:
                A_button.text = cevaplar[questionNo].ToString();
                B_button.text = Random.RandomRange(6, 30).ToString();
                C_button.text = Random.RandomRange(10, 30).ToString();
                D_button.text = Random.RandomRange(19, 30).ToString();
                break;
            case 1:
                A_button.text = Random.RandomRange(18, 30).ToString();
                B_button.text = cevaplar[questionNo].ToString();
                C_button.text = Random.RandomRange(10, 30).ToString();
                D_button.text = Random.RandomRange(15, 30).ToString();
                break;
            case 2:
                A_button.text = Random.RandomRange(18, 30).ToString();
                B_button.text = Random.RandomRange(13, 30).ToString();
                C_button.text = cevaplar[questionNo].ToString();
                D_button.text = Random.RandomRange(19, 30).ToString();
                break;
            case 3:
                A_button.text = Random.RandomRange(18, 30).ToString();
                B_button.text = Random.RandomRange(19, 30).ToString();
                C_button.text = Random.RandomRange(17, 30).ToString();
                D_button.text = cevaplar[questionNo].ToString();
                break;
            default:
                break;
        }

        indexCount = dogruIndex;

    }
    void Next_Button()
    {
        // soru cevap ekraný acýlacak
        // býr onceký kart ekraný objelerý kapanacak
        // timer geri sayýmý baþlayacak
    }
    void Prev_Button()
    {
        // kart ekraný objelerý acýlacak
        // soru cevap ekraný kapanacak
        // timer geri sayýmý sýfýrlanacak
        // son kalýnan soru tutulup devam edilmesi saðlanacak
    }
}
