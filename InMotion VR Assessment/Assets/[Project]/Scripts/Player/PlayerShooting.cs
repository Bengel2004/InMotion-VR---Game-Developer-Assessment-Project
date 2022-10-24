using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float timeStamp = 0.0f;
    [SerializeField] private float rateOfFire = 60;

    [SerializeField] private ParticleSystem[] laserParticles = default;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && SimpleGameManger.GameIsStarted)
        {
            if(Time.time > timeStamp)
            {
                timeStamp = Time.time + (60 / rateOfFire);

                foreach(ParticleSystem laser in laserParticles)
                {
                    laser.Play();
                }
            }
        }
    }
}
