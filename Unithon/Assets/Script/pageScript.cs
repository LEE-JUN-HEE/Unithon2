using UnityEngine;
using System.Collections;

public class pageScript : MonoBehaviour {
	
	public GameObject page;
	// Grid 에서 표시하고자 하는 이미지들이 저장될 Texture 배열
	//public Texture[] images;

	//처음 객체가 로딩될 때, 초기화 함수 호출 
	void Start () { 
		InitItem(); 
	}


	void InitItem() {
		// 이미지의 수 만큼 반복합니다.
		for (int i = 0; i < 3; i++) {
			GameObject obj = Instantiate(page, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;

			obj.transform.parent = this.transform;

			obj.transform.localScale = new Vector3(1f, 1f, 1f);

			UILabel label = GetChildObj (obj, "storyLabel01").GetComponent<UILabel>(); 

			//texture.mainTexture = images[i];

			if (i == 0) 
			{
				label.text = "1페이지";
			}
				
			else if (i == 1)
				label.text = "2페이지";
			else
				label.text = "3페이지";
		}

		GetComponent<UIGrid>().Reposition();
	}

	//자식 요소를 찾아서 리턴하는 함수 
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
