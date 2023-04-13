using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButtonScript : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    private PlayerScript sp_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Open()
    {
        sp_ = FindObjectOfType<PlayerScript>();

        if (sp_.Button1 == true && sp_.Button2 == true)
        {
            Destroy(Door1);
            Destroy(Door2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
