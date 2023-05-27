using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 30;
    PlayerController2 playerControllerScript;
    float leftBound = -15;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController2>();
    }
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound)//左の限界値(leftBound)よりも行ってしまったら
        {
            Destroy(gameObject);//障害物を消してしまう
        }
    }
}
