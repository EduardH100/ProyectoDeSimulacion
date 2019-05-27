using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Text healthText;
    public Text infoText;
    public Text finalText;
    public GameObject referencia;

    private Rigidbody rb;
    private int healthPoints;
    private int trashCount;
    private int cansCount;
    private int plantsCount;
    private bool play;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 5f;
        healthPoints = 10;
        cansCount = 0;
        plantsCount = 0;
        trashCount = 20;
        setHealthText();
        finalText.text = "";
        healthText.text = "Health: " + healthPoints.ToString();
        infoText.text = "Cans: " + cansCount.ToString() + "/10    " + "Plant: " + plantsCount.ToString() + "/10";
        play = true;

    }

    void FixedUpdate()
    {
        if (play == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }

            rb.AddForce(moveVertical * referencia.transform.forward * moveSpeed);
            rb.AddForce(moveHorizontal * referencia.transform.right * moveSpeed);
        }
        else
        {
            System.Threading.Thread.Sleep(5000);
            new BotonInicio().IrACreditos();
        }


      
    }

    void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.CompareTag("Can"))
            {
                other.gameObject.SetActive(false);
                healthPoints -= 1;
                trashCount -= 1;
                cansCount += 1;
                setHealthText();
                setInfoCount();


            }
            else if (other.gameObject.CompareTag("Plant"))
            {
                other.gameObject.SetActive(false);
                healthPoints -= 1;
                trashCount -= 1;
                plantsCount += 1;
                setHealthText();
                setInfoCount();

            }
            else if (other.gameObject.CompareTag("Food"))
            {

                if (healthPoints < 10)
                {
                    other.gameObject.SetActive(false);
                    healthPoints += 1;
                    setHealthText();
                }
            }
        
        
    }

    void setHealthText()
    {
        healthText.text = "Health: " + healthPoints.ToString();
        //trashCount = trashCount - (cansCount + plantsCount);

        if (healthPoints == 0 & trashCount == 0)
        {
            finalText.text = "You have cleaned the whole area but you are dead!";
        }
        else if (healthPoints > 0 & trashCount == 0)
        {
            finalText.text = "Congratulations, You have cleaned the whole area!";
        }
        else if (healthPoints == 0 & trashCount > 0)
        {
            finalText.text = "Hoo, You are dead! :(";
        }

        if (trashCount == 0 | healthPoints == 0)
        {
            play = false;

        }
    }

    void setInfoCount()
    {
        infoText.text = "Cans: " + cansCount.ToString() + "/10    " + "Plant: " + plantsCount.ToString() + "/10";
    }

}
