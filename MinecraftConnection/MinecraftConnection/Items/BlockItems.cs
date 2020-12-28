﻿using System;

namespace MinecraftConnection.Items
{
    /// <summary>
    /// Minecraftのブロックアイテムクラスです。
    /// </summary>
    public class BlockItems : IBlockItems
    {
        //石類
        public static string Air { get; private set; } = "minecraft:air";
        public static string Stone { get; private set; } = "minecraft:stone";
        public static string Granite { get; private set; } = "minecraft:granite";
        public static string PolishedGranite { get; private set; } = "minecraft:polished_granite";
        public static string Diorite { get; private set; } = "minecraft:diorite";
        public static string PolishedDiorite { get; private set; } = "minecraft:polished_diorite";
        public static string Andesite { get; private set; } = "minecraft:andesite";
        public static string PolishedAndesite { get; private set; } = "minecraft:polished_andesite";
        public static string CobbleStone { get; private set; } = "minecraft:cobblestone";
        public static string Bedrock { get; private set; } = "minecraft:bedrock";
        public static string CobblestoneStairs { get; private set; } = "minecraft:cobblestone_stairs";

        //土類
        public static string GrassBlock { get; private set; } = "minecraft:grass_block";
        public static string Dirt { get; private set; } = "minecraft:dirt_block";
        public static string CoarseDIrt { get; private set; } = "minecraft:coarse_dirt";
        public static string Podzol { get; private set; } = "minecraft:podzol";

        //木材類
        public static string OakPlanks { get; private set; } = "minecraft:oak_planks";
        public static string SprucePlanks { get; private set; } = "minecraft:spruce_planks";
        public static string BirchPlanks { get; private set; } = "minecraft:birch_planks";
        public static string JunglePlanks { get; private set; } = "minecraft:jungle_planks";
        public static string AcaciaPlanks { get; private set; } = "minecraft:acacia_planks";
        public static string DarkOakPlanks { get; private set; } = "dark_oak_planks";

        //苗木類
        public static string OakSapling { get; private set; } = "minecraft:oak_sapling";
        public static string SpruceSapling { get; private set; } = "minecraft:spruce_sapling";
        public static string BirchSapling { get; private set; } = "minecraft:birch_sapling";
        public static string JungleSapling { get; private set; } = "minecraft:jungle_sapling";
        public static string AcaciaSapling { get; private set; } = "minecraft:acacia_sapling";
        public static string DarkOakSapling { get; private set; } = "minecraft:dark_oak_sapling";

        //流体類
        public static string Water { get; private set; } = "minecraft:water";
        public static string Lava { get; private set; } = "minecraft:lava";

        //砂類
        public static string Sand { get; private set; } = "minecraft:sand";
        public static string RedSand { get; private set; } = "minecraft:red_sand";
        public static string Gravel { get; private set; } = "minecraft:gravel";
        public static string Sandstone { get; private set; } = "minecraft:sandstone";
        public static string ChiseledSandstone { get; private set; } = "minecraft:chiseled_sandstone";
        public static string CutSandstone { get; private set; } = "minecraft:cut_sandstone";
        //public static string hoge { get; private set; } = "minecraft:";

        //鉱石類
        public static string GoldOre { get; private set; } = "minecraft:gold_ore";
        public static string IronOre { get; private set; } = "minecraft:iron_ore";
        public static string CoalOre { get; private set; } = "minecraft:coal_ore";
        public static string LapisOre { get; private set; } = "minecraft:lapis_ore";
        public static string DiamondOre { get; private set; } = "minecraft:diamond_ore";

        //原木類
        public static string OakLog { get; private set; } = "minecraft:oak_log";
        public static string SpruceLog { get; private set; } = "minecraft:spruce_log";
        public static string BirchLog { get; private set; } = "minecraft:birch_log";
        public static string JungleLog { get; private set; } = "minecraft:jungle_log";
        public static string AcaciaLog { get; private set; } = "minecraft:acacia_log";
        public static string DarkOakLog { get; private set; } = "minecraft:dark_oak_log";

        //樹皮なし原木類
        public static string StrippedOakLog { get; private set; } = "minecraft:stripped_oak_log";
        public static string StrippedSpruceLog { get; private set; } = "minecraft:stripped_spruce_log";
        public static string StrippedBirchLog { get; private set; } = "minecraft:stripped_birch_log";
        public static string StrippedJungleLog { get; private set; } = "minecraft:stripped_jungle_log"; 
        public static string StrippedAcaciaLog { get; private set; } = "minecraft:stripped_acacia_log";
        public static string StrippedDarkOakLog { get; private set; } = "minecraft:stripped_dark_oak_log";


        //樹皮なし木材類
        public static string StrippedOakWood { get; private set; } = "minecraft:stripped_oak_wood";
        public static string StrippedSpruceWood { get; private set; } = "minecraft:stripped_spruce_wood";
        public static string StrippedBirchWood { get; private set; } = "minecraft:stripped_birch_wood";
        public static string StrippedJungleWood { get; private set; } = "minecraft:stripped_jungle_wood";
        public static string StrippedAcaciaWood { get; private set; } = "minecraft:stripped_acacia_wood";
        public static string StrippedDarkOakWood { get; private set; } = "minecraft:stripped_dark_oak_wood";

        //木類
        public static string OakWood { get; private set; } = "minecraft:oak_wood";
        public static string SpruceWood { get; private set; } = "minecraft:spruce_wood";
        public static string BirchWood { get; private set; } = "minecraft:birch_wood";
        public static string JungleWood { get; private set; } = "minecraft:jungle_wood";
        public static string AcaciaWood { get; private set; } = "minecraft:acacia_wood";
        public static string DarkOakWood { get; private set; } = "minecraft:dark_oak_wood";

        //葉類
        public static string OakLeaves { get; private set; } = "minecraft:oak_leaves";
        public static string SpruceLeaves { get; private set; } = "minecraft:spruce_leaves";
        public static string BirchLeaves { get; private set; } = "minecraft:birch_leaves";
        public static string JungleLeaves { get; private set; } = "minecraft:jungle_leaves";
        public static string AcaciaLeaves { get; private set; } = "minecraft:acacia_leaves";
        public static string DarkOakLeaves { get; private set; } = "minecraft:dark_oak_leaves";

        //スポンジ類
        public static string Sponge { get; private set; } = "minecraft:sponge";
        public static string WetSponge { get; private set; } = "minecraft:wet_sponge";

        //ガラス類
        public static string Glass { get; private set; } = "minecraft:glass";

        //鉱石ブロック類
        public static string LapisBlock { get; private set; } = "minecraft:lapis_block";
        public static string IronBlock { get; private set; } = "minecraft:iron_block";
        public static string GoldBlock { get; private set; } = "minecraft:gold_block";
        public static string DiamondBlock { get; private set; } = "minecraft:diamond_block";
        //public static string hoge { get; private set; } = "minecraft:";

        //機械・回路類
        public static string Dispenser { get; private set; } = "minecraft:dispenser";
        public static string NoteBlock { get; private set; } = "minecraft:note_block";
        public static string StickyPiston { get; private set; } = "minecSraft:sticky_piston";
        public static string Piston { get; private set; } = "minecraft:piston";

        //レール・運搬類
        public static string PoweredRail { get; private set; } = "minecraft:powered_rail";
        public static string DetectorRail { get; private set; } = "minecraft:detector_rail";
        public static string Rail { get; private set; } = "minecraft:rail";


        //植物・藻類
        public static string Cobweb { get; private set; } = "minecraft:cobweb";
        public static string Grass { get; private set; } = "minecraft:grass";
        public static string Fern { get; private set; } = "minecraft:fern";
        public static string Dead_Bush { get; private set; } = "minecraft:dead_bush";
        public static string Seagrass { get; private set; } = "minecraft:seagrass";
        public static string Tall_seagrass { get; private set; } = "minecraft:tall_seagrass";
        public static string SeaPickle { get; private set; } = "minecraft:sea_pickle";

        //羊毛類
        public static string WhiteWool { get; private set; } = "minecraft:white_wool";
        public static string OrangeWool { get; private set; } = "minecraft:orange_wool";
        public static string MagentaWool { get; private set; } = "minecraft:magenta_wool";
        public static string LightBlueWool { get; private set; } = "minecraft:light_blue_wool";
        public static string YellowWool { get; private set; } = "minecraft:yellow_wool";
        public static string LimeWool { get; private set; } = "minecraft:lime_wool";
        public static string PinkWool { get; private set; } = "minecraft:pink_wool";
        public static string GrayWool { get; private set; } = "minecraft:gray_wool";
        public static string LightGrayWool { get; private set; } = "minecraft:light_gray_wool";
        public static string CyanWool { get; private set; } = "minecraft:cyan_wool";
        public static string PurpleWool { get; private set; } = "minecraft:purple_wool";
        public static string BlueWool { get; private set; } = "minecraft:blue_wool";
        public static string BrownWool { get; private set; } = "minecraft:brown_wool";
        public static string GreenWool { get; private set; } = "minecraft:green_wool";
        public static string RedWool { get; private set; } = "minecraft:red_wool";
        public static string BlackWool { get; private set; } = "minecraft:black_wool";

        //花類
        public static string Dandelion { get; private set; } = "minecraft:dandelion";
        public static string Poppy { get; private set; } = "minecraft:poppy";
        public static string BlueOrchid { get; private set; } = "minecraft:blue_orchid";
        public static string Allium { get; private set; } = "minecraft:allium";
        public static string Azure_bluet { get; private set; } = "minecraft:azure_bluet";
        public static string RedTulip { get; private set; } = "minecraft:red_tulip";
        public static string OrangeTulip { get; private set; } = "minecraft:orange_tulip";
        public static string WhiteTulip { get; private set; } = "minecraft:white_tulip";
        public static string PinkTulip { get; private set; } = "minecraft:pink_tulip";
        public static string OxeyeDaisy { get; private set; } = "minecraft:oxeye_daisy";
        public static string Cornflower { get; private set; } = "minecraft:cornflower";
        public static string LilyOfTheValley { get; private set; } = "minecraft:lily_of_the_valley";
        public static string WitherRose { get; private set; } = "minecraft:wither_rose";

        //キノコ類
        public static string BrownMushroom { get; private set; } = "minecraft:brown_mushroom";
        public static string RedMushroom { get; private set; } = "minecraft:red_mushroom";

        //ハーフブロック類
        public static string OakSlab { get; private set; } = "minecraft:oak_slab";
        public static string SpruceSlab { get; private set; } = "minecraft:spruce_slab";
        public static string BirchSlab { get; private set; } = "minecraft:birch_slab";
        public static string JungleSlab { get; private set; } = "minecraft:jungle_slab";
        public static string AcaciaSlab { get; private set; } = "minecraft:acacia_slab";
        public static string DarOakSlab { get; private set; } = "minecraft:dark_oak_slab";
        public static string StoneSlab { get; private set; } = "minecraft:stone_slab";
        public static string SmoothStoneSlab { get; private set; } = "minecraft:smooth_stone_slab";
        public static string SandStoneSlab { get; private set; } = "minecraft:sandstone_slab";
        public static string PetrifiedOakSlab { get; private set; } = "minecraft:petrified_oak_slab";
        public static string CobbleStoneSlab { get; private set; } = "minecraft:cobblestone_slab";
        public static string BrickSlab { get; private set; } = "minecraft:brick_slab";
        public static string StoneBrickSlab { get; private set; } = "minecraft:stone_brick_slab";
        public static string NetherBrickSlab { get; private set; } = "minecraft:nether_brick_slab";
        public static string RedSandstoneSlab { get; private set; } = "minecraft:red_sandstone_slab";
        public static string PurpurSlab { get; private set; } = "minecraft:purpur_slab";
        public static string PrismarineSlab { get; private set; } = "minecraft:prismarine_slab";
        public static string PrismarineBrickSlab { get; private set; } = "minecraft:prismarine_brick_slab";
        public static string DarkPrismarineSlab { get; private set; } = "minecraft:dark_prismarine_slab";

        //滑らかなブロック類
        public static string SmoothQuartz { get; private set; } = "minecraft:smooth_quartz";
        public static string SmoothRedSandstone { get; private set; } = "minecraft:smooth_red_sandstone";
        public static string SmoothSandstone { get; private set; } = "minecraft:smooth_sandstone";
        public static string SmoothStone { get; private set; } = "minecraft:smooth_stone";
        public static string QuartzSlab { get; private set; } = "minecraft:quartz_slab";

        //未分類
        public static string Bricks { get; private set; } = "minecraft:bricks";
        public static string TNT { get; private set; } = "minecraft:tnt";
        public static string Bookshelf { get; private set; } = "minecraft:bookshelf";
        public static string MossyCobblestone { get; private set; } = "minecraft:mossy_cobblestone";
        public static string Obsidian { get; private set; } = "minecraft:obsidian";
        public static string Chest { get; private set; } = "minecraft:chest";
        public static string Torch { get; private set; } = "minecraft:torch";
        public static string CraftingTable { get; private set; } = "minecraft:crafting_table";
        public static string Farmland { get; private set; } = "minecraft:farmland";
        public static string Furnace { get; private set; } = "minecraft:furnace";
        public static string Ladder { get; private set; } = "minecraft:ladder";

        //ジエンド素材類
        public static string EndRod { get; private set; } = "minecraft:end_rod";
        public static string ChorusPlant { get; private set; } = "minecraft:chorus_plant";
        public static string ChorusFlower { get; private set; } = "minecraft:chorus_flower";
        public static string PurpurBlock { get; private set; } = "minecraft:purpur_block";
        public static string PurpurPillar { get; private set; } = "minecraft:purpur_pillar";
        public static string PurpurStairs { get; private set; } = "minecraft:purpur_stairs";

        //木の階段類
        public static string OakStairs { get; private set; } = "minecraft:oak_stairs";
        public static string SpruceStairs { get; private set; } = "minecraft:spruce_stairs";
        public static string BirchStairs { get; private set; } = "minecraft:birch_stairs";
        public static string JungleStairs { get; private set; } = "minecraft:jungle_stairs";
        public static string AcaciaStairs { get; private set; } = "minecraft:acacia_stairs";
        public static string DarkOakStairs { get; private set; } = "minecraft:dark_oak_stairs";


    }
}