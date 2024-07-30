using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeMoveScript : MonoBehaviour
{
    public LogicScript logic;

    public float moveSpeed;
    public float deadZone = -30;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x <= deadZone)
        {
            Debug.Log("Bug Deleted");
            Destroy(gameObject);
        }
        else if (logic.isGameOver == true)
        {
            moveSpeed = 0;
        }
    }
}
