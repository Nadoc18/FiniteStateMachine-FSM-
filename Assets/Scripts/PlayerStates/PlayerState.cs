

using UnityEngine;

public abstract class PlayerState : IPlayerState
{
    public abstract void HandleInput(string p_inputData);

    public abstract void OnEnter(PlayerController p_playerController);

    public abstract void OnExit(PlayerController p_playerController);

    public abstract IPlayerState UpdateState(PlayerController p_playerController);
}

public class StandingState : PlayerState
{
    private IPlayerState m_nextState;

    public override void HandleInput(string p_inputData)
    {
       if(p_inputData == "Space-DOWN")
        {
            m_nextState = new JumpPlayerState();
        }
    }

    public override void OnEnter(PlayerController p_playerController)
    {
      p_playerController.isJumping = false;
    }

    public override void OnExit(PlayerController p_playerController)
    {
        
    }

    public override IPlayerState UpdateState(PlayerController p_playerController)
    {
       if(p_playerController.isJumping == true)
        {
            return new JumpPlayerState();
        }
        return null;
    }
}

public class JumpPlayerState : PlayerState
{
    public override void HandleInput(string p_inputData)
    {
       
    }

    public override void OnEnter(PlayerController p_playerController)
    {
        p_playerController.Jump();
        Debug.Log("OnEnter Jump");
        
    }

    public override void OnExit(PlayerController p_playerController)
    {
        
    }

    public override IPlayerState UpdateState(PlayerController p_playerController)
    {
        if(p_playerController.isJumping == false)
        {
            return new StandingState();
        }
        return null;
    }
}

