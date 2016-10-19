using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static PathfinderJson.Constants;

namespace PathfinderJson
{
    public class CharacterSheet
    {
        public CharacterSheet() { }
        public CharacterSheet(FieldReader reader)
        {
            ObjectMaterializer.Populate(this, reader, 0);

            Classes = Enumerable.Range(1, 5)
                .Select(x => ObjectMaterializer.Create<Class>(reader, x))
                .Where(x => !x.IsNull)
                .ToList();


            STR = ObjectMaterializer.Create<AbilityScore>(reader, $"{nameof(STR)}");
            DEX = ObjectMaterializer.Create<AbilityScore>(reader, $"{nameof(DEX)}");
            CON = ObjectMaterializer.Create<AbilityScore>(reader, $"{nameof(CON)}");
            INT = ObjectMaterializer.Create<AbilityScore>(reader, $"{nameof(INT)}");
            WIS = ObjectMaterializer.Create<AbilityScore>(reader, $"{nameof(WIS)}");
            CHA = ObjectMaterializer.Create<AbilityScore>(reader, $"{nameof(CHA)}");

            Skills = new SkillSet(reader);

            Feats = Enumerable.Range(1, 30)
                .Select(x => reader.GetField<string>($"FeatFeatures_{x:00}"))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            AD_Combat_Notes = Enumerable.Range(1, 10)
                .Select(x => reader.GetField<string>($"AD_Combat_Notes_{x:00}"))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            Weapons = Enumerable.Range(1, 5)
                .Select(x => ObjectMaterializer.Create<Weapon>(reader, x))
                .Where(x => !x.IsNull)
                .ToList();

            FeatsSpecials = Enumerable.Range(1, 20)
                .Select(x => ObjectMaterializer.Create<FeatsSpecial>(reader, $"{x:00}"))
                .Where(x => !x.IsNull)
                .ToList();

            EquipmentItems = Enumerable.Range(1, 54)
                .Select(x => ObjectMaterializer.Create<EquipmentItem>(reader, $"{x:00}"))
                .Where(x => !x.IsNull)
                .ToList();

            Containers = Enumerable.Range(1, 4)
                .Select(x => ObjectMaterializer.Create<Container>(reader, $"{x:00}"))
                .Where(x => !x.IsNull)
                .ToList();

            Treasures = Enumerable.Range(1, 4)
                .Select(x => ObjectMaterializer.Create<Treasure>(reader, $"{x:00}"))
                .Where(x => !x.IsNull)
                .ToList();

            Casters = Enumerable.Range(1, 2)
                .Select(x => ObjectMaterializer.Create<Caster>(reader, $"{x:0}"))
                .ToList();

            Spells = Enumerable.Range(1, 354)
                .Select(x => ObjectMaterializer.Create<Spell>(reader, $"{x:000}"))
                .Where(x => !x.IsNull)
                .ToList();

        }

        #region Character

        [Field]
        public string Character_Name { get; set; }
        [Field]
        public string Character_Player { get; set; }
        [Field]
        public string Character_Race { get; set; }
        [Field]
        public string Character_Size { get; set; }
        [Field]
        public string Character_Gender { get; set; }
        [Field]
        public string Character_Height { get; set; }
        [Field]
        public int Character_Weight { get; set; }
        [Field]
        public string Character_Hair { get; set; }
        [Field]
        public string Character_Eyes { get; set; }
        [Field]
        public string Character_Skin { get; set; }
        [Field]
        public int Character_Age { get; set; }
        [Field]
        public string Character_Alignment { get; set; }
        [Field]
        public string Character_Deity { get; set; }
        [Field]
        public string Character_Homeland { get; set; }
        [Field]
        public string Character_Languages { get; set; }
        [Field]
        public string Ability_Notes { get; set; }
        [Field]
        public string CR_Misc_Tracking { get; set; }

        #endregion Character

        #region CR

        [Field]
        public int CR_Current_HP { get; set; }
        [Field]
        public int CR_Nonlethal_HP { get; set; }
        [Field]
        public int CR_Temp_HP { get; set; }
        [Field]
        public int CR_HP_Total { get; set; }

        [Field]
        public string CR_Favored_Class { get; set; }
        [Field]
        public int CR_BAB_Total { get; set; }
        [Field]
        public int CR_Skill_Total { get; set; }
        [Field]
        public int CR_FC_Total { get; set; }
        [Field]
        public int CR_Fort_Total { get; set; }
        [Field]
        public int CR_Ref_Total { get; set; }
        [Field]
        public int CR_Will_Total { get; set; }
        [Field]
        public int CR_Levels_Total { get; set; }
        #endregion

        #region AC



        [Field]
        public int AD_AC_Total { get; set; }
        [Field]
        public int AD_AC_Base { get; set; }
        [Field]
        public int AD_AC_Armor { get; set; }
        [Field]
        public int AD_AC_Shield { get; set; }
        [Field]
        public int AD_AC_Dex { get; set; }
        [Field]
        public int AD_AC_Size { get; set; }
        [Field]
        public int AD_AC_Dodge { get; set; }
        [Field]
        public int AD_AC_Natural { get; set; }
        [Field]
        public int AD_AC_Deflect { get; set; }
        [Field]
        public int AD_AC_Misc { get; set; }
        [Field]
        public int AD_AC_Temp { get; set; }
        [Field]
        public int AD_Touch_Total { get; set; }
        [Field]
        public int AD_Touch_Misc { get; set; }
        [Field]
        public int AD_Touch_Temp { get; set; }
        [Field]
        public int AD_FF_Total { get; set; }
        [Field]
        public int AD_AC_Dex_Negative { get; set; }
        [Field]
        public int AD_FF_Misc { get; set; }
        [Field]
        public int AD_FF_Temp { get; set; }
        [Field]
        public int AD_Fort_Total { get; set; }
        [Field]
        public int AD_Fort_Base { get; set; }
        [Field]
        public int AD_Fort_Ability { get; set; }
        [Field]
        public int AD_Fort_Enhance { get; set; }
        [Field]
        public int AD_Fort_Misc { get; set; }
        [Field]
        public int AD_Fort_Temp { get; set; }
        [Field]
        public int AD_Ref_Total { get; set; }
        [Field]
        public int AD_Ref_Base { get; set; }
        [Field]
        public int AD_Ref_Ability { get; set; }
        [Field]
        public int AD_Ref_Enhance { get; set; }
        [Field]
        public int AD_Ref_Misc { get; set; }
        [Field]
        public int AD_Ref_Temp { get; set; }
        [Field]
        public int AD_Will_Total { get; set; }
        [Field]
        public int AD_Will_Base { get; set; }
        [Field]
        public int AD_Will_Ability { get; set; }
        [Field]
        public int AD_Will_Enhance { get; set; }
        [Field]
        public int AD_Will_Misc { get; set; }
        [Field]
        public int AD_Will_Temp { get; set; }
        [Field]
        public int AD_Melee_Total { get; set; }
        [Field]
        public int AD_Melee_BAB { get; set; }
        [Field]
        public int AD_Melee_Temp { get; set; }
        [Field]
        public int AD_Melee_Ability { get; set; }
        [Field]
        public int AD_Melee_Misc { get; set; }
        [Field]
        public int AD_Ranged_Total { get; set; }
        [Field]
        public int AD_Ranged_BAB { get; set; }
        [Field]
        public int AD_Ranged_Temp { get; set; }
        [Field]
        public int AD_Ranged_Ability { get; set; }
        [Field]
        public int AD_Ranged_Misc { get; set; }
        [Field]
        public int AD_CMB_Total { get; set; }
        [Field]
        public int AD_CMB_BAB { get; set; }
        [Field]
        public string AD_CMB_Option { get; set; }
        [Field]
        public int AD_CMB_Ability { get; set; }
        [Field]
        public int AD_CMB_Misc { get; set; }
        [Field]
        public int AD_CMD_Total { get; set; }
        [Field]
        public int AD_CMD_BAB { get; set; }
        [Field]
        public int AD_CMD_Dodge { get; set; }
        [Field]
        public int AD_CMD_Ability { get; set; }
        [Field]
        public int AD_CMD_Misc { get; set; }
        [Field]
        public int AD_ACP { get; set; }
        [Field]
        public int AD_Max_Dex { get; set; }
        [Field]
        public int AD_Spell_Failure { get; set; }



        #endregion

        #region XP


        [Field]
        public string Exp_Slow { get; set; }
        [Field]
        public string Exp_Medium { get; set; }
        [Field]
        public string Exp_Fast { get; set; }
        [Field]
        public int Exp_Current_Total { get; set; }
        [Field]
        public int Exp_Next_Level { get; set; }

        #endregion

        #region Stats


        [Field]
        public int Stats_Speed { get; set; }
        [Field]
        public int Stats_Speed_Base { get; set; }
        [Field]
        public int Stats_Speed_Fly { get; set; }
        [Field]
        public int Stats_Speed_Swim { get; set; }
        [Field]
        public int Stats_Speed_Climb { get; set; }
        [Field]
        public int Stats_Speed_Misc { get; set; }
        [Field]
        public int Stats_Init { get; set; }
        [Field]
        public int Stats_Init_Dex_Mod { get; set; }
        [Field]
        public int Stats_Init_Misc_Mod { get; set; }
        [Field]
        public int Stats_Hero { get; set; }
        [Field]
        public int Stats_SR { get; set; }
        [Field]
        public string Stats_DR { get; set; }
        [Field]
        public string Stats_Resistances { get; set; }
        [Field]
        public int Stats_Pool_Points { get; set; }
        [Field]
        public string Stats_Pool_Points_Used { get; set; }
        [Field]
        public string Stats_Notes_1 { get; set; }
        [Field]
        public string Stats_Notes_2 { get; set; }
        [Field]
        public string Stats_Notes_3 { get; set; }

        #endregion Stats

        #region Armor


        [Field]
        public string Armor_Name { get; set; }
        [Field]
        public int Armor_AC_Bonus { get; set; }
        [Field]
        public int Armor_Max_Dex { get; set; }
        [Field]
        public int Armor_Check_Penalty { get; set; }
        [Field]
        public int Armor_Spell_Fail { get; set; }
        [Field]
        public string Armor_Type { get; set; }
        [Field]
        public int Armor_Weight { get; set; }
        [Field]
        public string Armor_Shield_Name { get; set; }
        [Field]
        public int Armor_Shield_AC_Bonus { get; set; }
        [Field]
        public int Armor_Shield_Max_Dex { get; set; }
        [Field]
        public int Armor_Shield_Check_Penalty { get; set; }
        [Field]
        public int Armor_Shield_Spell_Fail { get; set; }
        [Field]
        public string Armor_Shield_Type { get; set; }
        [Field]
        public int Armor_Shield_Weight { get; set; }

        #endregion Armor

        #region WornEquip

        [Field]
        public string Worn_Equip_Belt { get; set; }
        [Field]
        public string Worn_Equip_Body { get; set; }
        [Field]
        public string Worn_Equip_Chest { get; set; }
        [Field]
        public string Worn_Equip_Eyes { get; set; }
        [Field]
        public string Worn_Equip_Feet { get; set; }
        [Field]
        public string Worn_Equip_Hands { get; set; }
        [Field]
        public string Worn_Equip_Head { get; set; }
        [Field]
        public string Worn_Equip_Headband { get; set; }
        [Field]
        public string Worn_Equip_Neck { get; set; }
        [Field]
        public string Worn_Equip_Ring1 { get; set; }
        [Field]
        public string Worn_Equip_Ring2 { get; set; }
        [Field]
        public string Worn_Equip_Shoulders { get; set; }
        [Field]
        public string Worn_Equip_Wrist { get; set; }

        #endregion WornEquip

        #region Currency



        [Field]
        public int Currency_Carried_Platinum { get; set; }
        [Field]
        public int Currency_Carried_Platinum_NA { get; set; }
        [Field]
        public int Currency_Stored_Platinum { get; set; }
        [Field]
        public int Currency_Carried_Gold { get; set; }
        [Field]
        public int Currency_Carried_Gold_NA { get; set; }
        [Field]
        public int Currency_Stored_Gold { get; set; }
        [Field]
        public int Currency_Carried_Silver { get; set; }
        [Field]
        public int Currency_Carried_Silver_NA { get; set; }
        [Field]
        public int Currency_Stored_Silver { get; set; }
        [Field]
        public int Currency_Carried_Copper { get; set; }
        [Field]
        public int Currency_Carried_Copper_NA { get; set; }
        [Field]
        public int Currency_Stored_Copper { get; set; }
        [Field]
        public string Currency_Other_Name { get; set; }
        [Field]
        public int Currency_Carried_Other { get; set; }
        [Field]
        public int Currency_Carried_Other_NA { get; set; }
        [Field]
        public int Currency_Stored_Other { get; set; }


        #endregion Currency

        #region Weight


        [Field]
        public double Weight_Carried_Armor { get; set; }
        [Field]
        public double Weight_Carried_Currency { get; set; }
        [Field]
        public double Weight_Carried_Equipment { get; set; }
        [Field]
        public double Weight_Carried_Misc { get; set; }
        [Field]
        public double Weight_Total { get; set; }

        [Field]
        public string Load_Light { get; set; }
        [Field]
        public string Load_Medium { get; set; }
        [Field]
        public int Load_Heavy { get; set; }
        [Field]
        public int Load_Lift_Head { get; set; }
        [Field]
        public int Load_Lift_Ground { get; set; }
        [Field]
        public int Load_Drag { get; set; }
        [Field]
        public int Load_Mod_Light { get; set; }
        [Field]
        public int Load_Mod_Medium { get; set; }
        [Field]
        public int Load_Mod_Heavy { get; set; }
        [Field]
        public int Load_Mod_Lift_Head { get; set; }
        [Field]
        public int Load_Mod_Lift_Ground { get; set; }
        [Field]
        public int Load_Mod_Drag { get; set; }
        [Field]
        public string Load_Light_Check { get; set; }
        [Field]
        public string Load_Medium_Check { get; set; }
        [Field]
        public string Load_Heavy_Check { get; set; }
        [Field]
        public int Load_ACP { get; set; }
        [Field]
        public int Load_Max_Dex { get; set; }

        #endregion Weight

        #region Spells

        [Field]
        public string Spells_Bloodline_1 { get; set; }
        [Field]
        public string Spells_Bloodline_2 { get; set; }
        [Field]
        public string Spells_Domain_1 { get; set; }
        [Field]
        public string Spells_Subdomain_1 { get; set; }
        [Field]
        public string Spells_Domain_2 { get; set; }
        [Field]
        public string Spells_Subdomain_2 { get; set; }
        [Field]
        public string Spells_Domain_3 { get; set; }
        [Field]
        public string Spells_Subdomain_3 { get; set; }
        [Field]
        public string Spells_Speciality { get; set; }
        [Field]
        public string Spells_Focused { get; set; }
        [Field]
        public string Spells_Prohibited_1 { get; set; }
        [Field]
        public string Spells_Prohibited_2 { get; set; }

        #endregion Spells

        public List<string> AD_Combat_Notes { get; set; }

        public AbilityScore STR { get; set; }
        public AbilityScore DEX { get; set; }
        public AbilityScore CON { get; set; }
        public AbilityScore INT { get; set; }
        public AbilityScore WIS { get; set; }
        public AbilityScore CHA { get; set; }

        public List<Class> Classes { get; set; }

        [Field]
        public int Skills_Ranks_Total { get; set; }
        public SkillSet Skills { get; set; }
        public List<string> Feats { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<FeatsSpecial> FeatsSpecials { get; set; }
        public List<EquipmentItem> EquipmentItems { get; set; }
        public List<Spell> Spells { get; set; }
        public List<Container> Containers { get; set; }
        public List<Treasure> Treasures { get; set; }
        public List<Caster> Casters { get; set; }

    }

    public class Class
    {
        [Field]
        public int CR_Current_HP { get; set; }
        [Field("CR_Class_Name_" + SubName)]
        public string Name { get; set; }
        [Field("CR_HpGained_" + SubName)]
        public int HP { get; set; }
        [Field("CR_BAB_" + SubName)]
        public int BAB { get; set; }
        [Field("CR_Skill_" + SubName)]
        public int Skill { get; set; }
        [Field("CR_FC_" + SubName)]
        public int FC { get; set; }
        [Field("CR_Fort_" + SubName)]
        public int Fort { get; set; }
        [Field("CR_Ref_" + SubName)]
        public int Ref { get; set; }
        [Field("CR_Will_" + SubName)]
        public int Will { get; set; }
        [Field("CR_Levels_" + SubName)]
        public int Levels { get; set; }
        [Field("CR_HD_" + SubName)]
        public int HitDie { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class AbilityScore
    {
        [Field("Ability_" + SubName + "_Total")]
        public int Total { get; set; }
        [Field("Ability_" + SubName + "_Base")]
        public int Base { get; set; }
        [Field("Ability_" + SubName + "_Enhance")]
        public int Enhance { get; set; }
        [Field("Ability_" + SubName + "_Misc")]
        public int Misc { get; set; }
        [Field("Ability_" + SubName + "_Temp")]
        public int Temp { get; set; }
    }

    public class SkillSet
    {
        public SkillSet(FieldReader reader)
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                prop.SetValue(this, ObjectMaterializer.Create<Skill>(reader, prop.Name));
            }
        }

        public Skill Acrobatics { get; set; }
        public Skill Appraise { get; set; }
        public Skill Bluff { get; set; }
        public Skill Climb { get; set; }
        public Skill Craft { get; set; }
        public Skill Custom1 { get; set; }
        public Skill Custom2 { get; set; }
        public Skill Custom3 { get; set; }
        public Skill Custom4 { get; set; }
        public Skill Custom5 { get; set; }
        public Skill Custom6 { get; set; }
        public Skill Diplomacy { get; set; }
        public Skill Disable { get; set; }
        public Skill Disguise { get; set; }
        public Skill Escape { get; set; }
        public Skill Fly { get; set; }
        public Skill Handle { get; set; }
        public Skill Heal { get; set; }
        public Skill Intimidate { get; set; }
        public Skill Knowledge1 { get; set; }
        public Skill Knowledge2 { get; set; }
        public Skill Knowledge3 { get; set; }
        public Skill Knowledge4 { get; set; }
        public Skill Knowledge5 { get; set; }
        public Skill Knowledge6 { get; set; }
        public Skill Linguistics { get; set; }
        public Skill Perception { get; set; }
        public Skill Perform { get; set; }
        public Skill Profession { get; set; }
        public Skill Ride { get; set; }
        public Skill SOH { get; set; }
        public Skill Sense { get; set; }
        public Skill Spellcraft { get; set; }
        public Skill Stealth { get; set; }
        public Skill Survival { get; set; }
        public Skill Swim { get; set; }
        public Skill UMD { get; set; }
    }

    public class Skill
    {
        [Field("Skill_" + SubName + "_Isclass")]
        public bool Isclass { get; set; }
        [Field("Skill_" + SubName + "_Name")]
        public string Name { get; set; }
        [Field("Skill_" + SubName + "_Total")]
        public int Total { get; set; }
        [Field("Skill_" + SubName + "_Ranks")]
        public int Ranks { get; set; }
        [Field("Skill_" + SubName + "_Ability")]
        public int Ability { get; set; }
        [Field("Skill_" + SubName + "_Trained")]
        public int Trained { get; set; }
        [Field("Skill_" + SubName + "_Misc")]
        public int Misc { get; set; }
    }

    public class Weapon
    {
        [Field("Weapon_Name_" + SubName)]
        public string Name { get; set; }
        [Field("Weapon_Attack_" + SubName)]
        public string Attack { get; set; }
        [Field("Weapon_Damage_" + SubName)]
        public string Damage { get; set; }
        [Field("Weapon_Critical_" + SubName)]
        public string Critical { get; set; }
        [Field("Weapon_Range_" + SubName)]
        public int Range { get; set; }
        [Field("Weapon_Type_" + SubName)]
        public string Type { get; set; }
        [Field("Weapon_Weight_" + SubName)]
        public int Weight { get; set; }
        [Field("Weapon_Ammo_" + SubName)]
        public int Ammo { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class FeatsSpecial
    {
        [Field("FeatsSpecial_" + SubName)]
        public string Name { get; set; }
        [Field("FeatsSpecial_Uses_" + SubName)]
        public int Uses { get; set; }
        [Field("FeatsSpecial_Used_" + SubName)]
        public int Used { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class EquipmentItem
    {
        [Field("Equip_Item_" + SubName)]
        public string Name { get; set; }

        [Field("Equip_Item_Qty_" + SubName)]
        public string QtyUses { get; set; }
        [Field("Equip_Item_Wgt_NA_" + SubName)]
        public string WgtNA { get; set; }
        [Field("Equip_Item_Wgt_" + SubName)]
        public string Wgt { get; set; }
        [Field("Equip_Item_Container_" + SubName)]
        public string Container { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class Container
    {
        [Field("Containers_ID_" + SubName)]
        public string ID { get; set; }
        [Field("Containers_Name_" + SubName)]
        public string Name { get; set; }
        [Field("Containers_Notes_" + SubName)]
        public string Notes { get; set; }
        [Field("Containers_Wgt_" + SubName)]
        public int Weight { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class Treasure
    {
        [Field("Treasure_ID_" + SubName)]
        public string ID { get; set; }
        [Field("Treasure_Name_" + SubName)]
        public string Name { get; set; }
        [Field("Treasure_Wgt_" + SubName)]
        public int Weight { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class Caster
    {
        [Field("Caster" + SubName + "_Class")]
        public string Caster_Class { get; set; }
        [Field("Caster" + SubName + "_Level")]
        public int Caster_Level { get; set; }
        [Field("Caster" + SubName + "_Save_DC_0")]
        public int Caster_Save_DC_0 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_0")]
        public int Caster_Spell_Total_0 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_0")]
        public int Caster_Spell_Class_0 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_0")]
        public int Caster_Spell_Misc_0 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_0")]
        public int Caster_Spell_Known_0 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_1")]
        public int Caster_Save_DC_1 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_1")]
        public int Caster_Spell_Total_1 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_1")]
        public int Caster_Spell_Class_1 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_1")]
        public int Caster_Spell_Ability_1 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_1")]
        public int Caster_Spell_Misc_1 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_1")]
        public int Caster_Spell_Known_1 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_2")]
        public int Caster_Save_DC_2 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_2")]
        public int Caster_Spell_Total_2 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_2")]
        public int Caster_Spell_Class_2 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_2")]
        public int Caster_Spell_Ability_2 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_2")]
        public int Caster_Spell_Misc_2 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_2")]
        public int Caster_Spell_Known_2 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_3")]
        public int Caster_Save_DC_3 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_3")]
        public int Caster_Spell_Total_3 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_3")]
        public int Caster_Spell_Class_3 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_3")]
        public int Caster_Spell_Ability_3 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_3")]
        public int Caster_Spell_Misc_3 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_3")]
        public int Caster_Spell_Known_3 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_4")]
        public int Caster_Save_DC_4 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_4")]
        public int Caster_Spell_Total_4 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_4")]
        public int Caster_Spell_Class_4 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_4")]
        public int Caster_Spell_Ability_4 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_4")]
        public int Caster_Spell_Misc_4 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_4")]
        public int Caster_Spell_Known_4 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_5")]
        public int Caster_Save_DC_5 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_5")]
        public int Caster_Spell_Total_5 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_5")]
        public int Caster_Spell_Class_5 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_5")]
        public int Caster_Spell_Ability_5 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_5")]
        public int Caster_Spell_Misc_5 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_5")]
        public int Caster_Spell_Known_5 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_6")]
        public int Caster_Save_DC_6 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_6")]
        public int Caster_Spell_Total_6 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_6")]
        public int Caster_Spell_Class_6 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_6")]
        public int Caster_Spell_Ability_6 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_6")]
        public int Caster_Spell_Misc_6 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_6")]
        public int Caster_Spell_Known_6 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_7")]
        public int Caster_Save_DC_7 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_7")]
        public int Caster_Spell_Total_7 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_7")]
        public int Caster_Spell_Class_7 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_7")]
        public int Caster_Spell_Ability_7 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_7")]
        public int Caster_Spell_Misc_7 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_7")]
        public int Caster_Spell_Known_7 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_8")]
        public int Caster_Save_DC_8 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_8")]
        public int Caster_Spell_Total_8 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_8")]
        public int Caster_Spell_Class_8 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_8")]
        public int Caster_Spell_Ability_8 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_8")]
        public int Caster_Spell_Misc_8 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_8")]
        public int Caster_Spell_Known_8 { get; set; }
        [Field("Caster" + SubName + "_Save_DC_9")]
        public int Caster_Save_DC_9 { get; set; }
        [Field("Caster" + SubName + "_Spell_Total_9")]
        public int Caster_Spell_Total_9 { get; set; }
        [Field("Caster" + SubName + "_Spell_Class_9")]
        public int Caster_Spell_Class_9 { get; set; }
        [Field("Caster" + SubName + "_Spell_Ability_9")]
        public int Caster_Spell_Ability_9 { get; set; }
        [Field("Caster" + SubName + "_Spell_Misc_9")]
        public int Caster_Spell_Misc_9 { get; set; }
        [Field("Caster" + SubName + "_Spell_Known_9")]
        public int Caster_Spell_Known_9 { get; set; }
        [Field("Caster" + SubName + "_Range_Close")]
        public int Caster_Range_Close { get; set; }
        [Field("Caster" + SubName + "_Range_Medium")]
        public int Caster_Range_Medium { get; set; }
        [Field("Caster" + SubName + "_Range_Long")]
        public int Caster_Range_Long { get; set; }
        [Field("Caster" + SubName + "_Spell_Points_Total")]
        public int Caster_Spell_Points_Total { get; set; }
        [Field("Caster" + SubName + "_Spell_Points_Class")]
        public int Caster_Spell_Points_Class { get; set; }
        [Field("Caster" + SubName + "_Spell_Points_Ability")]
        public int Caster_Spell_Points_Ability { get; set; }
        [Field("Caster" + SubName + "_Spell_Points_Other")]
        public int Caster_Spell_Points_Other { get; set; }
        [Field("Caster" + SubName + "_Spell_Points_Current")]
        public string Caster_Spell_Points_Current { get; set; }
    }

    public class Spell
    {
        [Field("Spell_Level_" + SubName)]
        public string Spell_Level { get; set; }
        [Field("Spell_Prep_" + SubName)]
        public string Spell_Prep { get; set; }
        [Field("Spell_Used_" + SubName)]
        public string Spell_Used { get; set; }
        [Field("Spell_Name_" + SubName)]
        public string Spell_Name { get; set; }
        [Field("Spell_School_" + SubName)]
        public string Spell_School { get; set; }
        [Field("Spell_Duration_" + SubName)]
        public string Spell_Duration { get; set; }
        [Field("Spell_Range_" + SubName)]
        public string Spell_Range { get; set; }
        [Field("Spell_Save_" + SubName)]
        public string Spell_Save { get; set; }
        [Field("Spell_SR_" + SubName)]
        public string Spell_SR { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Spell_Name);
    }
}
