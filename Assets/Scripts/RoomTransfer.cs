using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 cameraChange;
    public Vector3 playerChange;

    private CameraMovement cameraMovement;

    public bool isPlaceNameShow;
    public string placeName;
    public GameObject textToShow;
    public Text placeText;

    void Awake()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag("Player")){
            cameraMovement.maxPosition += cameraChange;
            cameraMovement.minPosition += cameraChange;

            target.transform.position += playerChange;

             if(isPlaceNameShow){
                StartCoroutine(placeNameCoroutine());
              }

        }
    }

    private IEnumerator placeNameCoroutine(){
        textToShow.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        textToShow.SetActive(false);
    }
}
