// Get the modal
var modal = document.getElementById("ImageModal");

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img = document.getElementById("viewableImage");
var modalImg = document.getElementById("imageContent");
var captionText = document.getElementById("caption");
img.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    modalImg.style.width = 'auto';
    modalImg.style.marginTop = '100px';
    captionText.innerHTML = this.alt;
    $('#ImageModal').show();
}

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("viewableImageClose")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}