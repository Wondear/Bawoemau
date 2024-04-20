using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //���ΰ��� ��ġ�ְ�ޱ�, ���� �ý��۰��� �� ��ũ��Ʈ
    //�ʿ� ���� ���߷ε�, 

    private bool isEscOn = false;
    private bool isPlaying = false;
    private bool partnerLocation;
    private bool playerLocation;
    private HashSet<int> renderedScenesCode = new HashSet<int>();//�ִ� ������ �� �������ؾ���

    void Start() {

    }

    // Update is called once per frame
    void Update() {



    }

    void renderNewScene(int mapCode, string sceneName) {
        if (!renderedScenesCode.Contains(mapCode)) {  //������ �� �Ǿ����� ��
            renderedScenesCode.Add(mapCode);
        }
    }
}
