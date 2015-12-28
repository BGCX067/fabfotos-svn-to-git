using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;
using Microsoft.Web.UI;

public partial class PhotosList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Initialize();
        else
            LoadViewState();
    }

    private void Initialize()
    {
        ImageList = new List<String>();
        FavList = new List<String>();
        AddImageUrl("~/Images");
        UpdateViewState();
        MyDataBind();
    }

    private void MyDataBind()
    {
        MyDataBind(DataListPics, ImageList);
        MyDataBind(DataListFavs, FavList);
    }
    private void MyDataBind(DataList Images, List<String> list)
    {
        Images.DataSource = list;
        Images.DataBind();
    }

    private void UpdateViewState()
    {
        ViewState["ImageList"] = ImageList;
        ViewState["FavList"] = FavList;
    }

    private void LoadViewState()
    {
        ImageList = (List<String>)ViewState["ImageList"];
        FavList = (List<String>)ViewState["FavList"];
    }

    private void AddImageUrl(string directory)
    {
        DirectoryInfo info = new DirectoryInfo(MapPath(directory));
        foreach (FileInfo fi in info.GetFiles())
            ImageList.Add("~/" + info.Name + "/" + fi.Name);
    }

    private void UpdatePhotos(String url, List<String> src, List<String> dest)
    {
        src.Remove(url);
        dest.Add(url);
        UpdateViewState();
        MyDataBind();
    }

    protected void DataListFavs_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        BindImages(e, "ImageButtonFavs", FavList);
    }

    private void BindImages(DataListItemEventArgs e, String control, List<String> list)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton img = (ImageButton)(e.Item.FindControl(control));
            img.ImageUrl = list[e.Item.ItemIndex];
            img.CssClass = "images";
            img.AlternateText = "";
            e.Item.CssClass = "Photo";
        }
    }

    protected void DataListFavs_ItemCommand(object source, DataListCommandEventArgs e)
    {
        UpdatePhotos(FavList[e.Item.ItemIndex], FavList, ImageList);
    }

    protected void DataListPics_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        BindImages(e, "ImageButtonPics", ImageList);
    }

    protected void DataListPics_ItemCommand(object source, DataListCommandEventArgs e)
    {
        UpdatePhotos(ImageList[e.Item.ItemIndex], ImageList, FavList);
    }

    private List<String> ImageList;
    private List<String> FavList;
}
