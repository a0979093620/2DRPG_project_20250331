using UnityEngine;
namespace lotta
{
    /// <summary>
    /// 玩家跳躍
    /// </summary>
    public class PlayerJump : PlayerState
    {
        public PlayerJump(Player _player, StateMachine _machine, string _name) : base(_player, _machine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.rig.linearVelocity = new Vector2(0, player.jumpForce);
            player.ani.SetBool("空中", true);
            player.ani.SetFloat("跳躍", 1);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}

