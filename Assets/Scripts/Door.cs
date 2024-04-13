using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    #region Enums

    private enum DoorState
    {
        Opened,
        Closed
    }

    #endregion

    #region Variables

    private DoorState doorState;
    [SerializeField] private Transform closedPosition;
    [SerializeField] private Transform openedPosition;

    #endregion

    private void Start()
    {
        doorState = DoorState.Closed;
    }

    private void FixedUpdate()
    {
        if (doorState == DoorState.Opened)
        {
            Vector3 movementVector = new Vector3();

            movementVector = openedPosition.position - transform.position;
            movementVector /= 8;

            transform.Translate(movementVector);
        }
        else
        {
            Vector3 movementVector = new Vector3();

            movementVector = closedPosition.position - transform.position;
            movementVector /= 8;

            transform.Translate(movementVector);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Agent"))
        {
            bool hasKey = collision.collider.GetComponent<AgentCollection>().hasKey;

            if (hasKey)
            {
                doorState = DoorState.Opened;
            }
        }
    }
}
