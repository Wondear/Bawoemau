using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interactionObject : MonoBehaviour {
    //��ȣ�ۿ��� ������ ��ü(NPC)�� �θ� Ŭ����
    // ��������� �Ǹ� ���̵�(�̹���) ǥ��, �� Ư�� ����Ű�� ������ �۵�

    public string actionKey;
    public GameObject guide;
    public Collider2D objectRange;//Ʈ���ŷ� ������
    public bool isPlayer;

    // Start is called before the first frame update
    protected virtual void Start() {
        guide.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update() {

        if (Input.GetButtonDown(actionKey) && isPlayer) {
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