using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour {
	
	public GameObject page;

	void Start () { 
		InitPage(); 
	}

	void InitPage() {
		for (int i = 0; i < 3; i++) {
			GameObject obj = Instantiate(page, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;

			obj.transform.parent = this.transform;

			obj.transform.localScale = new Vector3(1f, 1f, 1f);

			UILabel label = GetChildObj (obj, "Label").GetComponent<UILabel>(); 

			label.text = "페이지01";
		}

		GetComponent<UIGrid>().Reposition();
	}

	GameObject GetChildObj( GameObject source, string strName  ) { 
		Transform[] AllData = source.GetComponentsInChildren< Transform >(); 
		GameObject target = null;

		foreach( Transform Obj in AllData ) { 
			if( Obj.name == strName ) { 
				target = Obj.gameObject;
				break;
			} 
		}

		return target;
	}

}
