using UnityEngine;
namespace lotta
{
    /// <summary>
    /// 玩家狀態
    /// </summary>
    public class PlayerState : State
    {
        protected Player player;
        public PlayerState(Player _player , StateMachine _machine ,string _name)
        {
            player = _player;
            stateMachine = _machine;
            name = _name;
        }

    }

}
