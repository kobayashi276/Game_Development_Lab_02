using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    public GameController game;
    // public TextMeshProUGUI countText;
    // public GameObject winTextObject;
    // public TextMeshProUGUI positionText;
    // public TextMeshProUGUI speedText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        // game = GetComponent<GameController>();

        game.setCountText(count);
        game.winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(movementX,0.0f,movementY);

        rb.AddForce(movement * speed);

        game.setPositionText(transform.position.ToString());
        game.setSpeedText(rb.velocity.magnitude.ToString());
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;

            game.setCountText(count);
        }

    }

    // void setCountText(){
    //     countText.text = "Count: " + count.ToString();
    //     if (count>=2){
    //         winTextObject.SetActive(true);
    //     }
    // }

    // void setPositionText(string position){
    //     positionText.text = "Posistion: " + position;
    // }

    // void setSpeedText(string speed){
    //     speedText.text = "Speed: " + speed;
    // }
}
