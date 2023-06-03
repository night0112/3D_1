using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    [SerializeField] bool isOnGround = true;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem dirtParticle;
    public bool gameOver;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されて、かつ、地面にいたら、ゲームオーバーではないなら
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;//ジャンプした＝地面にいない
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }
    //衝突が起きたら実行
    private void OnCollisionEnter(Collision collision)
        
    {
        //ぶつかった相手（collision）のタグがGroundなら
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;//地面についている状態に変更
            if(gameOver == false)
            {
                dirtParticle.Play();
            }
            
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;//ゲームオーバー
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
}
