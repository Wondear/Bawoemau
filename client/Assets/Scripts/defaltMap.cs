using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class defaltMaps : MonoBehaviour {
    public string mapName;
    public int mapNumber;
    public int[] mapLocation = new int[2]; //맵 좌표, 다른거로 바뀔 수 있음
    public Collider2D mapRange; //트리거처리 후 캐릭터가 들어오면 카메라 전환
    public Collider2D cameraRange; // 카메라 범위
                                   //public Vector3 MapSpawnPosition;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


}
