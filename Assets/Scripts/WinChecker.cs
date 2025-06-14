using NUnit.Framework;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    public Transform[] modelSlots; // Slots that hold the model GameObjects
    public GameObject winPanel;
    public GameObject losePanel;
    public float checkDelay = 1f; // How often to check (optional)

    private bool gameEnded = false;


    //Rea's Code
    public string ObjTag;
    public WinCHeckerManager WinManagerScript;

    void Start()
    {
        InvokeRepeating(nameof(CheckForWin), 1f, checkDelay);
        ObjTag = gameObject.tag;
    }

    void CheckForWin()
    {
        /*if (gameEnded) return;

        for (int i = 0; i < modelSlots.Length; i += 3)
        {
            if (i + 2 >= modelSlots.Length) return;

            string tag1 = modelSlots[i].GetChild(0).tag;
            string tag2 = modelSlots[i + 1].GetChild(0).tag;
            string tag3 = modelSlots[i + 2].GetChild(0).tag;

            if (tag1 != tag2 || tag1 != tag3)
            {
                return; // Not a match, so don't win yet
            }
        }

        gameEnded = true;
        winPanel.SetActive(true);
        Debug.Log("You WIN!");*/

        

    }

    public void OnTimeUp()
    {
        if (gameEnded) return;

        gameEnded = true;
        losePanel.SetActive(true);
        Debug.Log("You LOST!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag))
        {
            if (gameObject.name != ObjTag)
            {
                WinManagerScript.Models.Add(gameObject);
            }
            gameObject.name = ObjTag;


        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ObjTag))
        {
            if (gameObject.name == ObjTag)
            {
                WinManagerScript.Models.Remove(gameObject);
            }
            gameObject.name = "Model";

        }
    }

}

