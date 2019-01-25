using System.Collections.Generic;
using UnityEngine;

public class OrganismMenu : MonoBehaviour
{

	[SerializeField]
	private Transform content;

	[SerializeField]
	private OrganismPanel _organismPanelPrefab;

	private Dictionary<OrganismsType, OrganismModel> _organismModels;
	
	public void AddOrganismPanel(OrganismModel organismModel)
	{
		var organismPanel = Instantiate(_organismPanelPrefab, content);
		organismPanel._organismModel = organismModel;
		organismPanel.Init();
	}

	private void Start()
	{
		_organismModels = new Dictionary<OrganismsType, OrganismModel>();
		var organismModel = new OrganismModel();
		organismModel.baseDnaCost = 1;
		organismModel.baseDnaGrowthRate = 2;
		organismModel.organismName = "Single Cell";
		_organismModels.Add(OrganismsType.SingleCell, organismModel);

        var tissueModel = new OrganismModel();
        tissueModel.baseDnaCost = 256;
        tissueModel.baseDnaGrowthRate = 64;
        tissueModel.organismName = "Tissues";
        _organismModels.Add(OrganismsType.Tissue, tissueModel);

        var humanModel = new OrganismModel();
        humanModel.baseDnaCost = 1024;
        humanModel.baseDnaGrowthRate = 2048;
        humanModel.organismName = "Human Being";
        _organismModels.Add(OrganismsType.Human, humanModel);

        foreach (var organism in _organismModels)
		{
			AddOrganismPanel(organism.Value);
		}
	}
}

public class OrganismModel
{
	public string organismName;
	
	public long baseDnaCost;

	public long baseDnaGrowthRate;
}

public enum OrganismsType
{
	SingleCell,
    Tissue,
    Human
}