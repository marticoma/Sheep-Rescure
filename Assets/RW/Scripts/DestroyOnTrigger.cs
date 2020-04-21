using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public string tagFilter;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag(tagFilter)){
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
