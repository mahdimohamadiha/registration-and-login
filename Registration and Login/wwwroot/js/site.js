function myFunction(pass_id, toggle_id) {
    const togglePassword = document.querySelector(toggle_id);
    const password = document.querySelector(pass_id);

    togglePassword.addEventListener('click', function (e) {

        if (password.getAttribute('type') === 'password') {
            password.setAttribute('type', 'text');
            this.src = "/icons/eye-show.png"
        }
        else {
            password.setAttribute('type', 'password');
            this.src = "/icons/eye-hide.png"
        }
    });
}

myFunction('#id_password' ,'#togglePassword')
myFunction('#id_confirm_password', '#toggleConfirmPassword')

function validatePassword() {
    var password = document.getElementById("id_password").value;
    var confirmPassword = document.getElementById("id_confirm_password").value;

    if (password !== confirmPassword) {
        document.getElementById('not_matching_password').hidden = false;

        return false; // Prevent form submission
    }

    return true; // Allow form submission
}