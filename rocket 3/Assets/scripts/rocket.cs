using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour
{
    Rigidbody rocketRB;
    AudioSource rocketAudioSource;

    // SerializeField
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float thrustspeed = 5.0f;
    [SerializeField] float rotationspeed = 2.5f;



    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        rocketAudioSource = GetComponent<AudioSource>();


    } 

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }
    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) {
        print("Thrust");
            rocketRB.AddRelativeForce(Vector3.up*thrustspeed);
            if (!rocketAudioSource.isPlaying) {
                rocketAudioSource.PlayOneShot(mainEngine);
            }
    }  else
        {
            rocketAudioSource.Stop();
        }
}
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        switch(collision.gameObject.tag)
        {
            case "friendly":
                print("No problem");
                break;
            case "Finish":
                print("You win!!!!!");
                SceneManager.LoadScene(1);
                break;
            default:
                   print("you lose :( ");
                SceneManager.LoadScene(0);
                break;
            case "Finishe 2":
                print("good job you win");
                SceneManager.LoadScene(2);
                break;
        }
    }

    void LoadNextScene()
    {

    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            print("Rotating Left");
            transform.Rotate(Vector3.forward *rotationspeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotating right");
            transform.Rotate(-Vector3.forward *rotationspeed);
        }
    }






}
