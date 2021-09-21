using UnityEngine;

public class DestroyAfterAnimation : StateMachineBehaviour
{
    //Called when animation finishes
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Game Object is destroyed
        Destroy(animator.gameObject);
    }
}
