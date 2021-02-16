using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Data
{
    /// <summary>
    /// エンチャント
    /// </summary>
    public enum Enchantments
    {
        /// <summary>
        /// 水中採掘 (ヘルメット) Lv1 
        /// <para>水中での採掘速度が上昇します。</para>
        /// </summary>
        [MinecraftID("aqua_affinity")]
        AquaAffinity,
        /// <summary>
        /// 虫特効 (剣, 斧) Lv1 - Lv5
        /// <para>虫へのダメージが増加します。</para>
        /// </summary>
        [MinecraftID("bane_of_arthropods")]
        BaneOfArthropods,
        /// <summary>
        /// 爆発耐性 (防具) Lv1 - Lv4
        /// <para>爆発のダメージを軽減します。</para>
        /// </summary>
        [MinecraftID("blast_protection")]
        BlastProtection,
        /// <summary>
        /// 召雷 (トライデント) Lv1
        /// <para>雷を落とせるようになります。</para>
        /// </summary>
        [MinecraftID("channeling")]
        Channeling,
        /// <summary>
        /// 束縛の呪い (防具) Lv1
        /// <para>1度装備すると外せなくなります。</para>
        /// </summary>
        [MinecraftID("binding_curse")]
        CurseOfBinding,
        /// <summary>
        /// 消滅の呪い Lv1
        /// <para>死ぬとアイテムが消滅します。</para>
        /// </summary>
        [MinecraftID("depth_strider")]
        CurseOfVanishing,
        /// <summary>
        /// 水中歩行 (ブーツ) Lv1 - Lv3
        /// <para>水中での移動速度が上昇します。</para>
        /// </summary>
        [MinecraftID("absorption")]
        DepthStrider,
        /// <summary>
        /// 効率強化 (採掘ツール) Lv1 - Lv5
        /// <para>採掘速度が上昇します。</para>
        /// </summary>
        [MinecraftID("efficiency")]
        Efficiency,
        /// <summary>
        /// 落下耐性 (ブーツ) Lv1 - Lv4
        /// <para>落下した際のダメージを軽減します。</para>
        /// </summary>
        [MinecraftID("feather_falling")]
        FeatherFalling,
        /// <summary>
        /// 火属性 (剣) Lv1 - Lv2
        /// <para>斬った相手に火をつけます。</para>
        /// </summary>
        [MinecraftID("fire_aspect")]
        FireAspect,
        /// <summary>
        /// 火炎耐性 (防具) Lv1 - Lv4
        /// <para>火のダメージを軽減します。</para>
        /// </summary>
        [MinecraftID("fire_protection")]
        FireProtection,
        /// <summary>
        /// フレイム (弓) Lv1
        /// <para>撃った矢に火がつきます。</para>
        /// </summary>
        [MinecraftID("flame")]
        Flame,
        /// <summary>
        /// 幸運 (採掘ツール) Lv1 - Lv3
        /// <para>採掘したときのアイテムドロップ量が増えやすくなります。</para>
        /// </summary>
        [MinecraftID("fortune")]
        Fortune,
        /// <summary>
        /// 氷渡り (ブーツ) Lv1 - Lv2
        /// <para>水上を歩行すると氷に変化します。</para>
        /// </summary>
        [MinecraftID("frost_walker")]
        FrostWalker,
        /// <summary>
        /// 水性特効 (トライデント) Lv1 - Lv5
        /// <para>水生生物へのダメージを増加します。(ドラウンドは含まない)</para>
        /// </summary>
        [MinecraftID("impaling")]
        Impaling,
        /// <summary>
        /// 無限 (弓) Lv1
        /// <para>矢を消費せずに撃つことができるようになります。</para>
        /// </summary>
        [MinecraftID("infinity")]
        Infinity,
        /// <summary>
        /// ノックバック (剣) Lv1 - Lv2
        /// <para>攻撃した際に相手をはじき飛ばします。</para>
        /// </summary>
        [MinecraftID("knockback")]
        Knockback,
        /// <summary>
        /// ドロップ増加 (剣) Lv1 - Lv3
        /// <para>Mobを倒したときのアイテムドロップ量が増えやすくなります。</para>
        /// </summary>
        [MinecraftID("looting")]
        Looting,
        /// <summary>
        /// 忠誠 (トライデント) Lv1 - Lv3
        /// <para>投げたトライデントが自動で戻って来やすくなります。</para>
        /// </summary>
        [MinecraftID("loyalty")]
        Loyality,
        /// <summary>
        /// 宝釣り (釣り竿) Lv1 - Lv3
        /// <para>宝を釣り上げる確率が増加します。</para>
        /// </summary>
        [MinecraftID("luck_of_the_sea")]
        LuckOfTheSea,
        /// <summary>
        /// 入れ食い (釣り竿) Lv1 - Lv3
        /// <para>魚が食いつくまでの時間が短縮されます。</para>
        /// </summary>
        [MinecraftID("lure")]
        Lure,
        /// <summary>
        /// 修繕 Lv1
        /// <para>経験値を取得すると耐久度が回復します。</para>
        /// </summary>
        [MinecraftID("mending")]
        Mending,
        /// <summary>
        /// 拡散 (クロスボウ) Lv1
        /// <para>矢を1本消費して扇状に3本撃てるようになります。</para>
        /// </summary>
        [MinecraftID("multishot")]
        Multishot,
        /// <summary>
        /// 貫通 (クロスボウ) Lv1 - Lv4
        /// <para>撃った矢がMobを貫通するようになります。</para>
        /// </summary>
        [MinecraftID("piercing")]
        Piercing,
        /// <summary>
        /// 射撃ダメージ増加 (弓) Lv1 - Lv5
        /// <para>Mobに与えるダメージ量が増加します。</para>
        /// </summary>
        [MinecraftID("power")]
        Power,
        /// <summary>
        /// 飛び道具耐性 (防具) Lv1 - Lv4
        /// <para>飛び道具 (矢など) で受けるダメージを軽減します。</para>
        /// </summary>
        [MinecraftID("projectile_protection")]
        ProjectileProtection,
        /// <summary>
        /// ダメージ軽減 (防具) Lv1 - Lv4
        /// <para>受けるダメージを軽減します。</para>
        /// </summary>
        [MinecraftID("protection")]
        Protection,
        /// <summary>
        /// パンチ (弓) Lv1 - Lv2
        /// <para>弓で殴ったMobをはじき飛ばします。</para>
        /// </summary>
        [MinecraftID("punch")]
        Punch,
        /// <summary>
        /// 高速充填 (クロスボウ) Lv1 - Lv3
        /// <para>矢の充填が早くなります。</para>
        /// </summary>
        [MinecraftID("quick_charge")]
        QuickCharge,
        /// <summary>
        /// 水中呼吸 (ヘルメット) Lv1 - Lv3
        /// <para>水中呼吸時間が早くなる。</para>
        /// </summary>
        [MinecraftID("respiration")]
        Respiration,
        /// <summary>
        /// 激流 (トライデント) Lv1 - Lv3
        /// <para>トライデントを投げた方向に高速移動します。</para>
        /// </summary>
        [MinecraftID("riptide")]
        Riptide,
        /// <summary>
        /// ダメージ増加 (剣, 斧) Lv1 - Lv5
        /// <para>Mobに与えるダメージが増加します。</para>
        /// </summary>
        [MinecraftID("sharpness")]
        Sharpness,
        /// <summary>
        /// シルクタッチ (採掘道具) Lv1
        /// <para>アイテムを破壊せずに回収できます。</para>
        /// </summary>
        [MinecraftID("silk_touch")]
        SilkTouch,
        /// <summary>
        /// アンデッド特効 (剣, 斧) Lv1 - Lv5
        /// <para>アンデッドへ与えるダメージが増加します。</para>
        /// </summary>
        [MinecraftID("smite")]
        Smite,
        /// <summary>
        /// ソウルスピード (ブーツ) Lv1 - Lv3
        /// <para>ソウルサンドの上を歩行する際の移動速度が上昇します。</para>
        /// </summary>
        [MinecraftID("soul_speed")]
        SoulSpeed,
        /// <summary>
        /// 範囲ダメージ増加 (剣) Lv1 - Lv3
        /// <para>範囲攻撃で与えるダメージが増加します。</para>
        /// </summary>
        [MinecraftID("sweeping")]
        SweepingEdge,
        /// <summary>
        /// 棘の鎧 (防具) Lv1 - Lv3
        /// <para>攻撃された相手にダメージを与えます。</para>
        /// </summary>
        [MinecraftID("thorns")]
        Thorns,
        /// <summary>
        /// 耐久力 Lv1 - Lv4
        /// <para>耐久度が増加して壊れにくくなります。</para>
        /// </summary>
        [MinecraftID("unbreaking")]
        Unbreaking,
    }
}
