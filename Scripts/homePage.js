
var model;

this.updateViewOnLoad = function (modelJson) {
	model = JSON.parse(modelJson);

	updateViewInfo();
};

this.updateViewInfo = function () {
	for (var i = 0; i < model.length; i++) {
		var producerWindow = document.getElementsByClassName(model[i].Title);

		for (var j = 0; j < producerWindow.length; j++) {
			producerWindow[j].style.backgroundColor = model[i].PrimaryColor;
			producerWindow[j].style.color = model[i].TextColor;
		}
	}
}