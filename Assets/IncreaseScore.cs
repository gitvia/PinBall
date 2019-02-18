using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScore : MonoBehaviour {

    //スコア増加用の変数
    private int incscore = 0;

    //スコアを表示するテキスト
    private GameObject scoreText;

	// Use this for initialization
	void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        //タグによってスコアの増分を変える
        if (tag == "SmallStarTag")
        {
            this.incscore = 10;
        }
        else if (tag == "LargeStarTag")
        {
            this.incscore = 20;
        }
        else if (tag == "SmallCloudTag")
        {
            this.incscore = 5;
        }
        else if (tag == "LargeCloudTag")
        {
            this.incscore = 8;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision other)
    {
        //スコアを更新
        this.scoreText.GetComponent<ScoreController>().ScoreUpdate(this.incscore);
    }
}
