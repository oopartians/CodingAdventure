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

		public int hp;				//����ü��
		public int maxHp;
		public int regenHp;			//ü��(5��)

		public SheildType sheildType;
		public int Sheild;

		// Cost
		//public CostInfo costInfo;
		public int mp;
		public int maxMp;
		public int regenMp;

		// Physical Damage
		public int attackDamage;	//���ݷ�
		public float attackSpeed;   //���ݼӵ�

		// Magic Damage
		public int abilityPower;	//�ֹ���
		public int abilityHaste;    //�ֹ�����

		// Registance
		//Damage Multiplier = 100 / (100 + R) {R >= 0} || 2 - 100 / (100 - MR) {R < 0}
		public int armor;			//����

		public int magicResistance;	//�������׷�

		public float moveSpeed;		//�̵��ӵ�

		// Items & Runes
		public int physicalVamp;    //��������
		public int omniVamp;        //�ֹ�����

		// Unit Radius
		public int gameRadius;		//����ũ��, ������Ÿ� = ����ũ��+��Ÿ�
		public int selectionRadius;
		public int pathingRadius;
	}

	public class LevelInfo
    {
		//���� ���ݷ�~�ϴ�
		public int id;	// ���� è�Ǿ� ���п�
		//
    }

	public enum SheildType
    {
		None,
		Damage,
		Physical,
		Magic,
		Black,		//CC �鿪
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
		RawDamage,          //ó������?, ���׹���, ���幫��, �ֹ�ȿ���� �������� ���� ����
		AbsoluteDamage,     //�鿪, ��Ȱ ���� ex)�칰������
		DefaultDamage,      //�⺻����, ȿ�� �ߵ� ���� ex)���÷��� ������, �絧, ����, ��ȭ
		ProcDamage,         //�ߵ�����, ȿ���ߵ� ���� ex)����, �������� �� ����(��Į, ����), ����,�ֹ����� �������� ����Ǵϱ� ����
		ReactiveDamage,     //�ݻ�����, ex) ���ð���
		BasicDamage,        //�Ϲ�����, ����(è, Ÿ��, �߸���, �̴Ͼ�)�� �⺻���� �Ǵ� �Ϻ� è �ɷ�(����Q,�߽���Q,����Q,�ǿ���Q)���� ���� ����, ȸ��(�轺E)�� ���(��W)�� ����
		SpellDamage,        //�ֹ�����, ���� ���
		AreaDamage,         //��������, AOE
		PersistentDamage,   //��������
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
		AOE,        //���ǵ� - OmniVamp 33%
		Periodic,   //��Ʈ��
		Item,       //������ ����, Non-Champion Source (Item or SummonerSpell)
		Proc,       //���ǹߵ�, 
		Pet,        //��ȯ��, ChampionSummonedUnit
		NonRedirectable,
		Indirect,
	}

	public enum AmmoType
	{
		Stock,      //
		Barrage,    //���� �� ����
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