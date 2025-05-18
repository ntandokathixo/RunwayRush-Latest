using UnityEngine;




public class PlayOnStart : MonoBehaviour
{
    public string animationStateName = "Walk";  

    void Start()
    {
        GetComponent<Animator>().Play(animationStateName);
    }
}