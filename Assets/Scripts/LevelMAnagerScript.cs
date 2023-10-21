using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class LevelMAnagerScript : MonoBehaviour
{
    private float sawTimer;
    private float spikeTimer;
    private float heartTimer;
    private float sawCountdown;
    private float spikeCountdown;
    private float heartCountdown;
    [SerializeField] private GameObject saw;
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject heart;

    private void Start() {
        sawTimer = 4;
        spikeTimer = 6;
        heartTimer = 20;

        sawCountdown  = 0;
        spikeCountdown = 0;
        heartCountdown = 0;

        getSaw();
    }

    private void Update() {
        if(sawCountdown >= sawTimer) {
            getSaw();
            sawCountdown = 0;
            sawTimer = Random.Range(3, 7);
        } else {
            sawCountdown += Time.deltaTime;
        }

        if(spikeCountdown >= spikeTimer) {
            getSpike();
            spikeCountdown = 0;
            spikeTimer = Random.Range(3, 7);
        } else {
            spikeCountdown += Time.deltaTime;
        } 

        if(heartCountdown >= heartTimer) {
            getHeart();
            heartCountdown = 0;
            heartTimer = Random.Range(15, 20);
        } else {
            heartCountdown += Time.deltaTime;
        }
    }

    private void getSaw() {
        Instantiate(saw, new Vector3(1.95f, -0.115f, 0), transform.rotation);
    }

    private void getSpike() {
        Instantiate(spike, new Vector3(1.95f, 0.153f, 0), transform.rotation);
    }

    private void getHeart() {
        Instantiate(heart, new Vector3(1.95f, 0.067f, 0), transform.rotation);
    }
}