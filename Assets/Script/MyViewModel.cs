using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyViewModel : BaseViewModel
{
    public MyViewModel() 
    {
        count = 1;
        price = 10;
        total = count * price;
    }

    int count;
    int price;
    int total;

    public int Count { 
        get { return count; }
        set {
            if (count != value)
            {
                count = value;
                OnPropertyChange(nameof(Count));
            }
        }
    }

    public int Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                price = value;
                OnPropertyChange(nameof(Price));
            }
        }
    }

    public int Total
    {
        get { return total; }
        set
        {
            if (total != value)
            {
                total = value;
                OnPropertyChange(nameof(Total));
            }
        }
    }
}
