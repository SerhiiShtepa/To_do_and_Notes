function auto_grow(element) {
   element.style.height = "5px";
   element.style.height = (element.scrollHeight) + "px";
}
function previewImage(event, id) {
   var reader = new FileReader();
   reader.onload = function () {
      var preview = document.getElementById(id);
      preview.src = reader.result;
   }
   reader.readAsDataURL(event.target.files[0]);
}