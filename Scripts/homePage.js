
var model;

this.updateViewOnLoad = function (modelJson) {
	model = JSON.parse(modelJson);

	updateViewInfo();
};

this.updateViewInfo = function () {
	for (var i = 0; i < model.Producers.length; i++) {
		var producerWindow = document.getElementsByClassName(model.Producers[i].Title);

		for (var j = 0; j < producerWindow.length; j++) {
			producerWindow[j].style.backgroundColor = model.Producers[i].PrimaryColor;
			producerWindow[j].style.color = model.Producers[i].TextColor;
		}
	}
}