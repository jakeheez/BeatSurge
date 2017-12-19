
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

beatClicked = function (beatId) {
	beatId = parseInt(beatId);
	var beatTitle = "";
	var beatLeasePrice = 0;
	var beatBuyPrice = 0;
	var producerId = model.Producer.Title;
	for (var i = 0; i < model.Beats.length; i++) {
		if (model.Beats[i].BeatId === beatId) {
			beatTitle = model.Beats[i].Title;
			beatLeasePrice = "Lease Price: $" + model.Beats[i].LeasePrice;
			beatBuyPrice = "Buy Price: $" + model.Beats[i].BuyPrice;
		}
	}

	document.getElementById("player-title").innerText = beatTitle;

	document.getElementById("beat-lease-price").innerText = beatLeasePrice;
	document.getElementById("purchase-button").onclick = function () { purchaseClicked(beatId) };

	document.getElementById("beat-buy-price").innerText = beatBuyPrice;
	document.getElementById("lease-button").onclick = function () { leaseClicked(beatId) };

	document.getElementById("audio-player").src = "/" + producerId + "/GetBeatAudio?producerId=" + producerId + "&beatId=" + beatId;

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

leaseClicked = function (beatId) {
	beatId = parseInt(beatId);
	var beatTitle = "";
	for (var i = 0; i < model.Beats.length; i++) {
		if (model.Beats[i].BeatId === beatId) {
			beatTitle = model.Beats[i].Title;
		}
	}
	alert("You clicked lease for '" + beatTitle + "'.");
};