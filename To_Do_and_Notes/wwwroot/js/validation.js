window.addEventListener('load', function () {
   // Example starter JavaScript for disabling form submissions if there are invalid fields
   (function () {
      'use strict'

      // Fetch all the forms we want to apply custom Bootstrap validation styles to
      var forms = document.querySelectorAll('.needs-validation')

      // Loop over them and prevent submission
      Array.prototype.slice.call(forms)
         .forEach(function (form) {
            form.addEventListener('submit', function (event) {
               if (!form.checkValidity()) {
                  event.preventDefault()
                  event.stopPropagation()
               }

               form.classList.add('was-validated')
            }, false)
         })
   })()

   const pwdInput = document.getElementById('pwd');
   const pwd2Input = document.getElementById('pwd2');
   const pwd2InvalidFeedback = document.getElementById('pwd2InvalidFeedback');

   function validatePasswords() {
      if (pwdInput.value !== pwd2Input.value) {
         pwd2Input.setCustomValidity('invalid');
         pwd2InvalidFeedback.textContent = 'Паролі не співпадають';
         pwd2InvalidFeedback.style.display = 'block';
      } else {
         pwd2Input.setCustomValidity('');
         pwd2InvalidFeedback.style.display = 'none';
      }
   }

   pwdInput.addEventListener('input', validatePasswords);
   pwd2Input.addEventListener('input', validatePasswords);
});
