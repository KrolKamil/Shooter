using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int gainedPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("IM GAME CONTRLL");
    }

    public void gainPoint()
    {
        gainedPoints++;
        if(gainedPoints >= 3)
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
