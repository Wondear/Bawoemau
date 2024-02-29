using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class interactionObject : MonoBehaviour {
    //상호작용이 가능한 물체(NPC)의 부모 클래스
    // 적용범위가 되면 가이드(이미지) 표시, 및 특정 방향키를 누르면 작동

    public KeyCode actionKey;
    public GameObject guide;
    public Collider2D objectRange;//트리거로 동작함
    public bool isPlayer;

    // Start is called before the first frame update
    protected virtual void Start() {
        guide.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update() {

        if (Input.GetKeyDown(actionKey) && isPlayer) {
            action();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            toggleState(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            toggleState(false);
        }
    }

    void toggleState( bool inter) {
        isPlayer = inter;
        if (guide)guide.SetActive(inter);

    }

    public virtual void action() { }
}