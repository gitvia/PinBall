using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコア
    public int score = 0;

    // Use this for initialization
    void Start () {
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update () {
        this.scoreText.GetComponent<Text>().text = "SCORE:" + this.score;
	}
}
