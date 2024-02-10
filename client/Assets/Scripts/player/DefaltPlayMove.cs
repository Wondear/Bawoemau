using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaltPlayMove : MonoBehaviour {
    //�������� ������ �÷��̾� ���� 
    // �÷����� �ൿ. ����, ���� ���� �浹, ����?/�� �̵� 
    private int jumpCount =2;
    private int jumpCnt;
    private bool jumped  =false; //�ش� Ű�Է����� ������ �ߴ��� Ȯ��
    private bool freeze =false; // ĳ���� ���� ��������
    public float jumpPower;
    public float maxSpeed;

    public Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    //Animator animator;

    //�Է¹��� Ű wasd? or ȭ��ǥ,
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


        //����, ���� ������ �����ϰ��� 
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
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; //spriteRenderer  �¿� ����
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

        // ĳ���� �Ʒ��� �ٴ��� �ִ��� Ȯ��, ������ -------------------------------------------------------------------
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
