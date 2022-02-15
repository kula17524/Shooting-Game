using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public GameObject BulletPrefab; //アウトレット接続
    private Ray ray; //Rayの宣言
    private float power = 1500f; //弾の飛ぶ強さ
    private float timeLimit = 3; //弾消滅時間
    GameObject Bullet; //弾のオブジェクト
    public float score = 0; //敵にHITした数
    public float totalScore = 0; //合計スコア
    public float bulletCount = 0; //撃った弾数
    public float totalTime = 30; //制限時間
    GameObject timeText;
    Text time_text;
    bool gameOverFlg;
    GameObject ResultPanel;
    Text result_text;

    void Awake()
    {
        ResultPanel = GameObject.Find("ResultPanel");
        ResultPanel.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Time");
        time_text = timeText.GetComponent<Text>();

        gameOverFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && totalTime != 0)
        {
            //左クリックを押された時の処理
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); //スクリーンの点を通してカメラからRayを通す
            Vector3 dir = ray.direction;
            Bullet = GameObject.Instantiate (BulletPrefab)as GameObject; //弾のオブジェクトを作成
            Bullet.GetComponent<Rigidbody>().AddForce(ray.direction * power);

            bulletCount ++;
        }
        Destroy(Bullet,timeLimit); //弾消滅時間がきたらBulletオブジェクトを削除

        //totalTime減算
        if(totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            time_text.text = "TIME  " + totalTime.ToString("f2");
        }
        else if(gameOverFlg == false)
        {
            gameOverFlg = true;
            
            totalTime = 0;
            time_text.text = "TIME  0";
            ResultPanel.SetActive(true);
            result_text = GameObject.Find("ResultText").GetComponent<Text>();

            if(bulletCount > 0)
            {
                //スコア×命中率×300加算
                float bonus = score * (score / bulletCount) * 300;

                totalScore = (score * 300 + bonus);
            }
            result_text.text = "TOTAL SCORE  " + Mathf.RoundToInt(totalScore).ToString("d4");
        }
    }
}
