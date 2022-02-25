using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float fltLoadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashsfx;
    bool blnHasCrashed = false;
void OnTriggerEnter2D(Collider2D other)
{
    if(other.tag == "Ground" && !blnHasCrashed)
    {
        blnHasCrashed = true;
        FindObjectOfType<PlayerController>().DisableControls();
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashsfx);
        Invoke("ReloadScene", fltLoadDelay);
    }

}
void ReloadScene(){
SceneManager.LoadScene(0);
}
}
