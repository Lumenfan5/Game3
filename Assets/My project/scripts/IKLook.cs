using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLook : MonoBehaviour
{
    Animator anim;
    [SerializeField] float lookIKWeight;
    [SerializeField] float headWeight;
    [SerializeField] float bodyWeight;
    [SerializeField] float clampWeight;
    [SerializeField] float timer;
    [SerializeField] Transform targetPos;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactive"))
        {
            TimePlus();
            lookIKWeight = timer;
            headWeight = timer;
            bodyWeight = timer;            
        }
        else
        {
            TimeMinus();
            lookIKWeight = timer;
            headWeight = timer;
            bodyWeight = timer;
        }


    }

    private void OnAnimatorIK()
    {
        anim.SetLookAtWeight(lookIKWeight, headWeight, bodyWeight, clampWeight);
        anim.SetLookAtPosition(targetPos.position);
    }


    //метод для плавного поворота головы в сторону цели
    void TimePlus()
    {
        
        if (timer <= 0.7f)
        {
            timer += Time.deltaTime*2; 
            if(timer >= 0.7f) 
            { 
                timer = 0.7f; 
            }
        } 
        
    }
    void TimeMinus()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0f;
            }
        }
    }
}
