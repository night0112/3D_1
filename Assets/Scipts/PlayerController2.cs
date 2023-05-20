using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    [SerializeField] bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されて、かつ、地面にいたら
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;//ジャンプした＝地面にいない
        }
    }
    //衝突が起きたら実行
    private void OnCollisionEnter(Collision collision)
        
    {
        //ぶつかった相手（collision）のタグがGroundなら
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;//地面についている状態に変更
        }
    }
}
