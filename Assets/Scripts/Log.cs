using UnityEngine;
namespace lotta
{
    /// <summary>
    /// 輸出類別
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 輸出文字訊息
        /// </summary>
        /// <param name="text">想要輸出的文字</param>
        /// <param name="color">想要設定的顏色</param>
        public static void Text(object text, string color)
        {
            string result = $"<color={color}>{text}</color>";
            Debug.Log(result);
        }
    }

}

