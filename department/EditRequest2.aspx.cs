using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;
using System.Data;

public partial class department_EditRequest : System.Web.UI.Page
{
    ManagerEmployee me = new ManagerEmployee();
    List<ItemQuantity> griddata;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else if (!(((Staff)Session["user"]).Role.Contains("Department") || ((Staff)Session["user"]).Role.Contains("Employee")))
        {
            Response.Redirect("~/department/Default.aspx");
        }
        else
        {
            //to see if this request is from Edit btn in ViewRequest.aspx
            if (Session["requisition"] != null)
            {
                Requisition req = (Requisition)Session["requisition"];
                Dictionary<string, int> cart = new Dictionary<string, int>();
                foreach(Requisition_Details red in req.Requisition_Details)
                {
                    cart[red.Item.Item_Name] = red.Requested_Qty;
                }

                Session["shoppingCart"] = cart;
                Session["requisition"] = null;
                Session["requisitionID"] = Convert.ToInt32(req.Requisition_ID);
            }

            if (Session["shoppingCart"] == null)
            {
                Response.Redirect("~/department/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    Dictionary<string, int> re = (Dictionary<string, int>)Session["shoppingCart"];

                    griddata = new List<ItemQuantity>();
                    foreach (string name in re.Keys)
                    {
                        //Error here if you have " in database
                        Item i = me.getItemByName(name);

                        ItemQuantity j = new ItemQuantity()
                        {
                            Item_ID = i.Item_ID,
                            ItemName = i.Item_Name,
                            Unit = i.UnitOfMeasurement,
                            Qty = re[name]
                        };
                        griddata.Add(j);
                    }
                    Session["griddata"] = griddata;

                    gridView.DataSource = griddata;
                    
                    gridView.DataBind();
                }
               
            }
        }

    }

    private void comfirmTable()
    {
        Dictionary<string, int> cart = new Dictionary<string,int>();
        foreach (GridViewRow row in gridView.Rows)
        {
            string key = row.Cells[1].Text;
            int value = Convert.ToInt32(((TextBox)row.Cells[2].FindControl("tbQty")).Text);
            cart.Add(key, value);
        }
        Session["shoppingCart"] = cart;
        griddata = new List<ItemQuantity>();
        foreach (string name in cart.Keys)
        {
            //Error here if you have " in database
            Item i = me.getItemByName(name);

            ItemQuantity j = new ItemQuantity()
            {
                Item_ID = i.Item_ID,
                ItemName = i.Item_Name,
                Unit = i.UnitOfMeasurement,
                Qty = cart[name]
            };
            griddata.Add(j);
        }
        Session["griddata"] = griddata;
    }

    protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            // Retrieve the row index stored in the 
            // CommandArgument property.
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button 
            // from the Rows collection.
            GridViewRow row = gridView.Rows[index];
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        comfirmTable();
        LinkButton lb = (LinkButton)sender;
        HiddenField hd = (HiddenField)(lb.FindControl("HiddenFieldItemName"));
        if(null==hd)
        {
            Response.Write("hidden field is null");
            return;
        }
        ItemQuantity iQty = null;
        griddata = (List<ItemQuantity>)Session["griddata"];
        foreach (ItemQuantity iq in griddata)
        {
            if(iq.ItemName.Equals(hd.Value))
            {
                iQty = iq;
                break;
            }
        }

        if (iQty == null)
        {
            Response.Write("Item is null");
            return;
        }
            
        griddata.Remove(iQty);
        gridView.DataSource = griddata;
        gridView.DataBind();

        comfirmTable();
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        comfirmTable();

        if (gridView.Rows.Count <= 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Item list cannot be empty')", true);
            return;
        }

        //see if from ViewRequest.aspx
        if (Session["requisitionID"] != null)
        {
            Dictionary<string, int> cart = (Dictionary<string, int>)Session["shoppingCart"];
            int rID = (int)Session["requisitionID"];
            Requisition req = me.getRequisitionByID(rID);

            //Delete unselected Item
            List<Requisition_Details> deleteItems = new List<Requisition_Details>();
            foreach (Requisition_Details red in req.Requisition_Details)
            {
                if (!cart.ContainsKey(red.Item.Item_Name))
                {
                    deleteItems.Add(red);
                }
            }
            foreach (Requisition_Details deleteDetail in deleteItems)
            {
                //req.Requisition_Details.Remove(deleteDetail);
                //me.updateRequisition();  
                me.deleteDetailRequisition(deleteDetail.RequisitionDetail_ID);
            }
             

            //insert and update
            foreach (string iName in cart.Keys)
            {
                Requisition_Details exist = null;
                foreach (Requisition_Details red in req.Requisition_Details)
                {
                    if (red.Item.Item_Name.Equals(iName))
                    {
                        exist = red;
                        //Update
                        red.Requested_Qty = cart[iName];
                        break;
                    }
                }
                if (exist == null)
                {
                    //Insert
                    Requisition_Details newDetail = new Requisition_Details();
                    Item item = me.getItemByName(iName);
                    newDetail.Item = item;
                    newDetail.Requested_Qty = cart[iName];
                    
                    req.Requisition_Details.Add(newDetail);
                }
                
            }

            //save changes
            me.updateRequisition();
            Session["Edit"] = null;
            Session["shoppingCart"] = null;
            Response.Redirect("~/department/ViewRequest.aspx?rID=" + rID);
            return;
        }
        List<ItemQuantity> shoppingResult = new List<ItemQuantity>();
        //update database
        int empID = ((Staff)Session["user"]).Employee_ID;
        List<string> itemIDs = new List<string>();
        List<int> qtys = new List<int>();
        foreach (GridViewRow row in gridView.Rows)
        {
            string itemName = row.Cells[1].Text;
            Item item = me.getItemByName(itemName);
            string itemID = item.Item_ID;
            int qty = Convert.ToInt32(((TextBox)row.Cells[2].FindControl("tbQty")).Text);

            ItemQuantity iq = new ItemQuantity();
            iq.Item_ID = itemID;
            iq.ItemName = itemName;
            iq.Qty = qty;
            itemIDs.Add(itemID);
            iq.Unit = item.UnitOfMeasurement;
            qtys.Add(qty);
            shoppingResult.Add(iq);
        }

        Session["griddata"] = null;


        //ManagerEmployee em = new ManagerEmployee();
        //em.makeRequisition(empID, itemIDs, qtys);
        //Session["shoppingCart"] = null;
        //Session["shoppingResult"] = shoppingResult;

        //Response.Redirect("~/department/RequestResult.aspx");
    }


    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        comfirmTable();
        Response.Redirect("~/department/SearchItem2.aspx");
    }
}