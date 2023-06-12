using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionGame : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_InputField answerInput;
    public TMP_Text logText;

    private List<Question> questionPool = new List<Question>();
    private int currentQuestionIndex = 0;

    public GameObject dogruLog,yanlisLog;
    private void Start()
    {
        dogruLog.SetActive(false);
        yanlisLog.SetActive(false);
        // Soru havuzunu oluþturun
        CreateQuestionPool();

        // Ýlk soruyu gösterin
        DisplayQuestion();
    }

    private void CreateQuestionPool()
    {
        // Soru havuzuna sorularý ekleyin
        questionPool.Add(new Question("Soru 1: 2 Ekim Çarþamba gününden 2 hafta sonra hangi gündür?", "16 Ekim"));
        questionPool.Add(new Question("Soru 2: 6 Ekim Pazar gününden 6 gün sonra hangi gündür?", "12 Ekim"));
        questionPool.Add(new Question("Soru 3: Ekim ayýnýn 3. Perþembesinden 8 gün sonra hangi gündür?", "25 Ekim"));
        questionPool.Add(new Question("Soru 4: Ekim ayýnýn son gününden 3 hafta öncesi hangi gündür?", "10 Ekim"));
        questionPool.Add(new Question("Soru 5: 12 Ekim Cumartesi gününden 2 hafta sonra hangi gündür?", "26 Ekim"));
    }

    private void DisplayQuestion()
    {
        // Mevcut soruyu gösterin
        questionText.text = questionPool[currentQuestionIndex].question;
    }

    public void CheckAnswer()
    {
        // Kullanýcýnýn cevabýný kontrol edin
        string userAnswer = answerInput.text;
        string correctAnswer = questionPool[currentQuestionIndex].answer;

        if (userAnswer == correctAnswer)
        {
            // Doðru cevaplandý, bir sonraki soruya geçin
            LogMessage("Doðru cevap!");
            Invoke("DogruLog",.2f);

            currentQuestionIndex++;

            if (currentQuestionIndex < questionPool.Count)
            {
                DisplayQuestion();
            }
            else
            {
                // Oyun bitti
                LogMessage("Oyun bitti!");
                SceneManager.LoadScene("Scene-3");
            }
        }
        else
        {
            // Yanlýþ cevaplandý, ayný soruyu tekrar sorun
            LogMessage("Yanlýþ cevap! Tekrar deneyin.");
            Invoke("YanlisLog",.2f);
        }

        // Giriþ alanýný temizleyin
        answerInput.text = "";
    }

    private void LogMessage(string message)
    {
        // Log mesajýný günlüðe kaydedin
        logText.text += message + "\n";
    }
    void DogruLog()
    {
        dogruLog.SetActive(true);
        yanlisLog.SetActive(false);
        float sayac = 0;
        sayac += Time.deltaTime;
        if (sayac>5)
        {
            CancelInvoke("DogruLog");
        }
    }
    void YanlisLog() 
    {
        yanlisLog.SetActive(true);
        dogruLog.SetActive(false);
        float sayac = 0;
        sayac += Time.deltaTime;
        if (sayac > 5)
        {
            CancelInvoke("DogruLog");
        }
    }
}

public class Question
{
    public string question;
    public string answer;

    public Question(string question, string answer)
    {
        this.question = question;
        this.answer = answer;
    }
}