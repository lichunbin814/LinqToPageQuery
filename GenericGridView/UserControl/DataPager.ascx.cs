using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataPager : System.Web.UI.UserControl
{
    public string PagedControlID
    {
        get { return dpIndex.PagedControlID; }
        set
        {
            this.dpIndex.PagedControlID = value;
        }
    }

    //public DataPager DataPage
    //{
    //    get { return dpIndex; }
    //    set
    //    {
    //        this.dpIndex = value;
    //    }
    //}

    public void SetPagerProperties(int startRowIndex, int maxRows, bool isDataBind)
    {
        this.dpIndex.SetPageProperties(startRowIndex, maxRows, isDataBind);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void dpIndex_PreRender(object sender, EventArgs e)
    {
        //TextBox txtPageSize = dpIndex.Controls[0].FindControl("txtPageSize") as TextBox;
        //txtPageSize.Text = dpIndex.PageSize.ToString();

        //int currentPage = (dpIndex.StartRowIndex / dpIndex.PageSize) + 1;
        //int totalPages = (dpIndex.TotalRowCount / dpIndex.PageSize) + 1;

        //DropDownList ddlSelectPage = dpIndex.Controls[0].FindControl("ddlSelectPage") as DropDownList;
        //if (ddlSelectPage.Items.Count == 0)
        //{
        //    for (int i = 1; i <= totalPages; i++)
        //    {
        //        ListItem item = new ListItem();
        //        item.Text = "第" + i.ToString() + "頁";
        //        item.Value = i.ToString();
        //        if (i == currentPage)
        //        {
        //            item.Selected = true;
        //        }
        //        ddlSelectPage.Items.Add(item);
        //    }
        //}


    }

    protected void TemplatePagerField_OnPagerCommand(object sender, DataPagerCommandEventArgs e)
    {
        //DropDownList ddlSelectPage = (DropDownList)sender
        //DropDownList ddlSelectPage = dpIndex.Controls[0].FindControl("ddlSelectPage") as DropDownList;
        switch (e.CommandName)
        {
            case "First":
                e.NewStartRowIndex = 0;
                e.NewMaximumRows = e.Item.Pager.MaximumRows;
                break;
            case "Previous":
                if (e.Item.Pager.StartRowIndex > 0)
                {
                    e.NewStartRowIndex = e.Item.Pager.StartRowIndex - e.Item.Pager.PageSize;
                    e.NewMaximumRows = e.Item.Pager.MaximumRows;
                }
                break;
            case "Next":
                int newIndex = e.Item.Pager.StartRowIndex + e.Item.Pager.PageSize;
                if (newIndex < e.TotalRowCount)
                {
                    //避免超出資料總數
                    e.NewStartRowIndex = newIndex;
                    e.NewMaximumRows = e.Item.Pager.MaximumRows;
                }
                break;
            case "Last":
                if (e.TotalRowCount % e.Item.Pager.MaximumRows == 0)
                {
                    //避免起始索引，超過資料總數
                    e.NewStartRowIndex = e.TotalRowCount - e.Item.Pager.MaximumRows;
                }
                else
                {
                    e.NewStartRowIndex = Convert.ToInt32(Math.Round(Convert.ToDouble(e.TotalRowCount / e.Item.Pager.PageSize), MidpointRounding.ToEven) * e.Item.Pager.PageSize);
                }                
                e.NewMaximumRows = e.Item.Pager.MaximumRows;
                break;
            //case "DropDownList":
            //    //string temp = string.Empty;
            //    //e.NewStartRowIndex = Convert.ToInt32(ddlSelectPage.SelectedValue) * e.Item.Pager.PageSize;
            //    e.NewStartRowIndex = Convert.ToInt32(ddlSelectPage.SelectedValue) * 10;
            //    e.NewMaximumRows = e.TotalRowCount;
            //    break;
            default:
                break;
        }
    }

    protected void ddlSelectPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlSelectPage = (DropDownList)sender;
        int pageNo = Convert.ToInt32(ddlSelectPage.SelectedValue);
        int startRowIndex = (pageNo - 1) * dpIndex.PageSize;
        dpIndex.SetPageProperties(startRowIndex, dpIndex.PageSize, true);  
    }

    protected void txtPageSize_TextChanged(object sender, EventArgs e)
    {
        TextBox txtPageSize = (TextBox)sender;
        int PageSize = 10;
        int.TryParse(txtPageSize.Text, out PageSize);
        if (PageSize > 0)
        {
            dpIndex.PageSize = PageSize;
        }
    }

    private void InitializeComponent()
    {

    }
}