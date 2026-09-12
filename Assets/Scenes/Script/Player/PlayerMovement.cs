using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Tooltip("Kecepatan gerak karakter")]
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");    


        Vector2 movement = new Vector2(moveX, moveY);
     
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}