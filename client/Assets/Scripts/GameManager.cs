using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //서로간의 위치주고받기, 게임 시스템관리 할 스크립트
    //맵에 대한 다중로드, 

    private bool isPause;
    private bool partnerLocation;
    private Queue<string> renderedScenes = new Queue<string>();//최대 랜더링 씬 개수정해야함

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void renderNewScene(string sceneName) { 
        
    }
}
