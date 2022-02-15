using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletAction : MonoBehaviour
{
    GameObject scoreText;
    Text score_text;
    GameObject hitText;
    Text hit_text;
    private float point = 1; //加算ポイント
    GameObject BulletScript; //Bulletscript
    BulletScript bulletScript; //BulletScriptオブジェクトのbulletscript

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score");
        score_text = scoreText.GetComponent<Text>();
        hitText = GameObject.Find("Hit");
        hit_text = hitText.GetComponent<Text>();

        BulletScript = GameObject.Find("BulletScript");
        bulletScript = BulletScript.GetComponent<BulletScript>();
        hit_text.text = "HIT  " + bulletScript.score + "/" + bulletScript.bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        hit_text.text = "HIT  " + bulletScript.score + "/" + bulletScript.bulletCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy") //タグで指定
        {
            Destroy(collision.gameObject);
            //ぶつかった場所で固定
            this.GetComponent<Rigidbody>().isKinematic = true;
            //パーティクルの再生
            this.GetComponent<ParticleSystem>().Play();
            //透明にする
            this.GetComponent<Renderer>().material.color = new Color(0,0,0,0);
            //1秒したら消滅させる
            Destroy(this.gameObject,1);

            //score加算
            bulletScript.score += point;
            bulletScript.totalScore = bulletScript.score * 300;

            score_text.text = "SCORE  " + bulletScript.totalScore.ToString();

        }
    }
}
