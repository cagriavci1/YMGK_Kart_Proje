using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager_Script : MonoBehaviour
{
    public static Game_Manager_Script Instance;
    
    public int Score;
    public int Joker;
    public int Time;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
    }

    
}
