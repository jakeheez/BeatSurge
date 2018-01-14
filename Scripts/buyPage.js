
var model;

this.updateViewOnLoad = function (modelJson) {
	model = JSON.parse(modelJson);

	updateViewInfo();
};

this.updateViewInfo = function () {

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

	// Stripe
	var stripe = Stripe('pk_test_5uirGTREfetsXglIQPHxCfLJ');
	var elements = stripe.elements();
};