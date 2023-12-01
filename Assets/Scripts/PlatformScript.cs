using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update() {
        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;

        if(transform.position.x <= -1.75) {
            Destroy(gameObject);
        }
    }
}
