using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class defaltMap { //�ʿ� ����ī�޶� �ο����� ����
    public string mapName;
    public int mapNumber;
    public int[] mapLocation = new int[2]; //�� ��ǥ, �ٸ��ŷ� �ٲ� �� ����
    public bool first = true;   //ù ����
    public Collider2D mapRange; //Ʈ����ó�� �� ĳ���Ͱ� ������ ī�޶� ��ȯ
    public Collider2D cameraRange; // ī�޶� ����
    public List<int> surroundMap;
    public int renderTime = -1; //�� �̵��ÿ� ����
    //public Vector3 MapSpawnPosition;
    public defaltMap() { 
        
    }

}
