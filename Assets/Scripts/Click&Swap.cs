using UnityEngine;

public class Clickandswap : MonoBehaviour
{
    private Transform firstSelected = null;

    // Set the max distance allowed for a valid swap
    [SerializeField] private float allowedSwapDistance = 3f;

    //Rea
    public Transform Indicaor;
    public TimerSystem timerScript;
    void Update()
    {
        if (timerScript.timer > 0) 
            {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null)
                {
                    Transform clicked = hit.transform;

                    if (firstSelected == null)
                    {
                        firstSelected = clicked;
                        Indicaor.position = hit.transform.position;
                        Indicaor.SetParent(hit.transform);
                        Indicaor.gameObject.SetActive(true);

                        // Debug.Log($"First selected: {clicked.name}");
                        AudioManager.instance.PlayClick(); // sound effect for click 
                    }
                    else
                    {
                        float distance = Vector3.Distance(firstSelected.position, clicked.position);

                        if (distance <= allowedSwapDistance)
                        {
                            // Swap positions
                            Vector3 tempPos = firstSelected.position;
                            firstSelected.position = clicked.position;
                            clicked.position = tempPos;
                            
                            AudioManager.instance.PlaySwish(); // sound effect for swish

                            //Debug.Log($"Swapped {firstSelected.name} with {clicked.name}");
                            Indicaor.position = hit.transform.position;
                            Indicaor.gameObject.SetActive(false);


                        }
                        else
                        {
                            //Debug.Log($"Too far to swap: {firstSelected.name} and {clicked.name} are {distance:F2} units apart.");
                            AudioManager.instance.PlayError(); // sound effect for error
                            Indicaor.gameObject.SetActive(false);


                        }

                        // Reset selection
                        firstSelected = null;
                    }
                }
                else
                {
                    // Debug.Log("Clicked, but no object was hit.");
                }
            }
        }
    }
}
