
var model;

this.updateViewOnLoad = function (modelJson) {
	model = JSON.parse(modelJson);

	updateViewInfo();
};

this.updateViewInfo = function () {
	document.body.style.backgroundColor = model.Producer.PrimaryColor;

	var beatButtons = document.getElementsByClassName("primary-colored");
	for (var i = 0; i < beatButtons.length; i++) {
		beatButtons[i].style.backgroundColor = model.Producer.PrimaryColor;
	}

	var beatContainers = document.getElementsByClassName("secondary-colored");
	for (var j = 0; j < beatContainers.length; j++) {
		beatContainers[j].style.backgroundColor = model.Producer.SecondaryColor;
	}

	var textColorItems = document.getElementsByClassName("text-colored");
	for (var k = 0; k < textColorItems.length; k++) {
		textColorItems[k].style.color = model.Producer.TextColor;
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

	var producerId = model.Producer.Title;
	document.getElementById("beat-audio").src = "/BeatPage/GetBeatAudio?producerId=" + producerId + "&beatId=" + beatId;

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
