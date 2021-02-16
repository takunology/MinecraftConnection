using MinecraftConnection.Data;
using MinecraftConnection.ItemsBase;

namespace MinecraftConnection.Items
{
    public static class PotionItem
    {
        /// <summary>
        /// 暗視のポーション (3分)
        /// </summary>
        public static Potion NightVisionPotion = new Potion(Effects.NightVision, false, false);
        /// <summary>
        /// 暗視のポーション (8分)
        /// </summary>
        public static Potion LongNightVisionPotion = new Potion(Effects.NightVision, true, false);
        /// <summary>
        /// 透明化のポーション (3分)
        /// </summary>
        public static Potion InvisibilityPotion = new Potion(Effects.Invisibility, false, false);
        /// <summary>
        /// 透明化のポーション (8分)
        /// </summary>
        public static Potion LongInvisibilityPotion = new Potion(Effects.Invisibility, true, false);
        /// <summary>
        /// 跳躍のポーション (3分)
        /// <para>ジャンプ力 +1ブロック</para>
        /// </summary>
        public static Potion JumpBoostPotion = new Potion(Effects.JumpBoost, false, false);
        /// <summary>
        /// 跳躍のポーション (3分)
        /// <para>ジャンプ力 +2ブロック</para>
        /// </summary>
        public static Potion LongJumpBoostPotion = new Potion(Effects.JumpBoost, true, false);
        /// <summary>
        /// 跳躍のポーション (1分30秒)
        /// <para>ジャンプ力 +2ブロック</para>
        /// </summary>
        public static Potion StrongJumpBoostPotion = new Potion(Effects.JumpBoost, false, true);
        /// <summary>
        /// 耐火のポーション (3分)
        /// <para>火や溶岩などのダメージを無効化</para>
        /// </summary>
        public static Potion FireResistancePotion = new Potion(Effects.FireResistance, false, false);
        /// <summary>
        /// 耐火のポーション (8分)
        /// <para>火や溶岩などのダメージを無効化</para>
        /// </summary>
        public static Potion LongFireResistancePotion = new Potion(Effects.FireResistance, true, false);
        /// <summary>
        /// 俊敏のポーション (3分)
        /// <para>移動速度 +20%</para>
        /// </summary>
        public static Potion SpeedPotion = new Potion(Effects.Speed, false, false);
        /// <summary>
        /// 俊敏のポーション (8分)
        /// <para>移動速度 +20%</para>
        /// </summary>
        public static Potion LongSpeedPotion = new Potion(Effects.Speed, true, false);
        /// <summary>
        /// 俊敏のポーション (1分30秒)
        /// <para>移動速度 +40%</para>
        /// </summary>
        public static Potion StrongSpeedPotion = new Potion(Effects.Speed, false, true);
        /// <summary>
        /// 鈍化のポーション (1分30秒)
        /// <para>移動速度 -15%</para>
        /// </summary>
        public static Potion SlownessPotion = new Potion(Effects.Slowness, false, false);
        /// <summary>
        /// 鈍化のポーション (4分)
        /// <para>移動速度 -15%</para>
        /// </summary>
        public static Potion LongSlownessPotion = new Potion(Effects.Slowness, true, false);
        /// <summary>
        /// 鈍化のポーション (20秒)
        /// <para>移動速度 -60%</para>
        /// </summary>
        public static Potion StrongSlownessPotion = new Potion(Effects.Slowness, false, true);
        /// <summary>
        /// 水中呼吸のポーション (3分)
        /// <para>酸素ゲージが減らなくなる</para>
        /// </summary>
        public static Potion WaterBreathingPotion = new Potion(Effects.WaterBreathing, false, false);
        /// <summary>
        /// 水中呼吸のポーション (8分)
        /// <para>酸素ゲージが減らなくなる</para>
        /// </summary>
        public static Potion LongWaterBreathingPotion = new Potion(Effects.WaterBreathing, true, false);
        /// <summary>
        /// 治癒のポーション (即時)
        /// <para>体力を 2 回復する</para>
        /// </summary>
        public static Potion HealingPotion = new Potion(Effects.Healing, false, false);
        /// <summary>
        /// 治癒のポーション (即時)
        /// <para>体力を 4 回復する</para>
        /// </summary>
        public static Potion StrongHealingPotion = new Potion(Effects.Healing, false, true);
        /// <summary>
        /// 負傷のポーション (即時)
        /// <para>3 のダメージを与える</para>
        /// </summary>
        public static Potion HarmingPotion = new Potion(Effects.Harming, false, false);
        /// <summary>
        /// 負傷のポーション (即時)
        /// <para>6 のダメージを与える</para>
        /// </summary>
        public static Potion StrongHarmingPotion = new Potion(Effects.Harming, false, true);
        /// <summary>
        /// 毒のポーション (45秒)
        /// <para>1.25 秒ごとに 0.5 のダメージを与える</para>
        /// </summary>
        public static Potion PoisonPotion = new Potion(Effects.Poison, false, false);
        /// <summary>
        /// 毒のポーション (1分30秒)
        /// <para>1.25 秒ごとに 0.5 のダメージを与える</para>
        /// </summary>
        public static Potion LongPoisonPotion = new Potion(Effects.Poison, true, false);
        /// <summary>
        /// 毒のポーション (21秒)
        /// <para>0.25 秒ごとに 0.5 のダメージを与える</para>
        /// </summary>
        public static Potion StrongPoisonPotion = new Potion(Effects.Poison, false, true);
        /// <summary>
        /// 再生のポーション (45秒)
        /// <para>2.5 秒ごとに体力を 0.5 回復</para>
        /// </summary>
        public static Potion RegenerationPotion = new Potion(Effects.Regeneration, false, false);
        /// <summary>
        /// 再生のポーション (1分30秒)
        /// <para>2.5 秒ごとに体力を 0.5 回復</para>
        /// </summary>
        public static Potion LongRegenerationPotion = new Potion(Effects.Regeneration, true, false);
        /// <summary>
        /// 再生のポーション (45秒)
        /// <para>1.25 秒ごとに体力を 0.5 回復</para>
        /// </summary>
        public static Potion StrongRegenerationPotion = new Potion(Effects.Regeneration, false, true);
        /// <summary>
        /// 力のポーション (3分)
        /// <para>攻撃力 +3</para>
        /// </summary>
        public static Potion StrengthPotion = new Potion(Effects.Strength, false, false);
        /// <summary>
        /// 力のポーション (8分)
        /// <para>攻撃力 +3</para>
        /// </summary>
        public static Potion LongStrengthPotion = new Potion(Effects.Strength, true, false);
        /// <summary>
        /// 力のポーション (1分30秒)
        /// <para>攻撃力 +6</para>
        /// </summary>
        public static Potion StrongStrengthPotion = new Potion(Effects.Strength, false, true);
        /// <summary>
        /// 弱体化のポーション (1分30秒)
        /// <para>攻撃力 -4</para>
        /// </summary>
        public static Potion WeaknessPotion = new Potion(Effects.Weakness, false, false);
        /// <summary>
        /// 弱体化のポーション (4分)
        /// <para>攻撃力 -4</para>
        /// </summary>
        public static Potion LongWeaknessPotion = new Potion(Effects.Weakness, true, false);
        /// <summary>
        /// 幸運のポーション (5分)
        /// <para>幸運 +1</para>
        /// </summary>
        public static Potion LuckPotion = new Potion(Effects.Luck, false, false);
        /// <summary>
        /// タートルマスターのポーション (20秒)
        /// <para>移動速度 -60%</para>
        /// <para>耐性 III</para>
        /// </summary>
        public static Potion TurtleMasterPotion = new Potion(Effects.TurtleMaster, false, false);
        /// <summary>
        /// タートルマスターのポーション (40秒)
        /// <para>移動速度 -60%</para>
        /// <para>耐性 III</para>
        /// </summary>
        public static Potion LongTurtleMasterPotion = new Potion(Effects.TurtleMaster, true, false);
        /// <summary>
        /// タートルマスターのポーション (20秒)
        /// <para>移動速度 -90%</para>
        /// <para>耐性 IV</para>
        /// </summary>
        public static Potion StrongTurtleMasterPotion = new Potion(Effects.TurtleMaster, false, true);
        /// <summary>
        /// 低速落下のポーション (1分30秒)
        /// <para>落下ダメージ無効化</para>
        /// </summary>
        public static Potion SlowFallingPotion = new Potion(Effects.SlowFalling, false, false);
        /// <summary>
        /// 低速落下のポーション (4分)
        /// <para>落下ダメージ無効化</para>
        /// </summary>
        public static Potion LongSlowFallingPotion = new Potion(Effects.SlowFalling, true, false);
    }
}
