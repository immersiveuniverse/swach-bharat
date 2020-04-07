using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotA22Controller_3D : MonoBehaviour
{
    public GameObject TrashObject, ContainerObject, timerObject, BagScoredObject;
    public Button btnShot, btnBoost, btnStart;
    public Sprite spriteBoost_OG, spriteBoost, spriteStart_OG, spriteStart;

    public float force;
    private bool canThrow = true;

    private float timeLeft = 30f;
    private float target = 30f;

    private readonly float throwTime = 1f;
    private readonly float minForce = 100f, maxForce = 200f;

    private bool boolForce = false;
    public void ApplyForce()
    {
        if (!boolForce)
        {
            force = maxForce;
            boolForce = true;
            btnBoost.GetComponent<Image>().sprite = spriteBoost;
            boostAudio.Play();
        }
        else
        {
            force = minForce;
            boolForce = false;
            btnBoost.GetComponent<Image>().sprite = spriteBoost_OG;
        }
    }


    int countBags = 0;
    string trashTag = "TrashBagTag";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(trashTag)) {
            countBags++;
            Destroy(other.gameObject);
            //Debug.Log(countBags);
        }
    }

    private bool boolGameOver = false;
    public void ShotTimer() {
        if (!boolGameOver)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft >= 0 && countBags < target)
            {
                TrashSpawn();
                timerObject.GetComponent<TextMesh>().text = timeLeft.ToString("f0");
                BagScoredObject.GetComponent<TextMesh>().text = countBags.ToString();

            }
            else if (timeLeft >= 0 && countBags == target)
            {
                timerObject.GetComponent<TextMesh>().text = "You";
                BagScoredObject.GetComponent<TextMesh>().text = "Win";
                winAudio.Play();
                boolGameOver = true;
                boolStartGame = false;
            }
            else if (timeLeft < 0 && countBags < target)
            {
                timerObject.GetComponent<TextMesh>().text = "You";
                BagScoredObject.GetComponent<TextMesh>().text = "Lose";
                lossAudio.Play();
                boolGameOver = true;
                boolStartGame = false;
            }
        }
    }

    public bool boolStartGame = false;

    private void Update()
    {
        if (boolStartGame)
        {
            ShotTimer();
            btnStart.GetComponent<Image>().sprite = spriteStart;
        }
        else
        {
            btnStart.GetComponent<Image>().sprite = spriteStart_OG;
        }
    }

    public void StartShotGame() {
        startAudio.Play();
        boolStartGame = true;
        boolGameOver = false;
        timeLeft = 30f;
        countBags = 0;
        Debug.Log(Time.deltaTime);
    }


    private bool btnShotActivate = false;
    public AudioSource shootAudio, startAudio, boostAudio, winAudio, lossAudio;
    public void ButtonShotActivator() {
        btnShotActivate = true;
        shootAudio.Play();
    }

    public void TrashSpawn() {
        GameObject _TrashObject;
        if (btnShotActivate && canThrow == true) {
            Vector3 shootPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _TrashObject = Instantiate(TrashObject, shootPosition, transform.rotation) as GameObject;

            Rigidbody _rb_TrashObject;
            _rb_TrashObject = _TrashObject.GetComponent<Rigidbody>();
            //_rb_TrashObject.AddForce((Vector3.forward + canThrowDirection) * force );

            //Debug.Log(Vector3.forward + "   " + shootPosition + "   " + _TrashObject.transform.position+"   "+ Input.mousePosition);
            //_rb_TrashObject.AddForce(-_TrashObject.transform.position * force );
            _rb_TrashObject.AddForce(-shootPosition * force);

            Destroy(_TrashObject, 2f);
            canThrow = false;
            btnShotActivate = false;
            StartCoroutine(DelayTrashSpawn());
        }
    }

    /* public void TrashSpawn()
    {
        GameObject _TrashObject;
        if (Input.GetMouseButtonDown(0) && canThrow == true)
        {
            Vector3 shootPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _TrashObject = Instantiate(TrashObject, shootPosition, transform.rotation) as GameObject;

            Rigidbody _rb_TrashObject;
            _rb_TrashObject = _TrashObject.GetComponent<Rigidbody>();
            //_rb_TrashObject.AddForce((Vector3.forward + canThrowDirection) * force );

            //Debug.Log(Vector3.forward + "   " + shootPosition + "   " + _TrashObject.transform.position+"   "+ Input.mousePosition);
            //_rb_TrashObject.AddForce(-_TrashObject.transform.position * force );
            _rb_TrashObject.AddForce(-shootPosition * force);

            Destroy(_TrashObject, 2f);
            canThrow = false;
            StartCoroutine(DelayTrashSpawn());
        }
    } */

    IEnumerator DelayTrashSpawn() {
        yield return new WaitForSeconds(throwTime);
        canThrow = true;
    }
}
