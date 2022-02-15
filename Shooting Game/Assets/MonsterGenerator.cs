using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject slimeGreenPrefab;
    private float counter; //秒数経過カウント
    private float countLimit = 2; //2秒毎にモンスターを生成
    GameObject BulletScript; //BulletScript
    BulletScript bulletScript; //BulletScriptオブジェクトのbulletScript

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;

        BulletScript = GameObject.Find("BulletScript");
        bulletScript = BulletScript.GetComponent<BulletScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletScript.totalTime > 0)
        {
            counter += Time.deltaTime;
            //2秒経ったらcounterを初期化し、モンスターを生成
            if(counter >= countLimit)
            {
               counter = 0;
               GameObject slimeGreen = Instantiate(slimeGreenPrefab) as GameObject;
            }
        }
    }
}
