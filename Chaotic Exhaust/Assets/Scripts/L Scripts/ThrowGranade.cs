using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGranade : MonoBehaviour
{
    public float throwForce = 500;

    public GameObject granadePrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Throw();
        }
    }

    public void Throw()
    {
        GameObject newGranede = Instantiate(granadePrefab, transform.position, transform.rotation);

        newGranede.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
    }
}
