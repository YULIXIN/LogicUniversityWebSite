using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdjustItem
/// </summary>
public class AdjustItem
{
    public int id { get; set; }
   public string Item { get; set; }
    public int Adjust_Qty { get; set; }
    public string Unit { get; set; }
    public int totalPrice { get; set;}

    public string reason { get; set; }

    public string subReason { get; set; }
}