using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AG_GameLevel : MonoBehaviour {

	//quantity of blocks
	int ag_BreakableBlocks;
	int ag_MinionBlocks;
	int ag_UnbreakableBlocks;

	//Tags name
	public string ag_BreakableBlocksTAG;
	public string ag_UnbreakableBlocksTAG;
	public string ag_RedMinionTAG;
	public string ag_GreenMinionTAG;

	[SerializeField] string ag_betweenScenes;

	public void AG_CountBreakableBlocks(){
		ag_BreakableBlocks++;
	}

	public void AG_CountMinionBlocks(){
		ag_MinionBlocks++;
	}

	public void AG_CountUnbreakableBlocks(){
		ag_UnbreakableBlocks++;
	}

	public void AG_BlockDestroyed(){
		ag_BreakableBlocks--;
		AG_WinConditional();
	}
	public void AG_MinionDestroyed(){
		ag_MinionBlocks--;
		AG_WinConditional();
	}

	public void AG_WinConditional(){
		if(ag_BreakableBlocks <=0 && ag_MinionBlocks<=0){
			SceneManager.LoadScene(ag_betweenScenes);
		}
	}

}
