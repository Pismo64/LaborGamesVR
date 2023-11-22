using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 40;
    public float range = 15;
    public int damage;
    public GameObject rayCastPoint;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Shoot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spwanedBullet = Instantiate(bullet);
        spwanedBullet.transform.position = spawnPoint.position;
        spwanedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spwanedBullet, 5);
    }

    public void Shoot(ActivateEventArgs arg)
    {
        
        if (Physics.Raycast(rayCastPoint.transform.position, rayCastPoint.transform.forward, out RaycastHit hit, range))
        {
            if (hit.transform.TryGetComponent<Bot1Script>(out var bot1Script))
            {
                bot1Script.TakeDamage(damage);
            }
            if (hit.transform.TryGetComponent<Bot2Script>(out var bot2Script))
            {
                bot2Script.TakeDamage(damage);
            }
            if (hit.transform.TryGetComponent<Bot3Script>(out var bot3Script))
            {
                bot3Script.TakeDamage(damage);
            }
            if (hit.transform.TryGetComponent<Bot4Script>(out var bot4Script))
            {
                bot4Script.TakeDamage(damage);
            }
        }
    }
}
