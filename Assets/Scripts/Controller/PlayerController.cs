using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerState m_currentState;
    private Rigidbody m_Rigidbody;
    public bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody=GetComponent<Rigidbody>();

        m_currentState = new StandingState();
        m_currentState.OnEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            ProcessInputData("Space-DOWN");
            isJumping = true;
        }



        var _nextState = m_currentState.UpdateState(this);
        if (_nextState != null)
        {
            m_currentState.OnExit(this);
            m_currentState = _nextState;
            m_currentState.OnEnter(this);
        }
        Debug.Log(_nextState);

    }

    private void ProcessInputData(string p_inputData)
    {
        m_currentState.HandleInput(p_inputData);
    }

    public void Jump()
    {
        m_Rigidbody.AddForce(Vector3.up * 300);
    }
}
