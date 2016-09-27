using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GreenScript : MonoBehaviour {

    public int Points;

    public GameObject ScoreBoard;
    public Text ScoreBoardText;
    public Text CurrentScore;

    private bool Dead;

	void Start () {
        ScoreBoard.SetActive(false);
        Dead = false;
	}

    void Update()
    {
        CurrentScore.text = "Score: " + Points.ToString();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && Dead == false)
        {
            GameOver();
            Dead = true;
        }
        else
        {
            return;
        }
    }

    public void GameOver()
    {
        ScoreBoardText.text = Points.ToString();
        ScoreBoard.SetActive(true);
    }
}
