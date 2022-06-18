using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //takes care of display
    public TextMeshProUGUI displayText;
    public GameMaster gm;
    int score = 0;
    public static Score instance;

    
   // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        //score = gm.savedScore;
        //displayText.text = "Score: " + score.ToString();

    }

    //change the score
    public void ChangeScore () 
    {
        score++;
        //gm.savedScore = score;
        displayText.text = "Score: " + score.ToString();
    }
        
}
