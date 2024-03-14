using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSkillForm : MonoBehaviour
{
    public string skillName;
    public KeyCode skillKey;
    public Animation ani; //재생할 이펙트
    public AudioClip efx; //효과음
    public float preDelay;
    public float postDelay;
    public bool skillCondition= false;
    public bool condition1=false;
    public float coolTime =1;
    public float curCoolTime=0;
    private void Start() {
        StartCoroutine(ConditionCheck());
    }
    public void Update() {
        
    }

    public virtual IEnumerator ConditionCheck () {
        yield return null;
        bool skillEdge = false;
        while (true) {
            if (curCoolTime > 0) {
                curCoolTime -= Time.deltaTime;
            }
            else if (!skillEdge && curCoolTime <= 0) { 
                //쿨타임이 다됐을때
                skillCondition = true;
            }
            skillEdge = skillCondition;
            yield return new WaitForFixedUpdate();
        }

    }
    public virtual IEnumerator action() {
        yield return new WaitForSeconds(preDelay);
            
        yield return new WaitForSeconds(postDelay);
        curCoolTime = coolTime;
        yield return null;
    }
    public bool returnOk() {
        return skillCondition && condition1;
    }
    public void skillSetOK() { 
        
    }

}
