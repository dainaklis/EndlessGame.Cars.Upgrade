using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform fireStart;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject newBullet = Instantiate(bullet, fireStart.position, fireStart.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = fireStart.up * bulletSpeed;

        
        
    }




}
