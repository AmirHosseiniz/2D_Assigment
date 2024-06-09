using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is an instance of the win panel 
// it is singlton for more easy integration and since there is not more than one win panel 
// it is okay to have only one instance of it 

public class WinPanel : GameUIPanelSingletone<WinPanel>
{
    protected override void OnHide()
    {
        
    }

    protected override void OnShow()
    {
       
    }
}
