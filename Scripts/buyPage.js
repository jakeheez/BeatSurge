
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

	// Stripe - Start
	var stripe = Stripe('pk_test_5uirGTREfetsXglIQPHxCfLJ');

	var elements = stripe.elements();
	var form = document.getElementById("payment-form");

	var cardNumber = elements.create("cardNumber");
	cardNumber.mount("#formItem-cardNumber");

	var cardExipry = elements.create("cardExpiry");
	cardExipry.mount("#formItem-cardExpiry");

	var cardCvc = elements.create("cardCvc");
	cardCvc.mount("#formItem-cardCvc");

	form.addEventListener("submit", function (event) {
		event.preventDefault();

		var name = form.querySelector("#formItem-Name");
		var email = form.querySelector("#formItem-Email");
		var additionalData = {
			name: name ? name.value : undefined,
			email: email ? email.value : undefined
		};

		// just sending one element item (cardNumber) is enough to create a token.
		stripe.createToken(cardNumber, additionalData).then(function (result) {
			if (result.error) {
				var errorElement = document.getElementById("card-errors");
				errorElement.textContent = result.error.message;
			}
			else {
				stripeTokenHandler(result.token);
			}
		});
	});
	// Stripe - End
};

function stripeTokenHandler(token) {
	var form = document.getElementById("payment-form");
	var hiddenInput = document.createElement("input");
	hiddenInput.setAttribute("type", "hidden");
	hiddenInput.setAttribute("name", "stripeToken");
	hiddenInput.setAttribute("value", token.id);
	form.appendChild(hiddenInput);

	form.submit();
}
