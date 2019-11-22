using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int gainedPoints = 0;
    public Text boosses;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("IM GAME CONTRLL");
        boosses.text = (3 - gainedPoints).ToString();
    }

    public void gainPoint()
    {
        gainedPoints++;
        int newScore = 3 - gainedPoints;
        boosses.text = newScore.ToString();
        if (gainedPoints >= 3)
        {
            winGame();
        }
    }

    public void winGame()
    {
        SceneManager.LoadScene("Win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
