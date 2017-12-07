// Index / _Layout js file

var model;

this.updateViewOnLoad = function (modelJson) {
	model = JSON.parse(modelJson);

	updateViewInfo();
};

this.updateViewInfo = function () {
	document.body.style.backgroundColor = model.Producer.primaryColor;

	var beatButtons = document.getElementsByClassName("beat-button");
	for (var i = 0; i < beatButtons.length; i++) {
		beatButtons[i].style.backgroundColor = model.Producer.primaryColor;
	}

	var beatContainers = document.getElementsByClassName("beat-container");
	for (var j = 0; j < beatContainers.length; j++) {
		beatContainers[j].style.backgroundColor = model.Producer.secondaryColor;
	}
};

playClicked = function (beatId) {
	beatId = parseInt(beatId);
	var beatInfo = { title: "", artist: "" };
	for (var i = 0; i < model.Beats.length; i++) {
		if (model.Beats[i].beatId === beatId) {
			beatInfo.title = model.Beats[i].title;
			beatInfo.artist = model.Beats[i].artist;
		}
	}
	alert("You are listening to the soothing sounds of:\n'" + beatInfo.title + "'\n by: " + beatInfo.artist);
	var beatClipUri = getBeatLink(beatId);
};

purchaseClicked = function (beatId) {
	beatId = parseInt(beatId);
	var beatInfo = { title: "", artist: "" };
	for (var i = 0; i < model.Beats.length; i++) {
		if (model.Beats[i].beatId === beatId) {
			beatInfo.title = model.Beats[i].title;
			beatInfo.artist = model.Beats[i].artist;
		}
	}
	alert("You clicked the 'Purchase' button for:\n'" + beatInfo.title + "'\n by: " + beatInfo.artist);
};

getBeatLink = function (beatId) {
	
};