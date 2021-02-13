using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Items
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
        AquaAffinity,
        /// <summary>
        /// 虫特効 (剣, 斧) Lv1 - Lv5
        /// <para>虫へのダメージが増加します。</para>
        /// </summary>
        BaneOfArthropods,
        /// <summary>
        /// 爆発耐性 (防具) Lv1 - Lv4
        /// <para>爆発のダメージを軽減します。</para>
        /// </summary>
        BlastProtection,
        /// <summary>
        /// 召雷 (トライデント) Lv1
        /// <para>雷を落とせるようになります。</para>
        /// </summary>
        Channeling,
        /// <summary>
        /// 束縛の呪い (防具) Lv1
        /// <para>1度装備すると外せなくなります。</para>
        /// </summary>
        CurseOfBinding,
        /// <summary>
        /// 消滅の呪い Lv1
        /// <para>死ぬとアイテムが消滅します。</para>
        /// </summary>
        CurseOfVanishing,
        /// <summary>
        /// 水中歩行 (ブーツ) Lv1 - Lv3
        /// <para>水中での移動速度が上昇します。</para>
        /// </summary>
        DepthStrider,
        /// <summary>
        /// 効率強化 (採掘ツール) Lv1 - Lv5
        /// <para>採掘速度が上昇します。</para>
        /// </summary>
        Efficiency,
        /// <summary>
        /// 落下耐性 (ブーツ) Lv1 - Lv4
        /// <para>落下した際のダメージを軽減します。</para>
        /// </summary>
        FeatherFalling,
        /// <summary>
        /// 火属性 (剣) Lv1 - Lv2
        /// <para>斬った相手に火をつけます。</para>
        /// </summary>
        FireAspect,
        /// <summary>
        /// 火炎耐性 (防具) Lv1 - Lv4
        /// <para>火のダメージを軽減します。</para>
        /// </summary>
        FireProtection,
        /// <summary>
        /// フレイム (弓) Lv1
        /// <para>撃った矢に火がつきます。</para>
        /// </summary>
        Flame,
        /// <summary>
        /// 幸運 (採掘ツール) Lv1 - Lv3
        /// <para>採掘したときのアイテムドロップ量が増えやすくなります。</para>
        /// </summary>
        Fortune,
        /// <summary>
        /// 氷渡り (ブーツ) Lv1 - Lv2
        /// <para>水上を歩行すると氷に変化します。</para>
        /// </summary>
        FrostWalker,
        /// <summary>
        /// 水性特効 (トライデント) Lv1 - Lv5
        /// <para>水生生物へのダメージを増加します。(ドラウンドは含まない)</para>
        /// </summary>
        Impaling,
        /// <summary>
        /// 無限 (弓) Lv1
        /// <para>矢を消費せずに撃つことができるようになります。</para>
        /// </summary>
        Infinity,
        /// <summary>
        /// ノックバック (剣) Lv1 - Lv2
        /// <para>攻撃した際に相手をはじき飛ばします。</para>
        /// </summary>
        Knockback,
        /// <summary>
        /// ドロップ増加 (剣) Lv1 - Lv3
        /// <para>Mobを倒したときのアイテムドロップ量が増えやすくなります。</para>
        /// </summary>
        Looting,
        /// <summary>
        /// 忠誠 (トライデント) Lv1 - Lv3
        /// <para>投げたトライデントが自動で戻って来やすくなります。</para>
        /// </summary>
        Loyality,
        /// <summary>
        /// 宝釣り (釣り竿) Lv1 - Lv3
        /// <para>宝を釣り上げる確率が増加します。</para>
        /// </summary>
        LuckOfTheSea,
        /// <summary>
        /// 入れ食い (釣り竿) Lv1 - Lv3
        /// <para>魚が食いつくまでの時間が短縮されます。</para>
        /// </summary>
        Lure,
        /// <summary>
        /// 修繕 Lv1
        /// <para>経験値を取得すると耐久度が回復します。</para>
        /// </summary>
        Mending,
        /// <summary>
        /// 拡散 (クロスボウ) Lv1
        /// <para>矢を1本消費して扇状に3本撃てるようになります。</para>
        /// </summary>
        Multishot,
        /// <summary>
        /// 貫通 (クロスボウ) Lv1 - Lv4
        /// <para>撃った矢がMobを貫通するようになります。</para>
        /// </summary>
        Piercing,
        /// <summary>
        /// 射撃ダメージ増加 (弓) Lv1 - Lv5
        /// <para>Mobに与えるダメージ量が増加します。</para>
        /// </summary>
        Power,
        /// <summary>
        /// 飛び道具耐性 (防具) Lv1 - Lv4
        /// <para>飛び道具 (矢など) で受けるダメージを軽減します。</para>
        /// </summary>
        ProjectileProtection,
        /// <summary>
        /// ダメージ軽減 (防具) Lv1 - Lv4
        /// <para>受けるダメージを軽減します。</para>
        /// </summary>
        Protection,
        /// <summary>
        /// パンチ (弓) Lv1 - Lv2
        /// <para>弓で殴ったMobをはじき飛ばします。</para>
        /// </summary>
        Punch,
        /// <summary>
        /// 高速充填 (クロスボウ) Lv1 - Lv3
        /// <para>矢の充填が早くなります。</para>
        /// </summary>
        QuickCharge,
        /// <summary>
        /// 水中呼吸 (ヘルメット) Lv1 - Lv3
        /// <para>水中呼吸時間が早くなる。</para>
        /// </summary>
        Respiration,
        /// <summary>
        /// 激流 (トライデント) Lv1 - Lv3
        /// <para>トライデントを投げた方向に高速移動します。</para>
        /// </summary>
        Riptide,
        /// <summary>
        /// ダメージ増加 (剣, 斧) Lv1 - Lv5
        /// <para>Mobに与えるダメージが増加します。</para>
        /// </summary>
        Sharpness,
        /// <summary>
        /// シルクタッチ (採掘道具) Lv1
        /// <para>アイテムを破壊せずに回収できます。</para>
        /// </summary>
        SilkTouch,
        /// <summary>
        /// アンデッド特効 (剣, 斧) Lv1 - Lv5
        /// <para>アンデッドへ与えるダメージが増加します。</para>
        /// </summary>
        Smite,
        /// <summary>
        /// ソウルスピード (ブーツ) Lv1 - Lv3
        /// <para>ソウルサンドの上を歩行する際の移動速度が上昇します。</para>
        /// </summary>
        SoulSpeed,
        /// <summary>
        /// 範囲ダメージ増加 (剣) Lv1 - Lv3
        /// <para>範囲攻撃で与えるダメージが増加します。</para>
        /// </summary>
        SweepingEdge,
        /// <summary>
        /// 棘の鎧 (防具) Lv1 - Lv3
        /// <para>攻撃された相手にダメージを与えます。</para>
        /// </summary>
        Thorns,
        /// <summary>
        /// 耐久力 Lv1 - Lv4
        /// <para>耐久度が増加して壊れにくくなります。</para>
        /// </summary>
        Unbreaking,
    }
}
