using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaceSign : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bubbleDialog;
    public Text dialogText;

    public string dialogContent;
    private bool isPlayerInRange;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isPlayerInRange){
            if(bubbleDialog.activeInHierarchy){
                bubbleDialog.SetActive(false);
            }else{
                bubbleDialog.SetActive(true);
                dialogText.text = dialogContent;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag("Player")){
            isPlayerInRange = true;
        }
    }


    private void OnTriggerExit2D(Collider2D target){
        if(target.CompareTag("Player")){
            isPlayerInRange = false;
            bubbleDialog.SetActive(false);
        }
    }

}
