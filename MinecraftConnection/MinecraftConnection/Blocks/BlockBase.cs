using System;
using System.Collections.Generic;
using System.Text;
using MinecraftConnection.Data;
namespace MinecraftConnection.Blocks
{
    /// <summary>
    /// ブロックの状態に関するクラスです。
    /// </summary>
    public class BlockBase
    {
        /// <summary>
        /// 雪が積もっているかどうか
        /// </summary>
        public bool Snowy { get; set; }
        /// <summary>
        /// 苗木が成長するかどうか
        /// </summary>
        public bool SaplingStage { get; set; }
        /// <summary>
        /// 流体の液量
        /// </summary>
        public int LiquidLevel { get; set; }
        /// <summary>
        /// ブロックの向き
        /// </summary>
        public Axis Axis { get; set; }
        /// <summary>
        /// 原木からの葉の位置
        /// </summary>
        public int LeafDistance { get; set; }
        /// <summary>
        /// 葉が消滅するかどうか
        /// </summary>
        public bool LeafPersistent { get; set; }
        /// <summary>
        /// 各方位とのブロックのつながり
        /// </summary>
        public List<Direction> BlocksConnect { get; set; }
        /// <summary>
        /// 水没しているかどうか
        /// </summary>
        public bool WaterLogged { get; set; }
        /// <summary>
        /// ハーフブロックの種類
        /// </summary>
        public HarfBlockType Type { get; set; }
        /// <summary>
        /// 階段の向き
        /// </summary>
        public Direction Facing { get; set; }
        /// <summary>
        /// 階段の上下の向き
        /// </summary>
        public StairsHarf StairsHarf { get; set; }
        /// <summary>
        /// 階段の形状
        /// </summary>
        public StairsShape StairsShape { get; set; }
        /// <summary>
        /// TNT の破壊時に爆発するかどうか
        /// </summary>
        public bool Unstable { get; set; }
        /// <summary>
        /// 炎の経過時間
        /// </summary>
        public int FireAge { get; set; }
        /// <summary>
        /// 上のブロックの底面に火が描画されるかどうか
        /// </summary>
        public bool FireUp { get; set; }
        /// <summary>
        /// 隣接ブロックの表面に火が描画されるかどうか
        /// </summary>
        public List<Direction> FireDirection { get; set; }

    }

    /// <summary>
    /// Minecraft 内での方向
    /// </summary>
    public enum Axis
    {
        /// <summary>
        /// 東西方向
        /// </summary>
        X,
        /// <summary>
        /// 上下方向
        /// </summary>
        Y,
        /// <summary>
        /// 南北方向
        /// </summary>
        Z
    }
    /// <summary>
    /// ハーフブロックの種類
    /// </summary>
    public enum HarfBlockType
    {
        /// <summary>
        /// 上付き
        /// </summary>
        [MinecraftID("top")]
        Top,
        /// <summary>
        /// 下付き
        /// </summary>
        [MinecraftID("bottom")]
        Bottom,
        /// <summary>
        /// 二段重ね
        /// </summary>
        [MinecraftID("double")]
        Double
    }
    /// <summary>
    /// 方向
    /// </summary>
    public enum Direction
    {
        [MinecraftID("north")]
        North,
        [MinecraftID("south")]
        South,
        [MinecraftID("east")]
        East,
        [MinecraftID("west")]
        West
    }
    /// <summary>
    /// 階段の上下の向き
    /// </summary>
    public enum StairsHarf
    {
        [MinecraftID("top")]
        Top,
        [MinecraftID("bottom")]
        Bottom
    }
    /// <summary>
    /// 階段の形状
    /// </summary>
    public enum StairsShape
    {
        [MinecraftID("straight")]
        Straight,
        [MinecraftID("inner_left")]
        InnerLeft,
        [MinecraftID("inner_right")]
        InnerRight,
        [MinecraftID("outer_left")]
        OuterLeft,
        [MinecraftID("outer_right")]
        OuterRight
    }
    
}
