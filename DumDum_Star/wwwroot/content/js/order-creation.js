function newUrlInputted() {
    let imgElement = document.getElementById("cyberImage");
    let imgPathInput = document.getElementById("cyberImageInput");

    imgElement.src = imgPathInput.value;
    correctImage = true;
}

function onErrorLoad() {
    let imgElement = document.getElementById("cyberImage");
    imgElement.src = "../icons/light/missing.png";

    correctImage = false;
}
