using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Object
	public class ObjectInfo
    {
		public int objectId;
		public string name;
		public Vector2 pos;
		public StatInfo statInfo;

	}
    #endregion

    #region Stat
    public class StatInfo
    {
		public int id;
		public LevelInfo levelInfo;

		public int hp;				//현재체력
		public int maxHp;
		public int regenHp;			//체젠(5초)

		public SheildType sheildType;
		public int Sheild;

		// Cost
		//public CostInfo costInfo;
		public int mp;
		public int maxMp;
		public int regenMp;

		// Physical Damage
		public int attackDamage;	//공격력
		public float attackSpeed;   //공격속도

		// Magic Damage
		public int abilityPower;	//주문력
		public int abilityHaste;    //주문가속

		// Registance
		//Damage Multiplier = 100 / (100 + R) {R >= 0} || 2 - 100 / (100 - MR) {R < 0}
		public int armor;			//방어력

		public int magicResistance;	//마법저항력

		public float moveSpeed;		//이동속도

		// Items & Runes
		public int physicalVamp;    //물리흡혈
		public int omniVamp;        //주문흡혈

		// Unit Radius
		public int gameRadius;		//유닛크기, 실제사거리 = 유닛크기+사거리
		public int selectionRadius;
		public int pathingRadius;
	}

	public class LevelInfo
    {
		//성장 공격력~싹다
		public int id;	// 동일 챔피언 구분용
		//
    }

	public enum SheildType
    {
		None,
		Damage,
		Physical,
		Magic,
		Black,		//CC 면역
    }

	public enum CostType
    {
		Mana,
		Energy,
    }

	[Serializable]
	public class StatData : ILoader<int, StatInfo>
	{
		public List<StatInfo> stats = new List<StatInfo>();

		public Dictionary<int, StatInfo> MakeDict()
		{
			Dictionary<int, StatInfo> dict = new Dictionary<int, StatInfo>();
			foreach (StatInfo stat in stats)
				dict.Add(stat.id, stat);
			return dict;
		}
	}
	#endregion

	#region Skill
	[Serializable]
	public class Skill
	{
		public int id;
		public string name;
		public ScailingInfo scailingInfo;	//Stats Percentage
		public float cooldown;              //Shortened by AbilityHaste
		public AmmoInfo ammoInfo;			//
		public RangeInfo rangeInfo;
		public float castTime;
		public float channel;
		public ActiveInfo activeInfo;
		public PassiveInfo passiveInfo;
		public ToggleInfo toggleInfo;
		public StanceInfo stanceInfo;
		public SummonInfo summonInfo;
		public OnHitInfo onHitInfo;
		public OnAttackInfo onAttackInfo;
	}

	public class ScailingInfo
    {
		public float Hp;
		public float Mp;
		public float AttackDamage;
		public float AbilityPower;
		public float Armor;
		public float MagicResistance;
		public float MoveSpeed;
    }

	public class AmmoInfo
    {
		public AmmoType ammoType;
		public int maxAmmo;
		public int ammo;
		public float cooldown;
    }

	public class RangeInfo
    {
		public RangeType rangeType;
		public float range;
    }

	public class ActiveInfo
    {
		public CastNumber castNumber;	//For Multiple Recasts
		public GameObject owner;
		public Vector2 location;
		public Vector2 direction;
    }

	public class PassiveInfo
    {
		//bufs
		public int WIP;
    }

	public class ToggleInfo
	{
		public ToggleType toggleType;
	}

	public class StanceInfo
	{

	}

	public class SummonInfo
    {
		public string name;
		public string prefab;
    }

	public class OnHitInfo
    {

    }

	public class OnAttackInfo
    {

    }

	[Serializable]
	public class SkillData : ILoader<int, Skill>
	{
		public List<Skill> skills = new List<Skill>();

		public Dictionary<int, Skill> MakeDict()
		{
			Dictionary<int, Skill> dict = new Dictionary<int, Skill>();
			foreach (Skill skill in skills)
				dict.Add(skill.id, skill);
			return dict;
		}
	}
	#endregion

	#region Skill Enum
	public enum DamageType
	{
		RawDamage,          //처형피해?, 저항무시, 쉴드무시, 주문효과와 피해흡혈 적용 없음
		AbsoluteDamage,     //면역, 부활 무시 ex)우물레이져
		DefaultDamage,      //기본피해, 효과 발동 무시 ex)스플래쉬 데미지, 루덴, 유성, 점화
		ProcDamage,         //발동피해, 효과발동 무시 ex)마최, 충전상태 후 공격(폭칼, 고연포), 몰왕,주문검은 피해흡혈 적용되니깐 제외
		ReactiveDamage,     //반사피해, ex) 가시갑옷
		BasicDamage,        //일반피해, 유닛(챔, 타워, 중립몹, 미니언)의 기본공격 또는 일부 챔 능력(이즈Q,야스오Q,갱플Q,피오라Q)으로 인한 피해, 회피(잭스E)나 방어(쉔W)로 막힘
		SpellDamage,        //주문피해, 단일 대상
		AreaDamage,         //범위피해, AOE
		PersistentDamage,   //지속피해
		PetDamage,
	}

	public enum DamageSubType
	{
		PhysicalDamage,
		MagicDamage,
		TrueDamage,
	}

	public enum DamageTag
	{
		BasicAttack,
		ActiveSpell,
		AOE,        //장판딜 - OmniVamp 33%
		Periodic,   //도트딜
		Item,       //아이템 피해, Non-Champion Source (Item or SummonerSpell)
		Proc,       //조건발동, 
		Pet,        //소환수, ChampionSummonedUnit
		NonRedirectable,
		Indirect,
	}

	public enum AmmoType
	{
		Stock,      //
		Barrage,    //시전 중 충전
	}

	public enum RangeType
	{
		CenterBased,
		EdgeBased,      //Increase When SIze Up
	}

	public enum ToggleType
	{
		OnOff,
	}

	public enum CastNumber
	{
		FirstCast,
		SecondCast,
		ThirdCast,
	}
	#endregion
}