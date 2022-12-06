using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState 
{

    void HandleInput(string p_inputData);
    IPlayerState UpdateState(PlayerController p_playerController);
    void OnEnter(PlayerController p_playerController);
    void OnExit(PlayerController p_playerController);


}
