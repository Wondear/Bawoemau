using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSkillForm : MonoBehaviour {
    public string skillName;
    public KeyCode skillKey;
    public Animation ani;
    public AudioClip efx;
    public float preDelay;
    public float postDelay;
    public bool skillCondition = false;
    public bool condition1 = false;
    public float coolTime = 1;
    public float curCoolTime = 0;
    private void Start() {
        StartCoroutine(ConditionCheck());
    }
    public void Update() {

    }

    public virtual IEnumerator ConditionCheck() {
        yield return null;
        bool skillEdge = false;
        while (true) {
            if (curCoolTime > 0) {
                curCoolTime -= Time.deltaTime;
            }
            else if (!skillEdge && curCoolTime <= 0) {
                //스킬 사용 확인
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