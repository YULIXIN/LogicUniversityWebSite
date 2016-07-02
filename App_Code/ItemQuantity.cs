using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemQuantity
/// </summary>
public class ItemQuantity
{
    public string Item_ID { get; set; }
    public string ItemName { get; set; }

    public string Unit { get; set; }

    public int Qty { get; set; }

    public string ItemImage
    {
        get { return "~/itemImage/" + Item_ID+".jpg";}
    }
}