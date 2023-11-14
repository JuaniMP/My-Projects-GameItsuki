using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villian : MonoBehaviour
{
    public GameObject Nyo;
    // Update is called once per frame
    private void Update()
    {
       Vector3 direction = Nyo.transform.position - transform.position;
       if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
       else  transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    }

}
