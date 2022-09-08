using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFoot : MonoBehaviour
{
    Animator anim;
    Vector3 leftFootPos;
    Vector3 rightFootPos;
    Quaternion leftFootRot;
    Quaternion rightFootRot;
    float leftFootWeight;
    float rightFootWeight;
    Transform leftFoot;
    Transform rightFoot;
    [SerializeField] float offsetY;
    //[SerializeField] float lookIKWeight;
    //[SerializeField] float headWeight;
    //[SerializeField] float bodyWeight;
    //[SerializeField] float clampWeight;
    //[SerializeField] Transform targetPos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        leftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        leftFootRot = leftFoot.rotation;
        rightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
        rightFootRot = rightFoot.rotation;
    }

    private void Update()
    {
        RaycastHit leftHit;
        Vector3 lPos = leftFoot.position;
        if(Physics.Raycast(lPos + Vector3.up*0.5f, Vector3.down,out leftHit))
        {
            leftFootPos = Vector3.Lerp(lPos, leftHit.point + Vector3.up * offsetY, Time.deltaTime * 10f);
            leftFootRot = Quaternion.FromToRotation(transform.up, leftHit.normal) * transform.rotation;
            Debug.DrawLine(lPos, leftFootPos);
        }

        RaycastHit rightHit;
        Vector3 rPos = rightFoot.position;
        if (Physics.Raycast(rPos + Vector3.up * 0.5f, Vector3.down, out rightHit))
        {
            rightFootPos = Vector3.Lerp(rPos, rightHit.point + Vector3.up * offsetY, Time.deltaTime * 10f);
            rightFootRot = Quaternion.FromToRotation(transform.up, rightHit.normal) * transform.rotation;
            Debug.DrawLine(rPos, rightFootPos);
        }
    }

   

    private void OnAnimatorIK()
    {
        //anim.SetLookAtWeight(lookIKWeight, headWeight, bodyWeight, clampWeight);
        //anim.SetLookAtPosition(targetPos.position);

        leftFootWeight = anim.GetFloat("LeftFoot");

        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
        anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPos);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
        anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRot);

        rightFootWeight = anim.GetFloat("RightFoot");

        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPos);
        anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRot);
    }
    }
