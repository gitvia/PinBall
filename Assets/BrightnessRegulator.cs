using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {
    //Materialを入れる
    Material myMaterial;

    //Emissionの最小値
    private float minEmission = 0.3f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //角度
    private int degree = 0;
    //発光速度
    private int speed = 10;
    //ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    //スコアを表示するテキスト
    private GameObject scoreText;
    //スコア増加分
    private int incscore = 0;

    // Use this for initialization
    void Start() {

        //タグによって光らせる色を変える
        //タグによってスコアの増分を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
            this.incscore = 10;
        } else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
            this.incscore = 20;
        } else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
            this.incscore = 5;
        }

        //オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);

        //シーン中のGameOverTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update () {

        if (this.degree >= 0)
        {
            //光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            //エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;
        }
	}

    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;

        //スコアを増加
        this.scoreText.GetComponent<ScoreController>().score += this.incscore;
    }
}
