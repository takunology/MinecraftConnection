using MinecraftConnection.Data;

namespace MinecraftConnection.ItemsBase
{
    /// <summary>
    /// ポーションに関するクラスです。
    /// </summary>
    public class Potion
    {
        /// <summary>
        /// ポーションの持っている効果
        /// </summary>
        public Effects Effect { get; set; }
        /// <summary>
        /// 延長効果
        /// </summary>
        public bool Long { get; set; }
        /// <summary>
        /// 強力な効果
        /// </summary>
        public bool Strong { get; set; }
        /// <summary>
        /// ポーションを作ります。
        /// </summary>
        /// <param name="Effect">ポーション効果</param>
        /// <param name="IsLong">延長の有無</param>
        /// <param name="IsStrong">強力の有無</param>
        /// <exception cref=""></exception>
        public Potion(Effects Effect, bool IsLong, bool IsStrong)
        {
            if (IsLong && IsStrong == true)
                throw new System.Exception("延長効果と強力効果は併用できません。");

            this.Effect = Effect;
            this.Long = IsLong;
            this.Strong = IsStrong;
        }

    }
}
