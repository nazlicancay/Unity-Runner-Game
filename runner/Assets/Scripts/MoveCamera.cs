using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameManager gm;
    public float Cameraspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isGameActive)
        {
            transform.position += new Vector3(0, 0, Cameraspeed * Time.deltaTime);

        }



    }

}
