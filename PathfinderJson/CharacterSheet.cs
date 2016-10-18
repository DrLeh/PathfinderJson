using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PathfinderJson
{
    public class Constants
    {
        public const string SubName = "subname";
    }

    [FieldDefined]
    public class CharacterSheet
    {
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

        public AbilityScore STR { get; set; }
        public AbilityScore DEX { get; set; }
        public AbilityScore CON { get; set; }
        public AbilityScore INT { get; set; }
        public AbilityScore WIS { get; set; }
        public AbilityScore CHA { get; set; }

        public List<Class> Classes { get; set; }

        public SkillSet Skills { get; set; }
        public List<string> Feats { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<FeatsSpecial> FeatsSpecials { get; set; }
        public List<EquipmentItem> EquipmentItems { get; set; }
        public List<Spell> Spells { get; set; }

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

            Spells = Enumerable.Range(1, 35)
                .Concat(Enumerable.Range(101, 53))
                .Concat(Enumerable.Range(201, 53))
                .Concat(Enumerable.Range(301, 53))

                .Select(x => ObjectMaterializer.Create<Spell>(reader, $"{x:000}"))
                .Where(x => !x.IsNull)
                .ToList();

        }
    }

    [FieldDefined]
    public class Class
    {
        [Field("CR_Class_Name_" + Constants.SubName)]
        public string Name { get; set; }
        [Field("CR_HpGained_" + Constants.SubName)]
        public int HP { get; set; }
        [Field("CR_BAB_" + Constants.SubName)]
        public int BAB { get; set; }
        [Field("CR_Skill_" + Constants.SubName)]
        public int Skill { get; set; }
        [Field("CR_FC_" + Constants.SubName)]
        public int FC { get; set; }
        [Field("CR_Fort_" + Constants.SubName)]
        public int Fort { get; set; }
        [Field("CR_Ref_" + Constants.SubName)]
        public int Ref { get; set; }
        [Field("CR_Will_" + Constants.SubName)]
        public int Will { get; set; }
        [Field("CR_Levels_" + Constants.SubName)]
        public int Levels { get; set; }
        [Field("CR_HD_" + Constants.SubName)]
        public int HitDie { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class AbilityScore
    {
        [Field("Ability_" + Constants.SubName + "_Total")]
        public int Total { get; set; }
        [Field("Ability_" + Constants.SubName + "_Base")]
        public int Base { get; set; }
        [Field("Ability_" + Constants.SubName + "_Enhance")]
        public int Enhance { get; set; }
        [Field("Ability_" + Constants.SubName + "_Misc")]
        public int Misc { get; set; }
        [Field("Ability_" + Constants.SubName + "_Temp")]
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
        [Field("Skill_" + Constants.SubName + "_Isclass")]
        public bool Isclass { get; set; }
        [Field("Skill_" + Constants.SubName + "_Name")]
        public string Name { get; set; }
        [Field("Skill_" + Constants.SubName + "_Total")]
        public int Total { get; set; }
        [Field("Skill_" + Constants.SubName + "_Ranks")]
        public int Ranks { get; set; }
        [Field("Skill_" + Constants.SubName + "_Ability")]
        public int Ability { get; set; }
        [Field("Skill_" + Constants.SubName + "_Trained")]
        public int Trained { get; set; }
        [Field("Skill_" + Constants.SubName + "_Misc")]
        public int Misc { get; set; }
    }

    public class Weapon
    {
        [Field("Weapon_Name_" + Constants.SubName)]
        public string Name { get; set; }
        [Field("Weapon_Attack_" + Constants.SubName)]
        public string Attack { get; set; }
        [Field("Weapon_Damage_" + Constants.SubName)]
        public string Damage { get; set; }
        [Field("Weapon_Critical_" + Constants.SubName)]
        public string Critical { get; set; }
        [Field("Weapon_Range_" + Constants.SubName)]
        public int Range { get; set; }
        [Field("Weapon_Type_" + Constants.SubName)]
        public string Type { get; set; }
        [Field("Weapon_Weight_" + Constants.SubName)]
        public int Weight { get; set; }
        [Field("Weapon_Ammo_" + Constants.SubName)]
        public int Ammo { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class FeatsSpecial
    {
        [Field("FeatsSpecial_" + Constants.SubName)]
        public string Name { get; set; }
        [Field("FeatsSpecial_Uses_" + Constants.SubName)]
        public int Uses { get; set; }
        [Field("FeatsSpecial_Used_" + Constants.SubName)]
        public int Used { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class EquipmentItem
    {
        [Field("Equip_Item_" + Constants.SubName)]
        public string Name { get; set; }

        [Field("Equip_Item_Qty_" + Constants.SubName)]
        public string QtyUses { get; set; }
        [Field("Equip_Wgt_NA_" + Constants.SubName)]
        public string WgtNA { get; set; }
        [Field("Equip_Wgt_" + Constants.SubName)]
        public string Wgt { get; set; }
        [Field("Equip_Container_" + Constants.SubName)]
        public string Container { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Name);
    }

    public class Spell
    {
        [Field("Spell_Level_" + Constants.SubName)]
        public string Spell_Level { get; set; }
        [Field("Spell_Prep_" + Constants.SubName)]
        public string Spell_Prep { get; set; }
        [Field("Spell_Used_" + Constants.SubName)]
        public string Spell_Used { get; set; }
        [Field("Spell_Name_" + Constants.SubName)]
        public string Spell_Name { get; set; }
        [Field("Spell_School_" + Constants.SubName)]
        public string Spell_School { get; set; }
        [Field("Spell_Duration_" + Constants.SubName)]
        public string Spell_Duration { get; set; }
        [Field("Spell_Range_" + Constants.SubName)]
        public string Spell_Range { get; set; }
        [Field("Spell_Save_" + Constants.SubName)]
        public string Spell_Save { get; set; }
        [Field("Spell_SR_" + Constants.SubName)]
        public string Spell_SR { get; set; }

        [JsonIgnore]
        public bool IsNull => string.IsNullOrWhiteSpace(Spell_Name);
    }
}
