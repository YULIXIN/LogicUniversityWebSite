using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity;

/// <summary>
/// Summary description for OrderInventory
/// </summary>
public class OrderInventory
{

    public string Item_Name { get; set; }

    public string Item_ID { get; set; }
    public string Unit { get; set; }
    public int reOrderLevel { get; set; }
    public int Qty { get; set; }
    public int Balance { get; set; }
    public string ItemImage
    {
        get { return "~/itemImage/" + Item_ID + ".jpg"; }
    }
	
}