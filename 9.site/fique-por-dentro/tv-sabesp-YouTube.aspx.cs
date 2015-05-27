using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Google.GData.Client;
using Google.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.GData.YouTube;
using System.Configuration;
using RedesSociais;

public partial class tv_Sabesp_YouTube : BasePage
{
    #region Properties

    public string YouTubeMovieID { get; set; }
    private DataTable YouTubeDataTable { get; set; }
    private DataRow drVideoData;
    private YouTube youtube = new YouTube();
    private YouTubeRequest youTubeRequest = new YouTubeRequest(new YouTubeRequestSettings(RedesSociais.YouTube.YouTubeApplicationName, RedesSociais.YouTube.YouTubeClientID, RedesSociais.YouTube.YouTubeDeveloperKey)); // Return an object Request with configurations of Youtube API

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadPage();
    }

    /// <summary>
    /// Configure settings necessary to load page
    /// </summary>
    protected void LoadPage()
    {
        //this.ConfigureYoutube();

        if (!IsPostBack)
        {
            this.CreateVideoFeed();
        }
    }
    
    /// <summary>
    /// Creates and binding a youtube video feed of channel
    /// </summary>
    protected void CreateVideoFeed()
    {
        this.CreateVideoFeed(null);
    }

    protected void CreateVideoFeed(YouTubeQuery youtubeQuery)
    {
        Feed<Video> videoFeed;

        if (youtubeQuery != null)
        {
            videoFeed = youTubeRequest.Get<Video>(youtubeQuery);
        }
        else
        {
            youtube.OrderBy = YoutubeOrderBy.Published;
            videoFeed = youTubeRequest.Get<Video>(new Uri(RedesSociais.YouTube.GetVideoFeedUrl(youtube)));
        }

        this.BindData(videoFeed);
    }

    protected void btnBusca_Click(object sender, EventArgs e)
    {
        YouTubeQuery query = new YouTubeQuery(RedesSociais.YouTube.GetVideoFeedUrl(youtube));
        query.OrderBy = YoutubeOrderBy.Relevance.ToString().ToLower(); //order results by relevance
        query.Query = txtBusca.Text; // search for keyword and include restricted content in the search results

        this.CreateVideoFeed(query);
    }

    /// <summary>
    /// Creates columns in Youtube Data Table
    /// </summary>
    protected void ConfigureYoutubeDT()
    {
        this.YouTubeDataTable = new DataTable();
        this.YouTubeDataTable.Columns.Add("Title");
        this.YouTubeDataTable.Columns.Add("Description");
        this.YouTubeDataTable.Columns.Add("DateUploaded");
        this.YouTubeDataTable.Columns.Add("Ratings");
        this.YouTubeDataTable.Columns.Add("NoOfComments");
        this.YouTubeDataTable.Columns.Add("VideoID");
        this.YouTubeDataTable.Columns.Add("Duration");
        this.YouTubeDataTable.Columns.Add("Keywords");
        this.YouTubeDataTable.Columns.Add("Thumbnail");

        this.YouTubeMovieID = string.Empty;
        lblDescription.Text = string.Empty;
    }

    /// <summary>
    /// Bind data with youtube feed results 
    /// </summary>
    /// <param name="videoFeed"></param>
    protected void BindData(Feed<Video> videoFeed)
    {
        this.ConfigureYoutubeDT();

        //Iterate through each video entry and store details in DataTable
        foreach (Video videoEntry in videoFeed.Entries)
        {
            this.drVideoData = this.YouTubeDataTable.NewRow();

            this.drVideoData["Title"] = videoEntry.Title;
            this.drVideoData["Description"] = videoEntry.Description;
            this.drVideoData["DateUploaded"] = videoEntry.Updated.ToShortDateString();
            this.drVideoData["Ratings"] = videoEntry.YouTubeEntry.Rating != null ? Convert.ToString(videoEntry.YouTubeEntry.Rating.Average) : string.Empty;
            this.drVideoData["NoOfComments"] = videoEntry.CommmentCount.ToString();
            this.drVideoData["VideoID"] = videoEntry.YouTubeEntry.VideoId;
            this.drVideoData["Duration"] = videoEntry.YouTubeEntry.Duration.Seconds.ToString();

            //fill thumbnail with first frame of video
            if (videoEntry.Thumbnails != null && videoEntry.Thumbnails.Count > 0)
            {
                this.drVideoData["Thumbnail"] = videoEntry.Thumbnails[0].Url;
            }

            //fill formated keywords
            foreach (string key in RedesSociais.YouTube.YoutubeKeywordsToList(videoEntry.Keywords))
            {
                if (String.IsNullOrEmpty(Convert.ToString(drVideoData["Keywords"])))
                {
                    this.drVideoData["Keywords"] = key;
                }
                else
                {
                    this.drVideoData["Keywords"] = String.Concat(Convert.ToString(this.drVideoData["Keywords"]), ", ", key);
                }
            }

            this.YouTubeDataTable.Rows.Add(drVideoData);
        }

        if (this.YouTubeDataTable != null && this.YouTubeDataTable.Rows.Count > 0)
        {
            AssignVideo();

            ltrResultados.Text = this.YouTubeDataTable.Rows.Count.ToString();
            repVideoList.DataSource = this.YouTubeDataTable;
            repVideoList.DataBind();
        }
    }

    /// <summary>
    /// Assign the first video details on page load.
    /// </summary>
    private void AssignVideo()
    {
        if (String.IsNullOrEmpty(this.YouTubeMovieID))
        {
            this.YouTubeMovieID = this.YouTubeDataTable.Rows[0]["VideoID"].ToString();
            lblDescription.Text = this.YouTubeDataTable.Rows[0]["Description"].ToString();
        }
    }

    /// <summary>
    /// Show video data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void repVideoList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drVideo = (DataRowView)e.Item.DataItem;

            LinkButton showVideo = (LinkButton)e.Item.FindControl("btnShowVideo");
            Literal title = (Literal)e.Item.FindControl("Title");
            Literal description = (Literal)e.Item.FindControl("Description");
            Literal ratings = (Literal)e.Item.FindControl("Ratings");
            Literal noOfComments = (Literal)e.Item.FindControl("NoOfComments");
            Literal duration = (Literal)e.Item.FindControl("Duration");
            Literal keywords = (Literal)e.Item.FindControl("Keywords");
            Image imgThumb = (Image)e.Item.FindControl("imgThumb");

            showVideo.CommandArgument = drVideo["VideoID"].ToString();
            title.Text = drVideo["Title"].ToString();
            description.Text = drVideo["Description"].ToString();
            ratings.Text = drVideo["Ratings"].ToString();
            noOfComments.Text = drVideo["NoOfComments"].ToString();
            duration.Text = drVideo["Duration"].ToString();
            keywords.Text = drVideo["Keywords"].ToString();
            imgThumb.ImageUrl = drVideo["Thumbnail"].ToString();
        }
    }

    protected void repVideoList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        // Pass the YouTube movie ID to flash
        this.YouTubeMovieID = e.CommandArgument.ToString();

        if (this.YouTubeMovieID == e.CommandArgument.ToString())
        {
            lblDescription.Text = ((Literal)e.Item.FindControl("Description")).Text;
        }
    }    
}