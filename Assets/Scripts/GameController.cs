using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI speedText;
    public GameObject pickUpParent;
    public GameObject player;
    private LineRenderer lineRenderer;
    private int gameMode;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        gameMode = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            gameMode++;
            Debug.Log(gameMode);
        }
        else{
            Debug.Log(gameMode);
        }
        if (gameMode%3==0){
            positionText.gameObject.SetActive(false);
            speedText.gameObject.SetActive(false);
            lineRenderer.gameObject.SetActive(false);
        }
        else if (gameMode%3==1){
            positionText.gameObject.SetActive(true);
            speedText.gameObject.SetActive(true);
        }else{
            lineRenderer.gameObject.SetActive(true);
        }
        drawLine(); 
    }

    public void setCountText(int count){
        countText.text = "Count: " + count.ToString();
        if (count>=2){
            winTextObject.SetActive(true);
        }
    }

    public void setPositionText(string position){
        positionText.text = "Posistion: " + position;
    }

    public void setSpeedText(string speed){
        speedText.text = "Speed: " + speed;
    }

    public void drawLine(){
        float min = 9999999999;
        int nearest = 99999999;
        bool check = false;
        for (int i = 0; i < pickUpParent.transform.childCount; i++)
        {
            if (pickUpParent.transform.GetChild(i).gameObject.activeSelf!=false){
                float distance = Vector3.Distance(player.transform.position,pickUpParent.transform.GetChild(i).transform.position);
                if (distance<min){
                    min = distance;
                    nearest = i;
                }
                check=true;
            }

        }
        if(check){
            lineRenderer.SetPosition(0,player.transform.position);
            lineRenderer.SetPosition(1,pickUpParent.transform.GetChild(nearest).transform.position);
            lineRenderer.SetWidth(0.1f,0.1f);
        }
        else{
            lineRenderer.gameObject.SetActive(false);
        }

    }
}
