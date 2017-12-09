// Index / _Layout js file

var model;

this.updateViewOnLoad = function (modelJson) {
	model = JSON.parse(modelJson);

	updateViewInfo();
};

this.updateViewInfo = function () {
	document.body.style.backgroundColor = model.Producer.PrimaryColor;

	var beatButtons = document.getElementsByClassName("beat-button");
	for (var i = 0; i < beatButtons.length; i++) {
		beatButtons[i].style.backgroundColor = model.Producer.PrimaryColor;
	}

	var beatContainers = document.getElementsByClassName("beat-container");
	for (var j = 0; j < beatContainers.length; j++) {
		beatContainers[j].style.backgroundColor = model.Producer.SecondaryColor;
	}
};

playClicked = function (beatId) {
	beatId = parseInt(beatId);
	var beatTitle = "";
	for (var i = 0; i < model.Beats.length; i++) {
		if (model.Beats[i].BeatId === beatId) {
			beatTitle = model.Beats[i].Title;
		}
	}
	alert("You are listening to the soothing sounds of '" + beatTitle + "'.");
	var beatClipUri = getBeatLink(beatId);
};

purchaseClicked = function (beatId) {
	beatId = parseInt(beatId);
	var beatTitle = "";
	for (var i = 0; i < model.Beats.length; i++) {
		if (model.Beats[i].BeatId === beatId) {
			beatTitle = model.Beats[i].Title;
		}
	}
	alert("You clicked purchase for '" + beatTitle + "'.");
};

getBeatLink = function (beatId) {
	
};