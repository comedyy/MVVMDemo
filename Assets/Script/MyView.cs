using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyView : BaseView<MyViewModel>
{
    private void Update()
    {
        ViewModel.Count++;
    }
}
