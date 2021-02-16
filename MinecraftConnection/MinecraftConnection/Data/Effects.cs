namespace MinecraftConnection.Data
{
    /// <summary>
    /// ステータスの状態
    /// </summary>
    public enum Effects
    {
        /// <summary>
        /// 衝撃吸収
        /// <para>ダメージを吸収します。</para>
        /// </summary>
        [MinecraftID("absorption")]
        Absorption,
        /// <summary>
        /// 不幸
        /// <para>ドロップするアイテム量が低下します。</para>
        /// </summary>
        [MinecraftID("unluck")]
        BadLuck,
        /// <summary>
        /// 不吉な予感
        /// <para>村に入ると襲撃イベントが発生します。</para>
        /// </summary>
        [MinecraftID("bad_omen")]
        BadOmen,
        /// <summary>
        /// 盲目
        /// <para>視界が暗くなり、ダッシュやクリティカルヒットができなくなります。</para>
        /// </summary>
        [MinecraftID("blindness")]
        Blindness,
        /// <summary>
        /// コンジットパワー
        /// <para>水中での暗視効果および採掘速度上昇の付与に加えて溺れなくなります。</para>
        /// </summary>
        [MinecraftID("conduit_power")]
        ConduitPower,
        /// <summary>
        /// イルカの好意
        /// <para>泳ぐ速度が上昇します。</para>
        /// </summary>
        [MinecraftID("dolphins_grace")]
        DolphinsGrace,
        /// <summary>
        /// 火炎耐性
        /// <para>火に対する耐性を得ます。</para>
        /// </summary>
        [MinecraftID("fire_resistance")]
        FireResistance,
        /// <summary>
        /// 発光
        /// <para>エンティティ (Mob) の淵が光ってブロック越しに見えるようになります。</para>
        /// </summary>
        [MinecraftID("glowing")]
        Glowing,
        /// <summary>
        /// 採掘速度上昇
        /// <para>採掘速度と攻撃速度が上昇します。</para>
        /// </summary>
        [MinecraftID("haste")]
        Haste,
        /// <summary>
        /// 体力増強
        /// <para>体力の最大値が増加します。</para>
        /// </summary>
        [MinecraftID("health_boost")]
        HealthBoost,
        /// <summary>
        /// 村の英雄
        /// <para>村人との交易で値引きが発生します。</para>
        /// </summary>
        [MinecraftID("hero_of_the_village")]
        HeroOfTheVillage,
        /// <summary>
        /// 空腹
        /// <para>満腹度の消耗が激しくなります。</para>
        /// </summary>
        [MinecraftID("hunger")]
        Hunger,
        /// <summary>
        /// 即時ダメージ
        /// <para>Mob にダメージを与えますが、アンデッド系には回復します。</para>
        /// </summary>
        [MinecraftID("instant_damage")]
        InstantDamage,
        /// <summary>
        /// 即時回復
        /// <para>Mob の体力は回復しますが、アンデッド系にはダメージを与えます。</para>
        /// </summary>
        [MinecraftID("instant_health")]
        InstantHealth,
        /// <summary>
        /// 透明化
        /// <para>視界が暗くなり, ダッシュやクリティカルヒットができなくなります。</para>
        /// </summary>
        [MinecraftID("invisibility")]
        Invisibility,
        /// <summary>
        /// 跳躍力上昇
        /// <para>ジャンプ力が増加し、落下ダメージが減少します。</para>
        /// </summary>
        [MinecraftID("jump_boost")]
        JumpBoost,
        /// <summary>
        /// 浮遊
        /// <para>Mob が浮かび上がります。</para>
        /// </summary>
        [MinecraftID("levitation")]
        Levitation,
        /// <summary>
        /// 幸運
        /// <para>ドロップするアイテム量が増加します。</para>
        /// </summary>
        [MinecraftID("luck")]
        Luck,
        /// <summary>
        /// 採掘速度低下
        /// <para>採掘速度と攻撃速度が低下します。</para>
        /// </summary>
        [MinecraftID("mining_fatigue")]
        MiningFatigue,
        /// <summary>
        /// 吐き気
        /// <para>視界が歪みます。</para>
        /// </summary>
        [MinecraftID("nausea")]
        Nausea,
        /// <summary>
        /// 暗視
        /// <para>暗い場所が明るく見やすくなります。</para>
        /// </summary>
        [MinecraftID("night_vision")]
        NightVision,
        /// <summary>
        /// 毒
        /// <para>体力が1になるまで時間経過とともにダメージを受けます。</para>
        /// </summary>
        [MinecraftID("poison")]
        Poison,
        /// <summary>
        /// 再生能力
        /// <para>時間とともに体力が回復します。</para>
        /// </summary>
        [MinecraftID("regeneration")]
        Regeneration,
        /// <summary>
        /// 耐性
        /// <para>受けるダメージが減少します。</para>
        /// </summary>
        [MinecraftID("resistance")]
        Resistance,
        /// <summary>
        /// 満腹度回復
        /// <para>時間と共に満腹度が回復します。</para>
        /// </summary>
        [MinecraftID("saturation")]
        Saturation,
        /// <summary>
        /// 落下速度低下
        /// <para>落下速度を低下させて落下時のダメージを防ぎます。</para>
        /// </summary>
        [MinecraftID("slow_falling")]
        SlowFalling,
        /// <summary>
        /// 移動速度低下
        /// <para>移動速度が低下します。</para>
        /// </summary>
        [MinecraftID("slowness")]
        Slowness,
        /// <summary>
        /// 移動速度上昇
        /// <para>移動速度が上昇します。</para>
        /// </summary>
        [MinecraftID("speed")]
        Speed,
        /// <summary>
        /// 攻撃力上昇
        /// <para>与えるダメージが増加します。</para>
        /// </summary>
        [MinecraftID("strength")]
        Strength,
        /// <summary>
        /// 水中呼吸
        /// <para>空気ゲージの消耗がなくなり、溺れなくなります。</para>
        /// </summary>
        [MinecraftID("water_breathing")]
        WaterBreathing,
        /// <summary>
        /// 弱体化
        /// <para>与えるダメージが低下します。</para>
        /// </summary>
        [MinecraftID("weakness")]
        Weakness,
        /// <summary>
        /// 衰弱
        /// <para>体力ゲージが黒くなり、時間と共にダメージを受けて死に至ります。</para>
        /// </summary>
        [MinecraftID("wither")]
        Wither,
        /// <summary>
        /// タートルマスター (ポーション)
        /// <para>耐性は付きますが、移動速度が低下します。</para>
        /// </summary>
        [MinecraftID("turtle_master")]
        TurtleMaster,
        /// <summary>
        /// 即時ダメージ (ポーション)
        /// <para>Mob にダメージを与えますが、アンデッド系には回復します。</para>
        /// </summary>
        [MinecraftID("healing")]
        Healing,
        /// <summary>
        /// 即時回復 (ポーション)
        /// <para>Mob の体力は回復しますが、アンデッド系にはダメージを与えます。</para>
        /// </summary>
        [MinecraftID("harming")]
        Harming,
    }
}
