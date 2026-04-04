namespace AAEmu.Game.Models.Game.Skills.Static;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1069 // Enums should not be duplicated

/// <summary>
/// Extracted enum of skill results, might not be correct
/// </summary>
public enum SkillResult : byte
{
    Success = 0x0,
    Failure = 0x1,
    SourceDied = 0x2,
    SourceAlive = 0x3,
    TargetDied = 0x4,
    TargetDestroyed = 0x5,
    TargetAlive = 0x6,
    OnCasting = 0x7,
    CooldownTime = 0x8,
    NoTarget = 0x9,
    LackHealth = 0xA,
    LackMana = 0xB,
    Obstacle = 0xC,
    OutofHeight = 0xD,
    TooCloseRange = 0xE,
    TooFarRange = 0xF,
    OutofAngle = 0x10,
    CannotCastInCombat = 0x11,
    CannotCastWhileMoving = 0x12,
    CannotCastInStun = 0x13,
    CannotCastWhileWalking = 0x14,
    CannotCastInSwimming = 0x15,
    BlankMinded = 0x16,
    Silence = 0x17,
    Crippled = 0x18,
    CannotCastInChanneling = 0x19,
    CannotCastInPrison = 0x1A,
    NeedStealth = 0x1B,
    NeedNocombatTarget = 0x1C,
    TargetImmune = 0x1D,
    InvalidSkill = 0x1E,
    InactiveAbility = 0x1F,
    NotEnoughAbilityLevel = 0x20,
    InvalidSource = 0x21,
    InvalidTarget = 0x22,
    InvalidLocation = 0x23,
    NeedReagent = 0x24,
    ItemLocked = 0x25,
    NeedMoney = 0x26,
    NeedLaborPower = 0x27,
    SourceIsHanging = 0x28,
    SourceIsRiding = 0x29,
    HigherBuff = 0x2A,
    NotPvpArea = 0x2B,
    NotNow = 0x2C,
    NoPerm = 0x2D,
    BagFull = 0x2E,
    ProtectedFaction = 0x2F,
    ProtectedLevel = 0x30,
    UnitReqsOrFail = 0x31,
    SkillReqFail = 0x32,
    BackpackOccupied = 0x33,
    ObstacleForSpawnDoodad = 0x34,
    CannotSpawnDoodadInHouse = 0x35,
    CannotUseForSelf = 0x36,
    NotPreoccupied = 0x37,
    NotMyNpc = 0x38,
    NotCheckedSecondPass = 0x39,
    ZoneBanned = 0x3A,
    InvalidGradeEnchantSupportItem = 0x3B,
    CheckCharacterPStatMin = 0x3C,
    CheckCharacterPStatMax = 0x3D,
    ItemSecured = 0x3E,
    InvalidAccountAttribute = 0x3F,
    FestivalZone = 0x40,
    AlreadyOtherPlayerBound = 0x41,
    MateDead = 0x42,
    CannotUnsummonUnderStunSleepRoot = 0x43,
    LackHighAbilityResource = 0x44,
    LackSourceItemSet = 0x45,
    LackActability = 0x46,
    UrkStart = 0x46, // Start offset for UnitReqsKindType
    UrkLevel = 0x47,
    UrkAbility = 0x48,
    UrkRace = 0x49,
    UrkGender = 0x4A,
    UrkEquipSlot = 0x4B,
    UrkEquipItem = 0x4C,
    UrkOwnItem = 0x4D,
    UrkTrainedSkill = 0x4E,
    UrkCombat = 0x4F,
    UrkStealth = 0x50,
    UrkHealth = 0x51,
    UrkBuff = 0x52,
    UrkTargetBuff = 0x53,
    UrkTargetCombat = 0x54,
    UrkCanLearnCraft = 0x55,
    UrkDoodadRange = 0x56,
    UrkEquipShield = 0x57,
    UrkNobuff = 0x58,
    UrkTargetBuffTag = 0x59,
    UrkCorpseRange = 0x5A,
    UrkEquipWeaponType = 0x5B,
    UrkTargetHealthLessThan = 0x5C,
    UrkTargetNpc = 0x5D,
    UrkTargetDoodad = 0x5E,
    UrkEquipRanged = 0x5F,
    UrkNoBuffTag = 0x60,
    UrkCompleteQuestContext = 0x61,
    UrkProgressQuestContext = 0x62,
    UrkReadyQuestContext = 0x63,
    UrkTargetNpcGroup = 0x64,
    UrkAreaSphere = 0x65,
    UrkExceptCompleteQuestContext = 0x66,
    UrkPrecompleteQuestContext = 0x67,
    UrkTargetOwnerType = 0x68,
    UrkNotUnderWater = 0x69,
    UrkFactionMatch = 0x6A,
    UrkTod = 0x6B,
    UrkMotherFaction = 0x6C,
    UrkActabilityPoint = 0x6D,
    UrkCrimePoint = 0x6E,
    UrkHonorPoint = 0x6F,
    UrkLivingPoint = 0x70,
    UrkCrimeRecord = 0x71,
    UrkJuryPoint = 0x72,
    UrkSourceOwnerType = 0x73,
    UrkAppellation = 0x74,
    UrkInZone = 0x75,
    UrkOutZone = 0x76,
    UrkDominionOwner = 0x77,
    UrkVerdictOnly = 0x78,
    UrkFactionMatchOnly = 0x79,
    UrkMotherFactionOnly = 0x7A,
    UrkNationOwner = 0x7B,
    UrkFactionMatchOnlyNot = 0x7C,
    UrkMotherFactionOnlyNot = 0x7D,
    UrkNationMember = 0x7E,
    UrkNationMemberNot = 0x7F,
    UrkNationOwnerAtPos = 0x80,
    UrkDominionOwnerAtPos = 0x81,
    UrkHousing = 0x82,
    UrkHealthMargin = 0x83,
    UrkManaMargin = 0x84,
    UrkLaborPowerMargin = 0x85,
    UrkNotOnMovingPhysicalVehicle = 0x86,
    UrkMaxLevel = 0x87,
    UrkExpeditionOwner = 0x88,
    UrkExpeditionMember = 0x89,
    UrkExceptProgressQuestContext = 0x8A,
    UrkExceptReadyQuestContext = 0x8B,
    UrkOwnItemNot = 0x8C,
    UrkLessActabilityPoint = 0x8D,
    UrkOwnQuestItemGroup = 0x8E,
}

// ReSharper disable InconsistentNaming
/// <summary>
/// Internally used enum for generating SkillResults, do not pass directly to the client
/// </summary>
public enum SkillResultKeys
{
    // NOTE: do not edit the formatting or case of these enums
    ok,
    skill_failure,
    skill_source_died,
    skill_source_alive,
    skill_target_died,
    skill_target_destroyed,
    skill_target_alive,
    skill_on_casting,
    skill_cooldown_time,
    skill_no_target,
    skill_lack_health,
    skill_lack_mana,
    skill_obstacle,
    skill_outof_height,
    skill_too_close_range,
    skill_too_far_range,
    skill_outof_angle,
    skill_cannot_cast_in_combat,
    skill_cannot_cast_while_moving,
    skill_cannot_cast_in_stun,
    skill_cannot_cast_while_walking,
    skill_cannot_cast_in_swimming,
    skill_blank_minded,
    skill_silence,
    skill_crippled,
    skill_cannot_cast_in_channeling,
    skill_cannot_cast_in_prison,
    skill_need_stealth,
    skill_need_nocombat_target,
    skill_target_immune,
    skill_invalid_skill,
    skill_inactive_ability,
    skill_not_enough_ability_level,
    skill_invalid_source,
    skill_invalid_target,
    skill_invalid_location,
    skill_need_reagent,
    skill_item_locked,
    skill_need_money,
    skill_need_labor_power,
    skill_source_is_hanging,
    skill_source_is_riding,
    skill_higher_buff,
    skill_not_pvp_area,
    skill_not_now,
    skill_no_perm,
    skill_bag_full,
    skill_protected_faction,
    skill_protected_level,
    skill_unit_reqs_or_fail,
    backpack_occupied,
    skill_obstacle_for_spawn_doodad,
    skill_cannot_spawn_doodad_in_house,
    skill_cannot_use_for_self,
    skill_not_preoccupied,
    skill_not_my_npc,
    skill_not_checked_second_pass,
    // SKILL_CANNOT_USE_HERE,
    skill_invalid_grade_enchant_support_item,
    skill_check_character_p_stat_min,
    skill_check_character_p_stat_max,
    skill_invalid_account_attribute,
    skill_urk_level,
    skill_urk_ability,
    skill_urk_race,
    skill_urk_gender,
    skill_urk_equip_slot,
    skill_urk_equip_item,
    skill_urk_own_item,
    skill_urk_trained_skill,
    skill_urk_combat,
    skill_urk_stealth,
    skill_urk_health,
    skill_urk_buff,
    skill_urk_target_buff,
    skill_urk_target_combat,
    skill_urk_can_learn_craft,
    skill_urk_doodad_range,
    skill_urk_equip_shield,
    skill_urk_nobuff,
    skill_urk_target_buff_tag,
    skill_urk_corpse_range,
    skill_urk_equip_weapon_type,
    skill_urk_target_health_less_than,
    skill_urk_target_npc,
    skill_urk_target_doodad,
    skill_urk_equip_ranged,
    skill_urk_no_buff_tag,
    skill_urk_complete_quest_context,
    skill_urk_progress_quest_context,
    skill_urk_ready_quest_context,
    skill_urk_target_npc_group,
    skill_urk_area_sphere,
    skill_urk_precomplete_quest_context,
    skill_urk_target_owner_type,
    skill_urk_not_under_water,
    skill_urk_faction_match,
    skill_urk_tod,
    skill_urk_mother_faction,
    skill_urk_actability_point,
    skill_urk_honor_point,
    skill_urk_living_point,
    skill_urk_in_zone,
    skill_urk_out_zone,
    skill_urk_dominion_owner,
    skill_urk_verdict_only,
    skill_urk_faction_match_only,
    skill_urk_mother_faction_only,
    skill_urk_faction_match_only_not,
    skill_urk_mother_faction_only_not,
    skill_urk_nation_member,
    skill_urk_nation_member_not,
    skill_urk_housing,
    skill_urk_mana_margin,
    skill_urk_labor_power_margin,
    skill_urk_unknown,
    skill_urk_max_level,
}
// ReSharper restore InconsistentNaming

/// <summary>
/// Helper class to generate skill result error messages
/// </summary>
public static class SkillResultHelper
{

    public static SkillResult SkillResultErrorKeyToId(SkillResultKeys key)
    {
        // if (ClientVersion == r208022)
        return SkillResultErrorKeyToIdFor_r208022(key.ToString());
    }

    /// <summary>
    /// Lookup the SkillResult for Version 1.2 r208022
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private static SkillResult SkillResultErrorKeyToIdFor_r208022(string key)
    {
        switch (key)
        {
            case "": return SkillResult.Success;
            case "skill_success": return SkillResult.Success;
            case "skill_failure": return (SkillResult)1; // 无法使用此技能。
            case "skill_source_died": return (SkillResult)2; // 死亡状态下无法使用。
            case "skill_source_alive": return (SkillResult)3; // 只能在死亡状态下使用。
            case "skill_target_died": return (SkillResult)4; // 无法对死亡目标使用。
            case "skill_target_destroyed": return (SkillResult)5; // 目标已被摧毁。
            case "skill_target_alive": return (SkillResult)6; // 无法对存活目标使用。
            case "skill_on_casting": return (SkillResult)7; // 已经在执行动作。
            case "skill_cooldown_time": return (SkillResult)8; // 当前无法使用。
            case "skill_no_target": return (SkillResult)9; // 请选择一个目标。
            case "skill_lack_health": return (SkillResult)10; // 生命值不足以使用此技能。
            case "skill_lack_mana": return (SkillResult)11; // 魔法值不足以使用此技能。
            case "skill_obstacle": return (SkillResult)12; // 没有视线。
            case "skill_outof_height": return (SkillResult)13; // 目标在不同的高度。
            case "skill_too_close_range": return (SkillResult)14; // 目标太近。
            case "skill_too_far_range": return (SkillResult)15; // 目标太远。
            case "skill_outof_angle": return (SkillResult)16; // 目标方向无效。
            case "skill_cannot_cast_in_combat": return (SkillResult)17; // 战斗中无法使用。
            case "skill_cannot_cast_while_moving": return (SkillResult)18; // 移动中无法使用。
            case "skill_cannot_cast_in_stun": return (SkillResult)19; // 眩晕状态下无法使用。
            case "skill_cannot_cast_while_walking": return (SkillResult)20; // 行走时无法使用。
            case "skill_cannot_cast_in_swimming": return (SkillResult)21; // 游泳时无法使用。
            case "skill_blank_minded": return (SkillResult)22; // 无法在 ($1) 未知状态下使用。
            case "skill_silence": return (SkillResult)23; // 沉默状态下无法使用魔法技能。
            case "skill_crippled": return (SkillResult)24; // 束缚状态下无法使用物理技能。
            case "skill_cannot_cast_in_channeling": return (SkillResult)25; // 忙碌时无法使用。
            case "skill_cannot_cast_in_prison": return (SkillResult)26; // 监禁期间请远离麻烦。
            case "skill_need_stealth": return (SkillResult)27; // 只能在隐身状态下使用。
            case "skill_need_nocombat_target": return (SkillResult)28; // 目标正在战斗。
            case "skill_target_immune": return (SkillResult)29; // 目标免疫。
            case "skill_invalid_skill": return (SkillResult)30; // 无法使用此技能。
            case "skill_inactive_ability": return (SkillResult)31; // 无法使用此能力。
            case "skill_not_enough_ability_level": return (SkillResult)32; // 技能等级不足。
            case "skill_invalid_source": return (SkillResult)33; // 无法在此状态下使用。
            case "skill_invalid_target": return (SkillResult)34; // 目标无效。
            case "skill_invalid_location": return (SkillResult)35; // 无法在这里使用。
            case "skill_need_reagent": return (SkillResult)36; // 物品不足 ($1) 未知。
            case "skill_item_locked": return (SkillResult)37; // 无法使用此物品。
            case "skill_need_money": return (SkillResult)38; // 金币不足。
            case "skill_need_labor_power": return (SkillResult)39; // 劳动力不足。
            case "skill_source_is_hanging": return (SkillResult)40; // 空中状态下无法使用。
            case "skill_source_is_riding": return (SkillResult)41; // 骑行状态下无法使用。
            case "skill_higher_buff": return (SkillResult)42; // 已有更强的效果激活时无法使用。
            case "skill_not_pvp_area": return (SkillResult)43; // 避难所区域不允许 PvP。
            case "skill_not_now": return (SkillResult)44; // 当前无法使用。
            case "skill_no_perm": return (SkillResult)45; // 你没有权限。
            case "skill_bag_full": return (SkillResult)46; // 背包已满。
            case "skill_protected_faction": return (SkillResult)47; // 无法在此区域对 ($1) 未知阵营发起突袭。
            case "skill_protected_level": return (SkillResult)48; // 保护区域内无法与 10 级及以下角色战斗。
            case "skill_unit_reqs_or_fail": return (SkillResult)49; // 不符合要求。
            // case "": return (SkillResult)50; // 未知
            case "backpack_occupied": return (SkillResult)51; // 已经携带着背包。
            case "skill_obstacle_for_spawn_doodad": return (SkillResult)52; // 被障碍物阻挡。
            case "skill_cannot_spawn_doodad_in_house": return (SkillResult)53; // 无法在这里放置。
            case "skill_cannot_use_for_self": return (SkillResult)54; // 无法对自己使用。
            case "skill_not_preoccupied": return (SkillResult)55; // 只能对选中的目标使用。
            case "skill_not_my_npc": return (SkillResult)56; // 你没有权限。
            case "skill_not_checked_second_pass": return (SkillResult)57; // 未通过二级密码验证。
            case "SKILL_CANNOT_USE_HERE": return (SkillResult)58; // 无法在此位置使用此技能。
            case "skill_invalid_grade_enchant_support_item": return (SkillResult)59; // 无法使用重铸符。
            case "skill_check_character_p_stat_min": return (SkillResult)60; // 你可以将此属性降级到 ($1) 未知。
            case "skill_check_character_p_stat_max": return (SkillResult)61; // 你可以将此属性升级到 ($1) 未知。
            case "skill_item_secured": return (SkillResult)62; // 89 ?? skill_item_secured
            case "skill_invalid_account_attribute": return (SkillResult)63; // 你的账户没有所需的权限。
            case "skill_urk_level": return (SkillResult)64; // 你的等级太低。
            case "skill_urk_ability": return (SkillResult)65; // 你的属性太低。
            case "skill_urk_race": return (SkillResult)66; // 不适用于此种族。
            case "skill_urk_gender": return (SkillResult)67; // 不适用于此性别。
            case "skill_urk_equip_slot": return (SkillResult)68; // 必须装备正确的装备。
            case "skill_urk_equip_item": return (SkillResult)69; // 必须装备物品。
            case "skill_urk_own_item": return (SkillResult)70; // 你需要 ($1) 未知(|r。)
            case "skill_urk_trained_skill": return (SkillResult)71; // 你还没有学习此技能。
            case "skill_urk_combat": return (SkillResult)72; // 战斗中无法使用。
            case "skill_urk_stealth": return (SkillResult)73; // 隐身状态不符合要求。
            case "skill_urk_health": return (SkillResult)74; // 生命值不符合要求。
            case "skill_urk_buff": return (SkillResult)75; // 必须是 ($1) 未知状态。
            case "skill_urk_target_buff": return (SkillResult)76; // 目标必须是 ($1) 未知状态。
            case "skill_urk_target_combat": return (SkillResult)77; // 目标的战斗状态不符合要求。
            case "skill_urk_can_learn_craft": return (SkillResult)78; // 你已经学习了此制作技能。
            case "skill_urk_doodad_range": return (SkillResult)79; // $1 不在你周围。
            case "skill_urk_equip_shield": return (SkillResult)80; // 必须装备盾牌。
            case "skill_urk_nobuff": return (SkillResult)81; // 不能处于 ($1) 未知效果下。
            case "skill_urk_target_buff_tag": return (SkillResult)82; // 目标必须是 ($1) 未知状态。
            case "skill_urk_corpse_range": return (SkillResult)83; // 附近没有尸体。
            case "skill_urk_equip_weapon_type": return (SkillResult)84; // 必须装备正确的武器。
            case "skill_urk_target_health_less_than": return (SkillResult)85; // 目标的生命值必须较低。
            case "skill_urk_target_npc": return (SkillResult)86; // 只能对 ($1) 未知使用。
            case "skill_urk_target_doodad": return (SkillResult)87; // 对象无效。
            case "skill_urk_equip_ranged": return (SkillResult)88; // 必须装备远程武器。
            case "skill_urk_no_buff_tag": return (SkillResult)89; // 当前无法执行。
            case "skill_urk_complete_quest_context": return (SkillResult)90; // 任务：$1 必须已完成。
            case "skill_urk_progress_quest_context": return (SkillResult)91; // 任务：$1 必须进行中。
            case "skill_urk_ready_quest_context": return (SkillResult)92; // 任务：$1 必须已完成。
            case "skill_urk_target_npc_group": return (SkillResult)93; // 目标无效。
            case "skill_urk_area_sphere": return (SkillResult)94; // 无法在这里使用。
            case "skill_urk_except_complete_quest_context": return (SkillResult)95; // 89 ?? Skill_urk_except_complete_quest_context
            case "skill_urk_precomplete_quest_context": return (SkillResult)96; // 任务：$1 必须进行中。
            case "skill_urk_target_owner_type": return (SkillResult)97; // 目标无效。
            case "skill_urk_not_under_water": return (SkillResult)98; // 水下无法使用。
            case "skill_urk_faction_match": return (SkillResult)99; // 你不是 $1 阵营的成员。
            case "skill_urk_tod": return (SkillResult)100; // 当前无法使用。
            case "skill_urk_mother_faction": return (SkillResult)101; // 你的阵营无法使用此功能。
            case "skill_urk_actability_point": return (SkillResult)102; // $1 熟练度不足。
            case "skill_urk_crime_point": return (SkillResult)103; // 89 ?? Skill_urk_crime_point
            case "skill_urk_honor_point": return (SkillResult)104; // 荣誉点数不符合要求。
            case "skill_urk_living_point": return (SkillResult)105; // 职业徽章不符合要求。
            case "skill_urk_crime_record": return (SkillResult)106; // 89 ?? Skill_urk_crime_record
            case "skill_urk_jury_point": return (SkillResult)107; // 89 ?? Skill_urk_jury_point
            case "skill_urk_source_owner_type": return (SkillResult)108; // 89 ?? Skill_urk_source_owner_type
            case "skill_urk_appelation": return (SkillResult)109; // 89 ?? Skill_urk_appelation
            case "skill_urk_in_zone": return (SkillResult)110; // 只能在 $1 中使用。
            case "skill_urk_out_zone": return (SkillResult)111; // 无法在 $1 中使用。
            case "skill_urk_dominion_owner": return (SkillResult)112; // 只有领主可以执行此操作。
            case "skill_urk_verdict_only": return (SkillResult)113; // 你的陪审团权限已被撤销。你不能再担任陪审员。
            case "skill_urk_faction_match_only": return (SkillResult)114; // 你不是 $1 阵营的成员。
            case "skill_urk_mother_faction_only": return (SkillResult)115; // 你的阵营无法使用此功能。
            case "skill_urk_nation_owner": return (SkillResult)116; // 89 ?? Skill_urk_nation_owner
            case "skill_urk_faction_match_only_not": return (SkillResult)117; // 必须先消耗 $1+ 生命值。// 这个翻译似乎不对
            case "skill_urk_mother_faction_only_not": return (SkillResult)118; // $1 子阵营无法执行此操作。
            case "skill_urk_nation_member": return (SkillResult)119; // 你必须加入一个民族。
            case "skill_urk_nation_member_not": return (SkillResult)120; // 你不能加入民族来执行此操作。
            case "skill_urk_nation_owner_at_pos": return (SkillResult)121; // 89 ?? Skill_urk_nation_owner_at_pos
            case "skill_urk_dominion_owner_at_pos": return (SkillResult)122; // 89 ?? Skill_urk_dominion_owner_at_pos
            case "skill_urk_housing": return (SkillResult)123; // 你没有 $1。
            case "skill_urk_health_margin": return (SkillResult)124; // 89 ?? Skill_urk_health_margin
            case "skill_urk_mana_margin": return (SkillResult)125; // 必须先消耗 $1+ 魔法值。
            case "skill_urk_labor_power_margin": return (SkillResult)126; // 必须先消耗 $1+ 劳动力。
            case "skill_urk_unknown": return (SkillResult)127; // 无法使用。
            case "skill_urk_max_level": return (SkillResult)128; // 你的等级太高。
            case "skill_urk_expedition_owner": return (SkillResult)129; // 89 ?? Skill_urk_expedition_owner
            case "skill_urk_expedition_member": return (SkillResult)130; // 89 ?? Skill_urk_expedition_member
            // case "skill_urk_progress_quest_context": return (SkillResult)131; //	89 ?? Skill_urk_progress_quest_context
            // case "skill_urk_ready_quest_context": return (SkillResult)132; //	89 ?? Skill_urk_ready_quest_context
            default: return SkillResult.Failure;
        }
    }
}
