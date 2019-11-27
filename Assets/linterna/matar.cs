using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "aa")
        {
            Destroy(col.gameObject);

        }
    }
     void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "aa")
        {
            Destroy(this.gameObject);
        }
    }
   
}
