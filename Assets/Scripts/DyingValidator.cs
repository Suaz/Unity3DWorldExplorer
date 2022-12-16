using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;

public class DyingValidator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform CheckPoint;
    [SerializeField] float minHeight;
    [SerializeField] KinematicCharacterMotor CharacterMotor;
    [SerializeField] GameObject Character;

    void Start()
    {
        //CharacterMotor.SetPosition(CheckPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CheckingFalling();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("trigger");
    //    if (other.CompareTag("CheckPoint"))
    //    {
    //        CheckPoint = other.gameObject.transform;
    //    }
    //}

    private void CheckingFalling()
    {
        if (Character.transform.position.y < minHeight)
        {
            CharacterMotor.SetPosition(CheckPoint.transform.position);
            GameController.Instance.ApplyDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pikes"))
        {
            CharacterMotor.SetPosition(CheckPoint.transform.position);
            GameController.Instance.ApplyDamage();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CharacterMotor.SetPosition(CheckPoint.transform.position);
            GameController.Instance.ApplyDamage();
        }
    }

    public void SetCheckPoint(Transform transform)
    {
        CheckPoint = transform;
    }
}
