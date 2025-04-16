using UnityEngine;
namespace lotta
{
    /// <summary>
    /// 狀態機 : 用來設定預設狀態以及狀態切換
    /// </summary>
    public class StateMachine
    {
        public State curentState;
        public void Initialize(State state)
        {
            curentState = state;    //目前狀態 = 待機
            curentState.Enter();    //進入狀態

        }
        public void Update()
        {
            curentState.Update();
        }
    }
}

