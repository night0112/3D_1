using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;//障害物プレハブ
    Vector3 spawnPos = new Vector3 (25,0,0);//スポーンする場所
    float elapsedTime;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //経過時間が2秒を超えたら
        if(elapsedTime > 2.0f)
        {
            elapsedTime = 0.0f;//経過時間リセット
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
