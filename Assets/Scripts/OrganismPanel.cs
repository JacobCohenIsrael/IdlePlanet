using UnityEngine;
using UnityEngine.UI;

public class OrganismPanel : MonoBehaviour
{
	[SerializeField]
	private Text requiredDnaText;

	[SerializeField]
	private Text organismNameText;

	private long organismsAlive;

	private float nextGrowth;
	
	
	public OrganismModel _organismModel;

	private bool isGrowing;

	public void Init()
	{
		requiredDnaText.text = _organismModel.baseDnaCost.ToString();
		organismNameText.text = _organismModel.organismName;
		nextGrowth = Time.time;
	}

	public void OnPopulate()
	{
		if (_organismModel.baseDnaCost <= GameManager.Dna)
		{
			organismsAlive++;
            GameManager.OrganismsAmount++;
			GameManager.Dna -= _organismModel.baseDnaCost;
            _organismModel.baseDnaCost = (long)(_organismModel.baseDnaCost * 1.2);
			requiredDnaText.text = _organismModel.baseDnaCost.ToString();
		}

		if (!isGrowing)
		{
			isGrowing = true;
		}
	}

	private void Update()
	{
		if (isGrowing && Time.time > nextGrowth)
		{
			GameManager.Dna += _organismModel.baseDnaGrowthRate * organismsAlive;
			nextGrowth = Time.time + 1;
		}
	}
}