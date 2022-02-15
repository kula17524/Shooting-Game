using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAction : MonoBehaviour
{
    private float scale;
    private float minScale = 150;
    private float maxScale = 170;
    private string status;

    // Start is called before the first frame update
    void Start()
    {
        float z = Random.Range(490,510); //開始位置のz座標をランダムで作る
        this.gameObject.transform.position = new Vector3(0,0,z); //開始位置
        scale = minScale;
        status = "up";
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(0,0,1); //カメラの方に向かって移動

        if(status == "up")
        {
            scale += 8;
            if(scale >= maxScale)
            {
                //最大になったら小さくする
                scale = maxScale;
                status = "down";
            }
        }
        else
        {
            scale -= 8;
            if(scale <= minScale)
            {
                //最小になったら大きくする
                scale = minScale;
                status = "up";
            }
        }
        this.gameObject.transform.localScale = new Vector3(scale,scale,scale);

        //x座標が-40より小さくなったらオブジェクトを削除
        if(this.gameObject.transform.position.x < -40)
        {
            Destroy(this.gameObject);
        }
    }
}
