using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void ButtonCheck(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitAp()
    {
        Application.Quit();
    }
}
