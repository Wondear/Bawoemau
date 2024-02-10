using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaltPlayMove : MonoBehaviour {
    //공통으로 들어가야할 플레이어 동작 
    // 플랫포머 행동. 점프, 몬스터 와의 충돌, 포털?/맵 이동 
    private int jumpCount =2;
    private int jumpCnt;
    private bool jumped  =false; //해당 키입력으로 점프를 했는지 확인
    private bool freeze =false; // 캐릭터 조작 금지상태
    public float jumpPower;
    public float maxSpeed;

    public Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    //Animator animator;

    //입력받을 키 wasd? or 화살표,
    KeyCode warp, exit, skill1, skill2 , talk;
    string jump, horiz;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        jumpCnt = jumpCount;
        horiz = "Horizontal";
        jump = "Jump";
        talk = KeyCode.KeypadEnter;
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void FixedUpdate() {
        if (!freeze) { 
        //if (Input.GetButtonDown(warp)) {}


        //점프, 다중 점프가 가능하게함 
        if (Input.GetButton(jump)&& !jumped&&jumpCnt > 0) {
            jumped = true;
            jumpCnt--;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //animator.SetBool("isJumping", true);
        }
        else if (!Input.GetButton(jump))
            jumped = false;
            //-
        //if (Input.GetButtonDown("Retern"))
              //  Debug.Log("talk");

        if (Input.GetButtonUp(horiz)) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            //animator.SetBool("isWalking", false);
        }

        if (Input.GetButton("Horizontal")) {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; //spriteRenderer  좌우 반전
                                                                         //capsuleCollider.set.Offset = new Vector2(capsuleCollider.x * (-1), capsuleCollider.y);
            //animator.SetBool("isWalking", true);
        }
        //if (Input.GetButtonDown(exit)) { }
        //if (Input.GetButtonDown(skill)) { }

        float h = Input.GetAxisRaw(horiz);

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1)) {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        // 캐릭터 아래에 바닥이 있는지 확인, 착지함 -------------------------------------------------------------------
        Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Ground"));
        //Debug.Log("Collider Layer: " + rayHit.collider.gameObject.layer);
        //Debug.Log("Hit distance: " + rayHit.distance);
        if (rayHit.collider != null && rigid.velocity.y < 0) {
            if (rayHit.distance <0.9f) {
                //animator.SetBool("isClimb", false);
                //animator.SetBool("isJumping", false);
                jumpCnt = jumpCount;
            }
        }
        }
    }
    public bool toggleFreeze() {
        freeze = !freeze; 
        return freeze; 
    }

    public void MoveToScene(string path) {
        SceneManager.LoadScene(path);
    
    }
    public void useSkill() { }

}
