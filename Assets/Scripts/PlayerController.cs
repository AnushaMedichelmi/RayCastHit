using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed;
     SpawnManager spawnManager;
    public Transform bulletLaunch;
    Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnManager = GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.rotation = transform.rotation * Quaternion.Euler(0, mouseX * rotationSpeed, 0);
        Camera cam = GetComponentInChildren<Camera>();
        cam.transform.localRotation = Quaternion.Euler(-mouseY, 0, 0) * cam.transform.localRotation;

        if (Input.GetMouseButtonDown(0))
        {
            HitEnemy();
        }
    }

    public void HitEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletLaunch.position, bulletLaunch.forward, out hit, 100f))
        {
            GameObject hitEnemy = hit.collider.gameObject;
            if (hitEnemy.gameObject.tag == "Enemy")
            {
                Destroy(hitEnemy);
                print("Enemy hit");
                hitEnemy.GetComponent<EnemyController>().EnemyDead();
            }
        }



    }

}
