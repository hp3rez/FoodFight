using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class LevelMAnagerScript : MonoBehaviour
{
    [SerializeField] private float sawTimer;
    [SerializeField] private float spikeTimer;
    [SerializeField] private float heartTimer;
    private float sawCountdown;
    private float spikeCountdown;
    private float heartCountdown;
    [SerializeField] private GameObject saw;
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject heart;

    private void Awake() {
    }

    private void Start() {
        sawTimer *= 100;
        spikeTimer *= 100;
        heartTimer *= 100;

        sawCountdown  = sawTimer;
        spikeCountdown = spikeTimer;
        heartCountdown = heartTimer;
    }

    private void Update() {
        if(sawCountdown >= sawTimer) {
            getSaw();
            sawCountdown = 0;
        } else {
            sawCountdown += 1;
        }

        if(spikeCountdown >= spikeTimer) {
            getSpike();
            spikeCountdown = 0;
        } else {
            spikeCountdown += 1;
        } 

        if(heartCountdown >= heartTimer) {
            getHeart();
            heartCountdown = 0;
        } else {
            heartCountdown += 1;
        }
    }

    private void getSaw() {
        Instantiate(saw);
    }

    private void getSpike() {
        Instantiate(spike);
    }

    private void getHeart() {
        Instantiate(heart);
    }
}
