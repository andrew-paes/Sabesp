
var globalCounter = new Array();
var ytplayer = new Array();
var indexCorr = 0;
function onYouTubePlayerReady(playerId) {
	ytplayer[indexCorr] = document.getElementById(playerId);
	ytplayer[indexCorr].addEventListener("onStateChange", "setytplayerState");
	globalCounter[indexCorr] = 0;
	indexCorr ++;	
}

//Fired when player state was changed
function setytplayerState(newState) {   
    
    var i;
    for(i=0; i<=indexCorr; i++)
    {   
	    if (ytplayer[i].getPlayerState() == 1) {
		    if (globalCounter[i] == 0) {
                var id = null;

                id = ytplayer[i].id.substring(11);

			    jQuery.ajax({
				    type: "POST",
				    url: "../PostPage.aspx/AddHit",
				    data: "{'conteudoId':'" + id + "'}",
				    contentType: "application/json; charset=utf-8",
				    dataType: "json",
				    success: function(msg) {
					    //
				    }
			    });
			    globalCounter[i]++;
		    }
	    }
	}
}

