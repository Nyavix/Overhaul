using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool moveLeft = true;
    private float detectRange = 1f;
    private LayerMask groundLayers;

    public Transform groundDetection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveLeft = true;
            }
        }

        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, transform.right, 2f);
        if (wallInfo.collider.CompareTag("Cubes"))
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveLeft = true;
            }
        }
        
 
    }
}
