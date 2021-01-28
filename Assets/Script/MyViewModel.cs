using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyViewModel : BaseViewModel
{
    public MyViewModel() 
    {
        count = 1;
        price = 10;
        shoppingBag = false;
        discount = 100;

        RecalcTotal();
    }

    int count;
    int price;
    int total;
    bool shoppingBag;
    float discount;

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

    public bool ShoppingBag
    {
        get { return shoppingBag; }
        set
        {
            if (shoppingBag != value)
            {
                shoppingBag = value;
                OnPropertyChange(nameof(ShoppingBag));
            }
        }
    }

    public float Discount
    {
        get { return discount; }
        set
        {
            if (discount != value)
            {
                discount = value;

                RecalcTotal();
                OnPropertyChange(nameof(Discount));
            }
        }
    }

    public void AddCount() 
    {
        Count++;
        RecalcTotal();
    }

    public void SetShoppingBag(bool isSet) 
    {
        ShoppingBag = isSet;
        RecalcTotal();
    }

    void RecalcTotal() 
    {
        int value = count * price;
        if (shoppingBag)
        {
            value++;
        }

        Total = (int)(value * discount / 100f);
    }
}
