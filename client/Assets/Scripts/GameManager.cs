using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //서로간의 위치주고받기, 게임 시스템관리 할 스크립트
    //맵에 대한 다중로드, 

    private bool isPause;
    private bool partnerLocation;
    private List<int> renderedScenes = new List<int>();//최대 랜더링 씬 개수정해야함
    private int maxSceneCnt = 16; //사양에 따라 달라질 수 있음
    private defaltMaps[] wholeMap;

    void Start()
    {
        //맵정보 엑셀 추가예정
        wholeMap = new defaltMaps[64];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int[] delSceneList(int numOfMap) { // 삭제할 신 리스트 
        int[] delMapList = new int[numOfMap];
        //처리로직 추가예정 추가된지 오래됐고, 현재위치에서 먼 순서로 삭제
        
        return delMapList;
    }
    void renderNewScenes(int[] mapNums) {
        //조건설정
        int cnt = mapNums.Length;
        if (renderedScenes.Count + cnt >= maxSceneCnt) {
            int[] sceneList = delSceneList(cnt);
            for (int i = 0; i < cnt; i++) {
                int tmp = sceneList[i];
                renderedScenes.Remove(tmp);
                SceneManager.UnloadSceneAsync(tmp);
            }
        }
        for (int i = 0; i < cnt; i++) {

        }

    }
}
