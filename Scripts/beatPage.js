
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
	var beatAudio = this.getBeatAudio(beatId);
	alert("You are listening to the soothing sounds of '" + beatTitle + "'.");
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

getBeatAudio = function (beatId) {
	beatId = parseInt(beatId);
	var producerId = model.Producer.Title;
	var url = "/BeatPage/GetBeatAudio?producerId=" + producerId + "&beatId=" + beatId;
	var result;

	var xmlHttp = new XMLHttpRequest();
	xmlHttp.onreadystatechange = function () {
		if (xmlHttp.readyState == 4 && xmlHttp.status == 200)
			return xmlHttp.responseText;
	}

	xmlHttp.open("GET", url, true);
	xmlHttp.send();

	result = xmlHttp.onreadystatechange();
	return result;
};