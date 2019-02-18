using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコア用変数
    private int score = 0;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

	}

    //スコアを更新する関数
    public void ScoreUpdate(int incscore)
    {
        this.score += incscore;
        this.GetComponent<Text>().text = "SCORE:" + this.score;
    }
}
