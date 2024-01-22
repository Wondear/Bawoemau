using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaltPlayMove : MonoBehaviour {
    //공통으로 들어가야할 플레이어 동작 
    // 플랫포머 행동. 점프, 몬스터 와의 충돌, 포털?/맵 이동 
    public int jumpCount;
    public int jumpCnt;
    public float jumpPower;
    public float maxSpeed;

    public Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    //Animator animator;

    //입력받을 키 wasd? or 화살표,
    string jump, horiz, warp, exit,skill;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        jumpCnt = jumpCount;
        horiz = "Horizontal";
        jump = "Jump";
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void FixedUpdate() {
        //if (Input.GetButtonDown(warp)) {}
        if (Input.GetButton(jump)&& jumpCnt > 0) {
            //getbuttondown은 프레임마다 확인이라 키씹이 발생함.
            jumpCnt--;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //animator.SetBool("isJumping", true);
    }

        if (Input.GetButtonUp("Horizontal")) {
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

    public void MoveToScene(string path) {
        SceneManager.LoadScene(path);
    
    }
    public void useSkill() { }

}
