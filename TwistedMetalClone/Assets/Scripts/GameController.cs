using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int maxScore = 3;
    [SerializeField] private Text blueScoreText;    
    [SerializeField] private Text redScoreText;
    private int redScore = 0;
    private int blueScore = 0;


    private void Start() {

    }
    private void Awake() {
        
    }

    private void PlayGame() {
        redScore = 0;
        redScoreText.text = redScore.ToString();
        blueScore = 0;
        blueScoreText.text = blueScore.ToString();
    }

    public void IncrementScore(string team) {
        if(team == "Blue") {
            blueScore ++;
            Debug.Log("Blue team scores!");
            blueScoreText.text = blueScore.ToString();
            if(blueScore >= maxScore) {
                Debug.Log("Blue team wins!");
            }
        }
        else if(team == "Red") {
            redScore ++;
            Debug.Log("Red team scores!");
            redScoreText.text = redScore.ToString();
            if(redScore >= maxScore) {
                Debug.Log("Red team wins!");
            }
        }
    }
}
